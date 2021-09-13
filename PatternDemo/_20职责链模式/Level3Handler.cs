using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20职责链模式
{
    class Level3Handler : Handler
    {
        public Level3Handler(string name)
            : base(name) { }

        public override void Handle(int level)
        {
            if (level <= 9)
            {
                Console.WriteLine("{0} 批准", Name);
            }
            else
            {
                Console.WriteLine("{0} 此事过于重大，暂不批准！", Name);
            }
        }
    }
}
