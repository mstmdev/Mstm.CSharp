using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15组合模式
{

    /// <summary>
    /// 组合模式（Composite）：
    ///     将对象组合成树形结构以表示”部分-整体“的层次结构。
    ///     Composite使得客户对单个对象和复合对象的使用具有一致性。
    ///     
    ///     例如.Net WinForm中的控件就是使用了组合模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Component componentRoot = new CompositeComponent("—电脑");
            componentRoot.Add(new LeafComponent("——机箱"));
            componentRoot.Add(new LeafComponent("——电源"));
            Component componentLevel2 = new CompositeComponent("——主板");
            componentLevel2.Add(new LeafComponent("———内存"));

            componentRoot.Add(componentLevel2);
            Component componentLevel3 = new CompositeComponent("———键盘");
            componentLevel3.Add(new LeafComponent("————键帽"));
            componentLevel2.Add(new LeafComponent("———硬盘"));
            componentLevel2.Add(componentLevel3);
            componentLevel2.Add(new LeafComponent("———鼠标"));

            componentRoot.Show();

            Console.ReadLine();
        }
    }
}
