using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{
    /// <summary>
    /// 订单完成处理逻辑
    /// </summary>
    class FinishedState : OrderStateAbstract
    {

        protected override void InnerHandle(OrderContext context)
        {
            Console.WriteLine("订单已签收，订单完结！");
        }

        protected override OrderStateEnum CurrentState
        {
            get { return OrderStateEnum.Finished; }
        }

        protected override OrderStateAbstract NextOrderState
        {
            get { return new CancelState(); }
        }
    }
}
