using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

        #region 商品管理
        /// <summary>
        /// 商品组合查询
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productName"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public DataTable QueryProductInventoryInfo(string productId,string productName,string categoryId)
        {
            string sql = "select ProductId,ProductName,Unit,UnitPrice,Discount,TotalCount,MaxCount,MinCount,InventoryStatus,CategoryId,CategoryName";
            sql += " from view_QueryInventoryInfo where 1=1";
            if (productId.Length != 0)
            {
                sql += string.Format(" and ProductId = '{0}'", productId);

            }

            if (productName.Length != 0)
            {
                sql += string.Format(" and productName like '%{0}%'", productName);
            }

            if (categoryId.Length != 0)
            {
                sql += string.Format(" and categoryId = {0}", categoryId);
            }

            try
            {
                return SqlHelper.GetDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
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
            SqlParameter outTotalCount = new SqlParameter("@TotalCount",SqlDbType.Int);
            outTotalCount.Direction = ParameterDirection.Output;
            SqlParameter outMaxCount = new SqlParameter("@MaxCount", SqlDbType.Int);
            outMaxCount.Direction = ParameterDirection.Output;
            SqlParameter outMinCount = new SqlParameter("@MinCount", SqlDbType.Int);
            outMinCount.Direction = ParameterDirection.Output;
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                outTotalCount,outMaxCount,outMinCount
            };

            try
            {
                DataSet ds = SqlHelper.GetDataSet("usp_QueryWarningInfo", sqlParameters, null, true);
                totalCount = Convert.ToInt32( outTotalCount.Value);
                maxCount = Convert.ToInt32(outMaxCount.Value); 
                minCount = Convert.ToInt32(outMinCount.Value);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 日志查询
        public DataTable QueryLogInfo(int pageSize,int currentPage,string beginTime, string endTime,out int totalount)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@CurrentPage",currentPage),
                new SqlParameter("@BeginTime",beginTime),
                new SqlParameter("@EndTime",endTime),
            };
           
            try
            {
                DataSet ds = SqlHelper.GetDataSet("usp_LogDataPager", sqlParameters, null, true);
                totalount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                return ds.Tables[0];
                //List<LoginLogs> list = new List<LoginLogs>();
                //SqlDataReader reader = SqlHelper.ExecuteReader("usp_LogDataPager", sqlParameters, true);
                //while (reader.Read())
                //{
                //    list.Add(new LoginLogs
                //    {
                //        LogId = Convert.ToInt32(reader["LogId"]),
                //        LoginId = Convert.ToInt32(reader["LoginId"]),
                //        SPName = reader["SPName"].ToString(),
                //        LoginTime = Convert.ToDateTime(reader["LoginTime"]),
                //        ExitTime = Convert.ToDateTime(reader["ExitTime"]),
                //    });
                //}
                //if (reader.NextResult())
                //{
                //    count = Convert.ToInt32(reader["totalount"]);
                //}
                //reader.Close();
                //totalount = count;
                //return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
