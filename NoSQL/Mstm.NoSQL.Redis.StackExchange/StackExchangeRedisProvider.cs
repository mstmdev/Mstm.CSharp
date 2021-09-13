using Mstm.Json.Core;
using Mstm.Json.Newtonsoft;
using Mstm.NoSQL.Redis.Core;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.StackExchange
{
    /// <summary>
    /// StackExchange的Redis客户端提供器
    /// </summary>
    public class StackExchangeRedisProvider : AbstractRedisProvider
    {

        ConnectionMultiplexer _redisConn;
        IDatabase _redisDB;
        IJsonProvider _jsonProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connStr">Redis连接字符串</param>
        /// <param name="db">DB信息</param>
        public StackExchangeRedisProvider(string connStr, int db = 0)
        {
            _jsonProvider = JsonFactory.GetProvider();

            if (string.IsNullOrWhiteSpace(connStr))
            {
                Logger.Error("Redis连接字符串配置错误");
                throw new ArgumentNullException("connStr", "Redis连接字符串配置错误！");
            }
            try
            {
                _redisConn = ConnectionMultiplexer.Connect(connStr);
            }
            catch (Exception ex)
            {
                Logger.Error("Redis连接超时，请检查连接配置！", ex);
                throw new TimeoutException("Redis连接超时，请检查连接配置！");
            }
            _redisDB = _redisConn.GetDatabase(db);
        }


        #region IRedisString

        public override string GetStringCore(string key)
        {
            return _redisDB.StringGet(key);
        }

        public override void SetStringCore(string key, string value, double cacheMinutes = -1)
        {
            _redisDB.StringSet(key, value, GetExpireTime(cacheMinutes));
        }

        public override void SetDataCore<T>(string key, T value, double cacheMinutes = -1)
        {
            var jsonStr = _jsonProvider.SerializeObject(value);
            SetString(key, jsonStr, cacheMinutes);
        }

        public override T GetDataCore<T>(string key)
        {
            try
            {
                string jsonStr = GetString(key);
                return string.IsNullOrWhiteSpace(jsonStr) ? default(T) : _jsonProvider.DeserializeObject<T>(jsonStr);
            }
            catch (Exception)
            {
                return default(T);
            }
        }


        public override bool IsExistStringCore(string key)
        {
            bool isExist = _redisDB.KeyExists(key);
            if (isExist)
            {
                isExist = _redisDB.KeyType(key) == RedisType.String;
            }
            return isExist;
        }

        public override bool DeleteStringCore(string key)
        {
            return _redisDB.KeyDelete(key);
        }

        public override string AppendStringCore(string key, string appendStr)
        {
            _redisDB.StringAppend(key, appendStr);
            return GetString(key);
        }


        public override byte[] GetBytesCore(string key)
        {
            return _redisDB.StringGet(key);
        }


        public override void SetBytesCore(string key, byte[] value, double cacheMinutes = -1)
        {
            _redisDB.StringSet(key, value, GetExpireTime(cacheMinutes));
        }


        #endregion



        #region IRedisKey

        public override bool IsExistKeyCore(string key)
        {
            return _redisDB.KeyExists(key);
        }


        public override long DeleteKeyCore(params string[] keys)
        {
            if (keys == null || keys.Length == 0) { return 0; }
            List<RedisKey> redisKeys = new List<RedisKey>();
            keys.ToList().ForEach((item) =>
            {
                redisKeys.Add(item);
            });
            return _redisDB.KeyDelete(redisKeys.ToArray());
        }

        public override RedisDataType GetKeyTypeCore(string key)
        {
            return (RedisDataType)_redisDB.KeyType(key);
        }


        public override string GetRandomKeyCore()
        {
            return _redisDB.KeyRandom();
        }

        public override int GetTTLCore(string key)
        {
            var timeSpan = _redisDB.KeyTimeToLive(key);
            return timeSpan == null ? 0 : (int)Math.Ceiling(timeSpan.Value.TotalSeconds);
        }

        public override bool PersistKeyCore(string key)
        {
            return _redisDB.KeyPersist(key);
        }

        public override bool ReNameKeyWithCoverCore(string oldKey, string newKey)
        {
            return _redisDB.KeyRename(oldKey, newKey, When.Always);
        }

        public override bool ReNameKeyWithOutCoverCore(string oldKey, string newKey)
        {
            return _redisDB.KeyRename(oldKey, newKey, When.NotExists);
        }

        public override bool SetExpireKeyCore(string key, int seconds)
        {
            return _redisDB.KeyExpire(key, TimeSpan.FromSeconds(seconds));
        }

        public override bool SetExpireatKeyCore(string key, long timestamp)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime time = startTime.AddMilliseconds(timestamp);
            return _redisDB.KeyExpire(key, time);
        }

        #endregion


        #region 私有方法
        /// <summary>
        /// 构建过期时间
        /// </summary>
        /// <param name="cacheMinutes">过期的分钟数</param>
        /// <returns></returns>
        private TimeSpan? GetExpireTime(double cacheMinutes)
        {
            TimeSpan? expire = null;
            if (cacheMinutes > 0) { expire = TimeSpan.FromMinutes(cacheMinutes); }
            return expire;
        }
        #endregion
    }
}
