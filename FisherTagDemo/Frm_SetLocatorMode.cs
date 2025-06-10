using FisherTagDemo.Locator;
using FormSet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisherTagDemo
{

    public partial class Frm_SetLocatorMode : Frm_Template
    {
        int _cmbIndex = 0;
        int _reportInterval = 3600;
        public event Action<Locator_ModeEntity> ModeEntiyConfirm;
        public Frm_SetLocatorMode()
        {
            InitializeComponent();
        }

        private void Frm_SetLocatorMode_Load(object sender, EventArgs e)
        {
            if (cmb_mode.Items.Count==0)
            {
                foreach (var item in Enum.GetNames(typeof(Locator_ModeEntity_WorkModeEnum)))
                {
                    cmb_mode.Items.Add(item);
                }
                cmb_mode.SelectedIndex = 0;
            }

        }

        private void btn_SetOK_Click(object sender, EventArgs e)
        {
            //cmd=MESSAGETOUC&param=MODE,x,y,A,B,C,D%23
            Locator_ModeEntity entity = new Locator_ModeEntity();
            entity.WorkModeEnum01 = (Locator_ModeEntity_WorkModeEnum)Enum.Parse(typeof(Locator_ModeEntity_WorkModeEnum), cmb_mode.Text);
            entity.ReportInterval02 = string.IsNullOrEmpty(txt_RFID_ServerPort.Text) ? 3600 : Convert.ToInt32(txt_RFID_ServerPort.Text);
            entity.GPS03 = chk_GPS.Checked ? 1 : 0;
            entity.WIFI04 = chk_wifi.Checked ? 1 : 0;
            entity.LBS05 = CHK_LBS.Checked ? 1 : 0;
            entity.GPRS06 = CHK_GPRS.Checked ? 1 : 0;
            if (DialogResult.Cancel == MessageBox.Show($"设定信息为：{JsonConvert.SerializeObject(entity)} \r\n 确定要进行设置吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return;
            }
            Task.Run(new Action(() =>
            {
                ModeEntiyConfirm?.Invoke(entity);
            }));

            this.Close();
        }

        private void txt_RFID_ServerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseFrmControl.KeyPressWithDigital(this, sender, e);
        }
    }
}
