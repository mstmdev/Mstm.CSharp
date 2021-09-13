using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Mstm.DynamicScript.Core;

namespace Mstm.DynamicScript.Lua.Tests
{
    /// <summary>
    /// Lua脚本引擎测试
    /// </summary>
    public class LuaDynamicScriptRuntimeTests
    {
        /// <summary>
        /// 动态执行Lua脚本文件
        /// </summary>
        [Fact]
        public void LuaExecuteFileTest()
        {
            var result = DynamicScriptRuntime.Execute("Lua/demo.lua");
            result.ShouldBe("120");
        }

        /// <summary>
        /// 执行指定的Lua脚本内容,类型不包含.
        /// </summary>
        [Fact]
        public void LuaExecuteScriptTest()
        {
            var result = DynamicScriptRuntime.Execute(@"		
                            function fact (n)
			                    if (n == 0) then
				                    return 1
			                    else
				                    return n*fact(n - 1)
			                    end
		                    end
		                    return fact(5)
            ", "lua");
            result.ShouldBe("120");
        }

        /// <summary>
        ///  执行指定的Lua脚本内容,类型包含.
        /// </summary>
        [Fact]
        public void LuaExecuteScriptWithDotTest()
        {
            var result = DynamicScriptRuntime.Execute(@"		
                            function fact (n)
			                    if (n == 0) then
				                    return 1
			                    else
				                    return n*fact(n - 1)
			                    end
		                    end
		                    return fact(5)
            ", ".lua");
            result.ShouldBe("120");
        }
    }
}
