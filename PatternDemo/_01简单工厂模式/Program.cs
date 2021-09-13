using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01简单工厂模式
{
    class Program
    {

        /// <summary>
        /// 简单工厂模式
        /// 就是通过用户的选择为用户生成需要的产品
        /// 使代码中的具体实现依赖于基类，而不是具体的实现类，可以减少代码的耦合性，使实现类不被暴露在外部，
        /// 当实现类发生变动时，代码的具体调用也不用发生太大的改变，只需要需改具体的实现与工厂即可
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            OperationBase calc = OperationFactory.GetCalc("+");
            calc.NumberA = 110;
            calc.NumberB = 200;
            Console.WriteLine(calc.GetResult());
            Console.ReadKey();
        }
    }
}
