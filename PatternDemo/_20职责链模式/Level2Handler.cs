using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20职责链模式
{
    class Level2Handler : Handler
    {
        public Level2Handler(string name)
            : base(name) { }

        public override void Handle(int level)
        {
            if (level <= 6)
            {
                Console.WriteLine("{0} 批准", Name);
            }
            else if (this.NextHandler != null)
            {
                this.NextHandler.Handle(level);
            }
            else
            {
                Console.WriteLine("请求{0}在处中断了！", Name);
            }
        }
    }
}
