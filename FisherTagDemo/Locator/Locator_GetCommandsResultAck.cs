using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetCommandsResultAck : RestfulReturnMsgBase
    {
        public List<Locator_GetCommandsResultAck_Data>  data{ get; set; } 
    }

    internal class Locator_GetCommandsResultAck_Data
    {
        public string CmdNo;
        public bool Status;
        public string ResponseMsg;
        public string CmdResult;
    }
}
