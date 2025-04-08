using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_SendCommandsAck : RestfulReturnMsgBase
    {
       public  List<Locator_SendCommandsAck_data> Data;
    }

    internal class Locator_SendCommandsAck_data
    {
        /// <summary>
        ///回执编号 
        /// </summary>
        public string CmdNo;//回执编号
        /// <summary>
        /// 返回的信息
        /// </summary>
        public string ReturnMsg;
    }
}
