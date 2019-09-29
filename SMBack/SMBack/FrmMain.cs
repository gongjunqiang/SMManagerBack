using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace SMBack
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //展示登录账户
            this.toolAdminName.Text = Program.currentAdmin.AdminName;
        }

        #region 新增商品

        public static FrmAddProduct frmAddProduct = null;
        //新增商品
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            if (frmAddProduct == null)
            {
                frmAddProduct = new FrmAddProduct();
                frmAddProduct.Show();
            }
            else
            {
                frmAddProduct.Activate();//激活最小化的窗体
                frmAddProduct.WindowState = FormWindowState.Normal;//让最小化的窗体正常显示
            }

            FrmStartPoint(frmAddProduct);
        }
        #endregion

        #region 商品入库
        //商品入库
        private void BtnProductInventor_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 库存管理
        //库存管理
        private void BtnInventoryManage_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 商品维护
        //商品维护
        private void BtnProductManage_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 销售统计
        //销售统计
        private void BtnSalAnalasys_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 日志查询
        //日志查询
        private void BtnLogQuery_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 密码修改
        //密码修改
        private void BtnModifyPwd_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 退出系统
        //退出系统
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 窗体显示在panel2的中间
        /// <summary>
        /// 窗体显示在panel2的中间
        /// </summary>
        /// <param name="objForm"></param>
        private void FrmStartPoint(Form objForm)
        {
            objForm.Location=new Point(
                this.Location.X + this.splitContainer1.Panel1.Width+(this.splitContainer1.Panel2.Width-objForm.Width)/2+12,
                this.Location.Y+ (this.splitContainer1.Panel2.Height - objForm.Height) / 2 + 50);
        }
        #endregion

        #region 退出系统时确认是否退出：退出需写入日志
        //窗体关闭之前发生的事件
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult= MessageBox.Show("确认退出系统吗？", "关闭提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.OK)
            {
                e.Cancel=true;//取消退出
            }
        }

        //窗体关闭之后发生的事件
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                new SysAdminManager().AdminLogout(Program.currentAdmin.LogId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("日志写入异常！");
            }
        }
        #endregion
    }
}
