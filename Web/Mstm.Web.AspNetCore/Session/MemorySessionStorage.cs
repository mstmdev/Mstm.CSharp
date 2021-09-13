using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Mstm.Web.AspNetCore.Session
{
    /// <summary>
    /// 使用内存作为Session存储方案
    /// </summary>
    internal class MemorySessionStorage : ISessionStorage
    {
        private static readonly ConcurrentDictionary<string, object> _dict = new ConcurrentDictionary<string, object>();

        public T Get<T>(string key)
        {
            object value;
            bool isSuccess = _dict.TryGetValue(key, out value);
            if (isSuccess == false) { return default(T); }
            return (T)value;
        }

        public string GetString(string key)
        {
            object value;
            bool isSuccess = _dict.TryGetValue(key, out value);
            if (isSuccess == false || value == null) { return null; }
            return value.ToString();
        }

        public void Set<T>(string key, T value, int cacheMinutes = 1440)
        {
            if (_dict.ContainsKey(key))
            {
                object removeValue;
                bool isSuccess = _dict.TryRemove(key, out removeValue);
                if (isSuccess)
                {
                    _dict.TryAdd(key, value);
                }
            }
            else
            {
                _dict.TryAdd(key, value);
            }
        }

        public void SetString(string key, string value, int cacheMinutes = 1440)
        {
            Set<string>(key, value, cacheMinutes);
        }
    }
}
