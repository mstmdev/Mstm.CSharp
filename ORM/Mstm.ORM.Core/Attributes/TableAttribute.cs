using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.ORM.Core.Attributes
{
    /// <summary>
    /// 设置数据库表名
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        private string _tableName;
        public TableAttribute(string tableName)
        {
            _tableName = tableName;
        }

        public string TableName
        {
            get { return _tableName; }
        }
    }
}
