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
using Common;

namespace SMBack
{
    public partial class FrmLogQuery : Form
    {
        private DataPageManager dataPageManager = new DataPageManager();
        public FrmLogQuery()
        {
            InitializeComponent();
            this.dgvLogs.AutoGenerateColumns = false;
            this.cbbPageSize.SelectedIndex = 0;//默认显示5条数据

            this.btnFirst.Enabled = false;
            this.btnPrevious.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnLast.Enabled = false;
            this.btnGoTo.Enabled = false;
            DataGridViewStyle.DgvStyle1(this.dgvLogs);

        }

        /// <summary>
        /// 点击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            //查询第一页
            this.dataPageManager.CurrentPage = 1;
            this.txtGoTo.Text = "1";
            Query();
            this.btnFirst.Enabled = false;
            this.btnPrevious.Enabled = false;

        }

        public void Query()
        {
            //开启所有按钮
            this.btnFirst.Enabled = true;
            this.btnPrevious.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnLast.Enabled = true;
            this.btnGoTo.Enabled = true;
            //设置查询参数并执行
            this.dataPageManager.PageSize = Convert.ToInt32(this.cbbPageSize.Text);
            DataTable dt = dataPageManager.QueryLogInfo(this.dtpStart.Text, this.dtpEnd.Text);
            //展示数据
            this.dgvLogs.DataSource = dt;
            this.lblRecordCount.Text = dataPageManager.RecordCount.ToString();
            this.lblPageCount.Text = dataPageManager.PageCount.ToString();
            if (this.lblPageCount.Text == "0")
            {
                this.lblCurrentPage.Text = "0";
            }
            else
            {
                this.lblCurrentPage.Text = dataPageManager.CurrentPage.ToString();
            }

            if (this.lblPageCount.Text == "0" || this.lblPageCount.Text == "1")
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnGoTo.Enabled = false;
            }
            else
            {
                this.btnGoTo.Enabled = true;
            }
        }


        private void FrmLogQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.logQuery = null;
        }

        //第一页
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            BtnQuery_Click(null, null);

        }

        //上一页
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            this.dataPageManager.CurrentPage--;
            Query();
            if (this.dataPageManager.CurrentPage == 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
            }
        }

        //下一页
        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.dataPageManager.CurrentPage++;
            Query();
            if (this.dataPageManager.CurrentPage == this.dataPageManager.PageCount)
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
        }

        //最后页
        private void BtnLast_Click(object sender, EventArgs e)
        {
            this.dataPageManager.CurrentPage = this.dataPageManager.PageCount;
            Query();
            this.btnNext.Enabled = false;
            this.btnLast.Enabled = false;
        }

        //跳转页码
        private void BtnGoTo_Click(object sender, EventArgs e)
        {
            if (this.txtGoTo.Text.Trim().Length == 0)
            {
                return;
            }
            var num = Convert.ToInt32(this.txtGoTo.Text.Trim());
            if (num > dataPageManager.PageCount || num <= 0)
            {
                MessageBox.Show("页码超出范围","提示信息");
                return;
            }
            this.dataPageManager.CurrentPage = num;
            this.lblCurrentPage.Text = num.ToString();
            Query();

            if (this.dataPageManager.CurrentPage == this.dataPageManager.PageCount)
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
            if (this.dataPageManager.CurrentPage == 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
