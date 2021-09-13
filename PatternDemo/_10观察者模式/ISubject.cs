using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10观察者模式
{

    /// <summary>
    /// 主题接口
    /// </summary>
    interface ISubject
    {

        /// <summary>
        /// 通知所有观察者
        /// </summary>
        void Notify();


        /// <summary>
        /// 记录主题的状态
        /// </summary>
        string State { get; set; }


        /// <summary>
        /// 主题的订阅事件
        /// </summary>
        event Action UpdateEvent;

    }
}
