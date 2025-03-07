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

            // webBrowser_map.ScriptErrorsSuppressed = true;
            // webView_map.CoreWebView2.NavigateToString("https://map.baidu.com/");
            MainHttp();
            InitializeWebView();
        }
        public async Task MainHttp()
        {
            string url = "http://localhost:8000/"; // 服务器地址
            _httpServer= new HttpServer(url);
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
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            _dt_rfid.Rows.Clear();
            _socketServer = new SocketServerClass(txt_RFID_ServerIP.Text, Convert.ToInt32(txt_RFID_ServerPort.Text));
            _socketServer.StartServer();
            _socketServer.receiveMessageEvent += RfidSocketMessageReceived;
            btn_connectRfid.Enabled = false;
            btn_disConnect.Enabled = true;
        }

        private void RfidSocketMessageReceived(SocketModule s)
        {
            lock (this)
            {
                _log.Debug($"SocketMessageReceived，client:{s.RemoteEndPoint.ToString()}, ASCII:{Encoding.UTF8.GetString(s.receiveBuffer)}");
                RFID_DataAnalysis rFID_Data = new RFID_DataAnalysis(s.receiveBuffer);
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
                    dgv_rfid.Refresh();
                }));
                ShowMessage(Newtonsoft.Json.JsonConvert.SerializeObject(rFID_Data, Newtonsoft.Json.Formatting.Indented));
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
        }

        private async void btn_getLocation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ShipLocatorId.Text))
            {
                BaseFrmControl.ShowDefalutMessageBox(this, $"请选择定位器！");
                return;
            }
            LocatorLogIn locatorLogInInfo;
            //先获取MDS
            if (!GetMds(out locatorLogInInfo))
            {
                return;
            }
            //获取设备数据
            string devRet = _locatorServer.GetMessageByRestful(Locator_GetDeviceCurrentLocationReq.GenerateGetAppendMsg(txt_ShipLocatorId_Obj.Text, locatorLogInInfo.mds));

            Locator_GetDeviceCurrentLocationAck devInfo = JsonConvert.DeserializeObject<Locator_GetDeviceCurrentLocationAck>(devRet) as Locator_GetDeviceCurrentLocationAck;
            if (devInfo == null)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{txt_ShipLocatorId},设备数据转换失败,ret:{devRet}");
                return;
            }
            else if (devInfo.success!="true")
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
                $"'{devInfo.data[0].records[0][devInfo.data[0].key.user_name].ToString()}','{devInfo.data[0].records[0][devInfo.data[0].key.datetime]}')");
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
            LocatorLogIn locatorLogInInfo;
            //先获取MDS
            if (!GetMds(out locatorLogInInfo))
            {
                return;
            }
            //获取设备数据
            string devRet = _locatorServer.GetMessageByRestful(Locator_GetDeviceListReq.GenerateGetAppendMsg(locatorLogInInfo.id, locatorLogInInfo.mds));

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
                    dr["Server_time"] = GPS_DateConvertToUTC8(info.server_time);
                    dr["Updtime"] = GPS_DateConvertToUTC8(info.updtime);
                    dr["Speed"] = info.speed;
                    dr["Gpstime"] = GPS_DateConvertToUTC8(info.gpstime);
                    _dt_locator.Rows.Add(dr);
                }
                dgv_locatorList.DataSource = _dt_locator;
                dgv_locatorList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

        }

        private bool GetMds(out LocatorLogIn locatorLogIn)
        {
            locatorLogIn = null;
            string mdsRet = _locatorServer.GetMessageByRestful(LocatorLogIn.GetLogInAppendMsg(txt_ShipLocatorUserName.Text, txt_ShipLocatorPassWord.Text));
            if (string.IsNullOrEmpty(mdsRet))
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"获取定位器服务mds失败!");
                return false;
            }

            locatorLogIn = Newtonsoft.Json.JsonConvert.DeserializeObject<LocatorLogIn>(mdsRet) as LocatorLogIn;
            if (locatorLogIn == null)
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器云端服务mds报文异常!,ret:{mdsRet}");
                return false;
            }
            if (locatorLogIn.success.ToLower() != "true")
            {
                BaseFrmControl.ShowErrorMessageBox(this, $"定位器云端服务mds获取失败,ret:{mdsRet}");
                return false;
            }
            return true;
        }

        private string GPS_DateConvertToUTC8(long gpsTimeStamp)
        {
            // 将Unix时间戳转换为DateTimeOffset（UTC时间）
            DateTimeOffset utcTime = DateTimeOffset.FromUnixTimeMilliseconds(gpsTimeStamp);

            // 将UTC时间转换为北京时间（UTC+8）
            DateTime beijingTime = utcTime.ToLocalTime().AddHours(8).UtcDateTime;

            // 或者，如果你知道系统时区是UTC+8，也可以直接使用：
            // DateTime beijingTime = utcTime.UtcDateTime.AddHours(8);

            return beijingTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
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
    }
}
