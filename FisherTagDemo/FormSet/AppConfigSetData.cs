using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace FormSet
{
    static class AppConfigSetData
    {

        static bool isShowLockLog = false;
        static bool isShowBusinessLog = false;
        static bool isShowRunLog = false;
        /// <summary>
        /// 显示锁定和解锁对象的日志
        /// </summary>
        public static bool IsShowLockLog
        {
            get { return AppConfigSetData.isShowLockLog; }
            set { AppConfigSetData.isShowLockLog = value; }
        }


        /// <summary>
        /// 显示锁定和解锁对象的日志
        /// </summary>
        public static bool IsShowBusinessLog
        {
            get { return AppConfigSetData.isShowBusinessLog; }
            set { AppConfigSetData.isShowBusinessLog = value; }
        }


        /// <summary>
        /// 显示锁定和解锁对象的日志
        /// </summary>
        public static bool IsShowRunLog
        {
            get { return AppConfigSetData.isShowRunLog; }
            set { AppConfigSetData.isShowRunLog = value; }
        }

        /// <summary>
        /// 向配置文件写入数据
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="valueToWrite"></param>
        /// <returns></returns>
        public static bool WriteDataToConfig(string keyName, string valueToWrite)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            try
            {
                if (config.AppSettings.Settings.AllKeys.Contains(keyName))
                {
                    config.AppSettings.Settings[keyName].Value = valueToWrite;
                }
                else
                {
                    config.AppSettings.Settings.Add(keyName, valueToWrite);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        static AppConfigSetData()
        {
            
            if (ConfigurationManager.AppSettings["isShowLockLog"] != null)
            {
                isShowLockLog = ConfigurationManager.AppSettings["isShowLockLog"].ToString().ToLower()=="true"?true:false;
            }
            if (ConfigurationManager.AppSettings["isShowRunLog"] != null)
            {
                isShowRunLog = ConfigurationManager.AppSettings["isShowRunLog"].ToString().ToLower() == "true" ? true : false;
            }
            if (ConfigurationManager.AppSettings["isShowBusinessLog"] != null)
            {
                isShowBusinessLog = ConfigurationManager.AppSettings["isShowBusinessLog"].ToString().ToLower() == "true" ? true : false;
            }

        }



    }
}
