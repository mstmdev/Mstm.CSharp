using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21中介者模式
{
    abstract class Person
    {
        protected string Name;

        /// <summary>
        /// 中介
        /// </summary>
        protected Mediator Mediator;

        public Person(string name, Mediator mediator)
        {
            this.Name = name;
            this.Mediator = mediator;
        }

        /// <summary>
        /// 通知当前用户
        /// </summary>
        /// <param name="msg"></param>
        public abstract void ReceiveNotify(string msg);


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        public abstract void Send(string msg);
    }
}
