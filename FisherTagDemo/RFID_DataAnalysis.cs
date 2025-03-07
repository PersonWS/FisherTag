using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo
{
    internal class RFID_DataAnalysis
    {
        byte[] _data;

        LogHelper.ILogEntity _log = LogHelper.EasyLogger.GetDefaultLoggerInstance();
        /// <summary>
        /// 1-8  大端 RFID 设备id
        /// </summary>
        public Int32 RfidDeviceID = 0;
        /// <summary>
        /// 时间戳  9-20
        /// </summary>
        public string TimeStamp = "";

        /// <summary>
        /// RFID芯片序列号 21-30
        /// </summary>
        public string RfidTagSerialNum = "";
        /// <summary>
        /// 标志位大写字符电量正常，标志位小写字母低电量   31
        /// A/a：定位功能，标签数据1里表示标签采集到的低频定位地址码，
        ///B/b：拆除报警功能
        ///S/s：标签端口功能，根据数据1值的定义， S00：标签应答成功 S01：按钮报警 S02：加速度报警
        ///H/h：心率功能，标标签数据1里表示标签采集到的心率、数据2表示血氧值。
        ///T/t：温度功能，标签数据1表示体温整数值、数据2表示体温小数值，数据3表示环境温度。
        /// </summary>
        public string RfidTagFunction = "";

        /// <summary>
        /// 标签数据1 32-33
        /// </summary>
        public byte RfidTagData1 = 0;
        /// <summary>
        /// 标签数据2 34-35
        /// </summary>
        public byte RfidTagData2 = 0;
        /// <summary>
        /// 标签数据3 36-37
        /// </summary>
        public byte RfidTagData3 = 0;
        /// <summary>
        /// 校验码
        /// </summary>
        public byte CheckSumNumber = 0;
        /// <summary>
        /// 标签信号强度
        /// </summary>
        public string TagSignalStrength { get => RfidTagData3.ToString("X").PadLeft(2,'0')[1].ToString(); }
        /// <summary>
        /// 标签通道号
        /// </summary>
        public string TagChannel { get => RfidTagData3.ToString("X")[0].ToString(); }

        public RFID_DataAnalysis()
        { }

        public RFID_DataAnalysis(byte[] data)
        {
            this._data = data;
        }

        public bool Analysis()
        {
            if (!CheckSumAll())
            {
                return false;
            }
            try
            {
                //分解设备id
                this.RfidDeviceID = Convert.ToInt32(Encoding.UTF8.GetString(this._data.Skip(1).Take(8).ToArray()), 16);
                //分解时间戳
                string temp1 = Encoding.UTF8.GetString(this._data.Skip(9).Take(12).ToArray());
                this.TimeStamp = $"20{temp1[0]}{temp1[1]}-{temp1[2]}{temp1[3]}-{temp1[4]}{temp1[5]} {temp1[6]}{temp1[7]}:{temp1[8]}{temp1[9]}:{temp1[10]}{temp1[11]}";
                this.RfidTagSerialNum = Encoding.UTF8.GetString(this._data.Skip(21).Take(10).ToArray());
                this.RfidTagFunction= Encoding.UTF8.GetString(this._data.Skip(31).Take(1).ToArray());
                this.RfidTagData1 = Convert.ToByte(Encoding.UTF8.GetString(this._data.Skip(32).Take(2).ToArray()), 16);
                this.RfidTagData1 = Convert.ToByte(Encoding.UTF8.GetString(this._data.Skip(34).Take(2).ToArray()), 16);
                this.RfidTagData1 = Convert.ToByte(Encoding.UTF8.GetString(this._data.Skip(36).Take(2).ToArray()), 16);
                return true;
            }
            catch (Exception ex)
            {
                _log.Error($"RFID 数据解析出现异常 ex:{ex.ToString()}");
                return false;
            }


        }


        private bool CheckSumAll()
        {
            if (_data == null || _data.Length == 0)
            {
                _log.Error("RFID 获得的数据长度为0");
                return false;
            }
            if ( _data.Length <=40)
            {
                _log.Error($"RFID 获得的数据长度异常，长度应为40，实际长度为:{_data.Length}");
                return false;
            }
            this.CheckSumNumber = Convert.ToByte(Encoding.UTF8.GetString(this._data.Skip(38).Take(2).ToArray()), 16);
            int check = 0;
            for (int i = 0; i < 38; i++)
            {
                check += this._data[i];
            }
            check += this.CheckSumNumber;

            if (check.ToString("X")[check.ToString("X").Length - 1] != '0')
            {
                _log.Error($"RFID CheckSum:{check.ToString("X")} 校验失败，最后一位不为0");
                return false;
            }
            else
            {
                _log.Debug($"RFID CheckSum:{check}");
                return true;
            }
        }



    }
}
