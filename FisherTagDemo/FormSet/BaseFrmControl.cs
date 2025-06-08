using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Drawing;

namespace FormSet
{
    public static class BaseFrmControl
    {
      public static  Color _color_ON = Color.Lime;
        public static Color _color_OFF = Color.DimGray;
        public static Color _color_ERROR = Color.Red;
        public static Color _color_Warn = Color.Yellow;
        public static int TextBoxMaxLength = 1048576;
        static BaseFrmControl()
        {
            MessageBoxEx.EnableGlass = false;
            MessageBoxEx.ButtonsDividerVisible = true;
            MessageBoxEx.DefaultStartPosition = FormStartPosition.CenterParent;

        }
        public static void ShowDefalutMessageBox(Form f, string text)
        {
            MessageBoxEx.MessageBoxTextColor = Color.Blue;
            f.Invoke(new Action(() =>
            {
                MessageBoxEx.Show(f, text, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }));

            return;
        }

        public static DialogResult ShowtMessageBoxWithReturn(Form f, string text)
        {
            MessageBoxEx.MessageBoxTextColor = Color.Black;
            DialogResult dr = DialogResult.OK;
            f.Invoke(new Action(() =>
            {
                dr = MessageBoxEx.Show(f,text, "询问信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }));

            return dr;

        }

        public static void ShowErrorMessageBox(Form f, string text)
        {
            MessageBoxEx.MessageBoxTextColor = Color.Red;
            f.Invoke(new Action(() =>
            {
                MessageBoxEx.Show(f,text, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }));
            return;
        }

        public static void ShowErrorMessageBox(Form f, string text ,Exception ex)
        {
            MessageBoxEx.MessageBoxTextColor = Color.Red;
            f.Invoke(new Action(() =>
            {
                MessageBoxEx.Show(f, $"{text} ex:{ex.ToString()}", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }));
            return;
        }

        /// <summary>
        /// 只允许数字输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void KeyPressWithDigital(Form f, object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                ShowDefalutMessageBox(f, "只能输入数字");
            }
        }

        public static void AddToolStripMenuItemForListView(Form f)
        {
            System.Windows.Forms.ToolStripMenuItem menu_copy = new ToolStripMenuItem();
            menu_copy.MouseUp += new MouseEventHandler((sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
                    switch (menuItem?.Text)
                    {
                        case "Copy":
                            ListView.SelectedListViewItemCollection selected = ((ListView)sender).SelectedItems;
                            StringBuilder sb = new StringBuilder();
                            foreach (ListViewItem item in selected)
                            {
                                sb.Append(item.Text.PadRight(10));
                                sb.Append(item.SubItems[1].Text);
                                //sb.Append("\r\n");
                            }
                            Clipboard.SetText(sb.ToString());
                            break;
                        default:
                            break;
                    }
                }
            });

        }

        public static void AddToolStripMenuItemForDataTable(Form f)
        {
            System.Windows.Forms.ToolStripMenuItem menu_copy = new ToolStripMenuItem();
            menu_copy.MouseUp += new MouseEventHandler((sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
                    switch (menuItem?.Text)
                    {
                        case "Copy":
                            ListView.SelectedListViewItemCollection selected = ((ListView)sender).SelectedItems;
                            StringBuilder sb = new StringBuilder();
                            foreach (ListViewItem item in selected)
                            {
                                sb.Append(item.Text.PadRight(10));
                                sb.Append(item.SubItems[1].Text);
                                //sb.Append("\r\n");
                            }
                            Clipboard.SetText(sb.ToString());
                            break;
                        default:
                            break;
                    }
                }
            });

        }

        public static void ShowMessageOnTextBox(Form f, TextBox textBox, string message)
        {
            ShowMessageOnTextBox(f, textBox, message, true);
        }

        public static void ShowMessageOnTextBox(Form f, TextBox textBox, string message,bool isScrollToCaret=true)
        {
            if (!f.IsHandleCreated)
            {
                return;
            }
            f.BeginInvoke(new Action(() =>
            {
                if (textBox.Text.Length > TextBoxMaxLength)
                {
                    textBox.Text = textBox.Text.Substring(textBox.Text.Length / 2, textBox.Text.Length - textBox.Text.Length / 2);
                }
                textBox.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {message} \r\n");
                textBox.Select(textBox.Text.Length, 0);
                if (isScrollToCaret) 
                textBox.ScrollToCaret();

            }));
           
        }





    }
}
