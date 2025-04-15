using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo
{
    public class RestfulReturnMsgBase
    {
        public string success { get; set; } // success
        public string msg { get; set; } // msg
        public string errorCode { get; set; } // errorCode
        public string errorDescribe { get; set; } // errorCode
    }
}
