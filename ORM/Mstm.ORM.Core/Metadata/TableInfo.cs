using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Concurrent;
using System.Reflection;
using Mstm.ORM.Core.Entity;
using Mstm.ORM.Core.Attributes;

namespace Mstm.ORM.Core.Metadata
{
    /// <summary>
    /// 数据表信息
    /// </summary>
    public class TableInfo
    {
        /// <summary>
        /// 私有构造函数，禁止外部直接构造
        /// </summary>
        private TableInfo() { }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// 表映射的类型
        /// </summary>
        public Type TableType { get; private set; }

        /// <summary>
        /// 主键集合
        /// </summary>
        public List<string> PKList { get; private set; }

        /// <summary>
        /// 排序后的所有字段集合
        /// </summary>
        public List<string> Columns { get; private set; }

        /// <summary>
        /// Columns对应的所有属性
        /// </summary>
        public List<PropertyInfo> Properties { get; private set; }

        /// <summary>
        /// 获取所有列的字符串
        /// </summary>
        /// <param name="containKey"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public string GetColumnsStr(bool containKey = true, string prefix = "")
        {
            if (prefix == null) { prefix = ""; }
            if (Columns == null || Columns.Count == 0)
            {
                throw new ArgumentException("当前表没有任何列");
            }
            StringBuilder builder = new StringBuilder();
            int count = Columns.Count;
            for (int i = 0; i < count; i++)
            {
                if (containKey == false && PKList != null && PKList.Count > 0)
                {
                    if (PKList.Contains(Columns[i])) { continue; }
                }
                if (i == count - 1)
                {
                    builder.AppendFormat("{0}{1}", prefix, Columns[i]);
                    continue;
                }
                builder.AppendFormat("{0}{1},", prefix, Columns[i]);
            }
            return builder.ToString();
        }

        /// <summary>
        /// 是否继承自BaseEntity类
        /// </summary>
        public bool IsBaseEntity { get; private set; }

        /// <summary>
        /// 是否实现了IEntity接口
        /// </summary>
        public bool IsIEntity { get; private set; }

        /// <summary>
        /// 是否实现了ICreateRecord接口
        /// </summary>
        public bool IsICreateRecord { get; private set; }

        /// <summary>
        /// 是否实现了IDeleted接口
        /// </summary>
        public bool IsIDeleted { get; private set; }

        /// <summary>
        /// 是否实现了IModifyRecord接口
        /// </summary>
        public bool IsIModifyRecord { get; private set; }

        private static ConcurrentDictionary<Type, TableInfo> _cache = new ConcurrentDictionary<Type, TableInfo>();

        /// <summary>
        /// 获取实体对应的表结构信息
        /// </summary>
        /// <typeparam name="T">表对应的实体类型</typeparam>
        /// <returns></returns>
        public static TableInfo GetTableInfo<T>()
        {
            Type type = typeof(T);
            TableInfo table;
            if (_cache.TryGetValue(type, out table))
            {
                return table;
            };

            var properties = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Where(a => a.GetCustomAttributes(typeof(IgnoreAttribute), true).Length == 0);
            var isBaseEntity = type.IsSubclassOf(typeof(BaseEntity));
            table = new TableInfo()
            {
                TableType = type,
                TableName = type.Name,
                Properties = properties.OrderBy(a => a.Name).ToList(),
                //对字段进行排序，避免代码顺序对逻辑的影响
                Columns = properties.Select(a => a.Name).OrderBy(a => a).ToList(),
                PKList = properties.Where(a => a.CustomAttributes.Count(attr => attr.AttributeType == typeof(PKAttribute)) > 0).Select(a => a.Name).ToList(),
                IsBaseEntity = isBaseEntity,
                IsIDeleted = isBaseEntity ? true : type.GetInterface(nameof(IDeleted)) != null,
                IsICreateRecord = isBaseEntity ? true : type.GetInterface(nameof(ICreateRecord)) != null,
                IsIEntity = isBaseEntity ? true : type.GetInterface(nameof(IEntity)) != null,
                IsIModifyRecord = isBaseEntity ? true : type.GetInterface(nameof(IModifyRecord)) != null
            };
            var tableAttr = type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            if (tableAttr != null)
            {
                string tableName = ((TableAttribute)tableAttr).TableName;
                if (string.IsNullOrWhiteSpace(tableName) == false)
                {
                    table.TableName = tableName;
                }
            }
            _cache.TryAdd(table.TableType, table);
            return table;
        }
    }
}
