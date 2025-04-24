using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    public class LocatorLogIn :RestfulReturnMsgBase
    {
        public string id { get; set; } // id

        public string mds { get; set; } // mds
        public string LoginType { get; set; } // LoginType
        public int grade { get; set; } // grade

        public string userName { get; set; } // userName
        public string PoiAddress { get; set; } // PoiAddress
        public string SetPositionType { get; set; } // SetPositionType

        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string GetLogInAppendMsg(string usrName ,string pwd)
        {
            return $"/loginSystem?LoginName={usrName}&LoginPassword={pwd}&LoginType=ENTERPRISE&language=cn";
        }
    }
}
