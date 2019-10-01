using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DataPageManager
    {
        /// <summary>
        /// 记录总条数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前第几页
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 分页总数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (RecordCount != 0)
                {
                    if (RecordCount % PageSize != 0)
                    {
                        return RecordCount / PageSize + 1;
                    }
                    else
                    {
                        return RecordCount / PageSize;
                    }
                }
                else
                {
                    this.CurrentPage = 1;
                    return 0;
                }
            }
        }


        #region 日志查询
        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable QueryLogInfo(string beginTime, string endTime)
        {
            int RecordCount = 0;
            DataTable dt = new ProductService().QueryLogInfo(this.PageSize, this.CurrentPage, beginTime, 
                Convert.ToDateTime(endTime).AddDays(1.0).ToShortDateString(), out RecordCount);
            this.RecordCount = RecordCount;

            return dt;
        }
        #endregion



    }
}
