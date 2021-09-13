using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01简单工厂模式
{
    class OperationBase
    {
        public long NumberA { get; set; }

        public long NumberB { get; set; }

        public virtual long GetResult()
        {
            return -1;
        }

    }
}
