using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{
    /// <summary>
    /// 等待订单打包处理逻辑
    /// </summary>
    class WaitToPackState : OrderStateAbstract
    {

        protected override void InnerHandle(OrderContext context)
        {
            Console.WriteLine("卖家已确认订单，等待打包商品......");
        }

        protected override OrderStateEnum CurrentState
        {
            get { return OrderStateEnum.WaitToPack; }
        }

        protected override OrderStateAbstract NextOrderState
        {
            get { return new WaitToShipmentState(); }
        }
    }
}
