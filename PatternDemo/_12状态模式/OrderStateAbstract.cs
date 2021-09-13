using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{
    /// <summary>
    /// 订单状态处理抽象类
    /// </summary>
    public abstract class OrderStateAbstract
    {

        /// <summary>
        /// 针对订单状态对订单进行处理
        /// </summary>
        /// <param name="context"></param>
        public virtual void Handle(OrderContext context)
        {
            if (context.StateEnum == this.CurrentState)
            {
                InnerHandle(context);
            }
            else
            {
                context.State = NextOrderState;
                context.ProceeOrder();
            }
        }

        /// <summary>
        /// 当前状态的处理事件
        /// </summary>
        /// <param name="context"></param>
        protected abstract void InnerHandle(OrderContext context);

        /// <summary>
        /// 当前状态的枚举标记
        /// </summary>
        protected abstract OrderStateEnum CurrentState { get; }

        /// <summary>
        /// 下一步订单状态的处理逻辑
        /// </summary>
        protected abstract OrderStateAbstract NextOrderState { get; }
    }
}
