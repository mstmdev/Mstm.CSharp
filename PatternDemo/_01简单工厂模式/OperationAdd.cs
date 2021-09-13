using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01简单工厂模式
{
    class OperationAdd : OperationBase
    {
        public override long GetResult()
        {
            return NumberA + NumberB;
        }
    }
}
