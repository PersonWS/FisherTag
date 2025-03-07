using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetDeviceHistoryLocationReq
    {
        /// <summary>
        /// 生成使用get方式获取历史轨迹（单个设备）
        /// </summary>
        /// <param name="dev_id">设备IMEI</param>
        /// <param name="mds"></param>
        /// <param name="startTime">查询的UTC起始时间 毫秒</param>
        /// <param name="endTime">查询的UTC结束时间 毫秒</param>
        /// <param name="playLBS"></param>
        /// <returns></returns>
        public static string GenerateGetAppendMsg(string dev_id, string mds, string startTime, string endTime, bool playLBS = true)
        {
            return $"/GetDate?method=getHistoryMByMUtcNew&mapType=BAIDU&macid={dev_id}&mds={mds}&from={startTime}&to={endTime}&playLBS={playLBS}";
        }
    }
}
