using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.ORM.Core.Attributes
{
    /// <summary>
    /// 标记该属性不作为数据库的字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
    }
}
