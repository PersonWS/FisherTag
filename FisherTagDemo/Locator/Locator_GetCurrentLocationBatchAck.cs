using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    public class Locator_GetCurrentLocationBatchAck : RestfulReturnMsgBase
    {
        public List< LocatorData > data { get; set; }

    }

    public class LocatorData
    {
        public SignalKeyName key { get; set; }
        /// <summary>
        /// SignalKeyName 对应的键值
        /// </summary>
        public List<List<object>> records { get; set; }
        public List<object> groups { get; set; }
        public int followCount { get; set; }
        public int deviceCount { get; set; }
    }

    public class SignalKeyName
    {
        public int sys_time { get; set; }
        public int user_name { get; set; }
        public int jingdu { get; set; }
        public int weidu { get; set; }
        public int ljingdu { get; set; }
        public int lweidu { get; set; }
        public int datetime { get; set; }
        public int heart_time { get; set; }
        public int su { get; set; }
        public int status { get; set; }
        public int hangxiang { get; set; }
        public int sim_id { get; set; }
        public int user_id { get; set; }
        public int sale_type { get; set; }
        public int iconType { get; set; }
        public int server_time { get; set; }
        public int product_type { get; set; }
        public int expire_date { get; set; }
        public int group_id { get; set; }
        public int statenumber { get; set; }
        public int electric { get; set; }
        public int describe { get; set; }
        public int sim { get; set; }
        public int precision { get; set; }
        public int isFollow { get; set; }
    }
}
