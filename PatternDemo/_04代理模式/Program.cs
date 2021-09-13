using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04代理模式
{
    /// <summary>
    /// 代理模式（Proxy）：
    ///     为其他对象提供一个代理以控制对这个对象的访问。
    ///     
    ///     代理模式对具体的实现进行了封装
    ///     可以让外部的调用中不用了解内部的实现，
    ///     另一方面可以在真正调用内部实现时对其进行一些必要的控制，如安全、权限方面的检查
    ///     例如WCF中自动生成的代码就是一个远程代理，通过代理帮我们隐藏了其其实是代用了远程的一个服务，
    ///     让我们看起来就想调用了本地的方法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product()
            {
                ProductName = "Apple Mac Book Pro",
                Price = 21000
            };
            OverseasProxy agent = new OverseasProxy();
            agent.Buy(product);
            Console.ReadLine();
        }
    }
}
