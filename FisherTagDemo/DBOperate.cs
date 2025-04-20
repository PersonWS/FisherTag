using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar.Schedule;
using FisherTagDemo.Locator;
using FormSet;
using IOTDBHepler;

namespace FisherTagDemo
{
    public class DBOperate
    {
        static IOTDBHepler.DB_Main dB = new DB_Main();

        public DBOperate()
        {
            dB.ConnectSqlLite(@"database\FishDB.db", true);

        }

        public void InsertLocatorRecord(Locator_GetCurrentLocationBatchAck devInfo)
        {
            foreach (var item in devInfo.data)
            {
                for (int i = 0; i < item.deviceCount; i++)
                {
                    LocatorRecord record = new LocatorRecord(item, i);
                    string sql = $"INSERT INTO TB_LocatorRecord (userName, currentSysTemTime, currentHeartTime, longitude, latitude, gmsLevel, batteryPersents, batteryVoltage, status, Statenumber)" +
                        $"VALUES('{record.UserName}', '{record.CurrentSysTimeString}', '{record.CurrentHeartTimeString}', {record.Longitude}, {record.Latitude}, {record.GmsLevel}, {record.BatteryPersents}, {record.BatteryPersents}, '{record.Status}', '{record.Statenumber}');";
                    dB.ExecuteQueryStringWithNonQuery(sql, "InsertLocatorRecord", true);
                }
            }

        }

        public void InsertLocatorOnlineState(string userName, string dateTime, Int64 utcTime, string state)
        {
            try
            {
                string sql = $"INSERT INTO TB_LocatorOfflineRecord " +
    $"(userName, DateTimeString, DateTimeUTC, OnlineState) VALUES('{userName}', '{dateTime}', {utcTime}, '{state}');";
                dB.ExecuteQueryStringWithNonQuery(sql, "InsertLocatorRecord", true);
            }
            catch (Exception ex)
            {
                Log.LogRecorder_runLog.Error($"InsertLocatorOnlineState , ex:{ex.ToString()}");
            }


        }

    }

    public class LocatorRecord
    {
        private string userName;
        private long currentHeartTime;
        private long currentSysTime;
        private double longitude;
        private double latitude;
        private int gmsLevel;
        private int batteryPersents;
        private double batteryVoltage;
        private string status;
        private string statenumber;
        public string CurrentHeartTimeString { get { return TimeDataConvert.GPS_DateConvertUTC8ToDateTime(this.currentHeartTime).ToString("yyyy-MM-dd HH:mm:ss.fff"); } }
        public string CurrentSysTimeString { get { return TimeDataConvert.GPS_DateConvertUTC8ToDateTime(this.currentSysTime).ToString("yyyy-MM-dd HH:mm:ss.fff"); } }

        public double Longitude { get => longitude; set => longitude = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public long DateTime { get => currentHeartTime; set => currentHeartTime = value; }
        public int GmsLevel { get => gmsLevel; set => gmsLevel = value; }
        public int BatteryPersents { get => batteryPersents; set => batteryPersents = value; }
        public double BatteryVoltage { get => batteryVoltage; set => batteryVoltage = value; }
        public string UserName { get => userName; set => userName = value; }
        public long CurrentSysTime { get => currentSysTime; set => currentSysTime = value; }
        public string Status { get => status; set => status = value; }
        public string Statenumber { get => statenumber; set => statenumber = value; }

        public LocatorRecord(LocatorData devInfo, int seq)
        {
            Analysis(devInfo, seq);

        }

        private void Analysis(LocatorData devInfo, int seq)
        {
            try
            {
                List<object> item = devInfo.records[seq];
                userName = item[devInfo.key.user_name].ToString();
                currentHeartTime = Convert.ToInt64(item[devInfo.key.heart_time].ToString());
                currentSysTime = Convert.ToInt64(item[devInfo.key.server_time].ToString());

                statenumber = item[devInfo.key.statenumber].ToString();
                status = item[devInfo.key.status].ToString();
                //记录信号强度
                string[] stateSplits = statenumber.Split(',');
                gmsLevel = Convert.ToInt32(stateSplits[7]);
                longitude = Convert.ToDouble(item[devInfo.key.jingdu]);
                latitude = Convert.ToDouble(item[devInfo.key.weidu]);
                batteryPersents = Convert.ToInt32(stateSplits[4]);
                batteryVoltage = Convert.ToDouble(stateSplits[5]);
            }
            catch (Exception ex)
            {
                Log.LogRecorder_runLog.Error($"LocatorRecord_Analysis , ex:{ex.ToString()}");
            }
        }
        public LocatorRecord(long dateTime, double longitude, double latitude, int gmsLevel, int batteryPersents, double batteryVoltage)
        {
        }
    }

}
