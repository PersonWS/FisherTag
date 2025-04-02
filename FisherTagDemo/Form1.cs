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
            _dt_locator.Columns.Add("Objectid");
            _dt_locator.Columns.Add("Offline");
            _dt_locator.Columns.Add("Speed");
            _dt_locator.Columns.Add("Server_time");
            _dt_locator.Columns.Add("Updtime");
            _dt_locator.Columns.Add("Gpstime");


            _dt_rfid.Columns.Add("seq");
            //_dt_rfid.Columns.Add("RfidDeviceID");
            _dt_rfid.Columns.Add("TagSerialNum");
            _dt_rfid.Columns.Add("TagFunction"); ;
            _dt_rfid.Columns.Add("TagSignal");
            _dt_rfid.Columns.Add("TimeStamp");
            dT_InBegin.Value = DateTime.Now.AddDays(-7);
            dT_InEnd.Value = DateTime.Now;

            // webBrowser_map.ScriptErrorsSuppressed = true;
            // webView_map.CoreWebView2.NavigateToString("https://map.baidu.com/");
            MainHttp();

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
            string devRet = _locatorServer.GetMessageByRestful(Locator_GetDeviceCurrentLocationReq.GenerateGetAppendMsg(txt_ShipLocatorId_Obj.Text, _locatorLogIn.mds));
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
            string devRet = _locatorServer.GetMessageByRestful(Locator_GetDeviceListReq.GenerateGetAppendMsg(_locatorLogIn.id, _locatorLogIn.mds));
            if (devRet == null)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器设备返回数据异常,ret:{devRet}");
                return;
            }
            Locator_GetDeviceListAck deviceInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Locator_GetDeviceListAck>(devRet) as Locator_GetDeviceListAck;

            if (deviceInfo == null)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器设备数据转换失败,ret:{devRet}");
                return;
            }
            if (deviceInfo.rows.Count > 0)
            {
                _dt_locator.Rows.Clear();
                for (int i = 0; i < deviceInfo.rows.Count; i++)
                {
                    DeviceInfo info = deviceInfo.rows[i];
                    DataRow dr = _dt_locator.NewRow();
                    dr["seq"] = i + 1;
                    dr["Macid"] = info.macid;
                    dr["Objectid"] = info.objectid;
                    dr["FullName"] = info.fullName;
                    dr["Offline"] = info.offline;
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
            if (_timerGetGpsAlarms==null)
            {
                _timerGetGpsAlarms = new System.Timers.Timer();
                _timerGetGpsAlarms.Elapsed += AlarmTimerCallback;
                _timerGetGpsAlarms.Interval = 1000;
                _timerGetGpsAlarms.Start();
            }
        }

        long _maxTime= TimeDataConvert.GPS_DateConvertDateTimeToUTC8(DateTime.Now.AddDays(-1));
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
                string devRet = _locatorServer.GetMessageByRestful(Locator_GetLocalAlarmInfoUtcReq.GenerateGetAppendMsg(_locatorLogIn.id, _locatorLogIn.mds, _maxTime.ToString()));
                if (devRet == null)
                {
                    BaseFrmControl.ShowErrorMessageBox(this, $"alarm,返回数据为空,ret:{devRet}");
                    _timerGetGpsAlarms.Start();
                    return;
                }
                Locator_GetLocalAlarmInfoUtcAck alarmInfo = JsonConvert.DeserializeObject<Locator_GetLocalAlarmInfoUtcAck>(devRet) as Locator_GetLocalAlarmInfoUtcAck;
                if (alarmInfo == null)
                {
                    BaseFrmControl.ShowErrorMessageBox(this, $"alarm,设备数据转换失败,ret:{devRet}");
                    _timerGetGpsAlarms.Start();
                    return;
                }
                else if (alarmInfo.success != "true")
                {
                    BaseFrmControl.ShowErrorMessageBox(this, $"alarm,数据异常,ret:{devRet}");
                    _timerGetGpsAlarms.Start();
                    return;
                }
                if (alarmInfo.total > 0)
                {
                    foreach (var item in alarmInfo.rows)
                    {
                        if (item.gps_time> _maxTime)
                        {
                            _maxTime=item.gps_time;
                        }
                        string alarmName = Enum.GetName(typeof(LocatorAlarmTypeEnum), item.type_id);
                        ShowMessage($"[ALARM!!!] 设备：{item.user_name}, alarmMsg:{alarmName}, " +
                            $"alarmTimeStamp:{TimeDataConvert.GetDateTimeString(TimeDataConvert.GPS_DateConvertUTC8ToDateTime(item.send_time))} ");
                    }
                }
            }
            catch (Exception ex)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"alarm,程序出现异常,ex:{ex.ToString()}");
            }
            finally
            { 
                _timerGetGpsAlarms.Start();
            }


        }

        private bool GetMds()
        {
            if (_mdsDataTime!=null&&((DateTime.Now - _mdsDataTime).Value.TotalMinutes < 19 && _locatorLogIn != null))
            {
                return true;
            }
            _log.Info("mds过期, 获取远程mds");
            string mdsRet = _locatorServer.GetMessageByRestful(LocatorLogIn.GetLogInAppendMsg(txt_ShipLocatorUserName.Text, txt_ShipLocatorPassWord.Text));
            if (string.IsNullOrEmpty(mdsRet))
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"获取定位器服务mds失败!");
                ShowMessage($"获取定位器服务mds失败!");
                return false;
            }

            _locatorLogIn = Newtonsoft.Json.JsonConvert.DeserializeObject<LocatorLogIn>(mdsRet) as LocatorLogIn;
            if (_locatorLogIn == null)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器云端服务mds报文异常!,ret:{mdsRet}");
                ShowMessage($"定位器云端服务mds报文异常!,ret:{mdsRet}");
                return false;
            }
            if (_locatorLogIn.success.ToLower() != "true")
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器云端服务mds获取失败,ret:{mdsRet}");
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
                TimeDataConvert.GPS_DateConvertDateTimeToUTC8(dT_InBegin.Value).ToString(), TimeDataConvert.GPS_DateConvertDateTimeToUTC8(dT_InEnd.Value).ToString()));

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
    }
}
