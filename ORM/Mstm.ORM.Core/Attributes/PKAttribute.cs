using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.ORM.Core.Attributes
{
    /// <summary>
    /// 标记属性为主键
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PKAttribute : Attribute
    {
    }
}
