using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19命令模式
{

    /// <summary>
    /// 命令模式（Command）：
    ///     将一个请求封装为一个对象，从而使你可用不同的请求对客户进行参数化，
    ///     对请求排队或者记录请求日志，以及支持可撤销的操作。
    ///     
    ///     使用命令模式可以对命令进行更好的进行控制，使其容易的形成一个队列，用户可以对其执行进行控制。
    ///     在命令执行前后可以加入我们自己的控制，如一些必要的检查以及日志的记录
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //创建两个厨师
            Cook cook = new Cook("张大厨师");
            Cook cook2 = new Cook("王厨");
            //点张大厨师做一道烤鱼
            CookingCommand fish = new CookingFishCommand(cook);
            //点王厨做一道特色豆腐
            CookingCommand tofu = new CookingTofuCommand(cook2);
            //创建服务员
            Waiter waiter = new Waiter("晓丽");
            //服务员帮客户点餐
            waiter.StartOrder(fish);
            waiter.StartOrder(tofu);
            //点餐完毕 开始下单
            waiter.StartCook();

            Console.ReadLine();
        }
    }
}
