using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Kafka.Core
{

    /// <summary>
    /// 消费者接口
    /// </summary>
    public interface IConsumer
    {

        /// <summary>
        /// 接收并处理消息
        /// </summary>
        /// <param name="action">处理消息的委托</param>
        void ReceiveMessage(Action<string> action);
    }
}
