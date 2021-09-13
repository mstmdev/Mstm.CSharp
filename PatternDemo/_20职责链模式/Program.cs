using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20职责链模式
{

    /// <summary>
    /// 职责链模式（Chain Of Responsibility）：
    ///     为解除请求的发送者和接收者之间的耦合，而使多个对象都有机会处理这个请求。
    ///     将这些对象连成一条链，并沿着这天链传递该请求，直到有一个对象处理它为止。
    ///     
    ///     使用职责链模式可以让请求按照顺序依次被不同的对象进行处理，如果当前对象无法处理请求，则会传递给下一个处理对象。
    ///     客户端的调用代码可以灵活的指定请求被调用的顺序。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Handler h1 = new Level1Handler("部门组长");
            Handler h2 = new Level2Handler("部门经理");
            Handler h3 = new Level3Handler("Boss");
            h1.SetNextHandler(h2);
            h2.SetNextHandler(h3);

            h1.Handle(2);
            h1.Handle(4);
            h1.Handle(9);
            h1.Handle(10);

            Console.ReadLine();


        }
    }
}
