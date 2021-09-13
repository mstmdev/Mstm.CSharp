using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12状态模式
{

    /// <summary>
    /// 订单状态枚举
    /// </summary>
    public enum OrderStateEnum
    {
        /// <summary>
        /// 订单待支付
        /// </summary>
        WaitToPay = 1,

        /// <summary>
        /// 订单待确认
        /// </summary>
        WaitToConfirm = 2,

        /// <summary>
        /// 等待打包
        /// </summary>
        WaitToPack = 3,

        /// <summary>
        /// 等待发货
        /// </summary>
        WaitToShipment = 4,

        /// <summary>
        /// 等待收货
        /// </summary>
        WaitToReceive = 5,

        /// <summary>
        /// 订单完成
        /// </summary>
        Finished = 6,

        /// <summary>
        /// 订单取消
        /// </summary>
        Cancel = 7
    }
}
