using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo
{
    public class TimeDataConvert
    {
        public static DateTime GPS_DateConvertUTC8ToDateTime(long gpsTimeStamp)
        {
            // 将Unix时间戳转换为DateTimeOffset（UTC时间）
            DateTimeOffset utcTime = DateTimeOffset.FromUnixTimeMilliseconds(gpsTimeStamp);

            // 将UTC时间转换为北京时间（UTC+8）
            DateTime beijingTime = utcTime.ToLocalTime().AddHours(8).UtcDateTime;

            // 或者，如果你知道系统时区是UTC+8，也可以直接使用：
            // DateTime beijingTime = utcTime.UtcDateTime.AddHours(8);

            return beijingTime;
        }

        public static string GetDateTimeString(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public static long GPS_DateConvertDateTimeToUTC8(DateTime dateTime)
        {

            return ((DateTimeOffset)dateTime.ToUniversalTime().AddHours(8)).ToUnixTimeMilliseconds();
        }

    }
}
