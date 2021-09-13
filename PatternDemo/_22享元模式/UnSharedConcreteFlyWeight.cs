using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22享元模式
{

    /// <summary>
    /// 非享元类型实现
    /// 对于某些对象无法以共享的方式提供给外部，只能每次创建新的实例对象
    /// </summary>
    class UnSharedConcreteFlyWeight : FlyWeight
    {
        public override void Execute(ProductInfo product)
        {
            if (product != null)
            {
                Console.WriteLine("{0}的价格为{1}, 通知来自于独立新对象", product.ProductName, product.ProductPrice);
            }
            else
            {
                Console.WriteLine("无效的参数,通知来自于独立新对象");
            }
        }
    }
}
