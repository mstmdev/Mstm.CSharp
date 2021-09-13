using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync.Core
{

    /// <summary>
    /// 缓存提供器工厂接口
    /// </summary>
    public interface ICacheProviderFactory
    {

        /// <summary>
        /// 获取缓存提供器
        /// </summary>
        /// <returns>ICacheProvider对象实例</returns>
        ICacheProvider GetCacheProvider();
    }
}
