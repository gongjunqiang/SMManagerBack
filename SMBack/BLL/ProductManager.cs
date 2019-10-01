using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 商品管理业务类
    /// </summary>
    public class ProductManager
    {
        private ProductService productService = new ProductService();

        #region 获取商品分类以及商品单位
        /// <summary>
        /// 获取商品分类
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetProductCategory()
        {
            return productService.GetProductCategory();
        }

        /// <summary>
        /// 获取商品单位
        /// </summary>
        /// <returns></returns>
        public string[] GetProductUnit()
        {
            return productService.GetProductUnit();
        }
        #endregion

        #region 添加商品
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="product"></param>
        /// <param name="inventoryInfo"></param>
        /// <returns></returns>
        public int AddNewProduct(Products product, ProductInventory inventoryInfo)
        {
            return productService.AddNewProduct(product, inventoryInfo);
        }
        #endregion

        #region 商品查询
        /// <summary>
        /// 根据商品ID查询商品信息
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Products QueryProductInfoById(string productId)
        {
            return productService.QueryProductInfoById(productId);
        }
        #endregion

        #region 商品入库
        /// <summary>
        /// 商品入库同时商品增加相应的库存
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="addedCount"></param>
        /// <returns></returns>
        public int ProductInventory(string productId, string addedCount)
        {
            return productService.ProductInventory(productId, addedCount);
        }
        #endregion

        #region 商品管理
        /// <summary>
        /// 商品组合查询
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productName"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public DataTable QueryProductInventoryInfo(string productId, string productName, string categoryId)
        {
            if (categoryId != "-1")
            {
                return productService.QueryProductInventoryInfo(productId, productName, categoryId);
            }
            else
            {
                return productService.QueryProductInventoryInfo(productId, productName, "");
            }
        }
        #endregion

        #region 商品库存管理
        /// <summary>
        /// 查询商品库存预警信息
        /// </summary>
        /// <returns></returns>
        public DataTable QueryWarningInfo(out int totalCount, out int maxCount, out int minCount)
        {
            return productService.QueryWarningInfo(out totalCount, out maxCount, out minCount);
        }
        #endregion

    }
}
