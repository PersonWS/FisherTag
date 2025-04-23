using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocketHelper.USocket;


namespace FisherTagDemo.Locator
{
    public class LocatorServerInterope
    {


        SocketHelper.USocket.HttpWebClient_Restful_doNet _restfulEntity;
        LogHelper.ILogEntity _log = LogHelper.EasyLogger.GetDefaultLoggerInstance();
        public LocatorServerInterope(string url, int timeOut, string authType = "NONE", string authParameters = "", string devName = "")
        {
            _restfulEntity = new SocketHelper.USocket.HttpWebClient_Restful_doNet(url, timeOut, authType, authParameters);
            _restfulEntity.KeepAlive = true;
        }


        internal string PostMessageByRestful(string message, bool traceLog = false)
        {
            bool isSendSucess = false;
            Int32 count = 0;
            do
            {
                count++;
                string jsonStr = JsonConvert.SerializeObject(message, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
                _log.Debug($"ThirdServer_Restful，PostTo:{_restfulEntity.GetDestinationURI()},message:{jsonStr} ");
                Task<string> task = _restfulEntity.PostMessage(jsonStr);
                task.Wait();
                string result = task.Result;
                _log.Debug($"ThirdServer_Restful，Receive:{_restfulEntity.GetDestinationURI()},message:{result} ");
                if (string.IsNullOrEmpty(task.Result))
                {
                    isSendSucess = true;
                    return task.Result;
                }
            } while ((!isSendSucess && count < 4));
            return "";
        }

        internal string GetMessageByRestful(string appendMessage, bool traceLog = false)
        {

            Int32 count = 0;
            string message = $"{_restfulEntity.GetDestinationURI()}{appendMessage}";
            _log.Debug($"ThirdServer_Restful，get:{message} ");
            return _restfulEntity.GetMessage(appendMessage, traceLog);

        }

    }
}
