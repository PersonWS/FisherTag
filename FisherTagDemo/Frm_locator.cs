using FisherTagDemo.Locator;
using FormSet;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisherTagDemo
{
    public partial class Frm_locator : Frm_Template
    {
        CommonResource _commonResource;
        /// <summary>
        /// 控件是否正在展示地图
        /// </summary>
        private bool _isShowPositionIng = false;
        public Frm_locator(CommonResource commonResource)
        {
            InitializeComponent();
            _commonResource = commonResource;
            Ini();
        }

        private void Ini()
        {
            cmb_locatorSelect.Items.Clear();
            cmb_locatorSelect.Items.Add("ALL");
            for (int i = 0; i < _commonResource?.LocatorDeviceInfo?.rows.Count; i++)
            {
                cmb_locatorSelect.Items.Add(_commonResource.LocatorDeviceInfo.rows[i].fullName);
            }
            cmb_signalStrengthLevelCountMethod.Items.Add("AVG");
            cmb_signalStrengthLevelCountMethod.Items.Add("MIN");
            cmb_signalStrengthLevelCountMethod.Items.Add("MAX");
            dT_InBegin.Value = DateTime.Now.AddDays(-7);
            dT_InEnd.Value = DateTime.Now;
            InitializeWebView();
            cmb_locatorSelect.SelectedIndex = 0;
            cmb_signalStrengthLevelCountMethod.SelectedIndex = 0;


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

        private void btn_queryGoodSingnal_Click(object sender, EventArgs e)
        {
            if (_isShowPositionIng)
            {
                FormSet.BaseFrmControl.ShowErrorMessageBox(this, "有其他查询结果正在展示中，请稍后再试！");
                return;
            }
            _isShowPositionIng = true;
            if (string.IsNullOrEmpty(txt_signalThreshold.Text))
            {
                BaseFrmControl.ShowErrorMessageBox(this, "信号阈值不可为空");
                return;
            }
            DataTable dt = _commonResource.DBOperate.QuerySignalBySignalStrength(cmb_locatorSelect.Text, Convert.ToInt32(txt_signalThreshold.Text), cmb_signalStrengthLevelCountMethod.Text, false);
            if (dt != null)
            {
                GeneratePointAndShow(new List<DataTable>() { dt });
            }
            else
            {
                ShowMessage("该时间区间查询到的信号数据为空");
            }
        }

        private async void GeneratePointAndShow(List<DataTable> dtList)
        {
            List<LocatoreHistoryLocation> data = new List<LocatoreHistoryLocation>();
            foreach (DataTable dt in dtList)
            {
                if (dt.Rows.Count < 3)
                {
                    ShowMessage("GeneratePointAndShow , 输入数据不正确");
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    LocatoreHistoryLocation his = new LocatoreHistoryLocation(row["longitude"].ToString(), row["latitude"].ToString(), row["timeStamp"].ToString(), row["gmsLevel"].ToString());
                    data.Add(his);
                }
            }
            //获得经纬度速度
            string locationStr = JsonConvert.SerializeObject(data);
            // 处理JSON字符串中的特殊字符
            string escapedJson = locationStr.Replace("'", "\\'");

            // 正确的JavaScript调用（注意括号匹配和参数传递）
            string jsCall = $"drawTrajectory(JSON.parse('{escapedJson}'), false)";

            ShowMessage($"开始执行地图显示数据绘制！");
            await webView_map.CoreWebView2.ExecuteScriptAsync(jsCall);
            _isShowPositionIng = false;
            ShowMessage($"地图显示数据绘制完成！");
        }

        private void ShowMessage(string msg)
        {
            FormSet.BaseFrmControl.ShowMessageOnTextBox(this, txt_showMessage, msg, true);

        }

        private void txt_signalThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormSet.BaseFrmControl.KeyPressWithDigital(this, sender, e);
        }

        private void btn_querylowLevelSignal_Click(object sender, EventArgs e)
        {
            if (_isShowPositionIng)
            {
                FormSet.BaseFrmControl.ShowErrorMessageBox(this, "有其他查询结果正在展示中，请稍后再试！");
                return;
            }
            _isShowPositionIng = true;
            if (string.IsNullOrEmpty(txt_signalThreshold.Text))
            {
                BaseFrmControl.ShowErrorMessageBox(this, "信号阈值不可为空");
                return;
            }
            DataTable dt = _commonResource.DBOperate.QuerySignalBySignalStrength(cmb_locatorSelect.Text, Convert.ToInt32(txt_signalThreshold.Text), cmb_signalStrengthLevelCountMethod.Text, true);
            if (dt != null)
            {
                GeneratePointAndShow(new List<DataTable>() { dt });
            }
            else
            {
                GeneratePointAndShow(new List<DataTable>() {  });
                ShowMessage("该时间区间查询到的信号数据为空");
            }
        }

        private void Frm_locator_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void btn_querySignalNotExistArea_Click(object sender, EventArgs e)
        {
            if (_isShowPositionIng)
            {
                FormSet.BaseFrmControl.ShowErrorMessageBox(this, "有其他查询结果正在展示中，请稍后再试！");
                return;
            }
            List<DataTable> dataTables = AnalysisShipLowSignalData();
            GeneratePointAndShow(dataTables);
            _isShowPositionIng = true;


        }

        DataTable _shipNoneSignalDataTable;

        private void IniShipNoneSignalDataTable()
        {
            _shipNoneSignalDataTable=new DataTable();
            _shipNoneSignalDataTable.Columns.Add("longitude");
            _shipNoneSignalDataTable.Columns.Add("latitude");
            _shipNoneSignalDataTable.Columns.Add("timeStamp");
            _shipNoneSignalDataTable.Columns.Add("gmsLevel");
        }
        /// <summary>
        /// 分析船只的无信号区域的数据
        /// </summary>
        private List<DataTable> AnalysisShipLowSignalData()
        {
            if (_shipNoneSignalDataTable == null)
            {
                IniShipNoneSignalDataTable();
            }
            else
            { _shipNoneSignalDataTable.Rows.Clear(); }
            List<DataTable> collectData = new List<DataTable>();
            DataTable dt ;
            if (!string.IsNullOrEmpty(cmb_locatorSelect.Text.ToLower()) && cmb_locatorSelect.Text.ToLower() != "all")//如果指定了设备就把其他的移除掉
            {
                dt=new DataTable();
                dt.Columns.Add("userName");
                DataRow dataRow = dt.NewRow();
                dataRow[0] = cmb_locatorSelect.Text;
                dt.Rows.Add(dataRow);
            }
            else
            { dt= _commonResource.DBOperate.QueryExistShip(); }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    string userName = item[0].ToString();
                    DataTable dt2 = _commonResource.DBOperate.QueryOfflineRecord(userName);//获得离线记录
                    if (dt2.Rows.Count > 0)
                    {
                        string oldState = dt2.Rows[0]["OnlineState"].ToString();
                        string beginTimeStamp = dt2.Rows[0]["DateTimeString"].ToString();
                        string endTimeStamp = dt2.Rows[0]["DateTimeString"].ToString();
                        for (int i = 1; i < dt2.Rows.Count; i++)
                        {
                            if (oldState.ToLower() == dt2.Rows[i]["OnlineState"].ToString().ToLower())
                            {
                                continue;
                            }
                            if (oldState.ToLower() == "offline" && dt2.Rows[i]["OnlineState"].ToString().ToLower() == "online")//认定这个是无信号的区间，给信号查出来
                            {
                                oldState = "online";
                                endTimeStamp = dt2.Rows[i]["DateTimeString"].ToString();
                                List<LocatoreHistoryLocation> history = GetHistoryLocation(userName, beginTimeStamp, endTimeStamp);//从服务器获得历史轨迹
                                if (history == null)
                                {
                                    ShowMessage($"userName：{userName} ,beginTimeStamp:{beginTimeStamp}, endTimeStamp:{endTimeStamp}, 存在{0}条离线定位消息");
                                    continue;
                                }
                                ShowMessage($"userName：{userName} ,beginTimeStamp:{beginTimeStamp}, endTimeStamp:{endTimeStamp}, 存在{history.Count}条离线定位消息");
                                foreach (LocatoreHistoryLocation location in history)
                                {
                                   DataRow dr= _shipNoneSignalDataTable.NewRow();
                                    dr["longitude"] = location.lng ;
                                    dr["latitude"] = location.lat;
                                    dr["timeStamp"] = location.time;
                                    dr["gmsLevel"] = -1;
                                    _shipNoneSignalDataTable.Rows.Add(dr);
                                }
                                //DataTable dt3 = _commonResource.DBOperate.QueryShipLocatorPosition(userName, beginTimeStamp, endTimeStamp);
                                //if (dt3.Rows.Count > 0)
                                //{
                                //    collectData.Add(dt3);
                                //}
                               

                            }
                            if (dt2.Rows[i]["OnlineState"].ToString().ToLower() == "offline")//设备离线时更新信息
                            {
                                oldState = "offline";
                                beginTimeStamp = dt2.Rows[i]["DateTimeString"].ToString();
                            }
                        }
                    }
                    else
                    {
                        ShowMessage($"船只:{item[0].ToString()}, 无离线记录");
                    }
                }
            }
            else
            {
                ShowMessage("数据库内无船舶历史记录");
            }
            if (_shipNoneSignalDataTable.Rows.Count>0)
            {
                collectData.Add(_shipNoneSignalDataTable);
            }
            return collectData;
        }


        string _getMdsString = "";
        private List<LocatoreHistoryLocation> GetHistoryLocation(string locatorUserName,string beginTime,string endTime)
        {
            //先获取MDS
            if (!_commonResource.GetMds(out _getMdsString))
            {
                ShowMessage(_getMdsString);
                return null;
            }
            ShowMessage($"开始获取设备数据...");
            //查找设备id
            string locatorID = "";
            foreach (var item in _commonResource.LocatorDeviceInfo.rows)
            {
                if (item.fullName== locatorUserName)
                {
                    locatorID = item.macid;
                    break;  
                }
            }
            //获取设备数据
            string devRet = _commonResource.LocatorServer.GetMessageByRestful(Locator_GetDeviceHistoryLocationReq.GenerateGetAppendMsg(locatorID, this._commonResource.LocatorLogIn.mds,
                TimeDataConvert.GPS_DateConvertDateTimeToUTC8(beginTime).ToString(), TimeDataConvert.GPS_DateConvertDateTimeToUTC8(endTime).ToString()), false);
            if (devRet == null)
            {
                ShowMessage($"定位器ID:{locatorUserName},设备数据为null ,ret:{devRet}");
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{locatorUserName},设备数据为null");
                return null;
            }
            Locator_GetDeviceHistoryLocationAck devInfo = JsonConvert.DeserializeObject<Locator_GetDeviceHistoryLocationAck>(devRet) as Locator_GetDeviceHistoryLocationAck;
            if (devInfo == null)
            {
                ShowMessage($"定位器ID:{locatorUserName},设备数据转换失败,ret:{devRet}");
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{locatorUserName},设备数据转换失败,ret:{devRet}");
                return null;
            }
            else if (devInfo.success != "true")
            {
                ShowMessage($"定位器ID:{locatorUserName},数据异常,ret:{devRet}");
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{locatorUserName},数据异常,ret:{devRet}");
                return null;
            }
            else if (devInfo.data == null || devInfo.data.Count == 0 || string.IsNullOrEmpty(devInfo.data[0].point))
            {
                ShowMessage($"定位器ID:{locatorUserName},无历史轨迹信息,ret:{devRet}");
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器ID:{locatorUserName},无历史轨迹信息,ret:{devRet}");
                return null;
            }

            //处理point数据
            string[] points = devInfo.data[0].point.Split(';');
            List<LocatoreHistoryLocation> data = new List<LocatoreHistoryLocation>();
            for (int i = 0; i < points.Length; i++)
            {
                string[] pointsData = points[i].Split(',');
                if (pointsData.Length < 3)
                {
                    continue;
                }
                Int64 utcTime = 0;
                Int64.TryParse(pointsData[2].ToString(), out utcTime);
                LocatoreHistoryLocation his = new LocatoreHistoryLocation(pointsData[0], pointsData[1], utcTime);
                data.Add(his);
            }
            return data;
        }






    }
}
