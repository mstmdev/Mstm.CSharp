using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19命令模式
{

    /// <summary>
    /// 具体的命令
    /// 命令厨师做一豆腐
    /// </summary>
    class CookingTofuCommand : CookingCommand
    {
        public CookingTofuCommand(Cook cook)
            : base(cook) { }


        public override void Execute()
        {
            if (_cook != null)
            {
                _cook.CookieTofu();
            }
        }
    }
}
