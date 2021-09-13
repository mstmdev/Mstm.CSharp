using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07模板方法模式
{

    /// <summary>
    /// 模板方法（Template Method）：
    ///     定义一个操作中的算法的骨架，而将一些步骤延迟到子类中。
    ///     Template Method使得子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤。
    ///     
    ///     模板方法模式就是利用面向对象的思想将对象的公共部分提取到基类中
    ///     通过在基类方法中调用抽象方法，使其抽象调用能够延迟到子类中进行实现
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            PhotoFiltersTemplate chinsePhoto = new ChineseStyleFilters();
            chinsePhoto.Render();

            Console.WriteLine(".....................");

            PhotoFiltersTemplate cutePhoto = new CuteStyleFilters();
            cutePhoto.Render();

            Console.ReadLine();

        }
    }
}
