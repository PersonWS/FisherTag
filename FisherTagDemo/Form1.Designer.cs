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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Sub1 = new System.Windows.Forms.SplitContainer();
            this.panel_operate = new DevComponents.DotNetBar.PanelEx();
            this.txt_filter = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btn_connectRfid = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_RFID_ServerPort = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btn_disConnect = new DevComponents.DotNetBar.ButtonX();
            this.txt_RFID_ServerIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txt_showMessage = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgv_rfid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_clearShowMsg = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Sub1)).BeginInit();
            this.splitContainer_Sub1.Panel1.SuspendLayout();
            this.splitContainer_Sub1.Panel2.SuspendLayout();
            this.splitContainer_Sub1.SuspendLayout();
            this.panel_operate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rfid)).BeginInit();
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
            this.splitContainer_Main.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.splitContainer_Main.Name = "splitContainer_Main";
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_Sub1);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.dgv_rfid);
            this.splitContainer_Main.Size = new System.Drawing.Size(1843, 941);
            this.splitContainer_Main.SplitterDistance = 1056;
            this.splitContainer_Main.SplitterWidth = 8;
            this.splitContainer_Main.TabIndex = 9;
            this.splitContainer_Main.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_Main_SplitterMoved);
            // 
            // splitContainer_Sub1
            // 
            this.splitContainer_Sub1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Sub1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Sub1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
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
            this.splitContainer_Sub1.Panel2.Controls.Add(this.txt_showMessage);
            this.splitContainer_Sub1.Size = new System.Drawing.Size(1056, 941);
            this.splitContainer_Sub1.SplitterDistance = 236;
            this.splitContainer_Sub1.SplitterWidth = 8;
            this.splitContainer_Sub1.TabIndex = 18;
            this.splitContainer_Sub1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_Sub1_SplitterMoved);
            // 
            // panel_operate
            // 
            this.panel_operate.AutoScroll = true;
            this.panel_operate.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel_operate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel_operate.Controls.Add(this.btn_clearShowMsg);
            this.panel_operate.Controls.Add(this.txt_filter);
            this.panel_operate.Controls.Add(this.labelX3);
            this.panel_operate.Controls.Add(this.btn_connectRfid);
            this.panel_operate.Controls.Add(this.labelX1);
            this.panel_operate.Controls.Add(this.txt_RFID_ServerPort);
            this.panel_operate.Controls.Add(this.btn_disConnect);
            this.panel_operate.Controls.Add(this.txt_RFID_ServerIP);
            this.panel_operate.Controls.Add(this.labelX2);
            this.panel_operate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_operate.Location = new System.Drawing.Point(0, 0);
            this.panel_operate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel_operate.Name = "panel_operate";
            this.panel_operate.Size = new System.Drawing.Size(1056, 236);
            this.panel_operate.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel_operate.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel_operate.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panel_operate.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel_operate.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel_operate.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel_operate.Style.GradientAngle = 90;
            this.panel_operate.TabIndex = 20;
            // 
            // txt_filter
            // 
            // 
            // 
            // 
            this.txt_filter.Border.Class = "TextBoxBorder";
            this.txt_filter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_filter.Location = new System.Drawing.Point(226, 135);
            this.txt_filter.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txt_filter.Name = "txt_filter";
            this.txt_filter.Size = new System.Drawing.Size(264, 35);
            this.txt_filter.TabIndex = 9;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(16, 124);
            this.labelX3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(196, 46);
            this.labelX3.TabIndex = 8;
            this.labelX3.Text = "Filter:";
            // 
            // btn_connectRfid
            // 
            this.btn_connectRfid.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_connectRfid.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_connectRfid.Location = new System.Drawing.Point(502, 18);
            this.btn_connectRfid.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_connectRfid.Name = "btn_connectRfid";
            this.btn_connectRfid.Size = new System.Drawing.Size(206, 98);
            this.btn_connectRfid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_connectRfid.TabIndex = 4;
            this.btn_connectRfid.Text = "启动RFID监听服务";
            this.btn_connectRfid.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(17, 21);
            this.labelX1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(196, 46);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "RFID_ServerIP:";
            // 
            // txt_RFID_ServerPort
            // 
            // 
            // 
            // 
            this.txt_RFID_ServerPort.Border.Class = "TextBoxBorder";
            this.txt_RFID_ServerPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_RFID_ServerPort.Location = new System.Drawing.Point(226, 75);
            this.txt_RFID_ServerPort.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txt_RFID_ServerPort.Name = "txt_RFID_ServerPort";
            this.txt_RFID_ServerPort.Size = new System.Drawing.Size(264, 35);
            this.txt_RFID_ServerPort.TabIndex = 3;
            this.txt_RFID_ServerPort.Text = "2000";
            // 
            // btn_disConnect
            // 
            this.btn_disConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_disConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_disConnect.Location = new System.Drawing.Point(720, 21);
            this.btn_disConnect.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_disConnect.Name = "btn_disConnect";
            this.btn_disConnect.Size = new System.Drawing.Size(206, 98);
            this.btn_disConnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_disConnect.TabIndex = 7;
            this.btn_disConnect.Text = "停止RFID监听服务";
            this.btn_disConnect.Click += new System.EventHandler(this.btn_disConnect_Click);
            // 
            // txt_RFID_ServerIP
            // 
            // 
            // 
            // 
            this.txt_RFID_ServerIP.Border.Class = "TextBoxBorder";
            this.txt_RFID_ServerIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_RFID_ServerIP.Location = new System.Drawing.Point(226, 21);
            this.txt_RFID_ServerIP.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txt_RFID_ServerIP.Name = "txt_RFID_ServerIP";
            this.txt_RFID_ServerIP.Size = new System.Drawing.Size(264, 35);
            this.txt_RFID_ServerIP.TabIndex = 1;
            this.txt_RFID_ServerIP.Text = "0.0.0.0";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(16, 75);
            this.labelX2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(196, 46);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "RFID_ServerPort:";
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
            this.txt_showMessage.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txt_showMessage.Multiline = true;
            this.txt_showMessage.Name = "txt_showMessage";
            this.txt_showMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_showMessage.Size = new System.Drawing.Size(1056, 697);
            this.txt_showMessage.TabIndex = 0;
            // 
            // dgv_rfid
            // 
            this.dgv_rfid.AllowUserToAddRows = false;
            this.dgv_rfid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_rfid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_rfid.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_rfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_rfid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_rfid.Location = new System.Drawing.Point(0, 0);
            this.dgv_rfid.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.dgv_rfid.Name = "dgv_rfid";
            this.dgv_rfid.ReadOnly = true;
            this.dgv_rfid.RowHeadersVisible = false;
            this.dgv_rfid.RowHeadersWidth = 82;
            this.dgv_rfid.RowTemplate.Height = 23;
            this.dgv_rfid.Size = new System.Drawing.Size(779, 941);
            this.dgv_rfid.TabIndex = 1;
            this.dgv_rfid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgv_rfid_Scroll);
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
            // btn_clearShowMsg
            // 
            this.btn_clearShowMsg.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_clearShowMsg.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_clearShowMsg.Location = new System.Drawing.Point(500, 124);
            this.btn_clearShowMsg.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_clearShowMsg.Name = "btn_clearShowMsg";
            this.btn_clearShowMsg.Size = new System.Drawing.Size(206, 98);
            this.btn_clearShowMsg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_clearShowMsg.TabIndex = 10;
            this.btn_clearShowMsg.Text = "清除信息";
            this.btn_clearShowMsg.Click += new System.EventHandler(this.btn_clearShowMsg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1843, 941);
            this.Controls.Add(this.splitContainer_Main);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rfid)).EndInit();
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
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_rfid;
        private System.Windows.Forms.SplitContainer splitContainer_Sub1;
        private DevComponents.DotNetBar.PanelEx panel_operate;
        private DevComponents.DotNetBar.ButtonX btn_connectRfid;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_RFID_ServerPort;
        private DevComponents.DotNetBar.ButtonX btn_disConnect;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_RFID_ServerIP;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_showMessage;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_filter;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btn_clearShowMsg;
    }
}

