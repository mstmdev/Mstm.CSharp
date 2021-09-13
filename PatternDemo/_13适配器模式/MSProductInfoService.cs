using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13适配器模式
{
    class MSProductInfoService
    {
        public MSProductInfo GetProductInfoById(long Id)
        {
            IList<MSProductInfo> list = new List<MSProductInfo>();
            var model = new MSProductInfo()
              {
                  MSProductId = 1002,
                  ProductName = "Surface Book",
                  MainPicture = "http://pic.test.com/sufacepic.jpg",
                  SellPrice = 20080m
              };
            list.Add(model);
            return list.Where(product => product.MSProductId == Id).FirstOrDefault();
        }
    }
}
