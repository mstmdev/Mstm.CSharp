using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21中介者模式
{

    /// <summary>
    /// 租客
    /// </summary>
    class Tenant : Person
    {
        public Tenant(string name, Mediator mediator)
            : base(name, mediator) { }

        public override void ReceiveNotify(string msg)
        {
            Console.WriteLine("{0}, {1}", Name, msg);
        }

        public override void Send(string msg)
        {
            if (this.Mediator != null)
            {
                this.Mediator.Communication(msg, this);
            }
        }
    }
}
