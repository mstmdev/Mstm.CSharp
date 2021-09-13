using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Mstm.ORM.Core.Common
{
    /// <summary>
    /// 字段表达式比较器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class FieldExpressionComparer<T> : IEqualityComparer<Expression<Func<T, object>>>
    {
        public bool Equals(Expression<Func<T, object>> x, Expression<Func<T, object>> y)
        {
            if (x == null && y == null) { return true; }
            if (x == null || y == null) { return false; }
            string fieldNameX, fieldNameY = "";
            fieldNameX = GetFieldName(x).ToLower();
            fieldNameY = GetFieldName(y).ToLower();
            if (fieldNameX == null && fieldNameY == null) { return true; }
            if (fieldNameX == null || fieldNameY == null) { return false; }
            bool isEqual = fieldNameX.ToLower().Trim() == fieldNameY.ToLower().Trim();
            return isEqual;
        }

        public int GetHashCode(Expression<Func<T, object>> obj)
        {
            string fieldName = GetFieldName(obj);
            int hashCode = fieldName.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// 从表达式中获取实际表现的字段名称
        /// </summary>
        /// <param name="expression">字段吧表达式</param>
        /// <returns></returns>
        private string GetFieldName(Expression<Func<T, object>> expression)
        {
            MemberExpression body = null;
            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                body = (expression.Body as UnaryExpression).Operand as MemberExpression;
            }
            else
            {
                body = expression.Body as MemberExpression;
            }
            if (body == null) { return null; }
            return body.Member.Name;
        }
    }
}
