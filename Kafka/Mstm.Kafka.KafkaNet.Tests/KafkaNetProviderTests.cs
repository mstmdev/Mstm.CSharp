using Mstm.Kafka.Core;
using System;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace Mstm.Kafka.KafkaNet.Tests
{
    public class KafkaNetProviderTests
    {
        private IKafkaProvider _provider;
        private static string _kafkaTopic;
        private static string _kafka_conns;


        public KafkaNetProviderTests()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile("appsettings.json").Build();
            _kafkaTopic = config["KafKa:Topic"];
            _kafka_conns = config["KafKa:Conns"];
            _provider = new KafkaNetProvider(_kafkaTopic, _kafka_conns);
        }


        /// <summary>
        /// 异步发送消息测试
        /// </summary>
        [Fact]
        public void SendMessageAsyncTest_Success()
        {
            _provider.SendMessageAsync("Hello Test Async");
            Thread.Sleep(5000);
        }

        /// <summary>
        /// 同步发送消息测试
        /// </summary>
        [Fact]
        public void SendMessageSyncTest_Success()
        {
            _provider.SendMessageSync("Hello Test Sync");
        }


        /// <summary>
        /// 异步发送消息测试
        /// </summary>
        [Fact]
        public void SendObjectAsyncTest_Success()
        {
            _provider.SendObjectAsync(new { UserName = "Tom", Age = 16, Address = "北京", Time = DateTime.Now });
            Thread.Sleep(5000);
        }

        /// <summary>
        /// 同步发送消息测试
        /// </summary>
        [Fact]
        public void SendObjectSyncTest_Success()
        {
            _provider.SendObjectSync(new { UserName = "Marry", Age = 17, Address = "河北", Time = DateTime.Now });
        }

        /// <summary>
        /// 异步发送消息测试
        /// </summary>
        [Fact]
        public void SendObjectAsyncTest_MutiObject_Success()
        {
            _provider.SendObjectAsync(new { UserName = "Tom", Age = 16, Address = "北京", Time = DateTime.Now },
                                      new { UserName = "五五", Age = 23, Address = "天津", Time = DateTime.Now });
            Thread.Sleep(5000);
        }

        /// <summary>
        /// 同步发送消息测试
        /// </summary>
        [Fact]
        public void SendObjectSyncTest_MutiObject_Success()
        {
            _provider.SendObjectSync(new { UserName = "Marry", Age = 17, Address = "河北", Time = DateTime.Now },
                                     new { UserName = "李四", Age = 23, Address = "河南", Time = DateTime.Now });
        }

        /// <summary>
        /// 接收消息测试
        /// </summary>
        [Fact]
        public void ReceiveMessageTest_Success()
        {
            var task = Task.Run(() =>
             {
                 _provider.ReceiveMessage((msg) =>
                 {
                     Console.WriteLine(msg);
                 });
             });

            task.Wait(1000 * 10);
        }


        /// <summary>
        /// 获取主题测试
        /// </summary>
        [Fact]
        public void GetTopicTest_Success()
        {
            string topicName = "TestForMstm";
            KafkaTopic topic = _provider.GetTopic(topicName);
            topic.ShouldNotBeNull();
        }
    }
}
