using Mstm.Cache.ClusterSync.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{

    /// <summary>
    /// 缓存策略对象
    /// </summary>
    public class CachePolicy
    {

        /// <summary>
        /// 相对于当前时间的绝对过期时间偏移量
        /// </summary>
        public TimeSpan AbsoluteExpiration { get; set; }

        /// <summary>
        /// 滑动过期时间偏移量
        /// </summary>
        public TimeSpan SlidingExpiration { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public CachePriority Priority { get; set; }

        /// <summary>
        /// 缓存删除时的回调操作（暂未使用）
        /// </summary>
        public CacheCallback<string> RemovedCallback { get; set; }

        /// <summary>
        /// 缓存更新时的回调操作（暂未使用）
        /// </summary>
        public CacheCallback<string> UpdateCallback { get; set; }

        /// <summary>
        /// 创建的时候是否监听子节点
        /// 如果为true，则更节点数据更新时，子节点的缓存依赖全部会更新
        /// 默认为false，只更新当前指定的节点
        /// </summary>
        public bool IsListenChildren { get; set; }
    }
}
