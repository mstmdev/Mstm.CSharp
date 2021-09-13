using Mstm.Common.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Mstm.Common.Config;
using System.Globalization;

namespace Mstm.Lock.Core
{
    /// <summary>
    /// 锁提供器工厂
    /// </summary>
    public class LockFactory : Factory<ILockProvider>
    {
        /// <summary>
        /// 私有构造函数，不予许外部直接构造实例
        /// </summary>
        private LockFactory(string groupName)
            : base(groupName)
        {
            Config = LockProviderConfig.New(groupName);
        }

        /// <summary>
        /// 锁的唯一标识
        /// </summary>
        public string Identity { get; private set; }

        /// <summary>
        /// 获取锁组件的实例
        /// </summary>
        /// <param name="identity">当前锁的唯一标识</param>
        /// <param name="groupName">组名称</param>
        /// <returns></returns>
        public static ILockProvider GetProvider(string identity, string groupName = null)
        {
            LockFactory factory = new LockFactory(groupName);
            factory.Identity = identity;
            var provider = factory.GetProviderCore(new object[] { identity });
            return provider;
        }

        /// <summary>
        /// 反射创建ILockProvider的实例
        /// </summary>
        /// <param name="assembly">ILockProvider实现类型所在的程序集实例</param>
        /// <param name="args">ILockProvider实现类型实例化构造函数需要的参数</param>
        /// <returns>锁组件ILockProvider的实例</returns>
        protected override ILockProvider CreateInstance(Assembly assembly, object[] args)
        {
            var provider = assembly.CreateInstance(Config.ClassFullName, true, BindingFlags.CreateInstance, null, args, CultureInfo.CurrentCulture, null) as ILockProvider;
            return provider;
        }

        /// <summary>
        /// 获取当前缓存键的值
        /// </summary>
        /// <returns></returns>
        protected override string GetCacheKeyCore()
        {
            string cacheKey = string.Format("{0}:{1}:{2}", Config.ModuleName, Config.GroupName, Identity);
            return cacheKey;
        }
    }
}
