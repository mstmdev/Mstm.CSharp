using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.ORM.Core.Linq
{
    /// <summary>
    /// 默认Linq解析器
    /// </summary>
    public class LinqBuilder : ILinqBuilder
    {
        public string BuildField<TSource>(Expression<Func<TSource, object>> field)
        {
            if (field == null) { return null; }
            MemberExpression body = null;
            if (field.Body.NodeType == ExpressionType.Convert)
            {
                body = (field.Body as UnaryExpression).Operand as MemberExpression;
            }
            else
            {
                body = field.Body as MemberExpression;
            }
            string fieldName = body.Member.Name;
            return fieldName;
        }

        public List<string> BuildFieldList<TSource>(params Expression<Func<TSource, object>>[] fields)
        {
            List<string> fieldList = new List<string>();
            if (fields == null || fields.Length == 0) { return fieldList; }
            for (int i = 0; i < fields.Length; i++)
            {
                string fieldName = BuildField(fields[i]);
                if (string.IsNullOrWhiteSpace(fieldName) == false)
                {
                    fieldList.Add(fieldName);
                }
            }
            //字段去重
            fieldList = fieldList.Distinct().ToList();
            return fieldList;
        }

        public string BuildFieldStr<TSource>(params Expression<Func<TSource, object>>[] fields)
        {
            StringBuilder fieldBuilder = new StringBuilder();
            List<string> fieldList = BuildFieldList(fields);
            if (fieldList == null || fieldList.Count == 0) { return fieldBuilder.ToString(); }
            for (int i = 0; i < fieldList.Count; i++)
            {
                fieldBuilder.Append(fieldList[i]);
                if (i != fieldList.Count - 1)
                {
                    fieldBuilder.Append(",");
                }
            }
            return fieldBuilder.ToString();
        }

        public string BuildOrderBy<TSource>(Expression<Func<TSource, object>> orderBy, bool isDesc = false)
        {
            string fieldName = this.BuildField(orderBy);
            string orderType = "ASC";
            orderType = isDesc ? "DESC" : orderType;
            string orderByStr = string.Format(" ORDER BY {0} {1} ", fieldName, orderType);
            return orderByStr;
        }

        public string BuildWhere<TSource>(Expression<Func<TSource, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
