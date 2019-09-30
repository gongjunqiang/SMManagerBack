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
using Models;

namespace SMBack
{
    public partial class FrmAddProduct : Form
    {
        private ProductManager productManager = new ProductManager();
        public FrmAddProduct()
        {
            InitializeComponent();

            #region 数据源初始化
            //绑定商品分类下拉列表数据源
            this.cboCategory.DataSource = productManager.GetProductCategory();
            this.cboCategory.DisplayMember = "CategoryName";
            this.cboCategory.ValueMember = "CategoryId";
            this.cboCategory.SelectedIndex = -1;
            //绑定商品单位数据源
            this.cboUnit.Items.AddRange(productManager.GetProductUnit());
            this.cboUnit.SelectedIndex = -1;
            #endregion

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMain.frmAddProduct = null;
        }

        #region 锁定与解锁
        /// <summary>
        /// 锁定与解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLock_Click(object sender, EventArgs e)
        {
            if (this.btnLock.Text == "锁定")
            {
                this.cboCategory.Enabled = false;
                this.cboUnit.Enabled = false;
                this.btnLock.Text = "解锁";
            }
            else
            {
                this.cboCategory.Enabled = true;
                this.cboUnit.Enabled = true;
                this.btnLock.Text = "锁定";
            }
        }
        #endregion

        #region 添加商品
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            #region 数据校验
            if (this.cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("请选择商品分类", "提示信息");
                return;
            }

            if (this.cboUnit.SelectedIndex == -1)
            {
                MessageBox.Show("请选择商品计量单位", "提示信息");
                return;
            }

            if (Convert.ToInt32(this.txtMaxCount.Text.Trim()) < Convert.ToInt32(this.txtMinCount.Text.Trim()))
            {
                MessageBox.Show("最大库存不能小于最小库存！", "提示信息");
                return;
            }
            #endregion

            #region 封装对象
            //封装对象
            Products product = new Products
            {
                ProductId = this.txtProductId.Text.Trim(),
                ProductName = this.txtProductName.Text.Trim(),
                UnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text.Trim()),
                Unit = this.cboUnit.SelectedText,
                CategoryId = Convert.ToInt32(this.cboCategory.SelectedValue)

            };

            ProductInventory productInventory = new ProductInventory
            {
                MaxCount = Convert.ToInt32(this.txtMaxCount.Text.Trim()),
                MinCount = Convert.ToInt32(this.txtMinCount.Text.Trim())
            };
            #endregion

            #region 调用后台
            try
            {
                productManager.AddNewProduct(product, productInventory);
                DialogResult dialogResult = MessageBox.Show("商品添加成功，是否继续添加？", "提示信息", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    //清空数据
                    this.txtMaxCount.Clear();
                    this.txtMinCount.Clear();
                    foreach (Control item in this.gbInfo.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = "";
                        }
                        if (item is ComboBox && this.btnLock.Text == "锁定")
                        {
                            ((ComboBox) item).SelectedIndex = -1;
                        }
                    }
                    this.txtProductId.Focus();
                }
                else
                {
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("商品添加失败："+ex.Message, "错误提示");
            }
            #endregion
        }


        #endregion

    }
}
