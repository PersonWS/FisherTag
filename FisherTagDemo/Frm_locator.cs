using FisherTagDemo.Locator;
using FormSet;
using IOTDBHepler;
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
            for (int i = 0; i < _commonResource.LocatorDeviceInfo?.rows.Count; i++)
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
            DataTable dt = _commonResource.DBOperate.QuerySignalBySignalStrength(Convert.ToInt32(txt_signalThreshold.Text), cmb_signalStrengthLevelCountMethod.Text, false);
            if (dt != null)
            {
                GeneratePointAndShow(dt);
            }
            else
            {
                ShowMessage("该时间区间查询到的信号数据为空");
            }
        }

        private async void GeneratePointAndShow(DataTable dt)
        {
            if (dt.Rows.Count < 3)
            {
                Log.LogRecorder_business.Error("GeneratePointAndShow , 输入数据不正确");
            }
            List<LocatoreHistoryLocation> data = new List<LocatoreHistoryLocation>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                LocatoreHistoryLocation his = new LocatoreHistoryLocation(row["longitude"].ToString(), row["latitude"].ToString(), row["gmsLevel"].ToString());
                data.Add(his);
            }

            //获得经纬度速度
            string locationStr = JsonConvert.SerializeObject(data);
            // 处理JSON字符串中的特殊字符
            string escapedJson = locationStr.Replace("'", "\\'");

            // 正确的JavaScript调用（注意括号匹配和参数传递）
            string jsCall = $"drawTrajectory(JSON.parse('{escapedJson}'), false)";

            ShowMessage($"即将执行: jscall");
            await webView_map.CoreWebView2.ExecuteScriptAsync(jsCall);
            _isShowPositionIng = false;
        }

        private void ShowMessage(string msg)
        {
            FormSet.BaseFrmControl.ShowMessageOnTextBox(this, txt_showMessage, msg, true);
            Log.LogRecorder_business.Info(msg);
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
            DataTable dt = _commonResource.DBOperate.QuerySignalBySignalStrength(Convert.ToInt32(txt_signalThreshold.Text), cmb_signalStrengthLevelCountMethod.Text,true);
            if (dt != null)
            {
                GeneratePointAndShow(dt);
            }
            else
            {
                ShowMessage("该时间区间查询到的信号数据为空");
            }
        }
    }
}
