using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24访问者模式
{

    /// <summary>
    /// 访问者模式中的主要元素对象
    /// </summary>
    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }
}
