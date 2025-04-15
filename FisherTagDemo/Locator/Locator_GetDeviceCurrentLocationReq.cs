using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetDeviceCurrentLocationReq
    {
        /// <summary>
        /// 生成使用get方式获取最新位置（单个设备）
        /// </summary>
        /// <returns></returns>
        public static string GenerateGetAppendMsg(string dev_id, string mds)
        {
            return $"/GetDate?method=getUserAndGpsInfoByIDsUtcNew&mapType=BAIDU&option=cn&user_id={dev_id}&mds={mds}";
        }

    }
}
