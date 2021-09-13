using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10观察者模式
{
    /// <summary>
    /// 观察者A
    /// </summary>
    class ObserverA
    {
        private ISubject _subject;

        public ObserverA(ISubject subject)
        {
            this._subject = subject;
        }

        public void UpdateA()
        {
            Console.WriteLine(_subject.State + "  UpdateA...");
        }
    }
}
