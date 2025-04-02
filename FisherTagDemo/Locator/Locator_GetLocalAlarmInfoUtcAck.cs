using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetLocalAlarmInfoUtcAck : RestfulReturnMsgBase
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 报警数据列表
        /// </summary>
        public List<Locator_GetLocalAlarmInfoUtcAck_AlarmData> rows { get; set; }
    }
    public class Locator_GetLocalAlarmInfoUtcAck_AlarmData
    {
        /// <summary>
        /// 报警编号（数据库主键，Guid 格式）
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string macid { get; set; }

        /// <summary>
        /// 方向（角度值，0-360）
        /// </summary>
        public int course { get; set; }

        /// <summary>
        /// GPS 状态描述（如"今天过期"）
        /// </summary>
        public string gps_status { get; set; }

        /// <summary>
        /// 接收到报警数据的时间（Unix 时间戳，毫秒）
        /// </summary>
        public long gps_time { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double jingdu { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double weidu { get; set; }

        /// <summary>
        /// 报警时间（Unix 时间戳，毫秒）
        /// </summary>
        public long send_time { get; set; }

        /// <summary>
        /// 速度（字符串形式，如"0"）
        /// </summary>
        public string speed { get; set; }

        /// <summary>
        /// 处理状态（0=未处理）
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 报警类型ID
        /// </summary>
        public int type_id { get; set; }

        /// <summary>
        /// 二级分类描述（补充说明）
        /// </summary>
        public int classifyDescribe { get; set; }

        /// <summary>
        /// 设备所有者ID（Guid 格式）
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 设备型号（如"GT03Y"）
        /// </summary>
        public string macname { get; set; }

        /// <summary>
        /// 将 Unix 时间戳（毫秒）转换为 DateTime
        /// </summary>
        public DateTime GetGpsTime()
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(gps_time).DateTime;
        }

        /// <summary>
        /// 将速度字符串转换为数值（如 "0" → 0）
        /// </summary>
        public int GetSpeedValue()
        {
            return int.TryParse(speed, out int result) ? result : 0;
        }
    }
}
