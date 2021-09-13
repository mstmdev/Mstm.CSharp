using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Reflection
{
    /// <summary>
    /// 动态类型相关工具类
    /// </summary>
    public class DynamicUtil
    {
        /// <summary>
        /// 获取一个动态类型实例
        /// </summary>
        /// <returns></returns>
        public static dynamic GetDynamicObject()
        {
            return new ExpandoObject();
        }
    }
}
