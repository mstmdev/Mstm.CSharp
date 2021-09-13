using Mstm.Cache.ClusterSync.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{

    /// <summary>
    /// 默认缓存提供器工厂
    /// 项目中直接使用该工厂操作缓存
    /// </summary>
    public sealed class DefaultCacheFactory
    {
        private static ICacheProviderFactory _factory;
        private static object lockObj = new object();

        /// <summary>
        /// 默认缓存操作组件
        /// </summary>
        public static ICacheProvider DefaultCache
        {
            get
            {
                if (_factory == null)
                {
                    lock (lockObj)
                    {
                        if (_factory == null)
                        {
                            _factory = GlobalCacheProviderFactory.Instance.GetDefaultCacheProviderFactory();
                        }
                    }
                }
                return _factory.GetCacheProvider();

            }
        }

        /// <summary>
        /// 重置默认缓存组件
        /// </summary>
        public static void Reset()
        {
            lock (lockObj)
            {
                _factory = null;
            }
        }
    }
}
