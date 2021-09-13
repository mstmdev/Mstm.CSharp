using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22享元模式
{
    /// <summary>
    /// 享元基类
    /// </summary>
    abstract class FlyWeight
    {

        /// <summary>
        /// 享元类型中的方法
        /// 享元类型中尽量使用外部数据传递到对象内部，如此处的product
        /// 如果数据存储在享元实例的内部，容易导致数据发生混乱
        /// </summary>
        /// <param name="product"></param>
        public abstract void Execute(ProductInfo product);
    }
}
