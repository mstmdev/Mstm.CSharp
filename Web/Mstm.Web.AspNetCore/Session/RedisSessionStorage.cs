using Mstm.NoSQL.Redis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Web.AspNetCore.Session
{
    /// <summary>
    /// 使用Redis作为Session存储方案
    /// </summary>
    internal class RedisSessionStorage : ISessionStorage
    {
        private IRedisProvider _redisCache;
        private const string RedisProviderGroup = "AspNetCoreSessionCore";

        public RedisSessionStorage()
        {
            _redisCache = RedisFactory.GetProvider(RedisProviderGroup);
        }

        public T Get<T>(string key)
        {
            T obj = _redisCache.GetData<T>(key);
            return obj;
        }

        public string GetString(string key)
        {
            return Get<string>(key);
        }

        public void Set<T>(string key, T value, int cacheMinutes = 1440)
        {
            _redisCache.SetData<T>(key, value, cacheMinutes);
        }

        public void SetString(string key, string value, int cacheMinutes = 1440)
        {
            Set<string>(key, value, cacheMinutes);
        }
    }
}
