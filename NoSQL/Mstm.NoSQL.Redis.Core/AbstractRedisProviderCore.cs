using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{
    public abstract partial class AbstractRedisProvider : IRedisProvider
    {
        public abstract string AppendStringCore(string key, string appendStr);

        public abstract long DeleteKeyCore(params string[] keys);

        public abstract bool DeleteStringCore(string key);

        public abstract byte[] GetBytesCore(string key);

        public abstract T GetDataCore<T>(string key);

        public abstract RedisDataType GetKeyTypeCore(string key);

        public abstract string GetRandomKeyCore();

        public abstract string GetStringCore(string key);

        public abstract int GetTTLCore(string key);

        public abstract bool IsExistKeyCore(string key);

        public abstract bool IsExistStringCore(string key);

        public abstract bool PersistKeyCore(string key);

        public abstract bool ReNameKeyWithCoverCore(string oldKey, string newKey);

        public abstract bool ReNameKeyWithOutCoverCore(string oldKey, string newKey);

        public abstract void SetBytesCore(string key, byte[] value, double cacheMinutes = -1);

        public abstract void SetDataCore<T>(string key, T value, double cacheMinutes = -1);

        public abstract bool SetExpireatKeyCore(string key, long timestamp);

        public abstract bool SetExpireKeyCore(string key, int seconds);

        public abstract void SetStringCore(string key, string value, double cacheMinutes = -1);
    }
}
