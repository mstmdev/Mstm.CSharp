using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.DynamicScript.Core
{
    /// <summary>
    ///动态脚本执行
    /// </summary>
    public static class DynamicScriptRuntime
    {
        /// <summary>
        /// 动态执行指定的脚本文件
        /// </summary>
        /// <param name="scriptFile">脚本文件</param>
        /// <returns>执行结果</returns>
        public static string Execute(string scriptFile)
        {
            var runtime = DynameScriptRuntimeFactory.GetProvider(scriptFile);
            return runtime.ExecuteFile(scriptFile);
        }

        /// <summary>
        /// 执行执行的脚本内容
        /// </summary>
        /// <param name="script">脚本代码</param>
        /// <param name="scriptType">脚本类型</param>
        /// <returns>执行结果</returns>
        public static string Execute(string script, string scriptType)
        {
            var runtime = DynameScriptRuntimeFactory.GetProvider(scriptType);
            return runtime.ExecuteScript(script);
        }
    }
}
