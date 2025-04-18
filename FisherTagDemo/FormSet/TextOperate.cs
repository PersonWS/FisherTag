using System;
using System.IO;
using System.Text;
using System.Threading;

namespace FormSet
{
    internal class TextOperate
    {
        private static readonly object _fileLock = new object();
        private static readonly Encoding FileEncoding = Encoding.UTF8;

        public static void WriteToFile(string fileName, object data)
        {
            string content = data?.ToString() ?? string.Empty;
            string directoryPath = "TraceSignal"; // 目录名
            string filePath = Path.Combine(directoryPath, $"{fileName}.txt"); // 完整文件路径

            lock (_fileLock)
            {
                try
                {
                    // 1. 检查目录是否存在，不存在则创建
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                        Console.WriteLine($"目录 {directoryPath} 已创建");
                    }

                    // 2. 安全写入文件
                    using (var fileStream = new FileStream(
                        filePath,
                        FileMode.Append,
                        FileAccess.Write,
                        FileShare.None))
                    using (var writer = new StreamWriter(fileStream, FileEncoding))
                    {
                        writer.WriteLine($"[{DateTime.Now:HH:mm:ss}] {content}");
                        Console.WriteLine($"线程 {Thread.CurrentThread.ManagedThreadId} 写入成功 -> {filePath}");
                    }
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"文件操作失败（请检查权限/路径）: {ioEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"未知错误: {ex.Message}");
                }
            }
        }
    }
}