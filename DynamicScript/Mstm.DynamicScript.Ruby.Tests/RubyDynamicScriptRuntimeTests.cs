#if NET47
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Mstm.DynamicScript.Core;

namespace Mstm.DynamicScript.Ruby.Tests
{
    /// <summary>
    /// Ruby脚本引擎测试
    /// </summary>
    public class RubyDynamicScriptRuntimeTests
    {
        /// <summary>
        /// 动态执行Ruby脚本文件
        /// </summary>
        [Fact]
        public void RubyExecuteFileTest()
        {
            var result = DynamicScriptRuntime.Execute("Ruby/demo.rb");
            result.ShouldBe("Hello ruby!");
        }

        /// <summary>
        /// 执行指定的Ruby脚本内容,类型不包含.
        /// </summary>
        [Fact]
        public void RubyExecuteScriptTest()
        {
            var result = DynamicScriptRuntime.Execute(@"		
class DsRubyClass  
  def Invoke  
	'Hello ruby!'
  end  
end
            ", "rb");
            result.ShouldBe("Hello ruby!");
        }

        /// <summary>
        ///  执行指定的Ruby脚本内容,类型包含.
        /// </summary>
        [Fact]
        public void RubyExecuteScriptWithDotTest()
        {
            var result = DynamicScriptRuntime.Execute(@"		
class DsRubyClass  
  def Invoke  
	'Hello ruby!'
  end  
end
            ", ".rb");
            result.ShouldBe("Hello ruby!");
        }
    }
}
#endif
