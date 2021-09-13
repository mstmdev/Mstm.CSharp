using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{

    /// <summary>
    /// 等待订单确认处理逻辑
    /// </summary>
    class WaitToConfirmState : OrderStateAbstract
    {

        protected override void InnerHandle(OrderContext context)
        {
            Console.WriteLine("订单支付成功，等待商家确认订单......");
        }

        protected override OrderStateEnum CurrentState
        {
            get { return OrderStateEnum.WaitToConfirm; }
        }

        protected override OrderStateAbstract NextOrderState
        {
            get { return new WaitToPackState(); }
        }
    }
}
