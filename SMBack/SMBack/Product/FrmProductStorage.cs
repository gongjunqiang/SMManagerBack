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
    public partial class FrmProductStorage : Form
    {
        private ProductManager productManager = new ProductManager();
        public FrmProductStorage()
        {
            InitializeComponent();
        }

        private void FrmProductStorage_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.frmProductStorage = null;
        }

        /// <summary>
        /// 回车键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 ) GetProductInfo();
        }

        private void TxtProductId_Leave(object sender, EventArgs e)
        {
            GetProductInfo();
        }

        //添加库存
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (GetProductInfo())
            {
                if (this.txtQuantity.Text.Trim().Length == 0)
                {
                    MessageBox.Show("入库数量不能为空！", "提示信息");
                }

                try
                {
                    productManager.ProductInventory(this.txtProductId.Text.Trim(), this.txtQuantity.Text.Trim());
                    MessageBox.Show("入库成功！", "提示信息");
                    this.txtQuantity.Clear();
                    this.txtProductName.Clear();
                    this.txtProductId.Clear();
                    this.txtProductId.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("入库异常："+ex.Message, "提示信息");
                }
            }
        }

        #region 获取商品信息
        private bool GetProductInfo()
        {
            if (this.txtProductId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入商品编号！", "提示信息");
                this.txtProductId.Focus();
                return false;
            }

            try
            {
                var product = productManager.QueryProductInfoById(this.txtProductId.Text.Trim());
                if (product == null)
                {
                    MessageBox.Show("该商品还未添加！", "提示信息");
                    this.txtProductId.Clear();
                    this.txtProductName.Clear();
                    return false;
                }
                else
                {
                    this.txtProductName.Text = product.ProductName;
                    this.txtQuantity.Focus();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作异常：" + ex.Message, "错误信息");
                throw ex;
            }
        }
        #endregion

        private void TxtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && this.txtQuantity.Text.Trim().Length != 0)
            {
                BtnConfirm_Click(null, null);
            }
        }
    }
}
