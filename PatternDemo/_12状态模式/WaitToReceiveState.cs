using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{
    /// <summary>
    /// 等待收货处理逻辑
    /// </summary>
    class WaitToReceiveState : OrderStateAbstract
    {

        protected override void InnerHandle(OrderContext context)
        {
            Console.WriteLine("订单已发货，请等待收货......");
        }

        protected override OrderStateEnum CurrentState
        {
            get { return OrderStateEnum.WaitToReceive; }
        }

        protected override OrderStateAbstract NextOrderState
        {
            get { return new FinishedState(); }
        }
    }
}
