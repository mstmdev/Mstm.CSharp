using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Design.Core
{
    /// <summary>
    /// 工厂接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TProvider"></typeparam>
    public interface IFactory<TKey, TProvider>
    {
        /// <summary>
        /// 获取类型实现的实例
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TProvider GetProvider(TKey key);
    }
}
