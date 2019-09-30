using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 商品单位实体类
    /// </summary>
    [Serializable]
    public class ProductUnit
    {
        public int Id { get; set; }
        public string Unit { get; set; }
    }
}
