using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo
{
    internal class ReadTextSimple
    {
        static LogHelper.ILogEntity _log = LogHelper.EasyLogger.GetDefaultLoggerInstance();
        public static string ReadText(string filePath)
        {
            string jsonString = "";
            try
            {
                // 1. 读取 TXT 文件内容
                 jsonString = File.ReadAllText(filePath,Encoding.UTF8);
                _log.Info($"文件 {filePath} ,读取到到的内容:{jsonString}");
            }
            catch (FileNotFoundException)
            {
                _log.Error($"错误: 文件 {filePath} 不存在！");
            }
            catch (JsonException ex)
            {
                _log.Error($"JSON 解析错误: {ex.Message}");
            }
            catch (Exception ex)
            {
                _log.Error($"读取filePath：{filePath}发生未知错误: {ex.Message}");
            }
            return jsonString;
        }


    }
}
