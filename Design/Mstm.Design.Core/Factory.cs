using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Design.Core
{

    /// <summary>
    /// 工厂构造器
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TProvider"></typeparam>
    public abstract class Factory<TKey, TProvider> : IFactory<TKey, TProvider>
    {
        private static Dictionary<TKey, TProvider> _innerDict;

        protected abstract Dictionary<TKey, TProvider> Init();


        /// <summary>
        /// 获取指定的Provider
        /// </summary>
        /// <param name="key">获取Provider的键</param>
        /// <returns>TProvider实例，如果未获取到则返回默认值</returns>
        public TProvider GetProvider(TKey key)
        {
            if (_innerDict == null)
            {
                _innerDict = Init();
            }
            if (key == null || _innerDict == null || _innerDict.ContainsKey(key) == false)
            {
                return default(TProvider);
            }
            else
            {
                return _innerDict[key];
            }
        }
    }
}
