using Mstm.Common.Factory;
using System;
using System.Globalization;
using System.Reflection;

namespace Mstm.Log.Core
{
    /// <summary>
    /// 日志组件工厂
    /// </summary>
    public class LogFactory : Factory<ILogProvider>
    {
        /// <summary>
        /// 私有构造函数，不予许外部直接构造实例
        /// </summary>
        private LogFactory(string groupName)
            : base(groupName)
        {
            Config = LogProviderConfig.New(groupName);
        }

        private Type CurrentType { get; set; }

        /// <summary>
        /// 获取日志组件的实例
        /// </summary>
        /// <param name="type">当前日志操作所在的类型</param>
        /// <param name="groupName">组名称</param>
        /// <returns>日志组件ILogProvider实例</returns>
        public static ILogProvider GetProvider(Type type, string groupName = null)
        {
            LogFactory factory = new LogFactory(groupName);
            factory.CurrentType = type ?? typeof(LogFactory);
            var provider = factory.GetProviderCore(new object[] { factory.Config, type });
            return provider;
        }

        /// <summary>
        /// 获取日志组件的实例
        /// </summary>
        /// <typeparam name="T">当前日志操作所在的类型</typeparam>
        /// <param name="groupName">组名称</param>
        /// <returns>日志组件ILogProvider实例</returns>
        public static ILogProvider GetProvider<T>(string groupName = null)
        {
            Type type = typeof(T);
            return GetProvider(type, groupName);
        }

        /// <summary>
        /// 获取日志组件的实例，如果构造失败则返回默认的EmptyLogProvider实例
        /// </summary>
        /// <param name="type">当前日志操作所在的类型</param>
        /// <param name="groupName">组名称</param>
        /// <returns>日志组件ILogProvider实例</returns>
        public static ILogProvider GetProviderOrDefault(Type type, string groupName = null)
        {
            ILogProvider provider = null;
            try
            {
                provider = GetProvider(type, groupName);
            }
            catch (Exception)
            {
                provider = EmptyLogProvider.New();
            }
            return provider ?? EmptyLogProvider.New();
        }

        /// <summary>
        /// 获取日志组件的实例，如果构造失败则返回默认的EmptyLogProvider实例
        /// </summary>
        /// <typeparam name="T">当前日志操作所在的类型</typeparam>
        /// <param name="groupName">组名称</param>
        /// <returns>日志组件ILogProvider实例</returns>
        public static ILogProvider GetProviderOrDefault<T>(string groupName = null)
        {
            ILogProvider provider = null;
            try
            {
                provider = GetProvider<T>(groupName);
            }
            catch (Exception)
            {
                provider = EmptyLogProvider.New();
            }
            return provider ?? EmptyLogProvider.New();
        }

        /// <summary>
        /// 反射创建ILogProvider的实例
        /// </summary>
        /// <param name="assembly">ILogProvider实现类型所在的程序集实例</param>
        /// <param name="args">ILogProvider实现类型实例化构造函数需要的参数</param>
        /// <returns>Log组件ILogProvider的实例</returns>
        protected override ILogProvider CreateInstance(Assembly assembly, object[] args)
        {
            var provider = assembly.CreateInstance(Config.ClassFullName, true, BindingFlags.CreateInstance, null, args, CultureInfo.CurrentCulture, null) as ILogProvider;
            return provider;
        }

        /// <summary>
        /// 获取当前缓存键的值
        /// </summary>
        /// <returns></returns>
        protected override string GetCacheKeyCore()
        {
            string cacheKey = string.Format("{0}:{1}:{2}", Config.ModuleName, Config.GroupName, CurrentType.FullName);
            return cacheKey;
        }
    }
}
