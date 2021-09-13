using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Kafka.Core
{

    /// <summary>
    /// 主题
    /// </summary>
    public class KafkaTopic
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public short ErrorCode { get; set; }

        /// <summary>
        /// 主题名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分区集合
        /// </summary>
        public List<KafkaPartition> Partitions { get; set; }

    }
}
