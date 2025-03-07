using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FisherTagDemo
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += ShowThreadException;
            Application.Run(new Form1());
        }

        static LogHelper.ILogEntity  _log = LogHelper.EasyLogger.GetDefaultLoggerInstance();
        private static void ShowThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            _log.Error($"意料之外的异常! , ex ;{e.Exception.StackTrace}");
            ThreadExceptionDialog threadExceptionDialog = new ThreadExceptionDialog(e.Exception);
            threadExceptionDialog.ShowDialog();
            if (threadExceptionDialog.DialogResult == DialogResult.Cancel)
            {
                _log.Error($"意料之外的异常! , 用户选择继续！");
                threadExceptionDialog.Close();
            }
            else if (threadExceptionDialog.DialogResult == DialogResult.Abort)
            {
                _log.Error($"意料之外的异常! , 用户选择退出！");
                Application.Exit();
            }
            //BaseFrmControl.ShowErrorMessageBox(threadExceptionDialog, e.Exception.StackTrace.ToString());
        }


    }
}
