using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetDeviceHistoryLocationAck : RestfulReturnMsgBase
    {

        public List<Locator_GetDeviceHistoryLocationAckPoint> data;
    }


    internal class Locator_GetDeviceHistoryLocationAckPoint
    {
        public string point;
    }

    internal class LocatoreHistoryLocation
    {
        public LocatoreHistoryLocation(string longi,string lati,string utcStr) 
        { 
            this.lng = longi;
            this.lat = lati;
            this.utcTimeStr = utcStr;
        }

        public string lng;
        public string lat;
        /// <summary>
        /// UTC的累计时间，是用long表示
        /// </summary>
        public string utcTimeStr;
        public string time
        {
            get
            {
                DateTime dt1;
                if (utcTimeStr == null)
                {
                    dt1= new DateTime(0);
                }
                else
                {
                    Int64 t = 0;
                    if (Int64.TryParse(utcTimeStr, out t))
                    {
                        dt1 = TimeDataConvert.GPS_DateConvertUTC8ToDateTime(t);
                    }
                    else
                    {
                        dt1 = new DateTime(0);
                    }
                }
                return TimeDataConvert.GetDateTimeString(dt1);
            }
        }
    }
}
