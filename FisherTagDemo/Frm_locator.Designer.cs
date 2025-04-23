namespace FisherTagDemo
{
    partial class Frm_locator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmb_signalStrengthLevelCountMethod = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btn_querySignalNotExistArea = new DevComponents.DotNetBar.ButtonX();
            this.cmb_locatorSelect = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btn_querylowLevelSignal = new DevComponents.DotNetBar.ButtonX();
            this.txt_signalThreshold = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.webView_map = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btn_queryHighLevelSignal = new DevComponents.DotNetBar.ButtonX();
            this.dT_InEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.dT_InBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txt_showMessage = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.webView_map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dT_InEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dT_InBegin)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_signalStrengthLevelCountMethod
            // 
            this.cmb_signalStrengthLevelCountMethod.DisplayMember = "Text";
            this.cmb_signalStrengthLevelCountMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_signalStrengthLevelCountMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_signalStrengthLevelCountMethod.FormattingEnabled = true;
            this.cmb_signalStrengthLevelCountMethod.ItemHeight = 25;
            this.cmb_signalStrengthLevelCountMethod.Location = new System.Drawing.Point(212, 208);
            this.cmb_signalStrengthLevelCountMethod.Name = "cmb_signalStrengthLevelCountMethod";
            this.cmb_signalStrengthLevelCountMethod.Size = new System.Drawing.Size(342, 31);
            this.cmb_signalStrengthLevelCountMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_signalStrengthLevelCountMethod.TabIndex = 38;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(15, 208);
            this.labelX3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(188, 43);
            this.labelX3.TabIndex = 37;
            this.labelX3.Text = "信号阈值计算方式:";
            // 
            // btn_querySignalNotExistArea
            // 
            this.btn_querySignalNotExistArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_querySignalNotExistArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_querySignalNotExistArea.Location = new System.Drawing.Point(924, 10);
            this.btn_querySignalNotExistArea.Name = "btn_querySignalNotExistArea";
            this.btn_querySignalNotExistArea.Size = new System.Drawing.Size(132, 90);
            this.btn_querySignalNotExistArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_querySignalNotExistArea.TabIndex = 36;
            this.btn_querySignalNotExistArea.Text = "查询信号消失位置";
            // 
            // cmb_locatorSelect
            // 
            this.cmb_locatorSelect.DisplayMember = "Text";
            this.cmb_locatorSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_locatorSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_locatorSelect.FormattingEnabled = true;
            this.cmb_locatorSelect.ItemHeight = 25;
            this.cmb_locatorSelect.Location = new System.Drawing.Point(213, 8);
            this.cmb_locatorSelect.Name = "cmb_locatorSelect";
            this.cmb_locatorSelect.Size = new System.Drawing.Size(342, 31);
            this.cmb_locatorSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_locatorSelect.TabIndex = 35;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(15, 8);
            this.labelX2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(186, 40);
            this.labelX2.TabIndex = 34;
            this.labelX2.Text = "定位器选择:";
            // 
            // btn_querylowLevelSignal
            // 
            this.btn_querylowLevelSignal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_querylowLevelSignal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_querylowLevelSignal.Location = new System.Drawing.Point(786, 10);
            this.btn_querylowLevelSignal.Name = "btn_querylowLevelSignal";
            this.btn_querylowLevelSignal.Size = new System.Drawing.Size(132, 90);
            this.btn_querylowLevelSignal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_querylowLevelSignal.TabIndex = 33;
            this.btn_querylowLevelSignal.Text = "查询低于阈值点";
            this.btn_querylowLevelSignal.Click += new System.EventHandler(this.btn_querylowLevelSignal_Click);
            // 
            // txt_signalThreshold
            // 
            // 
            // 
            // 
            this.txt_signalThreshold.Border.Class = "TextBoxBorder";
            this.txt_signalThreshold.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_signalThreshold.Location = new System.Drawing.Point(212, 155);
            this.txt_signalThreshold.Name = "txt_signalThreshold";
            this.txt_signalThreshold.Size = new System.Drawing.Size(343, 31);
            this.txt_signalThreshold.TabIndex = 32;
            this.txt_signalThreshold.Text = "40";
            this.txt_signalThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_signalThreshold_KeyPress);
            // 
            // webView_map
            // 
            this.webView_map.AllowExternalDrop = true;
            this.webView_map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView_map.CreationProperties = null;
            this.webView_map.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView_map.Location = new System.Drawing.Point(648, 106);
            this.webView_map.Name = "webView_map";
            this.webView_map.Size = new System.Drawing.Size(951, 557);
            this.webView_map.TabIndex = 31;
            this.webView_map.ZoomFactor = 1D;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 155);
            this.labelX1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(188, 43);
            this.labelX1.TabIndex = 30;
            this.labelX1.Text = "信号强度阈值:";
            // 
            // btn_queryHighLevelSignal
            // 
            this.btn_queryHighLevelSignal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_queryHighLevelSignal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_queryHighLevelSignal.Location = new System.Drawing.Point(648, 10);
            this.btn_queryHighLevelSignal.Name = "btn_queryHighLevelSignal";
            this.btn_queryHighLevelSignal.Size = new System.Drawing.Size(132, 90);
            this.btn_queryHighLevelSignal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_queryHighLevelSignal.TabIndex = 29;
            this.btn_queryHighLevelSignal.Text = "查询高于阈值点";
            this.btn_queryHighLevelSignal.Click += new System.EventHandler(this.btn_queryGoodSingnal_Click);
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
            this.dT_InEnd.Location = new System.Drawing.Point(213, 105);
            this.dT_InEnd.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
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
            this.dT_InEnd.Size = new System.Drawing.Size(343, 31);
            this.dT_InEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dT_InEnd.TabIndex = 28;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(15, 105);
            this.labelX8.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(186, 40);
            this.labelX8.TabIndex = 27;
            this.labelX8.Text = "历史位置结束日期:";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(15, 58);
            this.labelX7.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(186, 40);
            this.labelX7.TabIndex = 26;
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
            this.dT_InBegin.Location = new System.Drawing.Point(213, 58);
            this.dT_InBegin.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
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
            this.dT_InBegin.Size = new System.Drawing.Size(343, 31);
            this.dT_InBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dT_InBegin.TabIndex = 25;
            // 
            // txt_showMessage
            // 
            // 
            // 
            // 
            this.txt_showMessage.Border.Class = "TextBoxBorder";
            this.txt_showMessage.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_showMessage.Location = new System.Drawing.Point(0, 488);
            this.txt_showMessage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_showMessage.Multiline = true;
            this.txt_showMessage.Name = "txt_showMessage";
            this.txt_showMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_showMessage.Size = new System.Drawing.Size(639, 175);
            this.txt_showMessage.TabIndex = 39;
            // 
            // Frm_locator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1611, 675);
            this.Controls.Add(this.txt_showMessage);
            this.Controls.Add(this.cmb_signalStrengthLevelCountMethod);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.btn_querySignalNotExistArea);
            this.Controls.Add(this.cmb_locatorSelect);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.btn_querylowLevelSignal);
            this.Controls.Add(this.txt_signalThreshold);
            this.Controls.Add(this.webView_map);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btn_queryHighLevelSignal);
            this.Controls.Add(this.dT_InEnd);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.dT_InBegin);
            this.DoubleBuffered = true;
            this.Name = "Frm_locator";
            this.Text = "Frm_locator";
            ((System.ComponentModel.ISupportInitialize)(this.webView_map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dT_InEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dT_InBegin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Editors.DateTimeAdv.DateTimeInput dT_InEnd;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dT_InBegin;
        private DevComponents.DotNetBar.ButtonX btn_queryHighLevelSignal;
        private DevComponents.DotNetBar.LabelX labelX1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView_map;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_signalThreshold;
        private DevComponents.DotNetBar.ButtonX btn_querylowLevelSignal;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_locatorSelect;
        private DevComponents.DotNetBar.ButtonX btn_querySignalNotExistArea;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_signalStrengthLevelCountMethod;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_showMessage;
    }
}