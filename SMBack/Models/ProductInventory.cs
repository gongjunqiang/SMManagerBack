using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 商品库存实体类
    /// </summary>
    [Serializable]
    public class ProductInventory
    {
        public string ProductId { get; set; }

        public int TotalCount { get; set; }

        public int MinCount { get; set; }

        public int MaxCount { get; set; }

        public string Status { get; set; }


    }
}
