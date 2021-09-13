using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.RedPacket.Core
{

    /// <summary>
    /// 红包活动配置
    /// </summary>
    public class RedPacketConfig
    {
        /// <summary>
        /// 资金总金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 红包总数
        /// </summary>
        public int PacketCount { get; set; }


        /// <summary>
        /// 浮动上限（0-100）
        /// </summary>
        public decimal Ceiling { get; set; }


        /// <summary>
        /// 浮动下限（0-100）
        /// </summary>
        public decimal Floor { get; set; }


        /// <summary>
        /// 已发红包总额
        /// </summary>
        public decimal CurrentAmount { get; set; }


        /// <summary>
        /// 当前已发红包数
        /// </summary>
        public int CurrentPackageCount { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }


        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }


        /// <summary>
        /// 活动的唯一标识
        /// </summary>
        public string RedPacketIdentity { get; set; }
    }
}
