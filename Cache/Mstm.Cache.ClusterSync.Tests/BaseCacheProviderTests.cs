using Mstm.Cache.ClusterSync.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using System.Threading;

namespace Mstm.Cache.ClusterSync.Tests
{
    public class BaseCacheProviderTests : ICacheProviderTests
    {
        protected ICacheProvider cacheProvider;
        protected string rootNode = "/mstmdev_cache_test";



        /// <summary>
        /// 根节点名称测试
        /// </summary>
        [Fact]
        public virtual void RootNodeTest()
        {
            cacheProvider.RootNode.ShouldBe(rootNode);
        }


        /// <summary>
        /// 清理所有缓存测试
        /// </summary>
        [Fact]
        public virtual void ClearAllTest()
        {
            string node1 = "/ClearAll1";
            string value1 = "ClearAllTestValue1";
            string node2 = "/ClearAll2";
            string value2 = "ClearAllTestValue2";
            string node3 = "/ClearAll3";
            string value3 = "ClearAllTestValue3";
            cacheProvider.Add(node1, value1).Wait();
            cacheProvider.Add(node2, value2).Wait();
            cacheProvider.Add(node3, value3).Wait();
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            cacheProvider.Get<string>(node3).ShouldBe(value3);
            cacheProvider.ClearAll().Wait();
            //回调是异步的不能保证已经执行完成，这里用Sleep进行一定的模拟
            Thread.Sleep(5000);
            cacheProvider.Get<string>(node1).ShouldBeNull();
            cacheProvider.Get<string>(node2).ShouldBeNull();
            cacheProvider.Get<string>(node3).ShouldBeNull();
        }

        /// <summary>
        /// 递归清理指定的节点及其子节点下的缓存
        /// </summary>
        [Fact]
        public virtual void ClearTest()
        {
            string node1 = "/ClearTest1";
            string value1 = "ClearTestValue1";
            string node2 = "/ClearTest1/Inner";
            string value2 = "ClearTestValue2";
            cacheProvider.Add(node1, value1).Wait();
            cacheProvider.Add(node2, value2).Wait();
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            cacheProvider.Clear(node1).Wait();
            //回调是异步的不能保证已经执行完成，这里用Sleep进行一定的模拟
            Thread.Sleep(5000);
            cacheProvider.Get<string>(node1).ShouldBeNull();
            cacheProvider.Get<string>(node2).ShouldBeNull();
        }

        /// <summary>
        /// 仅清理指定节点的缓存
        /// </summary>
        [Fact]
        public virtual void ClearOneTest()
        {
            string node1 = "/ClearOneTest1";
            string value1 = "ClearOneTestValue1";
            string node2 = "/ClearOneTest2";
            string value2 = "ClearOneTestValue2";
            cacheProvider.Add(node1, value1).Wait();
            cacheProvider.Add(node2, value2).Wait();
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            cacheProvider.ClearOne(node1).Wait();
            //回调是异步的不能保证已经执行完成，这里用Sleep进行一定的模拟
            Thread.Sleep(5000);
            cacheProvider.Get<string>(node1).ShouldBeNull();
            cacheProvider.Get<string>(node2).ShouldBe(value2);
        }

        /// <summary>
        /// 添加缓存测试
        /// </summary>
        [Fact]
        public virtual void AddTest()
        {
            string node1 = "/AddTest";
            string value1 = "AddTestValue1";
            string node2 = "/AddTest2";
            string value2 = "AddTestValue2";
            cacheProvider.Add(node1, value1).Wait();
            cacheProvider.Add(node2, value2).Wait();
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
        }

        /// <summary>
        /// 添加绝对过期时间缓存测试，数据过期
        /// </summary>
        [Fact]
        public virtual void AddWithCachePolicy_AbsoluteExpiration_IsExpire_Test()
        {
            string node1 = "/AddWithCachePolicy_AbsoluteExpiration_IsExpire_Test1";
            string value1 = "AddWithCachePolicy_AbsoluteExpiration_IsExpire_TestValue1";
            string node2 = "/AddWithCachePolicy_AbsoluteExpiration_IsExpire_Test2";
            string value2 = "AddWithCachePolicy_AbsoluteExpiration_IsExpire_TestValue2";
            //三秒后绝对过期
            var policy = new CachePolicy()
            {
                AbsoluteExpiration = TimeSpan.FromSeconds(3)
            };
            cacheProvider.Add(node1, value1, policy).Wait();
            cacheProvider.Add(node2, value2, policy).Wait();
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            Thread.Sleep(3000);
            cacheProvider.Get<string>(node1).ShouldBeNull();
            cacheProvider.Get<string>(node2).ShouldBeNull();
        }


