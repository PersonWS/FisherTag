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
        public LocatoreHistoryLocation(string longi, string lati, Int64 utcTime)
        {
            this.lng = longi;
            this.lat = lati;
            this.utcTime = utcTime;
        }

        public LocatoreHistoryLocation(string longi, string lati, string timeString)
        {
            this.lng = longi;
            this.lat = lati;
            this.timeString = timeString;
        }

        public string lng;
        public string lat;
        /// <summary>
        /// UTC的累计时间，是用long表示
        /// </summary>
        public Int64 utcTime = -1;

        public string timeString = "";

        public string time
        {
            get
            {
                DateTime dt1;
                if (utcTime >-1)
                {
                    dt1 = new DateTime(0);
                }
                else if (!string.IsNullOrEmpty(timeString))
                {
                    return timeString;
                }
                else
                {
                    dt1 = TimeDataConvert.GPS_DateConvertUTC8ToDateTime(utcTime);

                }
                return TimeDataConvert.GetDateTimeString(dt1);
            }
        }
    }
}
