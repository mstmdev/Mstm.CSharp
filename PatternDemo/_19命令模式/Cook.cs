using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19命令模式
{

    /// <summary>
    /// 厨师
    /// 作为命令的执行者
    /// </summary>
    class Cook
    {
        private string _name;

        public Cook(string name)
        {
            _name = name;
        }

        public void CookingFish()
        {
            Console.WriteLine(_name + "  开始烤鱼....." + DateTime.Now);
        }

        public void CookieTofu()
        {
            Console.WriteLine(_name + "  开始做豆腐...." + DateTime.Now);
        }
    }
}
