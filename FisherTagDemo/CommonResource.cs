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
       private  LocatorServerInterope _locatorServer;
        /// <summary>
        /// 定位器企业的登录信息
        /// </summary>
        public LocatorServerInterope LocatorServer { get => _locatorServer; set => _locatorServer = value; }


        /// <summary>
        /// 定位器的设备信息
        /// </summary>
        Locator_GetDeviceListAck locatorDeviceInfo;

        public Locator_GetDeviceListAck LocatorDeviceInfo { get => locatorDeviceInfo; set => locatorDeviceInfo = value; }
        public DBOperate DBOperate { get => _dBOperate; set => _dBOperate = value; }

        DBOperate _dBOperate = new DBOperate();

    }
}
