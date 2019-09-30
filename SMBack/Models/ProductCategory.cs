﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 商品分类实体
    /// </summary>
    [Serializable]
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
