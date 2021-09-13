using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10观察者模式
{
    /// <summary>
    /// 观察者模式（Observer）：
    ///     定义对象间的一种一对多的依赖关系，以便当一个对象的状态发生改变的时候，
    ///     所有依赖它的对象都得到通知并自动刷新。
    /// 
    ///     使用观察者模式可以实现当一个主题状态发生改变时，所有的观察者都能够及时作出响应
    ///     使各自的状态保持一致
    ///     这里使用委托的形式进行实现
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ISubject sub = new Subject();
            ObserverA observerA = new ObserverA(sub);
            ObserverB observerB = new ObserverB(sub);
            sub.UpdateEvent += observerA.UpdateA;
            sub.UpdateEvent += observerB.UpdateB;

            sub.State = "Hello";
            sub.Notify();
            Console.ReadLine();
        }
    }
}
