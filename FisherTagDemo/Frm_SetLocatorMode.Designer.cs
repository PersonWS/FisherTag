namespace FisherTagDemo
{
    partial class Frm_SetLocatorMode
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
            this.CHK_GPRS = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.CHK_LBS = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_wifi = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cmb_mode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.chk_GPS = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btn_SetOK = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txt_RFID_ServerPort = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // CHK_GPRS
            // 
            // 
            // 
            // 
            this.CHK_GPRS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CHK_GPRS.Checked = true;
            this.CHK_GPRS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_GPRS.CheckValue = "Y";
            this.CHK_GPRS.Location = new System.Drawing.Point(217, 217);
            this.CHK_GPRS.Name = "CHK_GPRS";
            this.CHK_GPRS.Size = new System.Drawing.Size(199, 44);
            this.CHK_GPRS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CHK_GPRS.TabIndex = 23;
            this.CHK_GPRS.Text = "GPRS";
            // 
            // CHK_LBS
            // 
            // 
            // 
            // 
            this.CHK_LBS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CHK_LBS.Checked = true;
            this.CHK_LBS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_LBS.CheckValue = "Y";
            this.CHK_LBS.Location = new System.Drawing.Point(12, 217);
            this.CHK_LBS.Name = "CHK_LBS";
            this.CHK_LBS.Size = new System.Drawing.Size(199, 44);
            this.CHK_LBS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CHK_LBS.TabIndex = 22;
            this.CHK_LBS.Text = "LBS";
            // 
            // chk_wifi
            // 
            // 
            // 
            // 
            this.chk_wifi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk_wifi.Checked = true;
            this.chk_wifi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_wifi.CheckValue = "Y";
            this.chk_wifi.Location = new System.Drawing.Point(225, 137);
            this.chk_wifi.Name = "chk_wifi";
            this.chk_wifi.Size = new System.Drawing.Size(199, 44);
            this.chk_wifi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk_wifi.TabIndex = 21;
            this.chk_wifi.Text = "WIFI";
            // 
            // cmb_mode
            // 
            this.cmb_mode.DisplayMember = "Text";
            this.cmb_mode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_mode.FormattingEnabled = true;
            this.cmb_mode.ItemHeight = 29;
            this.cmb_mode.Location = new System.Drawing.Point(225, 12);
            this.cmb_mode.Name = "cmb_mode";
            this.cmb_mode.Size = new System.Drawing.Size(266, 35);
            this.cmb_mode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_mode.TabIndex = 20;
            // 
            // chk_GPS
            // 
            // 
            // 
            // 
            this.chk_GPS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk_GPS.Checked = true;
            this.chk_GPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_GPS.CheckValue = "Y";
            this.chk_GPS.Location = new System.Drawing.Point(12, 137);
            this.chk_GPS.Name = "chk_GPS";
            this.chk_GPS.Size = new System.Drawing.Size(199, 44);
            this.chk_GPS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk_GPS.TabIndex = 19;
            this.chk_GPS.Text = "GPS";
            // 
            // btn_SetOK
            // 
            this.btn_SetOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_SetOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_SetOK.Location = new System.Drawing.Point(501, 12);
            this.btn_SetOK.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btn_SetOK.Name = "btn_SetOK";
            this.btn_SetOK.Size = new System.Drawing.Size(206, 249);
            this.btn_SetOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_SetOK.TabIndex = 18;
            this.btn_SetOK.Text = "确定";
            this.btn_SetOK.Click += new System.EventHandler(this.btn_SetOK_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(16, 15);
            this.labelX1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(196, 46);
            this.labelX1.TabIndex = 15;
            this.labelX1.Text = "Mode:";
            // 
            // txt_RFID_ServerPort
            // 
            // 
            // 
            // 
            this.txt_RFID_ServerPort.Border.Class = "TextBoxBorder";
            this.txt_RFID_ServerPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_RFID_ServerPort.Location = new System.Drawing.Point(225, 82);
            this.txt_RFID_ServerPort.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txt_RFID_ServerPort.Name = "txt_RFID_ServerPort";
            this.txt_RFID_ServerPort.Size = new System.Drawing.Size(264, 35);
            this.txt_RFID_ServerPort.TabIndex = 17;
            this.txt_RFID_ServerPort.Text = "300";
            this.txt_RFID_ServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RFID_ServerPort_KeyPress);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(15, 82);
            this.labelX2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(196, 46);
            this.labelX2.TabIndex = 16;
            this.labelX2.Text = "ReportInterval:";
            // 
            // Frm_SetLocatorMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 278);
            this.Controls.Add(this.CHK_GPRS);
            this.Controls.Add(this.CHK_LBS);
            this.Controls.Add(this.chk_wifi);
            this.Controls.Add(this.cmb_mode);
            this.Controls.Add(this.chk_GPS);
            this.Controls.Add(this.btn_SetOK);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txt_RFID_ServerPort);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.Name = "Frm_SetLocatorMode";
            this.Text = "Frm_SetLocatorMode";
            this.Load += new System.EventHandler(this.Frm_SetLocatorMode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX CHK_GPRS;
        private DevComponents.DotNetBar.Controls.CheckBoxX CHK_LBS;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_wifi;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_mode;
        private DevComponents.DotNetBar.Controls.CheckBoxX chk_GPS;
        private DevComponents.DotNetBar.ButtonX btn_SetOK;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_RFID_ServerPort;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}