using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DAL
{
    /// <summary>
    /// 商品数据访问类
    /// </summary>
    public class ProductService
    {
        #region 获取商品分类以及商品单位
        /// <summary>
        /// 获取商品分类
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetProductCategory()
        {
            string sql = "select CategoryId,CategoryName from ProductCategory";
            List<ProductCategory> categoryList = new List<ProductCategory>();
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sql);
                while (reader.Read())
                {
                    categoryList.Add(new ProductCategory
                    {
                        CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        CategoryName = reader["CategoryName"].ToString()
                    });
                }
                reader.Close();
                return categoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取商品的单品
        /// </summary>
        /// <returns></returns>
        public string[] GetProductUnit()
        {
            string sql = "select Id,Unit from ProductUnit";
            List<string> unitList = new List<string>();
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(sql);
                while (reader.Read())
                {
                    unitList.Add(reader["Unit"].ToString());
                }
                reader.Close();
                return unitList.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 添加商品
        public int AddNewProduct(Products product, ProductInventory inventoryInfo)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId",product.ProductId),
                new SqlParameter("@ProductName",product.ProductName),
                new SqlParameter("@UnitPrice",product.UnitPrice),
                new SqlParameter("@Unit",product.Unit),
                new SqlParameter("@CategoryId",product.CategoryId),
                new SqlParameter("@MinCount",inventoryInfo.MinCount),
                new SqlParameter("@MaxCount",inventoryInfo.MaxCount),
            };

            try
            {
                return SqlHelper.ExecuteNonQuery("usp_AddProduct", sqlParameters,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region 商品查询
        public Products QueryProductInfoById(string productId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId",productId),
            };
            Products products = null;
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader("usp_GetProductById", sqlParameters,true);
                if (reader.Read())
                {
                    products = new Products
                    {
                        ProductName = reader["ProductName"].ToString(),
                        UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                        Unit = reader["UnitPrice"].ToString(),
                        Discount = Convert.ToInt32(reader["Discount"]),
                        CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        CategoryName = reader["CategoryName"].ToString(),
                    };
                }
                reader.Close();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 商品入库
        /// <summary>
        /// 商品入库同时商品增加相应的库存
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="addedCount"></param>
        /// <returns></returns>
        public int ProductInventory(string productId,string addedCount)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId",productId),
                new SqlParameter("@AddedCount",addedCount),
            };
            try
            {
                return SqlHelper.ExecuteNonQuery("usp_UpdateInventory", sqlParameters, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}
