using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10观察者模式
{
    /// <summary>
    /// 观察者B
    /// </summary>
    class ObserverB
    {
        private ISubject _subject;


        public ObserverB(ISubject subject)
        {
            this._subject = subject;
        }

        public void UpdateB()
        {
            Console.WriteLine(_subject.State + "  UpdateB...");
        }

    }
}
