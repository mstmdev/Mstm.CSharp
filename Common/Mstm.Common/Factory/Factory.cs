using Mstm.Common.Config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Factory
{
    /// <summary>
    /// 工厂类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Factory<T>
    {
        /// <summary>
        /// 内部并发字典，记录内部数据
        /// </summary>
        private static ConcurrentDictionary<string, T> _providerDict = new ConcurrentDictionary<string, T>();

        /// <summary>
        /// 缓存Assembly
        /// </summary>
        private static ConcurrentDictionary<string, Assembly> _assemblyDict = new ConcurrentDictionary<string, Assembly>();

        /// <summary>
        /// 私有构造函数，不予许外部直接构造实例
        /// </summary>
        protected Factory(string groupName)
        {
        }

        /// <summary>
        /// 反射创建指定类型的实例
        /// </summary>
        /// <param name="assembly">类型所在的程序集实例</param>
        /// <param name="args">类型实例化构造函数需要的参数</param>
        /// <returns>指定类型的实例</returns>
        protected abstract T CreateInstance(Assembly assembly, object[] args);

        /// <summary>
        /// 动态加载程序集相关的配置信息
        /// </summary>
        protected virtual BaseProviderConfig Config { get; set; }

        /// <summary>
        /// 获取当前缓存键的值
        /// </summary>
        /// <returns></returns>
        private string GetCacheKey()
        {
            string cacheKey = GetCacheKeyCore();
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                new ArgumentNullException(nameof(cacheKey), string.Format("当前字典缓存key不能为空，当前模块为{0},当前组名称为{1}", Config.ModuleName, Config.GroupName));
            }
            return cacheKey;
        }

        /// <summary>
        /// 获取当前缓存键的值
        /// </summary>
        /// <returns></returns>
        protected virtual string GetCacheKeyCore()
        {
            string cacheKey = string.Format("{0}:{1}", Config.ModuleName, Config.GroupName);
            return cacheKey;
        }

        /// <summary>
        /// 获取指定类型的具体实现类的实例
        /// </summary>
        /// <param name="args">实例化需要的构造函数参数</param>
        /// <param name="groupName">组名称</param>
        /// <returns></returns>
        public T GetProviderCore(object[] args)
        {
            if (Config == null)
            {
                throw new ArgumentNullException(nameof(Config), "Config配置信息为空，基类型为BaseProviderConfig，请在Factory的子类构造函数中实例化Config信息，当前Factory为" + this.GetType().FullName);
            }
            T provider = default(T);
            string cacheKey = GetCacheKey();
            if (Config.IsCacheProvider && _providerDict.ContainsKey(cacheKey))
            {
                _providerDict.TryGetValue(cacheKey, out provider);
                if (provider != null) { return provider; }
            }

            if (string.IsNullOrEmpty(Config.AssemblyName))
            {
                throw new ArgumentNullException(nameof(Config.AssemblyName), string.Format("{0}:{1}:{2} 未获取到{3}具体实现的程序集名称，请检查配置文件{4}", Config.ModuleName, Config.GroupName, nameof(Config.AssemblyName), typeof(T).FullName, Config.ConfigFile));
            }
            if (string.IsNullOrEmpty(Config.ClassFullName))
            {
                throw new ArgumentNullException(nameof(Config.ClassFullName), string.Format("{0}:{1}:{2} 未获取到{3}具体实现的类名，请检查配置文件{4}", Config.ModuleName, Config.GroupName, nameof(Config.ClassFullName), typeof(T).FullName, Config.ConfigFile));
            }
            Assembly assembly = null;
            if (Config.IsCacheProvider == false)
            {
                _assemblyDict.TryGetValue(Config.AssemblyName, out assembly);
            }
            if (assembly == null)
            {
                assembly = Assembly.Load(Config.AssemblyName);
            }
            if (assembly == null) { throw new ArgumentNullException(nameof(assembly), string.Format("未找到{0}程序集", Config.AssemblyName)); }
            provider = CreateInstance(assembly, args);
            if (provider == null) { throw new ArgumentNullException(nameof(provider), string.Format("实例化类型{0}失败", Config.ClassFullName)); }
            if (Config.IsCacheProvider)
            {
                _providerDict.TryAdd(cacheKey, provider);
            }
            else
            {
                _assemblyDict.TryAdd(Config.AssemblyName, assembly);
            }
            return provider;
        }
    }
}
