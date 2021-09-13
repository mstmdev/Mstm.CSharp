using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13适配器模式
{
    /// <summary>
    /// 商品模型
    /// </summary>
    class ProductInfo
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal ProductPrice { get; set; }


        /// <summary>
        /// 商品图片
        /// </summary>
        public string Picture { get; set; }
    }
}
