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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_msgShow = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_log = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Sub1 = new System.Windows.Forms.SplitContainer();
            this.panel_operate = new DevComponents.DotNetBar.PanelEx();
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
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_msgShow
            // 
            // 
            // 
            // 
            this.txt_msgShow.Border.Class = "TextBoxBorder";
            this.txt_msgShow.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_msgShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_msgShow.Location = new System.Drawing.Point(0, 0);
            this.txt_msgShow.Multiline = true;
            this.txt_msgShow.Name = "txt_msgShow";
            this.txt_msgShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_msgShow.Size = new System.Drawing.Size(375, 231);
            this.txt_msgShow.TabIndex = 5;
            // 
            // btn_log
            // 
            this.btn_log.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_log.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_log.Location = new System.Drawing.Point(825, 418);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(103, 50);
            this.btn_log.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_log.TabIndex = 6;
            this.btn_log.Text = "Log";
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
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
            this.splitContainer_Sub1.SplitterDistance = 311;
            this.splitContainer_Sub1.TabIndex = 18;
            this.splitContainer_Sub1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_Sub1_SplitterMoved);
            // 
            // panel_operate
            // 
            this.panel_operate.AutoScroll = true;
            this.panel_operate.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel_operate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
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
            this.panel_operate.Size = new System.Drawing.Size(489, 311);
            this.panel_operate.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel_operate.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel_operate.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel_operate.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel_operate.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel_operate.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel_operate.Style.GradientAngle = 90;
            this.panel_operate.TabIndex = 20;
            // 
            // btn_getHistoryPath
            // 
            this.btn_getHistoryPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_getHistoryPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_getHistoryPath.Location = new System.Drawing.Point(360, 234);
            this.btn_getHistoryPath.Name = "btn_getHistoryPath";
            this.btn_getHistoryPath.Size = new System.Drawing.Size(103, 63);
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
            this.btn_connectRfid.Size = new System.Drawing.Size(103, 63);
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
            this.txt_ShipLocatorId_Obj.Location = new System.Drawing.Point(284, 200);
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
            this.labelX3.Location = new System.Drawing.Point(9, 196);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(98, 23);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "ShipLocatorId:";
            // 
            // btn_GetDevList
            // 
            this.btn_GetDevList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_GetDevList.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_GetDevList.Location = new System.Drawing.Point(360, 95);
            this.btn_GetDevList.Name = "btn_GetDevList";
            this.btn_GetDevList.Size = new System.Drawing.Size(103, 63);
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
            this.txt_ShipLocatorId.Location = new System.Drawing.Point(113, 200);
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
            this.btn_getLocation.Location = new System.Drawing.Point(360, 165);
            this.btn_getLocation.Name = "btn_getLocation";
            this.btn_getLocation.Size = new System.Drawing.Size(103, 63);
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
            this.txt_ShipLocatorPassWord.Location = new System.Drawing.Point(142, 168);
            this.txt_ShipLocatorPassWord.Name = "txt_ShipLocatorPassWord";
            this.txt_ShipLocatorPassWord.PasswordChar = '*';
            this.txt_ShipLocatorPassWord.Size = new System.Drawing.Size(212, 21);
            this.txt_ShipLocatorPassWord.TabIndex = 16;
            this.txt_ShipLocatorPassWord.Text = "123456";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(8, 94);
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
            this.txt_RFID_ServerPort.Location = new System.Drawing.Point(113, 49);
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
            this.btn_disConnect.Size = new System.Drawing.Size(103, 63);
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
            this.labelX6.Location = new System.Drawing.Point(8, 166);
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
            this.txt_ShipLocatorURL.Location = new System.Drawing.Point(113, 96);
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
            this.txt_ShipLocatorUserName.Location = new System.Drawing.Point(142, 139);
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
            this.labelX5.Location = new System.Drawing.Point(8, 135);
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
            this.labelX2.Location = new System.Drawing.Point(8, 49);
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
            this.splitContainer_subLeftDown.Size = new System.Drawing.Size(489, 254);
            this.splitContainer_subLeftDown.SplitterDistance = 116;
            this.splitContainer_subLeftDown.TabIndex = 0;
            // 
            // dgv_rfid
            // 
            this.dgv_rfid.AllowUserToAddRows = false;
            this.dgv_rfid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_rfid.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_rfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_rfid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_rfid.Location = new System.Drawing.Point(0, 0);
            this.dgv_rfid.Name = "dgv_rfid";
            this.dgv_rfid.ReadOnly = true;
            this.dgv_rfid.RowHeadersVisible = false;
            this.dgv_rfid.RowTemplate.Height = 23;
            this.dgv_rfid.Size = new System.Drawing.Size(489, 116);
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
            this.txt_showMessage.Size = new System.Drawing.Size(489, 134);
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
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_locatorList.DefaultCellStyle = dataGridViewCellStyle14;
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
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer2.Size = new System.Drawing.Size(189, 231);
            this.splitContainer2.SplitterDistance = 115;
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_msgShow);
            this.splitContainer1.Size = new System.Drawing.Size(568, 231);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 569);
            this.Controls.Add(this.splitContainer_Main);
            this.Controls.Add(this.btn_log);
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
            this.splitContainer1.Panel2.ResumeLayout(false);
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
    }
}

