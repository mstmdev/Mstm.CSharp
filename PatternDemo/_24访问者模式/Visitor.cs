using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24访问者模式
{

    /// <summary>
    /// 访问者模式中的行为
    /// </summary>
    abstract class Visitor
    {
        public abstract void CallByElementA(ConcreteElementA element);

        public abstract void CallByElementB(ConcreteElementB element);
    }
}
