using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    [Serializable]
    public class Products
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Discount { get; set; }

        public int CategoryId { get; set; }


        //商品分类名称
        public string CategoryName { get; set; }

        //商品单位
        public string Unit { get; set; }

    }
}
