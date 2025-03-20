namespace FisherTagDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Sub1 = new System.Windows.Forms.SplitContainer();
            this.panel_operate = new DevComponents.DotNetBar.PanelEx();
            this.btnLog = new DevComponents.DotNetBar.ButtonX();
            this.dT_InEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.dT_InBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btn_clearLog = new DevComponents.DotNetBar.ButtonX();
            this.btn_getHistoryPath = new DevComponents.DotNetBar.ButtonX();
            this.btn_connectRfid = new DevComponents.DotNetBar.ButtonX();
            this.txt_ShipLocatorId_Obj = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btn_GetDevList = new DevComponents.DotNetBar.ButtonX();
            this.txt_ShipLocatorId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btn_getLocation = new DevComponents.DotNetBar.ButtonX();
            this.txt_ShipLocatorPassWord = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txt_RFID_ServerPort = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_disConnect = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txt_ShipLocatorURL = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_RFID_ServerIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_ShipLocatorUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.splitContainer_subLeftDown = new System.Windows.Forms.SplitContainer();
            this.dgv_rfid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.txt_showMessage = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.splitContainer_sub_right = new System.Windows.Forms.SplitContainer();
            this.dgv_locatorList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.webView_map = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Sub1)).BeginInit();
            this.splitContainer_Sub1.Panel1.SuspendLayout();
            this.splitContainer_Sub1.Panel2.SuspendLayout();
            this.splitContainer_Sub1.SuspendLayout();
            this.panel_operate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dT_InEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dT_InBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_subLeftDown)).BeginInit();
            this.splitContainer_subLeftDown.Panel1.SuspendLayout();
            this.splitContainer_subLeftDown.Panel2.SuspendLayout();
            this.splitContainer_subLeftDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rfid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_sub_right)).BeginInit();
            this.splitContainer_sub_right.Panel1.SuspendLayout();
            this.splitContainer_sub_right.Panel2.SuspendLayout();
            this.splitContainer_sub_right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_locatorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView_map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_Sub1);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.splitContainer_sub_right);
            this.splitContainer_Main.Size = new System.Drawing.Size(1009, 569);
            this.splitContainer_Main.SplitterDistance = 489;
            this.splitContainer_Main.TabIndex = 9;
            this.splitContainer_Main.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_Main_SplitterMoved);
            // 
            // splitContainer_Sub1
            // 
            this.splitContainer_Sub1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Sub1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Sub1.Name = "splitContainer_Sub1";
            this.splitContainer_Sub1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Sub1.Panel1
            // 
            this.splitContainer_Sub1.Panel1.Controls.Add(this.panel_operate);
            this.splitContainer_Sub1.Panel1.SizeChanged += new System.EventHandler(this.splitContainer_Main_Panel1_SizeChanged);
            // 
            // splitContainer_Sub1.Panel2
            // 
            this.splitContainer_Sub1.Panel2.Controls.Add(this.splitContainer_subLeftDown);
            this.splitContainer_Sub1.Size = new System.Drawing.Size(489, 569);
            this.splitContainer_Sub1.SplitterDistance = 334;
            this.splitContainer_Sub1.TabIndex = 18;
            this.splitContainer_Sub1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_Sub1_SplitterMoved);
            // 
            // panel_operate
            // 
            this.panel_operate.AutoScroll = true;
            this.panel_operate.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel_operate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel_operate.Controls.Add(this.btnLog);
            this.panel_operate.Controls.Add(this.dT_InEnd);
            this.panel_operate.Controls.Add(this.labelX8);
            this.panel_operate.Controls.Add(this.labelX7);
            this.panel_operate.Controls.Add(this.dT_InBegin);
            this.panel_operate.Controls.Add(this.btn_clearLog);
            this.panel_operate.Controls.Add(this.btn_getHistoryPath);
            this.panel_operate.Controls.Add(this.btn_connectRfid);
            this.panel_operate.Controls.Add(this.txt_ShipLocatorId_Obj);
            this.panel_operate.Controls.Add(this.labelX3);
            this.panel_operate.Controls.Add(this.btn_GetDevList);
            this.panel_operate.Controls.Add(this.txt_ShipLocatorId);
            this.panel_operate.Controls.Add(this.labelX1);
            this.panel_operate.Controls.Add(this.btn_getLocation);
            this.panel_operate.Controls.Add(this.txt_ShipLocatorPassWord);
            this.panel_operate.Controls.Add(this.labelX4);
            this.panel_operate.Controls.Add(this.txt_RFID_ServerPort);
            this.panel_operate.Controls.Add(this.btn_disConnect);
            this.panel_operate.Controls.Add(this.labelX6);
            this.panel_operate.Controls.Add(this.txt_ShipLocatorURL);
            this.panel_operate.Controls.Add(this.txt_RFID_ServerIP);
            this.panel_operate.Controls.Add(this.txt_ShipLocatorUserName);
            this.panel_operate.Controls.Add(this.labelX5);
            this.panel_operate.Controls.Add(this.labelX2);
            this.panel_operate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_operate.Location = new System.Drawing.Point(0, 0);
            this.panel_operate.Name = "panel_operate";
            this.panel_operate.Size = new System.Drawing.Size(489, 334);
            this.panel_operate.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel_operate.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel_operate.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel_operate.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel_operate.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel_operate.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel_operate.Style.GradientAngle = 90;
            this.panel_operate.TabIndex = 20;
            // 
            // btnLog
            // 
            this.btnLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLog.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLog.Location = new System.Drawing.Point(9, 256);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(103, 49);
            this.btnLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLog.TabIndex = 25;
            this.btnLog.Text = "LOG";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // dT_InEnd
            // 
            // 
            // 
            // 
            this.dT_InEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dT_InEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dT_InEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dT_InEnd.ButtonDropDown.Visible = true;
            this.dT_InEnd.IsPopupCalendarOpen = false;
            this.dT_InEnd.Location = new System.Drawing.Point(142, 227);
            // 
            // 
            // 
            this.dT_InEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dT_InEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dT_InEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dT_InEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dT_InEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dT_InEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dT_InEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dT_InEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dT_InEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dT_InEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dT_InEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dT_InEnd.MonthCalendar.DisplayMonth = new System.DateTime(2025, 3, 1, 0, 0, 0, 0);
            this.dT_InEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dT_InEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dT_InEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dT_InEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dT_InEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dT_InEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dT_InEnd.MonthCalendar.TodayButtonVisible = true;
            this.dT_InEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dT_InEnd.Name = "dT_InEnd";
            this.dT_InEnd.Size = new System.Drawing.Size(212, 21);
            this.dT_InEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dT_InEnd.TabIndex = 24;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(8, 227);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(128, 23);
            this.labelX8.TabIndex = 23;
            this.labelX8.Text = "历史位置结束日期:";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(8, 200);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(128, 23);
            this.labelX7.TabIndex = 22;
            this.labelX7.Text = "历史位置开始日期:";
            // 
            // dT_InBegin
            // 
            // 
            // 
            // 
            this.dT_InBegin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dT_InBegin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dT_InBegin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dT_InBegin.ButtonDropDown.Visible = true;
            this.dT_InBegin.IsPopupCalendarOpen = false;
            this.dT_InBegin.Location = new System.Drawing.Point(142, 200);
            // 
            // 
            // 
            this.dT_InBegin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dT_InBegin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dT_InBegin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dT_InBegin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dT_InBegin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dT_InBegin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dT_InBegin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dT_InBegin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dT_InBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dT_InBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dT_InBegin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dT_InBegin.MonthCalendar.DisplayMonth = new System.DateTime(2025, 3, 1, 0, 0, 0, 0);
            this.dT_InBegin.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dT_InBegin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dT_InBegin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dT_InBegin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dT_InBegin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dT_InBegin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dT_InBegin.MonthCalendar.TodayButtonVisible = true;
            this.dT_InBegin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dT_InBegin.Name = "dT_InBegin";
            this.dT_InBegin.Size = new System.Drawing.Size(212, 21);
            this.dT_InBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dT_InBegin.TabIndex = 21;
            // 
            // btn_clearLog
            // 
            this.btn_clearLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_clearLog.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_clearLog.Location = new System.Drawing.Point(360, 234);
            this.btn_clearLog.Name = "btn_clearLog";
            this.btn_clearLog.Size = new System.Drawing.Size(103, 49);
            this.btn_clearLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_clearLog.TabIndex = 20;
            this.btn_clearLog.Text = "清除信息";
            this.btn_clearLog.Click += new System.EventHandler(this.btn_clearLog_Click);
            // 
            // btn_getHistoryPath
            // 
            this.btn_getHistoryPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_getHistoryPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_getHistoryPath.Location = new System.Drawing.Point(360, 179);
            this.btn_getHistoryPath.Name = "btn_getHistoryPath";
            this.btn_getHistoryPath.Size = new System.Drawing.Size(103, 49);
            this.btn_getHistoryPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_getHistoryPath.TabIndex = 19;
            this.btn_getHistoryPath.Text = "获取历史位置";
            this.btn_getHistoryPath.Click += new System.EventHandler(this.btn_getHistoryPath_Click);
            // 
            // btn_connectRfid
            // 
            this.btn_connectRfid.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_connectRfid.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_connectRfid.Location = new System.Drawing.Point(251, 9);
            this.btn_connectRfid.Name = "btn_connectRfid";
            this.btn_connectRfid.Size = new System.Drawing.Size(103, 49);
            this.btn_connectRfid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_connectRfid.TabIndex = 4;
            this.btn_connectRfid.Text = "启动RFID监听服务";
            this.btn_connectRfid.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_ShipLocatorId_Obj
            // 
            // 
            // 
            // 
            this.txt_ShipLocatorId_Obj.Border.Class = "TextBoxBorder";
            this.txt_ShipLocatorId_Obj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ShipLocatorId_Obj.Location = new System.Drawing.Point(284, 173);
            this.txt_ShipLocatorId_Obj.Name = "txt_ShipLocatorId_Obj";
            this.txt_ShipLocatorId_Obj.Size = new System.Drawing.Size(70, 21);
            this.txt_ShipLocatorId_Obj.TabIndex = 18;
            this.txt_ShipLocatorId_Obj.Text = "17074328039";
            this.txt_ShipLocatorId_Obj.Visible = false;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(9, 169);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(98, 23);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "ShipLocatorId:";
            // 
            // btn_GetDevList
            // 
            this.btn_GetDevList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_GetDevList.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_GetDevList.Location = new System.Drawing.Point(360, 69);
            this.btn_GetDevList.Name = "btn_GetDevList";
            this.btn_GetDevList.Size = new System.Drawing.Size(103, 49);
            this.btn_GetDevList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_GetDevList.TabIndex = 17;
            this.btn_GetDevList.Text = "获取定位器列表";
            this.btn_GetDevList.Click += new System.EventHandler(this.btn_GetDevList_Click);
            // 
            // txt_ShipLocatorId
            // 
            // 
            // 
            // 
            this.txt_ShipLocatorId.Border.Class = "TextBoxBorder";
            this.txt_ShipLocatorId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ShipLocatorId.Enabled = false;
            this.txt_ShipLocatorId.Location = new System.Drawing.Point(113, 173);
            this.txt_ShipLocatorId.Name = "txt_ShipLocatorId";
            this.txt_ShipLocatorId.Size = new System.Drawing.Size(241, 21);
            this.txt_ShipLocatorId.TabIndex = 10;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(9, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(98, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "RFID_ServerIP:";
            // 
            // btn_getLocation
            // 
            this.btn_getLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_getLocation.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_getLocation.Location = new System.Drawing.Point(360, 124);
            this.btn_getLocation.Name = "btn_getLocation";
            this.btn_getLocation.Size = new System.Drawing.Size(103, 49);
            this.btn_getLocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_getLocation.TabIndex = 8;
            this.btn_getLocation.Text = "获取定位器位置";
            this.btn_getLocation.Click += new System.EventHandler(this.btn_getLocation_Click);
            // 
            // txt_ShipLocatorPassWord
            // 
            // 
            // 
            // 
            this.txt_ShipLocatorPassWord.Border.Class = "TextBoxBorder";
            this.txt_ShipLocatorPassWord.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ShipLocatorPassWord.Location = new System.Drawing.Point(142, 141);
            this.txt_ShipLocatorPassWord.Name = "txt_ShipLocatorPassWord";
            this.txt_ShipLocatorPassWord.PasswordChar = '*';
            this.txt_ShipLocatorPassWord.Size = new System.Drawing.Size(212, 21);
            this.txt_ShipLocatorPassWord.TabIndex = 16;
            this.txt_ShipLocatorPassWord.Text = "ym@123456";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(8, 67);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(98, 23);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "ShipLocatorURL:";
            // 
            // txt_RFID_ServerPort
            // 
            // 
            // 
            // 
            this.txt_RFID_ServerPort.Border.Class = "TextBoxBorder";
            this.txt_RFID_ServerPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_RFID_ServerPort.Location = new System.Drawing.Point(113, 38);
            this.txt_RFID_ServerPort.Name = "txt_RFID_ServerPort";
            this.txt_RFID_ServerPort.Size = new System.Drawing.Size(132, 21);
            this.txt_RFID_ServerPort.TabIndex = 3;
            this.txt_RFID_ServerPort.Text = "2000";
            // 
            // btn_disConnect
            // 
            this.btn_disConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_disConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_disConnect.Location = new System.Drawing.Point(360, 10);
            this.btn_disConnect.Name = "btn_disConnect";
            this.btn_disConnect.Size = new System.Drawing.Size(103, 49);
            this.btn_disConnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_disConnect.TabIndex = 7;
            this.btn_disConnect.Text = "停止RFID监听服务";
            this.btn_disConnect.Click += new System.EventHandler(this.btn_disConnect_Click);
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(8, 139);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(143, 23);
            this.labelX6.TabIndex = 15;
            this.labelX6.Text = "ShipLocatorPassWord:";
            // 
            // txt_ShipLocatorURL
            // 
            // 
            // 
            // 
            this.txt_ShipLocatorURL.Border.Class = "TextBoxBorder";
            this.txt_ShipLocatorURL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ShipLocatorURL.Location = new System.Drawing.Point(113, 69);
            this.txt_ShipLocatorURL.Multiline = true;
            this.txt_ShipLocatorURL.Name = "txt_ShipLocatorURL";
            this.txt_ShipLocatorURL.Size = new System.Drawing.Size(241, 32);
            this.txt_ShipLocatorURL.TabIndex = 12;
            this.txt_ShipLocatorURL.Text = "http://openapi.18gps.net/GetDateServices.asmx";
            // 
            // txt_RFID_ServerIP
            // 
            // 
            // 
            // 
            this.txt_RFID_ServerIP.Border.Class = "TextBoxBorder";
            this.txt_RFID_ServerIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_RFID_ServerIP.Location = new System.Drawing.Point(113, 10);
            this.txt_RFID_ServerIP.Name = "txt_RFID_ServerIP";
            this.txt_RFID_ServerIP.Size = new System.Drawing.Size(132, 21);
            this.txt_RFID_ServerIP.TabIndex = 1;
            this.txt_RFID_ServerIP.Text = "0.0.0.0";
            // 
            // txt_ShipLocatorUserName
            // 
            // 
            // 
            // 
            this.txt_ShipLocatorUserName.Border.Class = "TextBoxBorder";
            this.txt_ShipLocatorUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_ShipLocatorUserName.Location = new System.Drawing.Point(142, 112);
            this.txt_ShipLocatorUserName.Name = "txt_ShipLocatorUserName";
            this.txt_ShipLocatorUserName.Size = new System.Drawing.Size(212, 21);
            this.txt_ShipLocatorUserName.TabIndex = 14;
            this.txt_ShipLocatorUserName.Text = "贝尔数据科技（大连）有限公司";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(8, 108);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(143, 23);
            this.labelX5.TabIndex = 13;
            this.labelX5.Text = "ShipLocatorUserName:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(8, 38);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(98, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "RFID_ServerPort:";
            // 
            // splitContainer_subLeftDown
            // 
            this.splitContainer_subLeftDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_subLeftDown.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_subLeftDown.Name = "splitContainer_subLeftDown";
            this.splitContainer_subLeftDown.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_subLeftDown.Panel1
            // 
            this.splitContainer_subLeftDown.Panel1.Controls.Add(this.dgv_rfid);
            // 
            // splitContainer_subLeftDown.Panel2
            // 
            this.splitContainer_subLeftDown.Panel2.Controls.Add(this.txt_showMessage);
            this.splitContainer_subLeftDown.Size = new System.Drawing.Size(489, 231);
            this.splitContainer_subLeftDown.SplitterDistance = 104;
            this.splitContainer_subLeftDown.TabIndex = 0;
            // 
            // dgv_rfid
            // 
            this.dgv_rfid.AllowUserToAddRows = false;
            this.dgv_rfid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_rfid.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_rfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_rfid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_rfid.Location = new System.Drawing.Point(0, 0);
            this.dgv_rfid.Name = "dgv_rfid";
            this.dgv_rfid.ReadOnly = true;
            this.dgv_rfid.RowHeadersVisible = false;
            this.dgv_rfid.RowTemplate.Height = 23;
            this.dgv_rfid.Size = new System.Drawing.Size(489, 104);
            this.dgv_rfid.TabIndex = 1;
            // 
            // txt_showMessage
            // 
            // 
            // 
            // 
            this.txt_showMessage.Border.Class = "TextBoxBorder";
            this.txt_showMessage.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_showMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_showMessage.Location = new System.Drawing.Point(0, 0);
            this.txt_showMessage.Multiline = true;
            this.txt_showMessage.Name = "txt_showMessage";
            this.txt_showMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_showMessage.Size = new System.Drawing.Size(489, 123);
            this.txt_showMessage.TabIndex = 0;
            // 
            // splitContainer_sub_right
            // 
            this.splitContainer_sub_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_sub_right.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_sub_right.Name = "splitContainer_sub_right";
            this.splitContainer_sub_right.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_sub_right.Panel1
            // 
            this.splitContainer_sub_right.Panel1.Controls.Add(this.dgv_locatorList);
            // 
            // splitContainer_sub_right.Panel2
            // 
            this.splitContainer_sub_right.Panel2.Controls.Add(this.webView_map);
            this.splitContainer_sub_right.Size = new System.Drawing.Size(516, 569);
            this.splitContainer_sub_right.SplitterDistance = 136;
            this.splitContainer_sub_right.TabIndex = 0;
            // 
            // dgv_locatorList
            // 
            this.dgv_locatorList.AllowUserToAddRows = false;
            this.dgv_locatorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_locatorList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_locatorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_locatorList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_locatorList.Location = new System.Drawing.Point(0, 0);
            this.dgv_locatorList.Name = "dgv_locatorList";
            this.dgv_locatorList.ReadOnly = true;
            this.dgv_locatorList.RowHeadersVisible = false;
            this.dgv_locatorList.RowTemplate.Height = 23;
            this.dgv_locatorList.Size = new System.Drawing.Size(516, 136);
            this.dgv_locatorList.TabIndex = 0;
            this.dgv_locatorList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_locatorList_CellClick);
            // 
            // webView_map
            // 
            this.webView_map.AllowExternalDrop = true;
            this.webView_map.CreationProperties = null;
            this.webView_map.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView_map.Location = new System.Drawing.Point(0, 0);
            this.webView_map.Name = "webView_map";
            this.webView_map.Size = new System.Drawing.Size(516, 429);
            this.webView_map.TabIndex = 0;
            this.webView_map.ZoomFactor = 1D;
            this.webView_map.SizeChanged += new System.EventHandler(this.webView_map_SizeChanged);
            this.webView_map.Resize += new System.EventHandler(this.webView_map_Resize);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer2.Size = new System.Drawing.Size(50, 100);
            this.splitContainer2.SplitterDistance = 49;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(150, 100);
            this.splitContainer1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 569);
            this.Controls.Add(this.splitContainer_Main);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "船舶电子标牌";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.splitContainer_Sub1.Panel1.ResumeLayout(false);
            this.splitContainer_Sub1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Sub1)).EndInit();
            this.splitContainer_Sub1.ResumeLayout(false);
            this.panel_operate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dT_InEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dT_InBegin)).EndInit();
            this.splitContainer_subLeftDown.Panel1.ResumeLayout(false);
            this.splitContainer_subLeftDown.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_subLeftDown)).EndInit();
            this.splitContainer_subLeftDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rfid)).EndInit();
            this.splitContainer_sub_right.Panel1.ResumeLayout(false);
            this.splitContainer_sub_right.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_sub_right)).EndInit();
            this.splitContainer_sub_right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_locatorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView_map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.TextBoxX txt_msgShow;
        private DevComponents.DotNetBar.ButtonX btn_log;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer_Sub1;
        private System.Windows.Forms.SplitContainer splitContainer_subLeftDown;
        private System.Windows.Forms.SplitContainer splitContainer_sub_right;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_showMessage;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_locatorList;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_rfid;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView_map;
        private DevComponents.DotNetBar.PanelEx panel_operate;
        private DevComponents.DotNetBar.ButtonX btn_getHistoryPath;
        private DevComponents.DotNetBar.ButtonX btn_connectRfid;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ShipLocatorId_Obj;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btn_GetDevList;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ShipLocatorId;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btn_getLocation;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ShipLocatorPassWord;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_RFID_ServerPort;
        private DevComponents.DotNetBar.ButtonX btn_disConnect;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ShipLocatorURL;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_RFID_ServerIP;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_ShipLocatorUserName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btn_clearLog;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dT_InEnd;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dT_InBegin;
        private DevComponents.DotNetBar.ButtonX btnLog;
    }
}

