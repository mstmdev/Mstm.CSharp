using Microsoft.Extensions.Configuration;
using Mstm.Common.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Json.Core
{
    /// <summary>
    /// Json序列化操作组件工厂
    /// </summary>
    public class JsonFactory : Factory<IJsonProvider>
    {
        /// <summary>
        /// 私有构造函数，不予许外部直接构造实例
        /// </summary>
        private JsonFactory(string groupName)
            : base(groupName)
        {
            Config = JsonProviderConfig.New(groupName);
        }

        /// <summary>
        /// 获取Json序列化组件实例
        /// </summary>
        /// <returns></returns>
        public static IJsonProvider GetProvider(string groupName = null)
        {
            JsonFactory factory = new JsonFactory(groupName);
            var provider = factory.GetProviderCore(null);
            return provider;
        }

        /// <summary>
        /// 反射创建IJsonProvider的实例
        /// </summary>
        /// <param name="assembly">IJsonProvider实现类型所在的程序集实例</param>
        /// <param name="args">IJsonProvider实现类型实例化构造函数需要的参数</param>
        /// <returns>Json组件IJsonProvider的实例</returns>
        protected override IJsonProvider CreateInstance(Assembly assembly, object[] args)
        {
            var provider = assembly.CreateInstance(Config.ClassFullName, true, BindingFlags.CreateInstance, null, args, CultureInfo.CurrentCulture, null) as IJsonProvider;
            return provider;
        }
    }
}
