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
using Models;


namespace SMBack
{
    public partial class FrmProductManage : Form
    {
        private ProductManager productManager = new ProductManager();
        public FrmProductManage()
        {
            InitializeComponent();
            //数据初始化

            List<ProductCategory> list = productManager.GetProductCategory();
            list.Insert(0, new ProductCategory() { CategoryId=-1,CategoryName=""});
            this.cboCategory.DataSource = list;
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryId";

            this.dgvProduct.AutoGenerateColumns = false;


            DataGridViewStyle.DgvStyle1(this.dgvProduct);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗体关闭后将FrmProductManage对象置为空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmProductManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.frmProductManage = null;
        }

        /// <summary>
        /// 提交查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            //数据校验
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


        private void DgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvProduct, e);
        }
    }
}
