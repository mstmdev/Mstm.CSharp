using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21中介者模式
{

    /// <summary>
    /// 中介者
    /// </summary>
    abstract class Mediator
    {
        protected string Name;

        public Mediator(string name)
        {
            this.Name = name;
        }


        /// <summary>
        /// 代替某人发起一个消息
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="person">消息发起者</param>
        public abstract void Communication(string msg, Person person);
    }
}
