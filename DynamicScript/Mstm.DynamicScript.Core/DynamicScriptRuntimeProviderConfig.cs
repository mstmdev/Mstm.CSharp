using Mstm.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.DynamicScript.Core
{
    /// <summary>
    /// 动态脚本提供器配置信息
    /// </summary>
    public class DynamicScriptRuntimeProviderConfig : BaseConfig
    {
        /// <summary>
        /// 当前模块的名称
        /// </summary>
        public const string ModuleName = "DynamicScriptRuntimeProvider";

        /// <summary>
        /// 私有构造函数，禁止外部构造
        /// </summary>
        private DynamicScriptRuntimeProviderConfig()
        {
        }

        /// <summary>
        /// 构造新的配置信息
        /// </summary>
        /// <returns>动态脚本提供器配置信息</returns>
        public static DynamicScriptRuntimeProviderConfig New()
        {
            return new DynamicScriptRuntimeProviderConfig();
        }

        List<string> _assemblyNameList = null;

        /// <summary>
        /// 动态脚本引擎程序集名称集合
        /// </summary>
        public List<string> AssemblyNameList
        {
            get
            {
                if (_assemblyNameList != null) { return _assemblyNameList; }
                _assemblyNameList = new List<string>();
                string key = string.Format("{0}:AssemblyNameList", ModuleName);
                var sections = this.Config.GetSection(key);
                if (sections == null) { throw new ArgumentNullException(nameof(AssemblyNameList), string.Format("未找到动态脚本引擎程序集名称集合，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                var assemblyNameList = sections.GetChildren();
                if (assemblyNameList == null || assemblyNameList.Count() == 0) { throw new ArgumentNullException(nameof(AssemblyNameList), string.Format("未找到动态脚本引擎程序集名称集合，对应的Key为{0},配置文件为{1}", key, ConfigFile)); }
                foreach (var item in assemblyNameList)
                {
                    _assemblyNameList.Add(item.Value);
                }
                return _assemblyNameList;
            }
        }
    }
}
