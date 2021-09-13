using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24访问者模式
{
    class ConcreteElementA : Element
    {

        public override void Accept(Visitor visitor)
        {
            visitor.CallByElementA(this);
            Console.WriteLine();
        }
    }
}
