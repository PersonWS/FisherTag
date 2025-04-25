using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar;
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
                    string sql = $"INSERT INTO TB_LocatorRecord (userName, currentSysTemTime, currentHeartTime, longitude, latitude,longiLati, gmsLevel, batteryPersents, batteryVoltage, status, Statenumber)" +
                        $"VALUES('{record.UserName}', '{record.CurrentSysTimeString}', '{record.CurrentHeartTimeString}', {record.Longitude}, {record.Latitude},'{record.Longitude},{record.Latitude}',{record.GmsLevel}, {record.BatteryPersents}, {record.BatteryPersents}, '{record.Status}', '{record.Statenumber}');";
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

        /// <summary>
        /// 查询信号点，根据信号的强度
        /// </summary>
        /// <param name="userName">船名</param>
        /// <param name="singnalThreshold"></param>
        /// <param name="signalCountMethod"></param>
        /// <param name="isShowLowlevel">true: 显示信号小于singnalThreshold这个值的数据，false:显示信号大于等于singnalThreshold这个值的数据</param>
        /// <returns></returns>
        public DataTable QuerySignalBySignalStrength(string userName, int singnalThreshold, string signalCountMethod, bool isShowLowlevel)
        {
            try
            {
                string gsmString = "";
                switch (signalCountMethod)
                {
                    case "MIN":
                        gsmString = "MIN (gmsLevel) as gmsLevel";
                        break;
                    case "MAX":
                        gsmString = "MAX (gmsLevel) as gmsLevel";
                        break;
                    default:
                        gsmString = "AVG (gmsLevel) as gmsLevel";
                        break;
                }
                string signalLevel = "";
                if (isShowLowlevel)
                {
                    signalLevel = $"and gmsLevel < '{singnalThreshold}'";
                }
                else
                {
                    signalLevel = $"and gmsLevel > '{singnalThreshold - 1}'";
                }

                string userNameString = "";
                if (!string.IsNullOrEmpty(userName) && userName.ToLower() != "all")
                {
                    userNameString = $"and userName= '{userName}'";
                }

                string sql = $"SELECT ID, userName, currentSysTemTime, currentHeartTime as timeStamp, longitude, latitude, {gsmString} ,batteryPersents, batteryVoltage, status, Statenumber, longiLati\r\nFROM TB_LocatorRecord  where 1=1 {userNameString}  {signalLevel} group by longiLati order by ID desc ";
                return dB.ExecuteQueryStringWithDataTableReturn(sql, true);
            }
            catch (Exception ex)
            {
                Log.LogRecorder_runLog.Error($"QueryGoodSignal , ex:{ex.ToString()}");
                return null;
            }


        }

        /// <summary>
        /// 查询船组
        /// </summary>
        /// <returns></returns>
        public DataTable QueryExistShip()
        {
            try
            {
                string sql = $"SELECT userName FROM TB_LocatorOfflineRecord group by userName";
                return dB.ExecuteQueryStringWithDataTableReturn(sql, true);
            }
            catch (Exception ex)
            {
                Log.LogRecorder_runLog.Error($"QueryExistShip , ex:{ex.ToString()}");
                return null;
            }
        }

        /// <summary>
        /// 查询船只离线记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable QueryOfflineRecord(string userName)
        {
            try
            {
                string sql = $"SELECT ID, userName, DateTimeString, DateTimeUTC, OnlineState FROM TB_LocatorOfflineRecord WHERE userName ='{userName}' ORDER by ID asc;";
                return dB.ExecuteQueryStringWithDataTableReturn(sql, true);
            }
            catch (Exception ex)
            {
                Log.LogRecorder_runLog.Error($"QueryOfflineRecord , ex:{ex.ToString()}");
                return null;
            }
        }
        /// <summary>
        /// 查询船只的定位数据，根据船只名称，起始结束数据
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable QueryShipLocatorPosition(string userName, string beginTime, string endTime)
        {
            try
            {
                string sql = $"SELECT ID, userName, currentSysTemTime, currentHeartTime as timeStamp, longitude, latitude,MAX (gmsLevel) as gmsLevel ,batteryPersents, batteryVoltage, status, Statenumber, longiLati  " +
                    $"FROM TB_LocatorRecord  where userName='{userName}' AND currentHeartTime>'{beginTime}' AND currentHeartTime<'{endTime}'   group by longiLati order by ID desc ";
                return dB.ExecuteQueryStringWithDataTableReturn(sql, true);
            }
            catch (Exception ex)
            {
                Log.LogRecorder_runLog.Error($"QueryShipLocatorPosition , ex:{ex.ToString()}");
                return null;
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
