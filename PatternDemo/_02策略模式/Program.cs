using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02策略模式
{
    class Program
    {

        /// <summary>
        /// 策略模式（Strategy）：
        ///     定义一些列的算法，把它们一个个封装起来，并且使它们可相互替换。
        ///     本模式使得算法的变化可独立于他的客户。
        ///     
        ///     策略模式就是将程序的算法给抽象出来，用户可以可以自定义算法的具体实现
        ///     比如.Net框架中的IComparable接口的使用就是策略模式很好的应用
        ///     这个Demo中使用策略模式和简单工厂模式的方式让用户根据具体传入的参数type进行不同算法实现的调用，
        ///     但是其调用的方式还是一样的，都是调用 context.DoWork();
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WorkContext context = new WorkContext("A");
            context.DoWork();
        }
    }
}
