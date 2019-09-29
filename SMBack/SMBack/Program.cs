using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.Diagnostics;


namespace SMBack
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 禁止启动多个项目进程
            //禁止启动多个项目进程
            int currentProcess = 0;
            Process[] processArray = Process.GetProcesses();
            foreach (var process in processArray)
            {
                if (process.ProcessName == Process.GetCurrentProcess().ProcessName)
                {
                    currentProcess++;
                }
            }

            if (currentProcess>1)
            {
                Application.Exit();
                return;
            }
            #endregion
            //显示登录窗体，并展示
            FrmLogin frmLogin = new FrmLogin();
            DialogResult dialogResult = frmLogin.ShowDialog();
            //判断是否登录成功
            if (dialogResult == DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
            else
            {
                Application.Exit();
            }
            
        }

        public static SysAdmins currentAdmin = null;
    }
}
