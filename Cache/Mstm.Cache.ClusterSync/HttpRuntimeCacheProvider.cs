using Mstm.Cache.ClusterSync.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mstm.Cache.ClusterSync
{

    /// <summary>
    /// 封装了HttpRuntime.Cache的缓存提供器
    /// </summary>
    internal class HttpRuntimeCacheProvider : AbstractCacheProvider
    {
        //内部真正存储数据的缓存结构
        private System.Web.Caching.Cache _innerCache = HttpRuntime.Cache;

        /// <summary>
        /// 构造函数
        /// </summary>
        public HttpRuntimeCacheProvider()
            : base()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dependency">缓存依赖操作接口</param>
        public HttpRuntimeCacheProvider(ICacheDependency dependency)
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
            DateTime absoluteExpiration = policy.AbsoluteExpiration == TimeSpan.Zero ? System.Web.Caching.Cache.NoAbsoluteExpiration : DateTime.Now.Add(policy.AbsoluteExpiration);
            TimeSpan slidingExpiration = policy.SlidingExpiration;
            _innerCache.Insert(node, value, null, absoluteExpiration, slidingExpiration);
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
