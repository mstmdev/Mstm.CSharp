using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23解释器模式
{

    /// <summary>
    /// 解释器模式（Interpreter）：
    ///     给定一个语言，定义它的文法的一种表示，
    ///     并定义一个解释器，这个解释器使用该表示来解释语言中的句子。
    ///     
    ///     下列例子通过不同的解析器对原文中的大小写字母进行解析，翻译成指定的密文
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<AbstractExpression> expressions = new List<AbstractExpression>();
            expressions.Add(new ConcreteExpressionA());
            expressions.Add(new ConcreteExpressionB());
            var context = new InterpreterContext() { Input = "AAjdu7H6&834 dfGjddf@8fD ;d" };
            foreach (var item in expressions)
            {
                item.Interprent(context);
            }

            Console.WriteLine(context.Input);
            Console.WriteLine(context.Output);

            Console.ReadLine();
        }
    }
}
