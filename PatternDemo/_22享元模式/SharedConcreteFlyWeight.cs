using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22享元模式
{

    /// <summary>
    /// 享元类型的具体实现
    /// </summary>
    class SharedConcreteFlyWeight : FlyWeight
    {
        public override void Execute(ProductInfo product)
        {
            if (product != null)
            {
                Console.WriteLine("{0}的价格为{1}, 通知来自于共享对象", product.ProductName, product.ProductPrice);
            }
            else
            {
                Console.WriteLine("无效的参数,通知来自于共享对象");
            }
        }
    }
}
