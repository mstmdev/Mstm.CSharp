using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Kafka.Core
{

    /// <summary>
    /// 生产者接口
    /// </summary>
    public interface IProducer
    {

        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <param name="msgs">要发送的消息集合</param>
        void SendMessageAsync(params string[] msgs);

        /// <summary>
        /// 同步发送消息
        /// </summary>
        /// <param name="msgs">要发送的消息集合</param>
        /// <returns>响应集合</returns>
        List<KafkaProduceResponse> SendMessageSync(params string[] msgs);

        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <param name="data">要发送的消息对象</param>
        void SendObjectAsync<T>(params T[] datas);

        /// <summary>
        /// 同步发送消息
        /// </summary>
        /// <param name="data">要发送的消息对象</param>
        /// <returns>响应集合</returns>
        List<KafkaProduceResponse> SendObjectSync<T>(params T[] datas);

        /// <summary>
        /// 获取主题信息
        /// </summary>
        /// <param name="topic">主题名称</param>
        /// <returns>主题对象</returns>
        KafkaTopic GetTopic(string topic);
    }
}
