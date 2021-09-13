using Mstm.Log.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.ORM.Core.Common
{
    /// <summary>
    /// 默认数据库框架日志
    /// </summary>
    /// <typeparam name="T">当前记录日志的类型</typeparam>
    public class DefaultLog<T> : DefaultLog
    {
        /// <summary>
        /// 默认日志组件
        /// </summary>
        public static ILogProvider Logger
        {
            get
            {
                return LogFactory.GetProviderOrDefault<T>(DefaultGroupName);
            }
        }

        /// <summary>
        /// 性能监控日志组件
        /// </summary>
        public static ILogProvider MonitorLogger
        {
            get
            {
                return LogFactory.GetProviderOrDefault<T>(MonitorGroupName);
            }
        }
    }
    /// <summary>
    /// 默认数据库框架日志
    /// </summary>
    public class DefaultLog
    {
        /// <summary>
        /// 默认日志组
        /// </summary>
        public const string DefaultGroupName = "DBFrameworkCoreDefaultLogger";

        /// <summary>
        /// 监控日志组
        /// </summary>
        public const string MonitorGroupName = "DBFrameworkCoreMonitorLogger";

        /// <summary>
        /// 默认日志组件
        /// </summary>
        public static ILogProvider GetLogger(Type type)
        {
            return LogFactory.GetProviderOrDefault(type, DefaultGroupName);
        }

        /// <summary>
        /// 性能监控日志组件
        /// </summary>
        public static ILogProvider GetMonitorLogger(Type type)
        {
            return LogFactory.GetProviderOrDefault(type, MonitorGroupName);
        }
    }
}
