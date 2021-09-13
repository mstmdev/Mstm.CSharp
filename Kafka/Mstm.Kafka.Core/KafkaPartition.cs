using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Kafka.Core
{

    /// <summary>
    /// Kafka分区信息
    /// </summary>
    public class KafkaPartition
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public short ErrorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> Isrs { get; set; }

        /// <summary>
        /// Leader的Id号
        /// </summary>
        public int LeaderId { get; set; }

        /// <summary>
        /// 分区Id
        /// </summary>
        public int PartitionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> Replicas { get; set; }
    }
}
