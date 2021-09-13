using Microsoft.Scripting.Hosting;
using Mstm.DynamicScript.Core;
using System;
using System.Collections.Generic;

namespace Mstm.DynamicScript.Ruby
{
    /// <summary>
    /// Ruby动态脚本运行引擎
    /// </summary>
    public class RubyDynamicScriptRuntime : IDynamicScriptRuntimeProvider
    {
        /// <summary>
        /// Ruby脚本识别名称及后缀
        /// </summary>
        public List<string> ScriptTypeList => new List<string>() { "ruby", ".rb", "rb" };

        /// <summary>
        /// 内部Ruby引擎
        /// </summary>
        private static ScriptEngine _scriptEngine;

        /// <summary>
        /// 构造函数，初始化Ruby引擎
        /// </summary>
        static RubyDynamicScriptRuntime()
        {
            _scriptEngine = IronRuby.Ruby.CreateEngine();
        }

        /// <summary>
        /// 执行脚本内容
        /// </summary>
        /// <param name="script">脚本内容</param>
        /// <returns>执行结果</returns>
        public string ExecuteScript(string script)
        {
            _scriptEngine.Execute(script);
            dynamic ruby = _scriptEngine.Runtime.Globals;
            dynamic dsRubyClass = ruby.DsRubyClass.@new();
            string result = (string)dsRubyClass.Invoke();
            return result;
        }

        /// <summary>
        /// 执行指定的脚本文件
        /// </summary>
        /// <param name="scriptFile">要执行的脚本文件</param>
        /// <returns>执行结果</returns>
        public string ExecuteFile(string scriptFile)
        {
            _scriptEngine.ExecuteFile(scriptFile);
            dynamic ruby = _scriptEngine.Runtime.Globals;
            dynamic dsRubyClass = ruby.DsRubyClass.@new();
            string result = (string)dsRubyClass.Invoke();
            return result;
        }
    }
}
