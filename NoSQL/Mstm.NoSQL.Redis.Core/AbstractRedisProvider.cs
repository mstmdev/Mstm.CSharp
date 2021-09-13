using Mstm.Log.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{
    /// <summary>
    /// Redis操作组件抽象类，所有Redis实现都要继承该类
    /// </summary>
    public abstract partial class AbstractRedisProvider : IRedisProvider
    {
        /// <summary>
        /// 日志组件
        /// </summary>
        public ILogProvider Logger;
        public const string RedisLogGroupName = "RedisLogger";

        /// <summary>
        /// 构造函数
        /// </summary>
        public AbstractRedisProvider()
        {
            Type type = this.GetType();
            Logger = LogFactory.GetProviderOrDefault(type, RedisLogGroupName);
        }

        public string AppendString(string key, string appendStr)
        {
            string result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = AppendStringCore(key, appendStr);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public long DeleteKey(params string[] keys)
        {
            long result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = DeleteKeyCore(keys);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public bool DeleteString(string key)
        {
            bool result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = DeleteStringCore(key);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public byte[] GetBytes(string key)
        {
            byte[] result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = GetBytesCore(key);
            #endregion

            #region 缓存操作后
            if (result == null)
            {
                Logger.DebugFormat("GetBytes 缓存查询未命中 Key=【{0}】", key);
            }
            #endregion
            return result;
        }

        public T GetData<T>(string key)
        {
            T result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = GetDataCore<T>(key);
            #endregion

            #region 缓存操作后
            if (result == null)
            {
                Logger.DebugFormat("GetData 缓存查询未命中 Key=【{0}】", key);
            }
            #endregion
            return result;
        }

        public RedisDataType GetKeyType(string key)
        {
            RedisDataType result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = GetKeyTypeCore(key);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public string GetRandomKey()
        {
            string result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = GetRandomKeyCore();
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public string GetString(string key)
        {
            string result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = GetStringCore(key);
            #endregion

            #region 缓存操作后
            if (result == null)
            {
                Logger.DebugFormat("GetString 缓存查询未命中 Key=【{0}】", key);
            }
            #endregion
            return result;
        }

        public int GetTTL(string key)
        {
            int result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = GetTTLCore(key);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public bool IsExistKey(string key)
        {
            bool result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = IsExistKeyCore(key);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public bool IsExistString(string key)
        {
            bool result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = IsExistStringCore(key);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public bool PersistKey(string key)
        {
            bool result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = PersistKeyCore(key);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public bool ReNameKeyWithCover(string oldKey, string newKey)
        {
            bool result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = ReNameKeyWithCoverCore(oldKey, newKey);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public bool ReNameKeyWithOutCover(string oldKey, string newKey)
        {
            bool result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = ReNameKeyWithOutCoverCore(oldKey, newKey);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public void SetBytes(string key, byte[] value, double cacheMinutes = -1)
        {
            #region 缓存操作前
            #endregion

            #region 缓存操作
            SetBytesCore(key, value, cacheMinutes);
            #endregion

            #region 缓存操作后
            #endregion
        }

        public void SetData<T>(string key, T value, double cacheMinutes = -1)
        {
            #region 缓存操作前
            #endregion

            #region 缓存操作
            SetDataCore<T>(key, value, cacheMinutes);
            #endregion

            #region 缓存操作后
            #endregion
        }

        public bool SetExpireatKey(string key, long timestamp)
        {
            bool result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = SetExpireatKeyCore(key, timestamp);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public bool SetExpireKey(string key, int seconds)
        {
            bool result;
            #region 缓存操作前
            #endregion

            #region 缓存操作
            result = SetExpireKeyCore(key, seconds);
            #endregion

            #region 缓存操作后
            #endregion
            return result;
        }

        public void SetString(string key, string value, double cacheMinutes = -1)
        {
            #region 缓存操作前
            #endregion

            #region 缓存操作
            SetStringCore(key, value, cacheMinutes);
            #endregion

            #region 缓存操作后
            #endregion
        }
    }
}
