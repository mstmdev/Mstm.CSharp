using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.CLR
{
    /// <summary>
    /// GC工具类
    /// </summary>
    public class GCUtil
    {
        /// <summary>
        /// 获取指定对象的GC句柄
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static GCHandle GetHandler(object obj)
        {
            return GCHandle.Alloc(obj);
        }
    }
}
