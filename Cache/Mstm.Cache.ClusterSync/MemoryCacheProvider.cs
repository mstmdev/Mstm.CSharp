using Mstm.Cache.ClusterSync.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{
    /// <summary>
    /// 封装了MemoryCache的缓存提供器
    /// </summary>
    internal class MemoryCacheProvider : AbstractCacheProvider
    {
        //内部真正存储数据的缓存结构
        private MemoryCache _innerCache = MemoryCache.Default;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MemoryCacheProvider()
            : base()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dependency">缓存依赖操作接口</param>
        public MemoryCacheProvider(ICacheDependency dependency)
            : base(dependency)
        {
        }




        #region 抽象类中缓存操作的具体实现
        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="value">缓存数据</param>
        /// <param name="policy">缓存策略</param>
        public override void InsertCore(string node, object value, CachePolicy policy)
        {
            DateTimeOffset absoluteExpiration = policy.AbsoluteExpiration == TimeSpan.Zero ? DateTimeOffset.MaxValue : DateTimeOffset.Now.Add(policy.AbsoluteExpiration);
            TimeSpan slidingExpiration = policy.SlidingExpiration;
            _innerCache.Set(node, value, new CacheItemPolicy() { SlidingExpiration = slidingExpiration, AbsoluteExpiration = absoluteExpiration });
        }


        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>缓存数据</returns>
        public override object GetCore(string node)
        {
            return _innerCache.Get(node);
        }


        /// <summary>
        /// 移除缓存数据
        /// </summary>
        /// <param name="node">节点名称</param>
        public override void RemoveCacheCore(string node)
        {
            //直接清除本地内存
            this._innerCache.Remove(node);
        }

        #endregion

    }
}
