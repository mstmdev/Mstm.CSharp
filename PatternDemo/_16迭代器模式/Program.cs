using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16迭代器模式
{

    /// <summary>
    /// 迭代器模式（Iterator）：
    ///     提供一种方法顺序访问一个聚合对象中的各个元素，而又不暴露该对象的内部表示
    ///     
    ///     典型的例子就使C#中的foreach语句
    ///     foreach就是通过IEnumerator接口和IEnumerable接口来实现的
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            ConcreteAggregate aggregate = new ConcreteAggregate();
            aggregate.Add("A1");
            aggregate.Add("A2");
            aggregate.Add("A3");
            aggregate.Add("A4");
            aggregate.Add("A5");
            aggregate.Add("A6");
            IIterator iterator = aggregate.GetIterator();

            iterator.Reset();
            while (iterator.IsLast() == false)
            {
                Console.WriteLine(iterator.Current());
                iterator.Next();
            }

            Console.ReadLine();
        }
    }
}
