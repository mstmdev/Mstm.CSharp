using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Web.AspNetCore.Session
{
    /// <summary>
    /// 默认Session存储方案
    /// </summary>
    public class DefaultSessionStorage
    {
        public static ISessionStorage Default = new MemorySessionStorage();

        /// <summary>
        /// 使用内存作为Session的存储方案
        /// </summary>
        public static void UseMemorySessionStorage()
        {
            Default = new MemorySessionStorage();
        }

        /// <summary>
        /// 使用Redis作为Session的存储方案
        /// </summary>
        public static void UseRedisSessionStorage()
        {
            Default = new RedisSessionStorage();
        }
    }
}
