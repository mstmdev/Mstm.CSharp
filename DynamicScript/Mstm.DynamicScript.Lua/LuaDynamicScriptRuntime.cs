using MoonSharp.Interpreter;
using Mstm.DynamicScript.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.DynamicScript.Lua
{
    /// <summary>
    /// Lua动态脚本运行引擎
    /// </summary>
    public class LuaDynamicScriptRuntime : IDynamicScriptRuntimeProvider
    {
        /// <summary>
        /// Lua脚本识别名称及后缀
        /// </summary>
        public List<string> ScriptTypeList => new List<string>() { "lua", ".lua" };

        /// <summary>
        /// 执行脚本内容
        /// </summary>
        /// <param name="script">脚本内容</param>
        /// <returns>执行结果</returns>
        public string ExecuteScript(string script)
        {
            DynValue value = Script.RunString(script);
            return value.ToString();
        }

        /// <summary>
        /// 执行指定的脚本文件
        /// </summary>
        /// <param name="scriptFile">要执行的脚本文件</param>
        /// <returns>执行结果</returns>
        public string ExecuteFile(string scriptFile)
        {
            DynValue value = Script.RunFile(scriptFile);
            return value.ToString();
        }
    }
}
