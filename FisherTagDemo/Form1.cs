using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormSet;
using SocketHelper;
using SocketHelper.USocket;
using Newtonsoft.Json;
using Microsoft.Web.WebView2.Core;
using System.IO;
using FisherTagDemo.Locator;
using System.Threading;
using System.Security.Policy;
using System.Net;
using DevComponents.Editors;
using System.Timers;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Schedule;
using DevComponents.DotNetBar.Controls;
using FormSet;

namespace FisherTagDemo
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007Form
    {
        SocketHelper.USocket.SocketServerClass _socketServer = null;
        LogHelper.ILogEntity _log = LogHelper.EasyLogger.GetDefaultLoggerInstance();

        private object _lockReceive = new object();
        /// <summary>
        /// 定位器datatable
        /// </summary>
        DataTable _dt_locator = new DataTable();

        /// <summary>
        /// rfid 的datatable
        /// </summary>
        DataTable _dt_rfid = new DataTable();
        /// <summary>
        /// 定位器登录信息
        /// </summary>
        LocatorServerInterope _locatorServer;

        /// <summary>
        /// HTTPserver
        /// </summary>
        HttpServer _httpServer = null;

        System.Timers.Timer _timerGetGpsAlarms = null;

        DateTime? _mdsDataTime = null;
        /// <summary>
        /// 登录信息
        /// </summary>
        LocatorLogIn _locatorLogIn;
        /// <summary>
        /// rfid和locator的对应关系  string:rfid序列号
        /// </summary>
        Dictionary<string, Rfid_LocatorCorrespond> _dic_locatorRfidCorrespond = new Dictionary<string, Rfid_LocatorCorrespond>();
        /// <summary>
        /// 定位器的设备信息
        /// </summary>
        Locator_GetDeviceListAck _locatorDeviceInfo;
        public Form1()
        {
            InitializeComponent();
            this.EnableGlass = false;
            Ini();
        }
        private async void Ini()
        {
            _dt_locator.Columns.Add("seq");
            _dt_locator.Columns.Add("FullName");
            _dt_locator.Columns.Add("Macid");
            _dt_locator.Columns.Add("Offline");
            //以下显示定位器自身的状态
            _dt_locator.Columns.Add("Charge");
            _dt_locator.Columns.Add("Battery");
            //以下显示定位器的位置
            _dt_locator.Columns.Add("longitude");
            _dt_locator.Columns.Add("latitude");
            //以下显示定位器工作的状态
            _dt_locator.Columns.Add("WorkMode");
            _dt_locator.Columns.Add("ReportInterval");
            _dt_locator.Columns.Add("GPS");
            _dt_locator.Columns.Add("WIFI");
            _dt_locator.Columns.Add("LBS");
            _dt_locator.Columns.Add("GPRS");


            //其他信息

            _dt_locator.Columns.Add("Speed");
            _dt_locator.Columns.Add("Objectid");
            _dt_locator.Columns.Add("Server_time");
            _dt_locator.Columns.Add("Heart_time");
            _dt_locator.Columns.Add("Updtime");
            _dt_locator.Columns.Add("Gpstime");

            _dt_rfid.Columns.Add("seq");
            _dt_rfid.Columns.Add("ShipName_船牌号");
            _dt_rfid.Columns.Add("TagSerialNum");
            _dt_rfid.Columns.Add("TimeStamp");

            _dt_rfid.Columns.Add("TagFunction");
            _dt_rfid.Columns.Add("TagSignal");
            dT_InBegin.Value = DateTime.Now.AddDays(-1);
            dT_InEnd.Value = DateTime.Now;

            IniRfid_LocatorCorrespondInfo();
            // webBrowser_map.ScriptErrorsSuppressed = true;
            // webView_map.CoreWebView2.NavigateToString("https://map.baidu.com/");
            MainHttp();

        }

        private void IniRfid_LocatorCorrespondInfo()
        {
            string s = ReadTextSimple.ReadText("RFID_Config");
            List<Rfid_LocatorCorrespond> rl = JsonConvert.DeserializeObject<List<Rfid_LocatorCorrespond>>(s);
            if (rl.Count == 0)
            {
                _log.Info($"未读取到locator与RFID的对应关系");
                return;
            }
            foreach (var item in rl)
            {
                if (_dic_locatorRfidCorrespond.Keys.Contains(item.RfidSerial))
                {
                    _log.Error($"检测到重复的RFID和locator的对应编号，重复的RFID序列号:{item.RfidSerial}");
                    continue;
                }
                _dic_locatorRfidCorrespond.Add(item.RfidSerial, item);
            }
        }

        public async Task MainHttp()
        {
            string url = "http://localhost:8000/"; // 服务器地址
            _httpServer = new HttpServer(url);
            try
            {
                await _httpServer.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                //server.Stop();
            }
        }

        private void ShowMessage(string msg)
        {
            FormSet.BaseFrmControl.ShowMessageOnTextBox(this, txt_showMessage, msg, true);
            _log.Info(msg);
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            _dt_rfid.Rows.Clear();
            _socketServer = new SocketServerClass(txt_RFID_ServerIP.Text, Convert.ToInt32(txt_RFID_ServerPort.Text));
            _socketServer.StartServer();
            _socketServer.receiveMessageEvent += RfidSocketMessageReceived;
            //ConnectRFIDServer("",0);
            btn_connectRfid.Enabled = false;
            btn_disConnect.Enabled = true;
            ShowMessage("RFID 监听服务已启动");
        }

        private void ConnectRFIDServer(string ip, int port)
        {
            SocketClientClass socketClient = new SocketClientClass(IPAddress.Parse("192.168.1.88"), 2000);
            socketClient.CreateConnect();

            socketClient.ReceivedMessageAsyncEvent += RfidSocketMessageReceived_sub;
            socketClient.ReceiveMessageAsyncStart();
        }

        private void RfidSocketMessageReceived(SocketModule s)
        {

            _log.Debug($"SocketMessageReceived，client:{s.RemoteEndPoint.ToString()}, ASCII:{Encoding.UTF8.GetString(s.receiveBuffer)}");
            RfidSocketMessageReceived_sub(s.receiveBuffer);
        }

        private void RfidSocketMessageReceived_sub(byte[] bytes)
        {
            lock (this)
            {
                RFID_DataAnalysis rFID_Data = new RFID_DataAnalysis(bytes);
                rFID_Data.Analysis();
                bool isNewRfid = true;
                if (Convert.ToInt64(rFID_Data.RfidTagSerialNum) == 0)
                { return; }
                foreach (DataRow item in _dt_rfid.Rows)
                {
                    if (item["TagSerialNum"].ToString() == rFID_Data.RfidTagSerialNum)
                    {
                        item["TagFunction"] = rFID_Data.RfidTagFunction;
                        item["TagSignal"] = rFID_Data.TagSignalStrength;
                        item["TimeStamp"] = rFID_Data.TimeStamp;
                        isNewRfid = false; break;
                    }
                }
                if (isNewRfid)
                {
                    DataRow dr = _dt_rfid.NewRow();
                    dr["seq"] = _dt_rfid.Rows.Count + 1;
                    lock (_dic_locatorRfidCorrespond)
                    {
                        if (_dic_locatorRfidCorrespond.Keys.Contains(rFID_Data.RfidTagSerialNum))
                        {
                            dr["ShipName_船牌号"] = _dic_locatorRfidCorrespond[rFID_Data.RfidTagSerialNum].ShipName;
                        }
                    }
                    dr["TagSerialNum"] = rFID_Data.RfidTagSerialNum;
                    dr["TagFunction"] = rFID_Data.RfidTagFunction;
                    dr["TagSignal"] = rFID_Data.TagSignalStrength;
                    dr["TimeStamp"] = rFID_Data.TimeStamp;
                    _dt_rfid.Rows.Add(dr);
                }
                this.Invoke(new Action(() =>
                {
                    dgv_rfid.DataSource = _dt_rfid;
                    dgv_rfid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgv_rfid.Refresh();
                }));

                string append = "";
                if (rFID_Data.RfidTagFunction.ToLower() == "b")
                {
                    append = "\r\n该标签已被拆除！";
                }
                ShowMessage(

                  $"{Newtonsoft.Json.JsonConvert.SerializeObject(rFID_Data, Newtonsoft.Json.Formatting.Indented)}{append}"

                    );
            }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            LogHelper.EasyLogger.ShowDiagnoseForm();
        }

        private void btn_disConnect_Click(object sender, EventArgs e)
        {
            if (_socketServer != null)
            {
                _socketServer.receiveMessageEvent -= RfidSocketMessageReceived;
                _socketServer.StopServer();
                _socketServer = null;
            }
            btn_connectRfid.Enabled = true;
            btn_disConnect.Enabled = false;
            ShowMessage("RFID 监听服务已停止");
        }

        private async void btn_getLocation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ShipLocatorId.Text))
            {
                BaseFrmControl.ShowDefalutMessageBox(this, $"请选择定位器！");
                return;
            }
            //先获取MDS
            if (!GetMds())
            {
                return;
            }
            //获取设备数据
            string devRet = _locatorServer.GetMessageByRestful(Locator_GetDeviceCurrentLocationReq.GenerateGetAppendMsg(txt_ShipLocatorId_Obj.Text, _locatorLogIn.mds), chk_traceLog.Checked);
            if (devRet == null)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},返回数据为空,ret:{devRet}");
                return;
            }
            Locator_GetDeviceCurrentLocationAck devInfo = JsonConvert.DeserializeObject<Locator_GetDeviceCurrentLocationAck>(devRet) as Locator_GetDeviceCurrentLocationAck;
            if (devInfo == null)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},设备数据转换失败,ret:{devRet}");
                return;
            }
            else if (devInfo.success != "true")
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},数据异常,ret:{devRet}");
                return;
            }
            //webView_map.CoreWebView2.NavigateToString("file:///E:/GIT/FisherTagDemo/output/baidu_Map.html");
            //webBrowser_map.Url = new Uri("file:///E:/GIT/FisherTagDemo/output/baidu_Map.html");

            //double lng = devInfo.data[0].jingdu; // 经度（上海外滩）
            //double lat = devInfo.data[0].weidu;  // 纬度

            double lng = Convert.ToDouble(devInfo.data[0].records[0][devInfo.data[0].key.jingdu]); // 经度（上海外滩）
            double lat = Convert.ToDouble(devInfo.data[0].records[0][devInfo.data[0].key.weidu]);  // 纬度
            await webView_map.CoreWebView2.ExecuteScriptAsync($"showLocation({lng}, {lat}," +
                $"'{devInfo.data[0].records[0][devInfo.data[0].key.user_name].ToString()}',{devInfo.data[0].records[0][devInfo.data[0].key.datetime]})");
            //await webView_map.CoreWebView2.ExecuteScriptAsync($"showLocation({lng}, {lat},'{"A00001"}')");

        }
        private async void InitializeWebView()
        {
            // 设置 WebView2 环境
            var env = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Path.GetTempPath(), "WebView2Cache"));
            await webView_map.EnsureCoreWebView2Async(env);

            // 加载本地 HTTP 服务器的 URL
            string url = "http://localhost:8000/baidu_map.html"; // 本地 HTTP 服务器
            webView_map.CoreWebView2.Navigate(url);

            // 等待页面加载完成
            webView_map.CoreWebView2.NavigationCompleted += WebView_NavigationCompleted;
        }
        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            //Thread.Sleep(3000);
            ////// 页面加载完成后，调用 JavaScript 方法显示指定点
            //double lng = 121.4905; // 经度（上海外滩）
            //double lat = 31.2354;  // 纬度
            //webView_map.CoreWebView2.ExecuteScriptAsync($"showLocation({lng}, {lat})");

        }

        private void btn_GetDevList_Click(object sender, EventArgs e)
        {
            _locatorServer = new LocatorServerInterope(this.txt_ShipLocatorURL.Text, 5);
            //先获取MDS
            if (!GetMds())
            {
                return;
            }
            //获取设备数据
            string devRet = _locatorServer.GetMessageByRestful(Locator_GetDeviceListReq.GenerateGetAppendMsg(_locatorLogIn.id, _locatorLogIn.mds), chk_traceLog.Checked);
            if (devRet == null)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器设备返回数据为null,ret:{devRet}");
                return;
            }
            _locatorDeviceInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Locator_GetDeviceListAck>(devRet) as Locator_GetDeviceListAck;

            if (_locatorDeviceInfo == null)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器设备数据转换失败,ret:{devRet}");
                return;
            }
            if (_locatorDeviceInfo.rows.Count > 0)
            {
                _dt_locator.Rows.Clear();
                for (int i = 0; i < _locatorDeviceInfo.rows.Count; i++)
                {
                    DeviceInfo info = _locatorDeviceInfo.rows[i];
                    DataRow dr = _dt_locator.NewRow();
                    dr["seq"] = i + 1;
                    dr["Macid"] = info.macid;
                    dr["Objectid"] = info.objectid;
                    dr["FullName"] = info.fullName;
                    string offLine = Enum.Parse(typeof(Locator.LocatorEnum_OfflineStateEnum), info.offline).ToString();
                    dr["Offline"] = string.IsNullOrEmpty(offLine) ? info.offline : offLine;
                    dr["Speed"] = info.speed;
                    dr["Server_time"] = TimeDataConvert.GetDateTimeString(TimeDataConvert.GPS_DateConvertUTC8ToDateTime(info.server_time));
                    dr["Updtime"] = TimeDataConvert.GetDateTimeString(TimeDataConvert.GPS_DateConvertUTC8ToDateTime(info.updtime));
                    dr["Speed"] = info.speed;
                    dr["Gpstime"] = TimeDataConvert.GetDateTimeString(TimeDataConvert.GPS_DateConvertUTC8ToDateTime(info.gpstime));
                    _dt_locator.Rows.Add(dr);
                }
                dgv_locatorList.DataSource = _dt_locator;
                dgv_locatorList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            //启动定时器定时查询报警信息
            if (_timerGetGpsAlarms == null)
            {
                _timerGetGpsAlarms = new System.Timers.Timer();
                _timerGetGpsAlarms.Elapsed += AlarmTimerCallback;
                _timerGetGpsAlarms.Interval = 2000;
                _timerGetGpsAlarms.Start();
            }
        }

        long _maxTime = TimeDataConvert.GPS_DateConvertDateTimeToUTC8(DateTime.Now.AddDays(-1));
        private void AlarmTimerCallback(object sender, ElapsedEventArgs e)
        {
            try
            {
                _timerGetGpsAlarms.Stop();
                //先获取MDS
                if (!GetMds())
                {
                    _timerGetGpsAlarms.Start();
                    return;
                }
                //获取设备数据
                string devRet = _locatorServer.GetMessageByRestful(Locator_GetLocalAlarmInfoUtcReq.GenerateGetAppendMsg(_locatorLogIn.id, _locatorLogIn.mds, _maxTime.ToString()), chk_traceLog.Checked);
                if (devRet == null)
                {
                    ShowMessage($"alarm,返回数据为空,ret:{devRet}");
                    _timerGetGpsAlarms.Start();
                    return;
                }
                Locator_GetLocalAlarmInfoUtcAck alarmInfo = JsonConvert.DeserializeObject<Locator_GetLocalAlarmInfoUtcAck>(devRet) as Locator_GetLocalAlarmInfoUtcAck;
                if (alarmInfo == null)
                {
                    ShowMessage($"alarm,设备数据转换失败,ret:{devRet}");
                    _timerGetGpsAlarms.Start();
                    return;
                }
                else if (alarmInfo.success != "true")
                {
                    ShowMessage($"alarm,数据异常,ret:{devRet}");
                    _timerGetGpsAlarms.Start();
                    return;
                }
                if (alarmInfo.total > 0)
                {
                    foreach (var item in alarmInfo.rows)
                    {
                        if (item.gps_time > _maxTime)
                        {
                            _maxTime = item.gps_time;
                        }
                        string alarmName = Enum.GetName(typeof(LocatorEnum_AlarmType), item.type_id);
                        ShowMessage($"[ALARM!!!] 设备：{item.user_name}, alarmMsg:{alarmName}, " +
                            $"alarmTimeStamp:{TimeDataConvert.GetDateTimeString(TimeDataConvert.GPS_DateConvertUTC8ToDateTime(item.send_time))} ");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"alarm,程序出现异常,ex:{ex.ToString()}");
            }
            finally
            {
                _timerGetGpsAlarms.Start();
            }


        }

        private bool GetMds()
        {
            if (_locatorServer == null)
            {
                ShowMessage($"获取定位器服务mds失败,请先获取定位器列表");
                return false;
            }
            if (_mdsDataTime != null && ((DateTime.Now - _mdsDataTime).Value.TotalMinutes < 19 && _locatorLogIn != null))
            {
                return true;
            }
            ShowMessage("mds过期, 获取远程mds");
            string mdsRet = _locatorServer.GetMessageByRestful(LocatorLogIn.GetLogInAppendMsg(txt_ShipLocatorUserName.Text, txt_ShipLocatorPassWord.Text), chk_traceLog.Checked);
            if (string.IsNullOrEmpty(mdsRet))
            {
                //BaseFrmControl.ShowErrorMessageBox(this, $"获取定位器服务mds失败!");
                ShowMessage($"获取定位器服务mds失败!");
                return false;
            }

            _locatorLogIn = Newtonsoft.Json.JsonConvert.DeserializeObject<LocatorLogIn>(mdsRet) as LocatorLogIn;
            if (_locatorLogIn == null)
            {
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器云端服务mds报文异常!,ret:{mdsRet}");
                ShowMessage($"定位器云端服务mds报文异常!,ret:{mdsRet}");
                return false;
            }
            if (_locatorLogIn.success.ToLower() != "true")
            {
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器云端服务mds获取失败,ret:{mdsRet}");
                ShowMessage($"定位器云端服务mds获取失败,ret:{mdsRet}");
                return false;
            }
            ShowMessage($"mds获取成功,mds:{_locatorLogIn.mds}");
            _mdsDataTime = DateTime.Now;
            return true;
        }



        private void dgv_locatorList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            txt_ShipLocatorId.Text = _dt_locator.Rows[e.RowIndex]["Macid"].ToString();
            txt_ShipLocatorId_Obj.Text = _dt_locator.Rows[e.RowIndex]["Objectid"].ToString();
        }

        private async void btn_getHistoryPath_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ShipLocatorId.Text))
            {
                BaseFrmControl.ShowDefalutMessageBox(this, $"请选择定位器！");
                return;
            }
            //先获取MDS
            if (!GetMds())
            {
                return;
            }
            ShowMessage($"开始获取设备数据...");
            //获取设备数据
            string devRet = _locatorServer.GetMessageByRestful(Locator_GetDeviceHistoryLocationReq.GenerateGetAppendMsg(txt_ShipLocatorId.Text, _locatorLogIn.mds,
                TimeDataConvert.GPS_DateConvertDateTimeToUTC8(dT_InBegin.Value).ToString(), TimeDataConvert.GPS_DateConvertDateTimeToUTC8(dT_InEnd.Value).ToString()), chk_traceLog.Checked);
            if (devRet == null)
            {
                ShowMessage($"定位器ID:{txt_ShipLocatorId},设备数据为null ,ret:{devRet}");
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},设备数据为null");
                return;
            }
            Locator_GetDeviceHistoryLocationAck devInfo = JsonConvert.DeserializeObject<Locator_GetDeviceHistoryLocationAck>(devRet) as Locator_GetDeviceHistoryLocationAck;
            if (devInfo == null)
            {
                ShowMessage($"定位器ID:{txt_ShipLocatorId},设备数据转换失败,ret:{devRet}");
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},设备数据转换失败,ret:{devRet}");
                return;
            }
            else if (devInfo.success != "true")
            {
                ShowMessage($"定位器ID:{txt_ShipLocatorId},数据异常,ret:{devRet}");
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},数据异常,ret:{devRet}");
                return;
            }
            else if (devInfo.data == null || devInfo.data.Count == 0 || string.IsNullOrEmpty(devInfo.data[0].point))
            {
                ShowMessage($"定位器ID:{txt_ShipLocatorId},无历史轨迹信息,ret:{devRet}");
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},无历史轨迹信息,ret:{devRet}");
                return;
            }

            //处理point数据
            string[] points = devInfo.data[0].point.Split(';');
            List<LocatoreHistoryLocation> data = new List<LocatoreHistoryLocation>();
            for (int i = 0; i < points.Length; i++)
            {
                string[] pointsData = points[i].Split(',');
                if (pointsData.Length < 3)
                {
                    _log.Warn($"pointsData:{points[i]}数据异常");
                    continue;
                }
                LocatoreHistoryLocation his = new LocatoreHistoryLocation(pointsData[0], pointsData[1], pointsData[2]);
                data.Add(his);
            }

            //获得经纬度速度
            string locationStr = JsonConvert.SerializeObject(data);
            //await webView_map.CoreWebView2.ExecuteScriptAsync($"drawTrajectory('{locationStr}'" );.
            // 调用 JavaScript 函数，传入 JSON 字符串
            ShowMessage($"await webView_map.CoreWebView2.ExecuteScriptAsync($\"drawTrajectory(JSON.parse('{{locationStr}}'))\")");
            await webView_map.CoreWebView2.ExecuteScriptAsync($"drawTrajectory(JSON.parse('{locationStr}'))");


        }

        private void splitContainer_Main_Panel1_SizeChanged(object sender, EventArgs e)
        {
            //if (((Control)sender).Size.Width>500)//489, 366
            //{
            //    ((Control)sender).Size = new Size(500,((Control)sender).Size.Height);
            //}
            //if (((Control)sender).Size.Height > 400)//489, 366
            //{
            //    ((Control)sender).Size = new Size(((Control)sender).Size.Width,400);
            //}
        }

        private async void Map_initUI()
        {
            await webView_map.CoreWebView2.ExecuteScriptAsync("initMapSub()");
        }

        private void splitContainer_Main_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (((SplitContainer)sender).SplitterDistance > 500)
            {
                ((SplitContainer)sender).SplitterDistance = 500;
            }
        }

        private void splitContainer_Sub1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (((SplitContainer)sender).SplitterDistance > 400)
            {
                ((SplitContainer)sender).SplitterDistance = 400;
            }
        }

        private void webView_map_SizeChanged(object sender, EventArgs e)
        {
            // Map_initUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            InitializeWebView();
        }

        private void btn_clearLog_Click(object sender, EventArgs e)
        {
            txt_showMessage.Text = "";
            _dt_rfid.Rows.Clear();
        }

        private void webView_map_Resize(object sender, EventArgs e)
        {
            ShowMessage($"webView_map.CoreWebView2?.ExecuteScriptAsync($\"handleResize())\")");
            webView_map.CoreWebView2?.ExecuteScriptAsync($"handleResize())");
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            LogHelper.EasyLogger.GetDiagnoseForm().Show(this);
        }
        /// <summary>
        /// 是否正在处理定位器的模式请求
        /// </summary>
        bool _isLocatorModeProcessing = false;
        private void btn_getLocatorMode_Click(object sender, EventArgs e)
        {
            if (_isLocatorModeProcessing)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"正在获取定位器模式，请等待！");
                return;
            }
            _isLocatorModeProcessing = true;

            Task.Run(() =>
             {
                 GetLocatorMode();
             });
        }
        private void GetLocatorMode()
        {
            try
            {
                ShowMessage($"获取定位器模式信息开始！");
                AnalysisDevCurrentInfo(GetLocatorCurrentStatus());
                GetLocatorModeSub01();
                ShowMessage($"获取定位器模式信息完成！");
            }
            catch (Exception ex)
            {
                ShowMessage($"GetLocatorMode 出现异常 ex:{ex.ToString()}");
            }
            finally
            {

                _isLocatorModeProcessing = false;
            }
        }
        /// <summary>
        /// 发送透传数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns>string : id    DeviceInfo:设备信息</returns>
        private Dictionary<string, DeviceInfo> SendMessageToLocatorBySendCommand(string param)
        {
            Dictionary<string, DeviceInfo> devDic = null;
            //先获取MDS
            if (!GetMds())
            {
                return null;
            }

            devDic = new Dictionary<string, DeviceInfo>();
            foreach (var item in _locatorDeviceInfo.rows)
            {
                //获取设备数据
                string devRet = _locatorServer.GetMessageByRestful(Locator_SendCommandsReq.GenerateGetAppendMsg(item.macid, _locatorLogIn.mds,
                   LocatorEnum_SendCommand.PASSTHROUGHA.ToString(), Locator_ModeEntity.GenerateGetModeCommand()));

                Locator_SendCommandsAck devInfo = JsonConvert.DeserializeObject<Locator_SendCommandsAck>(devRet) as Locator_SendCommandsAck;
                if (devInfo == null)
                {
                    ShowMessage($"定位器ID:{item.macName},设备透传回执数据转换失败,ret:{devRet}");
                    //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},设备数据转换失败,ret:{devRet}");
                    continue;
                }
                else if (devInfo.success != "true")
                {
                    ShowMessage($"定位器ID:{item.macName},透传回执数据异常,ret:{devRet}");
                    //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},数据异常,ret:{devRet}");
                    continue;
                }
                else if (devInfo.Data == null || devInfo.Data.Count == 0)
                {
                    ShowMessage($"定位器ID:{item.macName},透传回执信息,ret:{devRet}");
                    //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},无历史轨迹信息,ret:{devRet}");
                    continue;
                }
                devDic.Add(devInfo.Data[0].CmdNo, item);
            }
            return devDic;
        }

        private void GetLocatorModeSub01()
        {
            ShowMessage($"开始获取所有设备Mode数据回执...");
            Dictionary<string, DeviceInfo> devDic = SendMessageToLocatorBySendCommand(Locator_ModeEntity.GenerateGetModeCommand());
            if (devDic == null || devDic.Count == 0)
            {
                ShowMessage($"获取所有设备Mode数据失败!");
            }
            Thread.Sleep(3000);
            //接下来获得结果
            //先获取MDS
            if (!GetMds())
            {
                return;
            }
            ShowMessage($"开始获取所有设备Mode数据结果...");
            foreach (var item in devDic)
            {
                //获取设备数据
                string devRet = _locatorServer.GetMessageByRestful(Locator_GetCommandsResultReq.GenerateGetAppendMsg(item.Value.macid, _locatorLogIn.mds,
                   item.Key));

                Locator_GetCommandsResultAck devInfo = JsonConvert.DeserializeObject<Locator_GetCommandsResultAck>(devRet) as Locator_GetCommandsResultAck;
                if (devInfo == null)
                {
                    ShowMessage($"定位器ID:{item.Value.fullName},设备Mode数据转换失败,ret:{devRet}");
                    //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},设备数据转换失败,ret:{devRet}");
                    continue;
                }
                else if (devInfo.success != "true")
                {
                    ShowMessage($"定位器ID:{item.Value.fullName},Mode数据异常,ret:{devRet}");
                    //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},数据异常,ret:{devRet}");
                    continue;
                }
                else if (devInfo.data == null || devInfo.data.Count == 0)
                {
                    ShowMessage($"定位器ID:{item.Value.fullName},无Mode信息信息,ret:{devRet}");
                    //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},无历史轨迹信息,ret:{devRet}");
                    continue;
                }
                else if (!devInfo.data[0].Status)
                {
                    ShowMessage($"定位器ID:{item.Value.fullName},Mode获取失败，远程尚未处理完成,ret:{devRet}");
                    Thread.Sleep(1000);
                    continue;
                }
                lock (_dgvLock)
                {
                    DataRow[] drs = _dt_locator.Select($"Macid='{item.Value.macid}'");
                    if (drs.Count() > 0)
                    {
                        Locator_ModeEntity entity = new Locator_ModeEntity(devInfo.data[0].ResponseMsg);
                        drs[0]["WorkMode"] = entity.WorkModeEnum01;
                        drs[0]["ReportInterval"] = entity.ReportInterval02;
                        drs[0]["GPS"] = entity.GPS03;
                        drs[0]["WIFI"] = entity.WIFI04;
                        drs[0]["LBS"] = entity.LBS05;
                        drs[0]["GPRS"] = entity.GPRS06;
                    }
                }

            }
        }
        /// <summary>
        /// 获得定位当前状态
        /// </summary>
        /// <returns></returns>
        private Locator_GetCurrentLocationBatchAck GetLocatorCurrentStatus()
        {
            if (!GetMds())
            {
                return null;
            }
          //  ShowMessage($"批量获取设备数据开始...");
            //获取设备数据
            string devRet = _locatorServer.GetMessageByRestful(Locator_GetCurrentLocationBatchReq.GenerateGetAppendMsg(_locatorLogIn.id, _locatorLogIn.mds));
            if (devRet == null)
            {
                ShowMessage($"批量获取设备数据结果为空,ret:{devRet}");
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},设备数据转换失败,ret:{devRet}");
                return null;
            }
            Locator_GetCurrentLocationBatchAck devInfo = JsonConvert.DeserializeObject<Locator_GetCurrentLocationBatchAck>(devRet) as Locator_GetCurrentLocationBatchAck;
            if (devInfo == null)
            {
                ShowMessage($"批量获取设备数据转换为json失败,ret:{devRet}");
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},设备数据转换失败,ret:{devRet}");
                return null;
            }
            else if (devInfo.success != "true")
            {
                ShowMessage($"批量获取设备数据，服务器返回失败,ret:{devRet}");
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},数据异常,ret:{devRet}");
                return null;
            }
            else if (devInfo.data == null || devInfo.data[0].deviceCount == 0)
            {
                ShowMessage($"批量获取设备数据,获取到的设备数量为0,ret:{devRet}");
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},无历史轨迹信息,ret:{devRet}");
                return null;
            }
          //  ShowMessage($"批量获取设备数据完成");
            return devInfo;
        }
        private static readonly object _dgvLock=new object();
        private void AnalysisDevCurrentInfo(Locator_GetCurrentLocationBatchAck devInfo)
        {
            if (devInfo==null)
            {
                return;
            }
            foreach (var dev in devInfo.data[0].records)
            {
                if (dev != null)
                {
                    lock (_dgvLock)
                    {
                        DataRow[] drs = _dt_locator.Select($"Macid='{dev[devInfo.data[0].key.sim_id]}'");
                        if (drs.Count() > 0)
                        {
                            //Locator_Status locator_Status = new Locator_Status(dev[devInfo.data[0].key.status].ToString());
                            drs[0]["Charge"] = dev[devInfo.data[0].key.describe].ToString().Contains("未充电") ? 0 : 1;
                            drs[0]["Battery"] = dev[devInfo.data[0].key.electric];
                            drs[0]["longitude"] = dev[devInfo.data[0].key.jingdu];
                            drs[0]["latitude"] = dev[devInfo.data[0].key.weidu];
                            //drs[0]["Heart_time"] = dev[devInfo.data[0].key.heart_time];
                            drs[0]["Heart_time"] = TimeDataConvert.GetDateTimeString(TimeDataConvert.GPS_DateConvertUTC8ToDateTime(Convert.ToInt64(dev[devInfo.data[0].key.heart_time])));
                            drs[0]["Server_time"] = TimeDataConvert.GetDateTimeString(TimeDataConvert.GPS_DateConvertUTC8ToDateTime(Convert.ToInt64(dev[devInfo.data[0].key.server_time])));
                        }
                    }
                }
            }
        }

        private void btn_locating_Click(object sender, EventArgs e)
        {
            Dictionary<string, DeviceInfo> devDic = SendMessageToLocatorBySendCommand("LJDW%23");
            foreach (var item in devDic)
            {
                ShowMessage($"dev:{item.Value.fullName} 立即定位指令  Send OK");
            }
        }

        private async void btn_getLocationBatch_Click(object sender, EventArgs e)
        {

            Locator_GetCurrentLocationBatchAck devInfos = GetLocatorCurrentStatus();
            if (devInfos == null)
            {
                ShowMessage($"获取定位器当前位置失败，返回数据为null");
                BaseFrmControl.ShowErrorMessageBox(this, $"获取定位器当前位置失败，返回数据为null");
                return;
            }
            AnalysisDevCurrentInfo(devInfos);
            //webView_map.CoreWebView2.NavigateToString("file:///E:/GIT/FisherTagDemo/output/baidu_Map.html");
            //webBrowser_map.Url = new Uri("file:///E:/GIT/FisherTagDemo/output/baidu_Map.html");

            //double lng = devInfo.data[0].jingdu; // 经度（上海外滩）
            //double lat = devInfo.data[0].weidu;  // 纬度

            double[] lngs = new double[devInfos.data[0].deviceCount];
            double[] lats = new double[devInfos.data[0].deviceCount];
            string[] labels = new string[devInfos.data[0].deviceCount];
            string[] timeStamps = new string[devInfos.data[0].deviceCount];
            for (int i = 0; i < devInfos.data[0].deviceCount; i++)
            {
                try
                {
                    lngs[i] = Convert.ToDouble(devInfos.data[0].records[i][devInfos.data[0].key.jingdu]);
                    lats[i] = Convert.ToDouble(devInfos.data[0].records[i][devInfos.data[0].key.weidu]);
                    labels[i] = devInfos.data[0].records[i][devInfos.data[0].key.user_name].ToString();
                    timeStamps[i] = TimeDataConvert.GPS_DateConvertUTC8ToDateTime(Convert.ToInt64(devInfos.data[0].records[i][devInfos.data[0].key.heart_time].ToString())).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception ex)
                {
                    BaseFrmControl.ShowErrorMessageBox(this, $"ex:{ex.ToString()}");
                }

            }
            string script = $@"
    showLocations(
        {JsonConvert.SerializeObject(lngs)},
        {JsonConvert.SerializeObject(lats)},
        {JsonConvert.SerializeObject(labels)},
        {JsonConvert.SerializeObject(timeStamps)}
    )";
            await webView_map.CoreWebView2.ExecuteScriptAsync(script);
            //await webView_map.CoreWebView2.ExecuteScriptAsync($"showLocation({lng}, {lat},'{"A00001"}')");
        }

        private bool _isTraceSignalStrength = false;

        Task _taskTraceSignalStrength;

        DBOperate _dBOperate = new DBOperate();
        private void btn_traceSignalStrength_Click(object sender, EventArgs e)
        {
            if (((ButtonX)sender).Text == "启动信号跟踪")
            {
                btn_getLocationBatch.Enabled = false;
                _isTraceSignalStrength = true;
                ((ButtonX)sender).Text = "启动信号跟踪中，点击停止";
                _taskTraceSignalStrength = Task.Run(() => { RecordDevDSignalInfo(); });
            }
            else
            {
                btn_getLocationBatch.Enabled = true;
                _isTraceSignalStrength = false;
               _taskTraceSignalStrength.Wait();
                ((ButtonX)sender).Text = "启动信号跟踪";
            }

        }
        private int _traceLocatorInterval = 30000;
        List<string> _recordDevTimeList;
        private void RecordDevDSignalInfo()
        {
            ShowMessage("开始启动信号跟踪");
            _recordDevTimeList = new List<string>();
            while (_isTraceSignalStrength)
            {
                Locator_GetCurrentLocationBatchAck devInfo = GetLocatorCurrentStatus();
               // AnalysisDevCurrentInfo(devInfo);
                string message = "";
                if (devInfo!=null)
                {
                    foreach (var item in devInfo.data[0].records)
                    {
                        try
                        {
                            string user_name = item[devInfo.data[0].key.user_name].ToString();
                            long currentHeartTime = Convert.ToInt64(item[devInfo.data[0].key.heart_time]);
                            long currentSysTime = Convert.ToInt64(item[devInfo.data[0].key.server_time]);
                            //验证是否离线
                            if (currentSysTime - currentHeartTime > 130000)//系统时间超前心跳时间130秒
                            {

                                if (!_recordDevTimeList.Contains(user_name))//不存在则添加
                                {
                                    message= $"{TimeDataConvert.GPS_DateConvertUTC8ToDateTime(currentHeartTime)}  ,  {currentHeartTime}  ,  OF";
                                    _recordDevTimeList.Add(user_name);//表示该id已离线
                                    TextOperate.WriteToFile(user_name, message);
                                    _dBOperate.InsertLocatorOnlineState(user_name, TimeDataConvert.GPS_DateConvertUTC8ToDateTime(currentHeartTime).ToString("yyyy-MM-dd HH:mm:ss.fff"), currentHeartTime, "offLine");
                                    ShowMessage($"{user_name},{message}");
                                }
                            }
                            else//小于则表示在线
                            {
                                if (_recordDevTimeList.Contains(user_name))//在线时如果字典内还存在该设备，表示设备之前已离线
                                {
                                    message = $"{TimeDataConvert.GPS_DateConvertUTC8ToDateTime(currentHeartTime)}  ,  {currentHeartTime}  ,  ON";
                                    _recordDevTimeList.Remove(user_name);//表示该id已离线
                                    _dBOperate.InsertLocatorOnlineState(user_name, TimeDataConvert.GPS_DateConvertUTC8ToDateTime(currentHeartTime).ToString("yyyy-MM-dd HH:mm:ss.fff"), currentHeartTime, "onLine");
                                    TextOperate.WriteToFile(user_name, message);
                                    ShowMessage($"{user_name},{message}");
                                }
                            }
                            //记录信号强度
                            string[] stateSplits = item[devInfo.data[0].key.statenumber].ToString().Split(',');
                            if (stateSplits.Length>15)
                            {
                                TextOperate.WriteToFile($"{user_name}_gsmLevel",$"{TimeDataConvert.GPS_DateConvertUTC8ToDateTime(currentSysTime)} ,longiLati:{item[devInfo.data[0].key.jingdu]} | {item[devInfo.data[0].key.weidu]}" +
                                    $" ,gsmLevel:{stateSplits[7]} ,batteryPersents:{stateSplits[4]} ,batteryVoltage:{stateSplits[5]}" );
                            }
                        }
                        catch (Exception ex)
                        {
                            ShowMessage($"RecordDevDSignalInfo ex:{ex.ToString()}");
                        }

                    }

                    _dBOperate.InsertLocatorRecord(devInfo);
                }
                Thread.Sleep(_traceLocatorInterval);
            }
            ShowMessage("信号跟踪停止");
        }

        private void txt_traceInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseFrmControl.KeyPressWithDigital(this, sender, e);
            if (e.KeyChar == '\r')
            {
                int interval = 60;
                ;
                if (!Int32.TryParse(txt_traceInterval.Text.Replace("\r","").Replace("\n", ""), out interval)) { return; }
                if (interval < 3 || interval > 300)
                {
                    return;
                }
                this._traceLocatorInterval = interval * 1000;
            }
        }
    }
    }
