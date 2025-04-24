using FisherTagDemo.Locator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo
{
    public class CommonResource
    {
        /// <summary>
        /// 定位器登录信息
        /// </summary>
        private LocatorServerInterope _locatorServer;
        /// <summary>
        /// 定位器企业的登录信息
        /// </summary>
        public LocatorServerInterope LocatorServer { get => _locatorServer; set => _locatorServer = value; }


        /// <summary>
        /// 定位器的设备信息
        /// </summary>
        Locator_GetDeviceListAck _locatorDeviceInfo;

        public Locator_GetDeviceListAck LocatorDeviceInfo { get => _locatorDeviceInfo; set => _locatorDeviceInfo = value; }
        public DBOperate DBOperate { get => _dBOperate; set => _dBOperate = value; }
        /// <summary>
        /// 云服务要求的MDS
        /// </summary>
        public DateTime? MdsDataTime { get => _mdsDataTime; set => _mdsDataTime = value; }


        DBOperate _dBOperate = new DBOperate();

        DateTime? _mdsDataTime = null;


        /// <summary>
        /// 登录信息
        /// </summary>
        LocatorLogIn _locatorLogIn;
        /// <summary>
        /// 登录信息
        /// </summary>
        public  LocatorLogIn LocatorLogIn { get => _locatorLogIn; set => _locatorLogIn = value; }
        /// <summary>
        /// 登录服务器的用户名
        /// </summary>
        private string _usrName;
        /// <summary>
        /// 登录服务器的密码
        /// </summary>
        private string _pwd;

        public CommonResource(string usrName, string pwd)
        {
            this._usrName = usrName;
            this._pwd = pwd;
        }

        public bool GetMds(out string message, bool isTraceLog = false)
        {
            message = "";
            if (this.LocatorServer == null)
            {
                message = $"获取定位器服务mds失败,请先获取定位器列表";
                return false;
            }
            if (MdsDataTime != null && ((DateTime.Now - MdsDataTime).Value.TotalMinutes < 19 && LocatorLogIn != null))
            {
                return true;
            }
            message = "mds过期, 获取远程mds";
            string mdsRet = this.LocatorServer.GetMessageByRestful(Locator.LocatorLogIn.GetLogInAppendMsg(_usrName, _pwd), isTraceLog);
            if (string.IsNullOrEmpty(mdsRet))
            {
                //BaseFrmControl.ShowErrorMessageBox(this, $"获取定位器服务mds失败!");
                message = $"获取定位器服务mds失败!";
                return false;
            }

            _locatorLogIn = Newtonsoft.Json.JsonConvert.DeserializeObject<LocatorLogIn>(mdsRet) as LocatorLogIn;
            if (_locatorLogIn == null)
            {
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器云端服务mds报文异常!,ret:{mdsRet}");
                message = $"定位器云端服务mds报文异常!,ret:{mdsRet}";
                return false;
            }
            if (_locatorLogIn.success.ToLower() != "true")
            {
                //BaseFrmControl.ShowErrorMessageBox(this, $"定位器云端服务mds获取失败,ret:{mdsRet}");
                message = $"定位器云端服务mds获取失败,ret:{mdsRet}";
                return false;
            }
            message = $"mds获取成功,mds:{_locatorLogIn.mds}";
            MdsDataTime = DateTime.Now;
            return true;
        }

    }
}
