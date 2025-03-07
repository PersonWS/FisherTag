using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FisherTagDemo
{
    internal class HttpServer
    {

        private HttpListener listener;

        public HttpServer(string url)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url);
        }

        public async Task StartAsync()
        {
            listener.Start();
            Console.WriteLine("HTTP server started. Listening for requests...");

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                _ = HandleRequestAsync(context); // 异步处理请求
            }
        }

        private async Task HandleRequestAsync(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            // 获取请求路径
            string path = request.Url.LocalPath.TrimStart('/');
            if (string.IsNullOrEmpty(path))
            {
                path = "baidu_map.html"; // 默认加载 baidu_map.html
            }

            // 读取文件内容
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            if (File.Exists(filePath))
            {
                byte[] buffer = File.ReadAllBytes(filePath);
                response.ContentLength64 = buffer.Length;
                response.ContentType = GetMimeType(filePath);
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
                string notFoundMessage = "404 - File not found";
                byte[] buffer = Encoding.UTF8.GetBytes(notFoundMessage);
                response.ContentLength64 = buffer.Length;
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            }

            response.OutputStream.Close();
        }

        private string GetMimeType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            switch (extension)
            {
                case ".html":
                    return "text/html";
                case ".js":
                    return "application/javascript";
                case ".css":
                    return "text/css";
                default:
                    return "application/octet-stream";
            }
        }

        public void Stop()
        {
            listener.Stop();
            listener.Close();
        }
    }
}
