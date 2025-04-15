using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    public class Locator_GetCurrentLocationBatchReq
    {
        /// <summary>
        /// 生成使用get方式获取最新位置（所有设备）
        /// </summary>
        /// <param name="id">单位id</param>
        /// <param name="mds"></param>
        /// <returns></returns>
        public static string GenerateGetAppendMsg(string id, string mds)
        {
            return $"/GetDate?method=getDeviceListByCustomId&mapType=BAIDU&id={id}&mds={mds}";
        }


    }
}
