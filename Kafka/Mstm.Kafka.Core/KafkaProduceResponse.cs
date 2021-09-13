using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Kafka.Core
{

    /// <summary>
    /// Kafka生产者响应结果
    /// </summary>
    public class KafkaProduceResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public short Error { get; set; }

        /// <summary>
        /// 偏移
        /// </summary>
        public long Offset { get; set; }

        /// <summary>
        /// 分区Id
        /// </summary>
        public int PartitionId { get; set; }

        /// <summary>
        /// 主题名称
        /// </summary>
        public string Topic { get; set; }
    }
}