        /// <summary>
        /// 添加绝对过期时间缓存测试，数据未过期
        /// </summary>
        [Fact]
        public virtual void AddWithCachePolicy_AbsoluteExpiration_IsNotExpire_Test()
        {
            string node1 = "/AddWithCachePolicy_AbsoluteExpiration_IsNotExpire_Test1";
            string value1 = "AddWithCachePolicy_AbsoluteExpiration_IsNotExpire_TestValue1";
            string node2 = "/AddWithCachePolicy_AbsoluteExpiration_IsNotExpire_Test2";
            string value2 = "AddWithCachePolicy_AbsoluteExpiration_IsNotExpire_TestValue2";
            //三秒后绝对过期
            var policy = new CachePolicy()
            {
                AbsoluteExpiration = TimeSpan.FromSeconds(3)
            };
            cacheProvider.Add(node1, value1, policy).Wait();
            cacheProvider.Add(node2, value2, policy).Wait();
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            Thread.Sleep(1800);
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
        }

        /// <summary>
        /// 添加滑动过期时间缓存测试，数据过期
        /// </summary>
        [Fact]
        public virtual void AddWithCachePolicy_SlidingExpiration_IsExpire_Test()
        {
            string node1 = "/AddWithCachePolicy_SlidingExpiration_IsExpire_Test1";
            string value1 = "AddWithCachePolicy_SlidingExpiration_IsExpire_TestValue1";
            string node2 = "/AddWithCachePolicy_SlidingExpiration_IsExpire_Test2";
            string value2 = "AddWithCachePolicy_SlidingExpiration_IsExpire_TestValue2";
            //三秒后滑动过期
            var policy = new CachePolicy()
            {
                SlidingExpiration = TimeSpan.FromSeconds(3)
            };
            cacheProvider.Add(node1, value1, policy).Wait();
            cacheProvider.Add(node2, value2, policy).Wait();
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            Thread.Sleep(3000);
            cacheProvider.Get<string>(node1).ShouldBeNull();
            cacheProvider.Get<string>(node2).ShouldBeNull();
        }

        /// <summary>
        /// 添加滑动过期时间缓存测试，数据未过期
        /// </summary>
        [Fact]
        public virtual void AddWithCachePolicy_SlidingExpiration_IsNotExpire_Test()
        {
            string node1 = "/AddWithCachePolicy_SlidingExpiration_IsNotExpire_Test1";
            string value1 = "AddWithCachePolicy_SlidingExpiration_IsNotExpire_TestValue1";
            string node2 = "/AddWithCachePolicy_SlidingExpiration_IsNotExpire_Test2";
            string value2 = "AddWithCachePolicy_SlidingExpiration_IsNotExpire_TestValue2";
            //三秒后滑动过期
            var policy = new CachePolicy()
            {
                SlidingExpiration = TimeSpan.FromSeconds(3)
            };
            cacheProvider.Add(node1, value1, policy).Wait();
            cacheProvider.Add(node2, value2, policy).Wait();
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            Thread.Sleep(2000);
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            Thread.Sleep(2000);
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
        }


        /// <summary>
        /// 获取缓存测试
        /// </summary>
        [Fact]
        public virtual void GetTest()
        {
            string node1 = "/GetTest";
            string value1 = "GetTestValue1";
            string node2 = "/GetTest2";
            string value2 = "GetTestValue2";
            cacheProvider.Add(node1, value1).Wait();
            cacheProvider.Add(node2, value2).Wait();
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
            cacheProvider.Get<string>(node1).ShouldBe(value1);
            cacheProvider.Get<string>(node2).ShouldBe(value2);
        }
    }
}
