using BLL;
using Common;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMBack
{
    public partial class FrmInventoryManage : Form
    {
        private ProductManager productManager = new ProductManager();
        private DataTable table = null;

        public FrmInventoryManage()
        {
            InitializeComponent();

            List<ProductCategory> list = productManager.GetProductCategory();
            list.Insert(0, new ProductCategory() { CategoryId = -1, CategoryName = "" });
            this.cboCategory.DataSource = list;
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryId";

            this.dgvProduct.AutoGenerateColumns = false;
            QueryWarningInfo();
            DataGridViewStyle.DgvStyle1(this.dgvProduct);


        }

        /// <summary>
        /// 查询商品预警信息
        /// </summary>
        public void QueryWarningInfo()
        {
            int totalCount , maxCount, minCount;
            totalCount = maxCount = minCount = 0;
            table= productManager.QueryWarningInfo(out totalCount, out maxCount, out minCount);
            this.dgvProduct.DataSource = null;
            this.dgvProduct.DataSource = table;
            this.lblCount.Text = totalCount.ToString();
            this.lblMaxCount.Text = maxCount.ToString();
            this.lblMinCount.Text = minCount.ToString();
        }


        //提交查询
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (this.txtProductId.Text.Trim().Length == 0 &&
              this.txtProductName.Text.Trim().Length == 0 &&
              this.cboCategory.Text == "")
            {
                MessageBox.Show("请至少选择一个查询条件", "错误提示");
                return;
            }

            try
            {
                var result = productManager.QueryProductInventoryInfo(this.txtProductId.Text.Trim(), this.txtProductName.Text.Trim(), this.cboCategory.SelectedValue.ToString());
                this.dgvProduct.DataSource = null;
                this.dgvProduct.DataSource = result;
            }
            catch (Exception ex)
            {

                MessageBox.Show("查询异常：" + ex.Message, "错误提示");
            }
        }

        private void FrmInventoryManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.InventoryManage = null;
        }

        private void DgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvProduct, e);
        }

        /// <summary>
        /// 显示超库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowMax_Click(object sender, EventArgs e)
        {
            this.table.DefaultView.RowFilter = "InventoryStatus='已满仓'";
            this.dgvProduct.DataSource = table;
        }

        /// <summary>
        /// 显示低于库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowMin_Click(object sender, EventArgs e)
        {
            this.table.DefaultView.RowFilter = "InventoryStatus='需进货'";
            this.dgvProduct.DataSource = table;
        }

        /// <summary>
        /// 单元格选择展示库存信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvProduct.CurrentRow == null || this.dgvProduct.RowCount == 0)
            {
                return;
            }
            this.txtMaxCount.Text = this.dgvProduct.CurrentRow.Cells["MaxCount"].Value.ToString();
            this.txtMinCount.Text = this.dgvProduct.CurrentRow.Cells["MinCount"].Value.ToString();
            this.txtTotalCount.Text = this.dgvProduct.CurrentRow.Cells["TotalCount"].Value.ToString();
        }

        /// <summary>
        /// 刷新库存信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Linklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QueryWarningInfo();
            DateTime.Compare(DateTime.Now, DateTime.Now);
            ClearText();
        }

        private void ClearText()
        {
            this.txtMaxCount.Text = "";
            this.txtMinCount.Text = "";
            this.txtTotalCount.Text = "";
        }

    }
}
