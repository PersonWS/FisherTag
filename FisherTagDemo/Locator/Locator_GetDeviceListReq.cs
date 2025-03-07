using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetDeviceListReq
    {
        public static string GenerateGetAppendMsg(string id, string mds)
        {
            return $"/GetDate?method=getDeviceList&id={id}&mds={mds}";
        }
    }
}
