using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{
    /// <summary>
    /// 状态模式（State）：
    ///     允许一个对象在其内部状态改变时改变它的行为。
    ///     对象看起来似乎修改了它所属的类。
    ///     
    ///     利用状态模式可以解决程序中每个选择分支的逻辑过于庞大的问题，
    ///     使程序可以根据当前的状态执行相应的行为
    ///     这里以订单的状态为例，订单处于不同的状态，它的相应的处理也是不同的，
    ///     因一个订单包含很多的状态，所以普通的switch方式会导致代码过于庞大，不易扩展，难以维护
    ///     这里使用状态模式和模板模式（OrderStateAbstract）将订单每个状态的处理逻辑都独立成一个类，
    ///     每个状态的处理逻辑发生改变时，只需修改相应的类即可，无需对其他类进行修改，而且扩展也比较方便
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            OrderContext context = new OrderContext();
            context.StateEnum = OrderStateEnum.WaitToReceive;
            context.ProceeOrder();


            context.StateEnum = OrderStateEnum.Finished;
            context.ProceeOrder();


            context.StateEnum = OrderStateEnum.Cancel;
            context.ProceeOrder();

            Console.ReadLine();
        }
    }
}
