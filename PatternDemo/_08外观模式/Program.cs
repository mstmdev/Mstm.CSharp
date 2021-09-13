using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08外观模式
{
    /// <summary>
    /// 外观模式（Facade）：
    ///     对系统中的一组接口提供一个一致的界面，Facade模式定义了一个高层接口，
    ///     这个接口使得这一子系统更加容易使用。
    /// 
    ///     使用外观模式可以对程序内部的实现进行封装和隐藏，使暴露在外部的接口尽量简单
    ///     还可以使用外观模式对原有遗留系统的代码进行封装，
    ///     使需要对原有系统功能进行调用时不用直接针对原有系统进行开发，新的组件只需要针对Facade组件进行开发就可以了
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            string code = "FFA7HJ7U7K3cN4LZZ90H34S2431";
            facade.Login(code);
            Console.ReadLine();
        }
    }
}
