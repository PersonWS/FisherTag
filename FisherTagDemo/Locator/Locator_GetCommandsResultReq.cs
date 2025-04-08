using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetCommandsResultReq
    {
        public static string GenerateGetAppendMsg(string macid, string mds, string cmdNo)
        {
            return $"/GetDate?method=GetCommandResults&macid={macid}&mds={mds}&cmdNo={cmdNo}";
        }
    }
}
