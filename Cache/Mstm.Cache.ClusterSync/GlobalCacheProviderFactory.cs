using Mstm.Cache.ClusterSync.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{
    /// <summary>
    /// 全局默认的缓存提供器工厂配置
    /// </summary>
    public sealed class GlobalCacheProviderFactory
    {
        private static GlobalCacheProviderFactory _instance = new GlobalCacheProviderFactory();
        private ICacheProviderFactory _factory;
        private GlobalCacheProviderFactory() { }


        /// <summary>
        /// 获取GlobalCacheFactory实例 单例模式
        /// </summary>
        public static GlobalCacheProviderFactory Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// 获取默认的缓存提供器工厂实例
        /// </summary>
        /// <returns>缓存提供器工厂实例</returns>
        public ICacheProviderFactory GetDefaultCacheProviderFactory()
        {
            return _factory ?? new HttpRuntimeCacheProviderFactory();
        }

        /// <summary>
        ///  设置默认的缓存提供器工厂实例
        /// </summary>
        /// <param name="factory">缓存提供器工厂实例</param>
        public void SetDefaultCacheProviderFactory(ICacheProviderFactory factory)
        {
            _factory = factory;
        }
    }
}
