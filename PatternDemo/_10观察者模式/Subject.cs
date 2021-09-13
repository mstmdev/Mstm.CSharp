using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10观察者模式
{

    /// <summary>
    /// 主题
    /// </summary>
    class Subject : ISubject
    {
        private string _state;

        /// <summary>
        /// 通知所有观察者
        /// </summary>
        public void Notify()
        {
            if (this._event != null)
            {
                this._event();
            }
        }


        /// <summary>
        /// 记录主题中的状态
        /// </summary>
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        private event Action _event;

        event Action ISubject.UpdateEvent
        {
            add { _event += value; }
            remove { _event -= value; }
        }

    }
}
