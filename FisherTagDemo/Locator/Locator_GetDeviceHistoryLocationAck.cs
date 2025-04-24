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

        public LocatoreHistoryLocation(string longi, string lati, string timeString, string gsmString)
        {
            this.lng = longi;
            this.lat = lati;
            this.timeString = timeString;
            this.gsmString = gsmString;
        }

        public string lng;
        public string lat;
        /// <summary>
        /// UTC的累计时间，是用long表示
        /// </summary>
        public Int64 utcTime = -1;

        public string timeString = "";

        public string gsmString = "";

        public string time
        {
            get
            {
                if (utcTime > -1)
                {
                    return TimeDataConvert.GetDateTimeString(TimeDataConvert.GPS_DateConvertUTC8ToDateTime(utcTime));
                }
                else if (!string.IsNullOrEmpty(timeString))
                {
                    return timeString;
                }
                return TimeDataConvert.GetDateTimeString(TimeDataConvert.GPS_DateConvertUTC8ToDateTime(0));
            }
        }






    }
}
