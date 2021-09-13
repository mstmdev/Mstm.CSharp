using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21中介者模式
{
    class HouseMediator : Mediator
    {

        public HouseMediator(string name)
            : base(name)
        {

        }

        /// <summary>
        /// 房东
        /// </summary>
        public Person Landlord { get; set; }


        /// <summary>
        /// 房客
        /// </summary>
        public Person Tenant { get; set; }


        
        public override void Communication(string msg, Person person)
        {
            //如果是房东则通知租客
            if (person is Landlord)
            {
                Tenant.ReceiveNotify(msg);
            }
            else //如果是租客则通知房东
            {
                Landlord.ReceiveNotify(msg);
            }
        }
    }
}
