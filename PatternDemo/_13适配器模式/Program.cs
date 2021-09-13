using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13适配器模式
{

    /// <summary>
    /// 适配器模式（Adapter）：
    ///     适配器模式用于将一个类的接口转化为客户希望的另一个接口。
    ///     适配器模式可以使原来因为接口不兼容而不能共同工作的类可以一起工作。
    ///     
    ///     如下面的例子，对于一个产品本公司对于产品信息（ProductInfo）的定义，
    ///     与其他公司对于产品信息（MSProductInfo）的定义不完全相同，所以对于第三方接口的数据与本公司的数据无法协同处理，
    ///     此时就需要一个适配器将第三方的数据适配为符合本公司产品模型定义的结构，
    ///     在业务上可以实现本公司的产品与第三方的产品以相同的方式展示到客户端
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IProductService localService = new ProductInfoService();
            var localModel = localService.GetProductById(1001);

            IProductService msService = new MSProductInfoServiceAdapter();
            var msModel = msService.GetProductById(1002);

        }
    }
}
