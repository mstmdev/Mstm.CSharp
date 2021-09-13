using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{

    /// <summary>
    /// 全局默认的缓存策略配置
    /// </summary>
    public sealed class GlobalCachePolicy
    {
        private GlobalCachePolicy() { }
        private static GlobalCachePolicy _instance = new GlobalCachePolicy();

        private CachePolicy _policy;



        /// <summary>
        /// 当前类型的实例 单例模式
        /// </summary>
        public static GlobalCachePolicy Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// 获取当前默认缓存策略配置
        /// </summary>
        /// <returns>默认缓存策略配置实例</returns>
        public CachePolicy GetDefaultCachePolicy()
        {
            return _policy ?? new CachePolicy()
            {
                AbsoluteExpiration = TimeSpan.Zero,
                SlidingExpiration = TimeSpan.FromSeconds(1800),
                Priority = CachePriority.Default,
                RemovedCallback = null,
                UpdateCallback = null

            };
        }

        /// <summary>
        ///  设置当前默认缓存策略配置
        /// </summary>
        /// <param name="policy">缓存策略配置实例</param>
        public void SetDefaultCachePolicy(CachePolicy policy)
        {
            _policy = policy;
        }
    }
}
