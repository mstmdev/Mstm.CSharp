using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{

    /// <summary>
    /// 取消订单处理逻辑
    /// </summary>
    class CancelState : OrderStateAbstract
    {

        protected override void InnerHandle(OrderContext context)
        {
            Console.WriteLine("订单已取消！");
        }

        protected override OrderStateEnum CurrentState
        {
            get { return OrderStateEnum.Cancel; }
        }

        protected override OrderStateAbstract NextOrderState
        {
            get { return this; }
        }
    }
}
