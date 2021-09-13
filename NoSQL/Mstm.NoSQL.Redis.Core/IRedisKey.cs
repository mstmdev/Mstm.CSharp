using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{

    /// <summary>
    /// 提供Key相关操作接口
    /// </summary>
    public interface IRedisKey
    {
        /// <summary>
        /// 判断指定的键是否已经存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>键是否存在</returns>
        bool IsExistKey(string key);


        /// <summary>
        /// 删除指定的key
        /// </summary>
        /// <param name="keys">要删除的多个key</param>
        /// <returns>实际被删除的key的数目</returns>
        long DeleteKey(params string[] keys);


        /// <summary>
        /// 重命名Key，如果新的Key已存在则进行覆盖
        /// </summary>
        /// <param name="oldKey">待重命名的Key</param>
        /// <param name="newKey">新的Key</param>
        /// <returns>操作是否成功</returns>
        bool ReNameKeyWithCover(string oldKey, string newKey);


        /// <summary>
        /// 重命名Key，如果新的Key已存在则忽略操作
        /// </summary>
        /// <param name="oldKey">待重命名的Key</param>
        /// <param name="newKey">新的Key</param>
        /// <returns>操作是否成功</returns>
        bool ReNameKeyWithOutCover(string oldKey, string newKey);


        /// <summary>
        /// 对指定的Key进行持久化
        /// </summary>
        /// <param name="key">带持久化的Key</param>
        /// <returns>Key是否存在，并且成功从会过期的状态转变为持久化状态</returns>
        bool PersistKey(string key);


        /// <summary>
        /// 为键设置过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="seconds">过期时间，秒</param>
        /// <returns>是否设置成功</returns>
        bool SetExpireKey(string key, int seconds);


        /// <summary>
        /// 为键设置绝对过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="timestamp">该时间参数是Unix timestamp格式的，即从1970年1月1日开始所流经的秒数</param>
        /// <returns>是否设置成功</returns>
        bool SetExpireatKey(string key, long timestamp);

        /// <summary>
        /// 查询Key的剩余超时时间
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>超时秒数，如果为-1表示键不存在</returns>
        int GetTTL(string key);



        /// <summary>
        /// 随机获取一个键
        /// </summary>
        /// <returns>随机获取的键</returns>
        string GetRandomKey();


        /// <summary>
        /// 获取键的类型
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>指定键的数据类型</returns>
        RedisDataType GetKeyType(string key);
    }
}
