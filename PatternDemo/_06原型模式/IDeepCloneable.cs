using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06原型模式
{
    /// <summary>
    /// 深克隆接口
    /// </summary>
    interface IDeepCloneable
    {
        object DeepClone();
    }
}
