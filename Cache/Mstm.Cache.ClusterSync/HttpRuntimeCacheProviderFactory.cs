using Mstm.Cache.ClusterSync.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{
    /// <summary>
    /// HttpRuntimeCacheProvider的工厂类
    /// </summary>
    public class HttpRuntimeCacheProviderFactory : ICacheProviderFactory
    {

        /// <summary>
        /// 获取缓存提供器
        /// </summary>
        /// <returns>HttpRuntimeCacheProvider对象实例</returns>
        public ICacheProvider GetCacheProvider()
        {
            return new HttpRuntimeCacheProvider();
        }
    }
}
