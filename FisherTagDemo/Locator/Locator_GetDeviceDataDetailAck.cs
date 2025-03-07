using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo.Locator
{
    internal class Locator_GetDeviceDataDetailAck : RestfulReturnMsgBase
    {
        public List<Locator_GetDeviceDataDetailAck_Data> data;
    }

    internal class Locator_GetDeviceDataDetailAck_Data
    {
        public string user_name;             //设备名称
        public DateTime sys_time;  //最近定位时间
        public DateTime datetime;   //最近位置更新时间
        public DateTime heart_time;  //最近信号时间
        public double sudu;                       //超速设置值
        public string status;                     //无
        public DateTime create_time;         //平台到期时间
        public string remark;                      //备注
        public string use_time;         //激活时间
        public string factory_date;       //出厂时间
        public string tel;                        //电话
        public string sex;                //车牌号
        public string sim_id;          //设备号
        public string phone;          //sim卡
        public string user_id;
        public int grade;                     //无
        public int sale_type;                //无
        public string service_flag;                  //无
        public string product_type;          //型号
        public string iconType;                  //图标序号
        public string out_time;           //用户到期时间
        public double jingdu;        //经度
        public double weidu;         //纬度
        public string su;                     //iccid
        public string owner;                    //联系人
        public string jingwei;
        public int alarm;                         //离线报警开关，0关
        public string deviceRemark;                //服务商描述
        public string alarmFuel;                     //无
        public string fuelPerHKM;         //无
        public string fuelSize;               //无
        public string maxFuelV;             //无
        public string minFuelV;             //无
        public string macVersion;           //设备软件版本号
        public string FuelTotalHeight;        //无  
        public string carColor;          //无
        public string VideoConfig;         //视频地址
        public string HighTempAlarm;     //高温报警值
        public string LowTempAlarm;       //低温报警值
        public string VendorCode;            //厂商编码
        public string OwnerId;              //业主ID
        public int PColour;              //车牌颜色
        public string TerminalType;          //终端类型
        public string DeviceCode;            //设备编码
    }
}
