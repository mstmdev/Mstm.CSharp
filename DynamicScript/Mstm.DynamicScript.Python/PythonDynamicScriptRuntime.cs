using Microsoft.Scripting.Hosting;
using Mstm.DynamicScript.Core;
using System;
using System.Collections.Generic;

namespace Mstm.DynamicScript.Python
{
    /// <summary>
    /// Python动态脚本运行引擎
    /// </summary>
    public class PythonDynamicScriptRuntime : IDynamicScriptRuntimeProvider
    {
        /// <summary>
        /// Python脚本识别名称及后缀
        /// </summary>
        public List<string> ScriptTypeList => new List<string>() { "python", ".py", "py" };

        /// <summary>
        /// 内部Python引擎
        /// </summary>
        private static ScriptEngine _scriptEngine;

        /// <summary>
        /// 构造函数，初始化Python引擎
        /// </summary>
        static PythonDynamicScriptRuntime()
        {
            try
            {
                ScriptRuntime scriptRuntime = ScriptRuntime.CreateFromConfiguration();
                _scriptEngine = scriptRuntime.GetEngine("python");
            }
            catch (Exception ex)
            {
                throw new Exception("内部加载Python运行时失败，请检查你的配置文件，是否配置了正确的microsoft.scripting节点", ex);
            }
        }

        /// <summary>
        /// 执行脚本内容
        /// </summary>
        /// <param name="script">脚本内容</param>
        /// <returns>执行结果</returns>
        public string ExecuteScript(string script)
        {
            ScriptSource source = _scriptEngine.CreateScriptSourceFromString(script);
            ScriptScope scope = _scriptEngine.CreateScope();
            source.Execute(scope);
            var result = scope.GetVariable("ds_python_result");
            return result;
        }

        /// <summary>
        /// 执行指定的脚本文件
        /// </summary>
        /// <param name="scriptFile">要执行的脚本文件</param>
        /// <returns>执行结果</returns>
        public string ExecuteFile(string scriptFile)
        {
            ScriptSource source = _scriptEngine.CreateScriptSourceFromFile(scriptFile);
            ScriptScope scope = _scriptEngine.CreateScope();
            source.Execute(scope);
            var result = scope.GetVariable("ds_python_result");
            return result;
        }
    }
}
