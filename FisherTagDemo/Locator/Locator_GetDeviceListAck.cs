using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetDeviceListAck:RestfulReturnMsgBase
    {
      public  List<DeviceInfo> rows { get; set; }
    }

    public class DeviceInfo
    {
        /// <summary>
        /// 设备 object ID
        /// </summary>
        public string objectid { get; set; } // 设备id
        public string platenumber { get; set; } // 车牌号
        /// <summary>
        /// 定位器名称
        /// </summary>
        public string fullName { get; set; } // 名称
        /// <summary>
        /// 设备编号
        /// </summary>
        public string macid { get; set; } // 设备号
        public string blockdate { get; set; } // 到期时间
        public string offline { get; set; } // 是否在线
        public string speed { get; set; } // 速度
        public long updtime { get; set; } // 最后更新时间
        public string defenceStatus { get; set; } // 设防状态
        public long gpstime { get; set; } // 定位时间
        public string sim { get; set; } // sim卡号码
        public long server_time { get; set; } // 当前时间
        public string macName { get; set; } // 设备型号
    }
}
