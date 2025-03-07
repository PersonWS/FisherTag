using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace FormSet
{
    internal class SetFormStyle
    {
        internal static void SetThemeColor(DevComponents.DotNetBar.Office2007Form frm)
        {
            SetThemeColor(frm, eStyle.Office2010Silver);
            //frm.EnableGlass = false;
            //StyleManager.Style = eStyle.Office2010Silver;
            ////StyleManager.Style = eStyle.Windows7Blue;
            //// 应用主题颜色
            //StyleManager.UpdateAmbientColors(frm);
        }

        internal static void SetThemeColor(DevComponents.DotNetBar.Office2007Form frm , eStyle style)
        {
            try
            {
                frm.EnableGlass = false;
                StyleManager.Style = style; 
                // 应用主题颜色
                StyleManager.UpdateAmbientColors(frm);
            }
            catch (Exception ex)
            {
                LogHelper.EasyLogger.GetDefaultLoggerInstance().Error($"SetThemeColor 错误 ex:{ex.ToString()}");
            }

        }

        internal static void SetThemeColor(Form frm)
        {
            StyleManager.Style = eStyle.Office2010Silver;
            // 应用主题颜色
            StyleManager.UpdateAmbientColors(frm);
        }
    }
}
