using Microsoft.Extensions.Configuration;
using Mstm.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{
    /// <summary>
    /// Redis组件配置文件信息
    /// </summary>
    public class RedisProviderConfig : BaseProviderConfig
    {
        /// <summary>
        /// 当前模块名称
        /// </summary>
        public override string ModuleName => "RedisProvider";

        /// <summary>
        /// 私有构造函数，禁止外部构造
        /// </summary>
        /// <param name="groupName">组名称</param>
        private RedisProviderConfig(string groupName)
            : base(groupName)
        {

        }

        /// <summary>
        /// 创建一个新的配置
        /// </summary>
        /// <param name="groupName">组名称</param>
        /// <returns></returns>
        public static RedisProviderConfig New(string groupName = null)
        {
            return new RedisProviderConfig(groupName);
        }

        /// <summary>
        /// Redis的连接字符串
        /// </summary>
        public string RedisClientConnStr
        {
            get
            {
                string key = string.Format("{0}:{1}:RedisClientConnStr", ModuleName, GroupName);
                string value = this.Config[key];
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(RedisClientConnStr), string.Format("未找到Redis的连接字符串，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                return value;
            }
        }

        /// <summary>
        /// Redis DB信息
        /// </summary>
        public int DB
        {
            get
            {
                string key = string.Format("{0}:{1}:DB", ModuleName, GroupName);
                try
                {
                    string value = this.Config[key];
                    if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(DB), string.Format("未找到Redis DB信息，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                    int db = int.Parse(value);
                    return db;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Redis DB 配置错误，请检查你的配置，对应的Key为{0},配置文件为{1}", key, ConfigFile), ex);
                }
            }
        }

    }
}
