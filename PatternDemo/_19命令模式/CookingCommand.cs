using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19命令模式
{

    /// <summary>
    /// 命令抽象类
    /// </summary>
    abstract class CookingCommand
    {
        //命令执行者 这里是厨师
        protected Cook _cook;

        public CookingCommand(Cook cook)
        {
            this._cook = cook;
        }

        /// <summary>
        /// 执行命令  开始做菜
        /// </summary>
        public abstract void Execute();
    }
}
