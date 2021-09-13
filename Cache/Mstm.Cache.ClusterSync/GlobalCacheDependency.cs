using Mstm.Cache.ClusterSync.Core;
using Rabbit.Zookeeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{
    /// <summary>
    /// 全局默认的缓存依赖组件配置
    /// </summary>
    public sealed class GlobalCacheDependency
    {
        private GlobalCacheDependency() { }
        private static GlobalCacheDependency _instance = new GlobalCacheDependency();
        private ICacheDependency _dependency;

        /// <summary>
        /// 当前类型的实例 单例模式
        /// </summary>
        public static GlobalCacheDependency Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 获取当前默认的缓存依赖接口
        /// </summary>
        /// <returns>缓存依赖接口实例</returns>
        public ICacheDependency GetDefaultCacheDependency()
        {
            _dependency = _dependency ?? new ZKCacheDependency(GlobalZKCacheDependencyOption.Instance.GetDefaultZKCacheDependencyOption());
            return _dependency;
        }


        /// <summary>
        /// 设置当前默认的缓存依赖接口
        /// </summary>
        /// <param name="dependency">缓存依赖接口</param>
        public void SetDefaultCacheDependency(ICacheDependency dependency)
        {
            _dependency = dependency;
        }

    }
}
