using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_SendCommandsReq
    {
        public static string GenerateGetAppendMsg(string macid, string mds, string cmd, string param = "")
        {
            string appendParam = string.IsNullOrEmpty(param) ? "" : $"&param={param}";
            return $"/GetDate?method=SendCommands&macid={macid}&mds={mds}&cmd={cmd}{appendParam}";
        }
    }
}
