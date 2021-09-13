using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24访问者模式
{

    /// <summary>
    /// 访问者模式（Visitor）：
    ///     表示一个作用于某对象结构中的各个元素的操作。
    ///     它使你可以在不改变元素的类的前提下定义作用于这些元素的新操作。
    ///     
    ///     如下基本结构中Element的子类数据是基本不变的只有ConcreteElementA和ConcreteElementB
    ///     Visitor子类的数量可以任意变化，也就是说在访问者模式中，数据结构使不变的，但是行为可以不断变化
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStruture obj = new ObjectStruture();
            obj.Attach(new ConcreteElementA());
            obj.Attach(new ConcreteElementB());


            obj.Accept(new VisitorA());
            Console.WriteLine("-----------------");

            obj.Accept(new VisitorC());
            Console.WriteLine("-----------------");

            obj.Accept(new VisitorB());
            Console.WriteLine("-----------------");


            Console.ReadLine();
        }
    }
}
