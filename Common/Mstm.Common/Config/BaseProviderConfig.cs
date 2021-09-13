using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Config
{
    /// <summary>
    /// Provider实现相关配置，用于动态加载程序集
    /// </summary>
    public abstract class BaseProviderConfig : BaseConfig
    {
        /// <summary>
        /// 默认组名称，默认为Default，如果用户没有传递GroupName,则默认使用DefaultGroupName
        /// </summary>
        public virtual string DefaultGroupName { get { return "Default"; } }

        /// <summary>
        /// 模块名称，即当前配置父节点的名称
        /// </summary>
        public abstract string ModuleName { get; }

        /// <summary>
        /// 组名称，即配置文件二级节点的名称
        /// </summary>
        public string GroupName { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="groupName">组名称</param>
        public BaseProviderConfig(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName)) { groupName = DefaultGroupName; }
            GroupName = groupName;
        }

        /// <summary>
        /// 需要反射的程序集的名称
        /// </summary>
        public string AssemblyName
        {
            get
            {
                string key = string.Format("{0}:{1}:AssemblyName", ModuleName, GroupName);
                string value = this.Config[key];
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(AssemblyName), string.Format("未找到需要反射的程序集的名称，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                return value;
            }
        }

        /// <summary>
        /// 需要反射的类的全称
        /// </summary>
        public string ClassFullName
        {
            get
            {
                string key = string.Format("{0}:{1}:ClassFullName", ModuleName, GroupName);
                string value = this.Config[key];
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(ClassFullName), string.Format("未找到需要反射的类的全称，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                return value;
            }
        }

        /// <summary>
        /// 是否缓存组件
        /// </summary>
        public bool IsCacheProvider
        {
            get
            {
                string key = string.Format("{0}:{1}:IsCacheProvider", ModuleName, GroupName);
                string value = this.Config[key];
                if (value != null && value.ToLower() == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
