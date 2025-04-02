using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetLocalAlarmInfoUtcReq
    {
        ///// <summary>
        ///// 生成使用get方式获取设备报警信息
        ///// http://openapi.18gps.net//GetDataService.aspx
        ///// </summary>
        ///// <returns></returns>
        ///// 



        /// <summary>
        /// 生成使用get方式获取设备报警信息
        /// </summary>
        /// <param name="school_id">school_id可以是两种登录类型的其中一个。单位登录能获取最大报警数量为150条，设备登录则是60条，数据来自缓存。</param>
        /// <param name="mds"></param>
        /// <param name="maxTime">第一次访问接口，为max_time赋一个默认的值，比如昨天中午12点，那么获取到的将是max_time（昨天中午12点）到现在之间的报警数据。</param>
        /// <returns></returns>
        public static string GenerateGetAppendMsg(string school_id, string mds, string maxTime)
        {
            return $"/GetDate?method=queryLocalAlarmInfoUtc&type=custom&school_id={school_id}&mds={mds}&max_time={maxTime}&timestamp={maxTime}";
        }
    }
}
