using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13适配器模式
{
    class MSProductInfoServiceAdapter : IProductService
    {
        private MSProductInfoService service;

        public MSProductInfoServiceAdapter()
        {
            service = new MSProductInfoService();
        }


        public ProductInfo GetProductById(long productId)
        {
            var msModel = service.GetProductInfoById(productId);
            if (msModel == null) { return null; }
            var localModel = new ProductInfo()
            {
                Picture = msModel.MainPicture,
                ProductId = msModel.MSProductId,
                ProductName = msModel.ProductName,
                ProductPrice = msModel.SellPrice
            };
            return localModel;
        }
    }
}
