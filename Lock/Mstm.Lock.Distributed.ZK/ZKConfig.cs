using Microsoft.Extensions.Configuration;
using Mstm.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Lock.Distributed.ZK
{
    /// <summary>
    /// Zookeeper相关的配置信息
    /// </summary>
    public class ZKConfig : BaseConfig
    {
        /// <summary>
        /// 默认组名称
        /// </summary>
        public const string DefaultGroup = "DefaultLockerZK";

        /// <summary>
        /// 当前模块的名称
        /// </summary>
        public const string ModuleName = "Zookeeper";

        /// <summary>
        /// 组名称
        /// </summary>
        public string GroupName { get; private set; }

        /// <summary>
        /// 私有构造函数，禁止外部构造
        /// </summary>
        /// <param name="groupName">组名称</param>
        private ZKConfig(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName)) { groupName = DefaultGroup; }
            GroupName = groupName;
        }

        /// <summary>
        /// 构造新的配置信息
        /// </summary>
        /// <param name="groupName">组名称，不传递则为默认名称</param>
        /// <returns>Zookeeper的配置信息实例</returns>
        public static ZKConfig New(string groupName = null)
        {
            return new ZKConfig(groupName);
        }

        /// <summary>
        /// Zookeeper的连接字符串
        /// </summary>
        public string ConnStr
        {
            get
            {
                string key = string.Format("{0}:{1}:ConnStr", ModuleName, GroupName);
                string value = this.Config[key];
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(ConnStr), string.Format("未找到Zookeeper的连接字符串，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                return value;
            }
        }

        /// <summary>
        /// 锁在Zookeeper中父节点的路径，例如： /lock_root/user
        /// </summary>
        public string LockZKRoot
        {
            get
            {
                string key = string.Format("{0}:{1}:LockZKRoot", ModuleName, GroupName);
                string value = this.Config[key];
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(LockZKRoot), string.Format("未找到锁在Zookeeper中父节点的路径信息，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                return value;
            }
        }

        /// <summary>
        /// 每个锁在zookeeper中的值
        /// 这个当前设置任意值皆可
        /// </summary>
        public string LockZKValue
        {
            get
            {
                string key = string.Format("{0}:{1}:LockZKValue", ModuleName, GroupName);
                string value = this.Config[key];
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(LockZKValue), string.Format("未找到每个锁在zookeeper中的值的配置信息，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                return value;
            }
        }
    }
}
