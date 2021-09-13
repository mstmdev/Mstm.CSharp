using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21中介者模式
{

    /// <summary>
    /// 中介者模式（Mediator）：
    ///     用一个中介对象来封装一系列的对象交互。中介者使各对象不需要显示的相互引用，从而达到解耦的目的，而且可以独立的
    ///     改变它们之间的交互。
    ///     
    ///     中介者模式中的中介者作为其他多个对象之间交互的中间人，对象之间不必进行直接的交互与通讯。
    ///     但是在中介者模式中中介者需要知道其他所有的对象，其他对象也必须认识中介者，这样会导致中介者中的逻辑过于复杂化，
    ///     不易于维护。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //创建中介、房东与租客
            HouseMediator mediator = new HouseMediator("房屋中介张先生");
            Person landlord = new Landlord("林房东", mediator);
            Person tenant = new Tenant("孙同学", mediator);

            mediator.Landlord = landlord;
            mediator.Tenant = tenant;

            //租客与房东分别发起会话  会话内容都是通过中介传递给对方的
            tenant.Send("我要租一间20平米的单间");
            landlord.Send("我这儿正好有一间，3000一个月");

            Console.ReadLine();
        }
    }
}
