using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetDeviceDataDetailReq
    {
        /// <summary>
        /// 生成使用get方式查询设备信息的附加信息
        /// </summary>
        /// <returns></returns>
        public static string GenerateGetAppendMsg(string dev_id, string mds)
        {
            return $"/GetDate?method=loadUser&user_id={dev_id}&mds={mds}";
        }

    }
}
