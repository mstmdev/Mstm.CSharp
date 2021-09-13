using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{

    /// <summary>
    /// 等待发货处理逻辑
    /// </summary>
    class WaitToShipmentState : OrderStateAbstract
    {

        protected override void InnerHandle(OrderContext context)
        {
            Console.WriteLine("订单打包完毕，等待发货......");
        }

        protected override OrderStateEnum CurrentState
        {
            get { return OrderStateEnum.WaitToShipment; }
        }

        protected override OrderStateAbstract NextOrderState
        {
            get { return new WaitToReceiveState(); }
        }
    }
}
