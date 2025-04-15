using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    public class Locator_Status
    {
        /// <summary>
        /// acc状态
        /// </summary>
        public bool accState_00 { get; set; }
        /// <summary>
        /// 设备自身设防状态
        /// </summary>
        public bool ProtectState_01 { get; set; }
        /// <summary>
        /// 油电开关
        /// </summary>
        public bool oilState_02 { get; set; }
        /// <summary>
        /// 充电状态
        /// </summary>
        public bool chargeState_03 { get; set; }
        /// <summary>
        /// 定位状态 1定位0未定位）【无意义】
        /// </summary>
        public bool locateState_04 { get; set; }
        /// <summary>
        /// 主电状态
        /// </summary>
        public bool ElecState05 { get; set; }

        public Locator_Status(string s)
        {
            if (s == null) throw new ArgumentNullException("Locator_Status 不可为null");
            if (s.Length == 0) throw new ArgumentException($"Locator_Status 长度不正确，长度应为9位，实际长度为:{s.Length}");
            accState_00 = s[0]=='1'?true : false;
            ProtectState_01 = s[1] == '1' ? true : false;
            oilState_02 = s[2] == '1' ? true : false;
            chargeState_03 = s[3] == '1' ? true : false;
            locateState_04 = s[4] == '1' ? true : false;
            ElecState05 = s[5] == '1' ? true : false;
        }
    }
}
