using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{
    /// <summary>
    /// 订单处理上下文
    /// </summary>
    public class OrderContext
    {
        /// <summary>
        /// 当前订单状态的处理逻辑
        /// </summary>
        public OrderStateAbstract State
        {
            get;
            set;
        }

        /// <summary>
        /// 当前订单的真实状态枚举
        /// </summary>
        public OrderStateEnum StateEnum
        {
            get;
            set;
        }

        public OrderContext()
        {
            //将订单初始状态逻辑设置为未支付
            this.State = new WaitToPayState();
        }

        /// <summary>
        /// 处理订单
        /// </summary>
        public void ProceeOrder()
        {
            this.State.Handle(this);
        }
    }
}
