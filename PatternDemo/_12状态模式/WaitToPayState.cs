using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{

    /// <summary>
    /// 等待订单支付处理逻辑
    /// </summary>
    class WaitToPayState : OrderStateAbstract
    {
        protected override void InnerHandle(OrderContext context)
        {
            Console.WriteLine("下单成功，请进行支付......");
        }

        protected override OrderStateEnum CurrentState
        {
            get { return OrderStateEnum.WaitToPay; }
        }

        protected override OrderStateAbstract NextOrderState
        {
            get { return new WaitToConfirmState(); }
        }
    }
}
