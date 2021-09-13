using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Kafka.Core
{

    /// <summary>
    /// Kafka服务提供接口
    /// </summary>
    public interface IKafkaProvider : IConsumer, IProducer
    {

    }
}
