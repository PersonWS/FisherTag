using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetDeviceCurrentLocationAck : RestfulReturnMsgBase
    {
        public List<DataItem> data { get; set; } // 数据列表
    }

    public class DataItem
    {
        public Key key { get; set; } // 数据键（字段说明）
        public List<List<object>> records { get; set; } // 记录列表
        public List<object> groups { get; set; } // 组列表
    }

    public class Key
    {
        public int sys_time { get; set; } // 设备定位时间
        public int user_name { get; set; } // 设备名称
        public int jingdu { get; set; } // 经度（GPS 定位）
        public int weidu { get; set; } // 纬度（GPS 定位）
        public int ljingdu { get; set; } // 基站经度（基站或 WiFi 定位）
        public int lweidu { get; set; } // 基站纬度（基站或 WiFi 定位）
        public int datetime { get; set; } // 数据更新时间（服务器接收时间）
        public int heart_time { get; set; } // 设备心跳时间（信号时间）
        public int su { get; set; } // 速度
        public int status { get; set; } // 状态组
        public int hangxiang { get; set; } // 方向
        public int sim_id { get; set; } // 设备编号
        public int user_id { get; set; } // 设备 ID
        public int sale_type { get; set; } // 销售类型（无用途）
        public int iconType { get; set; } // 图标
        public int server_time { get; set; } // 系统时间（当前时间）
        public int product_type { get; set; } // 设备类型
        public int expire_date { get; set; } // 到期时间
        public int group_id { get; set; } // 监控组 ID
        public int statenumber { get; set; } // 信息组
        public int electric { get; set; } // 电量
        public int describe { get; set; } // 设备描述信息（通常存放一些设备上传的运行参数）
        public int sim { get; set; } // SIM 卡
        public int precision { get; set; } // 精度误差（LBS/WiFi），当值为 10 表示 GPS 定位，无精度
        public int isFollow { get; set; } // 是否是关注设备
        public int plateNumber { get; set; } // 车牌号
        public int auth { get; set; } // 权限
        public int authList { get; set; } // 权限列表
        public int deptname { get; set; } // 单位名称（2022/11/11 添加）
    }


}
