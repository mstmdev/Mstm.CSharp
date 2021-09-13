using Microsoft.Extensions.Configuration;
using Mstm.Common.Factory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{
    /// <summary>
    /// Redis组件工厂
    /// </summary>
    public class RedisFactory : Factory<IRedisProvider>
    {
        /// <summary>
        /// 私有构造函数，不予许外部直接构造实例
        /// </summary>
        private RedisFactory(string groupName)
            : base(groupName)
        {
            Config = RedisProviderConfig.New(groupName);
        }

        /// <summary>
        /// 获取Redis操作组件实例
        /// </summary>
        /// <param name="groupName">组名称</param>
        /// <returns></returns>
        public static IRedisProvider GetProvider(string groupName = null)
        {
            RedisFactory factory = new RedisFactory(groupName);
            var config = factory.Config as RedisProviderConfig;
            var provider = factory.GetProviderCore(new object[] { config.RedisClientConnStr, config.DB });
            return provider;
        }

        /// <summary>
        /// 反射创建IRedisProvider的实例
        /// </summary>
        /// <param name="assembly">IRedisProvider实现类型所在的程序集实例</param>
        /// <param name="args">IRedisProvider实现类型实例化构造函数需要的参数</param>
        /// <returns>Redis组件IRedisProvider的实例</returns>
        protected override IRedisProvider CreateInstance(Assembly assembly, object[] args)
        {
            var config = Config as RedisProviderConfig;
            var provider = assembly.CreateInstance(config.ClassFullName, true, BindingFlags.CreateInstance, null, args, CultureInfo.CurrentCulture, null) as IRedisProvider;
            return provider;
        }
    }
}
