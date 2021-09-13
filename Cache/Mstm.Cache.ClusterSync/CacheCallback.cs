using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{
    /// <summary>
    /// 缓存变更后的回调委托原型
    /// </summary>
    /// <typeparam name="T">参数类型</typeparam>
    /// <param name="param">参数值</param>
    public delegate void CacheCallback<T>(T param);
}
