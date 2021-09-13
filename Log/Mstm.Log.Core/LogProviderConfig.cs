using Microsoft.Extensions.Configuration;
using Mstm.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Log.Core
{
    /// <summary>
    /// 日志配置信息
    /// </summary>
    public class LogProviderConfig : BaseProviderConfig
    {
        /// <summary>
        /// 当前模块名称
        /// </summary>
        public override string ModuleName => "LogProvider";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="groupName">组名称</param>
        private LogProviderConfig(string groupName)
            : base(groupName)
        {
        }

        /// <summary>
        /// 创建一个新的配置
        /// </summary>
        /// <param name="groupName">组名称</param>
        /// <returns></returns>
        public static LogProviderConfig New(string groupName = null)
        {
            return new LogProviderConfig(groupName);
        }

        /// <summary>
        /// 日志配置文件
        /// </summary>
        public string LogConfigFile
        {
            get
            {
                string key = string.Format("{0}:{1}:LogConfigFile", ModuleName, GroupName);
                string value = this.Config[key];
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentNullException(nameof(LogConfigFile), string.Format("未找到日志配置文件，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                return value;
            }
        }
    }
}
