using Mstm.Common.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Mstm.DynamicScript.Core
{
    /// <summary>
    /// 脚本运行时工厂
    /// </summary>
    internal static class DynameScriptRuntimeFactory
    {
        /// <summary>
        /// 所有引擎集合
        /// </summary>
        static List<IDynamicScriptRuntimeProvider> Providers = new List<IDynamicScriptRuntimeProvider>();

        /// <summary>
        /// 初始化引擎
        /// </summary>
        static DynameScriptRuntimeFactory()
        {
            var config = DynamicScriptRuntimeProviderConfig.New();
            if (config == null || config.AssemblyNameList == null)
            {
                throw new ArgumentException("未配置任何动态脚本引擎，请检查你的配置文件！");
            }
            var assemblyNameList = config.AssemblyNameList;
            foreach (var assemblyName in assemblyNameList)
            {
                try
                {
                    var assembly = Assembly.Load(assemblyName);
                    var typeList = assembly.GetTypes().Where(a => a.GetInterface(nameof(IDynamicScriptRuntimeProvider)) != null);
                    foreach (var type in typeList)
                    {
                        var instance = assembly.CreateInstance(type.FullName) as IDynamicScriptRuntimeProvider;
                        if (instance != null)
                        {
                            Providers.Add(instance);
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 获取脚本引擎
        /// </summary>
        /// <param name="scriptTypeOrName">脚本类型或者要执行的脚本名称</param>
        /// <returns>当前对应脚本语言对应的脚本引擎</returns>
        public static IDynamicScriptRuntimeProvider GetProvider(string scriptTypeOrName)
        {
            string scriptType;
            if (string.IsNullOrWhiteSpace(scriptTypeOrName))
            {
                throw new ArgumentNullException(nameof(scriptTypeOrName), "脚本类型或脚本语言名称不能为空");
            }
            int dotIndex = scriptTypeOrName.IndexOf(".");
            if (dotIndex < 0)
            {
                scriptType = scriptTypeOrName.ToLower();
            }
            else
            {
                scriptType = scriptTypeOrName.Substring(dotIndex + 1).ToLower();
            }
            var provider = Providers.Where(p => p.ScriptTypeList.Contains(scriptType)).FirstOrDefault();
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider), string.Format("未找到{0}支持的脚本引擎", scriptTypeOrName));
            }
            return provider;
        }
    }
}
