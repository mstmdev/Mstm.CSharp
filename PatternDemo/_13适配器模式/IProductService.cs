using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13适配器模式
{
    interface IProductService
    {
        /// <summary>
        /// 根据商品Id获取商品详情
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        ProductInfo GetProductById(long productId);
    }
}
