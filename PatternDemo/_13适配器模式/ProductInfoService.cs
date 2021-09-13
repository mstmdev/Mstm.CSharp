using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13适配器模式
{
    class ProductInfoService : IProductService
    {

        public ProductInfo GetProductById(long productId)
        {

            IList<ProductInfo> list = new List<ProductInfo>();
            var model = new ProductInfo()
            {
                ProductId = 1001,
                ProductName = "MacBook Pro",
                Picture = "http://pic.test.com/macpic.jpg",
                ProductPrice = 15000.12m
            };

            list.Add(model);

            return list.Where(product => product.ProductId == productId).FirstOrDefault();

        }
    }
}
