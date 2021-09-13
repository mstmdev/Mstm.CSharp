#if NET47
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Mstm.DynamicScript.Core;

namespace Mstm.DynamicScript.Python.Tests
{
    /// <summary>
    /// Python脚本引擎测试
    /// </summary>
    public class PythonDynamicScriptRuntimeTests
    {
        /// <summary>
        /// 动态执行Python脚本文件
        /// </summary>
        [Fact]
        public void PythonExecuteFileTest()
        {
            var result = DynamicScriptRuntime.Execute("Python/demo.py");
            result.ShouldBe("你好 python2.7");
        }

        /// <summary>
        /// 执行指定的Python脚本内容,类型不包含.
        /// </summary>
        [Fact]
        public void PythonExecuteScriptTest()
        {
            var result = DynamicScriptRuntime.Execute(@"
import sys
ds_python_result = u'你好 python'
ds_python_result = ds_python_result + '2.7'"
            , "py");
            result.ShouldBe("你好 python2.7");
        }

        /// <summary>
        ///  执行指定的Python脚本内容,类型包含.
        /// </summary>
        [Fact]
        public void PythonExecuteScriptWithDotTest()
        {
            var result = DynamicScriptRuntime.Execute(@"
import sys
ds_python_result = u'你好 python'
ds_python_result = ds_python_result + '2.7'"
            , ".py");
            result.ShouldBe("你好 python2.7");
        }
    }
}
#endif