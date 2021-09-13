using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24访问者模式
{
    class VisitorB:Visitor
    {

        public override void CallByElementA(ConcreteElementA element)
        {
            Console.WriteLine("{0}  from VisitorB_A", element.GetType().FullName);
        }

        public override void CallByElementB(ConcreteElementB element)
        {
            Console.WriteLine("{0}  from VisitorB_B", element.GetType().FullName);
        }
    }
}
