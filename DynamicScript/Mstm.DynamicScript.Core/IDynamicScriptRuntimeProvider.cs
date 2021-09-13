using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.DynamicScript.Core
{
    /// <summary>
    /// 动态脚本运行引擎
    /// </summary>
    public interface IDynamicScriptRuntimeProvider
    {
        /// <summary>
        /// 脚本类型识别列表，全部以小写表示，包含脚本语言名称，脚本后缀，带.的脚本后缀
        /// </summary>
        List<string> ScriptTypeList { get; }

        /// <summary>
        /// 执行脚本内容
        /// </summary>
        /// <param name="script">脚本内容</param>
        /// <returns>执行结果</returns>
        string ExecuteScript(string script);

        /// <summary>
        /// 执行指定的脚本文件
        /// </summary>
        /// <param name="scriptFile">要执行的脚本文件</param>
        /// <returns>执行结果</returns>
        string ExecuteFile(string scriptFile);
    }
}
