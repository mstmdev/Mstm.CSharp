using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using Mstm.Json.Core;
using Mstm.Json.Newtonsoft;
using Mstm.Kafka.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Kafka.KafkaNet
{
    /// <summary>
    /// Kafka操作组件
    /// </summary>
    public class KafkaNetProvider : IKafkaProvider
    {

        private KafkaOptions _options;
        private BrokerRouter _router;
        private Producer _producer;
        private Consumer _consumer;
        private string _topicName;
        private IJsonProvider _jsonProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="topic">主题名称</param>
        /// <param name="urls">Kakfa主机集合</param>
        public KafkaNetProvider(string topic, params string[] urls)
        {
            if (urls == null || urls.Length <= 0)
            {
                throw new ArgumentNullException("urls", "未配置Kafka服务器地址！");
            }

            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentNullException("topic", "主题名称不能为空！");
            }

            _topicName = topic;
            _options = new KafkaOptions(ConvertToUrl(urls).ToArray());
            _router = new BrokerRouter(_options);
            _producer = new Producer(_router);
            _consumer = new Consumer(new ConsumerOptions(_topicName, _router));
            _jsonProvider = JsonFactory.GetProvider();
        }


        #region IConsumer

        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="action">接受到消息后回调处理</param>

        public void ReceiveMessage(Action<string> action)
        {
            foreach (var message in _consumer.Consume())
            {
                string msgValue = System.Text.Encoding.UTF8.GetString(message.Value);
                action.Invoke(msgValue);
            }
        }

        #endregion


        #region IProducer

        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <param name="msgs">待发送的消息集合</param>

        public void SendMessageAsync(params string[] msgs)
        {
            ValidateMessageIsNotNull(msgs);
            _producer.SendMessageAsync(_topicName, ConvertToMessage(msgs));
        }

        /// <summary>
        /// 同步发送消息
        /// </summary>
        /// <param name="msgs">待发送的消息集合</param>
        /// <returns>发送的响应集合</returns>
        public List<KafkaProduceResponse> SendMessageSync(params string[] msgs)
        {
            ValidateMessageIsNotNull(msgs);
            Task<List<ProduceResponse>> task = _producer.SendMessageAsync(_topicName, ConvertToMessage(msgs));
            task.Wait();
            if (task.Status != TaskStatus.RanToCompletion)
            {
                return null;
            }
            List<KafkaProduceResponse> list = new List<KafkaProduceResponse>();
            task.Result.ForEach(response =>
            {
                list.Add(new KafkaProduceResponse()
                {
                    Error = response.Error,
                    Offset = response.Offset,
                    PartitionId = response.PartitionId,
                    Topic = response.Topic
                });
            });
            return list;
        }

        /// <summary>
        /// 异步发送指定的对象消息
        /// </summary>
        /// <typeparam name="T">发送的对象类型</typeparam>
        /// <param name="datas">发送的对象实例</param>
        public void SendObjectAsync<T>(params T[] datas)
        {
            ValidateMessageIsNotNull(datas);
            string[] jsons = SendObject<T>(datas);
            SendMessageAsync(jsons.ToArray());
        }

        /// <summary>
        /// 同步发送指定的对象消息
        /// </summary>
        /// <typeparam name="T">发送的对象类型</typeparam>
        /// <param name="datas">发送的对象实例</param>
        /// <returns>发送的响应集合</returns>
        public List<KafkaProduceResponse> SendObjectSync<T>(params T[] datas)
        {
            ValidateMessageIsNotNull(datas);
            string[] jsons = SendObject<T>(datas);
            var responses = SendMessageSync(jsons.ToArray());
            return responses;
        }

        /// <summary>
        /// 获取主题信息
        /// </summary>
        /// <param name="topic">主题名称</param>
        /// <returns>主题信息</returns>
        public KafkaTopic GetTopic(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
            {
                throw new ArgumentNullException("topic", "主题名称不能为空！");
            }
            var topicTemp = _producer.GetTopic(topic);
            return new KafkaTopic()
            {
                ErrorCode = topicTemp.ErrorCode,
                Name = topicTemp.Name,
                Partitions = ConvertToKafkaPartition(topicTemp.Partitions).ToList()
            };
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 将URL字符串集合转化为Uri集合
        /// </summary>
        /// <param name="urls"></param>
        /// <returns></returns>
        private IEnumerable<Uri> ConvertToUrl(IEnumerable<string> urls)
        {
            if (urls == null || urls.Count() == 0) { yield break; }
            foreach (var urlStr in urls)
            {
                yield return new Uri(urlStr);
            }
        }

        /// <summary>
        /// 将字符串消息集合转化为Message集合
        /// </summary>
        /// <param name="msgs"></param>
        /// <returns></returns>
        private IEnumerable<Message> ConvertToMessage(IEnumerable<string> msgs)
        {
            if (msgs == null || msgs.Count() == 0) { yield break; }
            foreach (var msg in msgs)
            {
                yield return new Message(msg);
            }
        }

        /// <summary>
        /// 将第三方的kafka分区信息转化为本地的分区信息
        /// </summary>
        /// <param name="partitions"></param>
        /// <returns></returns>
        private IEnumerable<KafkaPartition> ConvertToKafkaPartition(IEnumerable<Partition> partitions)
        {
            if (partitions == null || partitions.Count() == 0) { yield break; }
            foreach (var partition in partitions)
            {
                yield return new KafkaPartition()
                {
                    ErrorCode = partition.ErrorCode,
                    Isrs = partition.Isrs,
                    LeaderId = partition.LeaderId,
                    PartitionId = partition.PartitionId,
                    Replicas = partition.Replicas
                };
            }
        }

        /// <summary>
        /// 将指定的消息对象集合序列化为Json字符串集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <returns></returns>
        private string[] SendObject<T>(T[] datas)
        {
            if (datas == null)
            {
                throw new ArgumentNullException("datas", "发送的数据不能为空！");
            }
            List<string> jsons = new List<string>();
            datas.ToList().ForEach(data =>
            {
                string json = _jsonProvider.SerializeObject<T>(data);
                if (json == null) { throw new Exception("序列化发送数据失败！"); }
                jsons.Add(json);
            });
            return jsons.ToArray();
        }

        /// <summary>
        /// 校验消息是否为空
        /// </summary>
        /// <param name="msg"></param>
        private void ValidateMessageIsNotNull(Object msg)
        {
            if (msg == null)
            {
                throw new ArgumentException("发送的消息不能为空！");
            }
        }
        #endregion

    }
}
