using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    /// <summary>
    /// 定位器当前的模式
    /// </summary>
    public class Locator_ModeEntity
    {


        private static readonly string ModeCommandHeadString = "MODE";
        private static readonly string ModeCommandTailString = "%23";



        /// <summary>
        /// 工作模式
        /// </summary>
        public Locator_ModeEntity_WorkModeEnum WorkModeEnum01 { get; set; }
        /// <summary>
        /// 汇报间隔 单位：秒
        /// </summary>
        public int ReportInterval02 { get; set; }
        /// <summary>
        /// GPS 1:开启  0：关闭
        /// </summary>
        public int GPS03 { get; set; }
        public int WIFI04 { get; set; }
        /// <summary>
        /// 基站定位
        /// </summary>
        public int LBS05 { get; set; }
        public int GPRS06 { get; set; }

        public Locator_ModeEntity()
        {
            this.WorkModeEnum01 = Locator_ModeEntity_WorkModeEnum.intelligent;
            this.ReportInterval02 = 300;
            this.GPS03 = 1;
            this.WIFI04 = 0;
            this.LBS05 = 1;
            this.GPRS06 = 1;
        }
        /// <summary>
        /// 使用mode标准字符串来初始化实例 MODE,x,y,A,B,C,D#
        /// </summary>
        /// <param name="s"></param>
        public Locator_ModeEntity(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return;
            }
            string[] processMessage = s.Substring(0, s.Length - 1).Split(',');
            if (processMessage.Length < 7)
            {
                return;
            }
            try
            {
                Locator_ModeEntity_WorkModeEnum aaaa;
                Enum.TryParse<Locator_ModeEntity_WorkModeEnum>(processMessage[1], out aaaa);
                this.WorkModeEnum01 = aaaa;
                this.ReportInterval02 = Convert.ToInt32(processMessage[2]);
                this.GPS03 = Convert.ToInt32(processMessage[3]);
                this.WIFI04 = Convert.ToInt32(processMessage[4]);
                this.LBS05 = Convert.ToInt32(processMessage[5]);
                this.GPRS06 = Convert.ToInt32(processMessage[6]);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public static string GenerateGetModeCommand()
        {
            return $"{ModeCommandHeadString}{ModeCommandTailString}";
        }
        public string GenerateSetModeCommand()
        { return GenerateSetModeCommand(this); }
        public static string GenerateSetModeCommand(Locator_ModeEntity entity)
        { return GenerateSetModeCommand(entity.WorkModeEnum01, entity.ReportInterval02, entity.GPS03, entity.WIFI04, entity.LBS05, entity.GPRS06); }
        public static string GenerateSetModeCommand(Locator_ModeEntity_WorkModeEnum workMode, int ReportInterval, int gps, int wifi, int lbs, int gprs)
        {
            gps = (gps > 0) ? 1 : 0;
            wifi = (wifi > 0) ? 1 : 0;
            lbs = (lbs > 0) ? 1 : 0;
            gprs = (gprs > 0) ? 1 : 0;
            return $"{ModeCommandHeadString},{workMode},{ReportInterval},{gps},{wifi},{lbs},{gprs}{ModeCommandTailString}";
        }
    }
    /// <summary>
    /// 工作模式
    /// </summary>
    public enum Locator_ModeEntity_WorkModeEnum : int
    {
        /// <summary>
        /// 定时模式：按设置的时间间隔定时上报位置，上报位置之后自动进入休眠（维持心跳上报）。
        /// </summary>
        timing = 1,
        /// <summary>
        /// 智能模式：根据G-Sensor的判断，设备在运动时，按设置的时间间隔定时上报位置；设备静止超过三分钟，自动进入休眠（维持心跳上报）
        /// </summary>
        intelligent = 2,
        /// <summary>
        /// 省电模式(点名模式)：按照设置间隔定时上报，非定时时间离线（无心跳数据）
        /// </summary>
        powerSave = 6

    }
}
