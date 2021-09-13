using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09建造者模式
{
    /// <summary>
    /// 建造者模式（Builder）：
    ///     将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。
    ///     
    ///     每一个复杂的业务逻辑都会有一个固定的流程步骤，但是其每一步的具体实现可以使不同的
    ///     建造者模式就可以帮助我们来封装具体的流程步骤的调用顺序，使用户只需要完成具体的实现细节即刻
    ///     如下面的安装系统的例子，每个系统的安装界面与方式都是不同的，但其基本流程是类似的，
    ///     所以，我们可以根据建造者模式的思想将操作的步骤抽象出来，将具体的步骤与流程独立开来
    ///     我们只需要关注具体操作系统的每个安装细节即可，不必关注其操作流程
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Win7安装
            WebmasterDirector master = new WebmasterDirector(new Win7SystemInstallBuilder());
            master.InstallSystem();

            Console.WriteLine("----------------------------");

            //Red Hat安装
            master = new WebmasterDirector(new RedHatSystemInstallBuilder());
            master.InstallSystem();


            Console.ReadLine();
        }
    }
}
