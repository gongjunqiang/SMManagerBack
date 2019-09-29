using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using BLL;
using Common;

namespace SMBack
{
    public partial class FrmLogin : Form
    {
        private SysAdminManager adminManager = new SysAdminManager();
        public FrmLogin()
        {
            InitializeComponent();
        }

        //登录
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //数据校验
            if (!DataValidate.IsInteger(this.txtLoginId.Text.Trim()))
            {
                MessageBox.Show("登录Id只能是整数!", "提示信息！");
                this.txtLoginId.Focus();
                return;
            }
            if (this.txtLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("密码不能为空!", "提示信息！");
                return;
            }
            //封装对象

            SysAdmins admin = new SysAdmins
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text.Trim()
            };

            try
            {
                admin = adminManager.AdminLogin(admin);
                if (admin != null)
                {
                    if (admin.AdminStatus == 1)
                    {
                        Program.currentAdmin = admin;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("当前账户被禁用，请练习管理员！", "提示信息！");
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示信息！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("登录异常，"+ex.Message, "提示信息！");
            }
        }

        //取消
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
