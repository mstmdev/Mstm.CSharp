using Mstm.Cache.ClusterSync.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using System.Threading;
using System.Configuration;

namespace Mstm.Cache.ClusterSync.Tests
{
    public class HttpRuntimeCacheProviderTests : BaseCacheProviderTests
    {
        public HttpRuntimeCacheProviderTests()
        {
            string zkConns = ConfigurationManager.AppSettings["zk_cache_quorums"];
            GlobalCacheProviderFactory.Instance.SetDefaultCacheProviderFactory(new HttpRuntimeCacheProviderFactory());
            GlobalZKCacheDependencyOption.Instance.SetDefaultZKCacheDependencyOption(zkConns);
            cacheProvider = DefaultCacheFactory.DefaultCache;
            cacheProvider.RootNode = rootNode;
        }


        public override void RootNodeTest()
        {
            base.RootNodeTest();
        }

        public override void AddTest()
        {
            base.AddTest();
        }

        public override void AddWithCachePolicy_AbsoluteExpiration_IsExpire_Test()
        {
            base.AddWithCachePolicy_AbsoluteExpiration_IsExpire_Test();
        }

        public override void AddWithCachePolicy_AbsoluteExpiration_IsNotExpire_Test()
        {
            base.AddWithCachePolicy_AbsoluteExpiration_IsNotExpire_Test();
        }

        public override void AddWithCachePolicy_SlidingExpiration_IsExpire_Test()
        {
            base.AddWithCachePolicy_SlidingExpiration_IsExpire_Test();
        }

        public override void AddWithCachePolicy_SlidingExpiration_IsNotExpire_Test()
        {
            base.AddWithCachePolicy_SlidingExpiration_IsNotExpire_Test();
        }

        public override void ClearAllTest()
        {
            base.ClearAllTest();
        }

        public override void ClearOneTest()
        {
            base.ClearOneTest();
        }

        public override void ClearTest()
        {
            base.ClearTest();
        }

        public override void GetTest()
        {
            base.GetTest();
        }
    }
}
