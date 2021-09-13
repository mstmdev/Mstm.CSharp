using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{

    /// <summary>
    /// Redis数据类型枚举
    /// </summary>
    public enum RedisDataType
    {
        /// <summary>
        /// 键不存在
        /// </summary>
        None = 0,

        /// <summary>
        /// String类型
        /// </summary>
        String = 1,

        /// <summary>
        /// List类型
        /// </summary>
        List = 2,

        /// <summary>
        /// Set类型
        /// </summary>
        Set = 3,

        /// <summary>
        /// SortedSet类型
        /// </summary>
        SortedSet = 4,

        /// <summary>
        /// Hash类型
        /// </summary>
        Hash = 5,

        /// <summary>
        /// 未知的类型
        /// </summary>
        Unknown = 6,
    }
}
