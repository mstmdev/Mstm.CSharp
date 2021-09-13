using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.ORM.Core.Linq
{
    /// <summary>
    /// Linq解析器接口
    /// </summary>
    public interface ILinqBuilder
    {
        /// <summary>
        /// 解析where语句
        /// </summary>
        /// <typeparam name="TSource">数据源类型</typeparam>
        /// <param name="where">where表达式</param>
        /// <returns>where表达式对应的sql语句</returns>
        string BuildWhere<TSource>(Expression<Func<TSource, bool>> where);


        /// <summary>
        /// 解析orderby语句
        /// </summary>
        /// <typeparam name="TSource">数据源类型</typeparam>
        /// <typeparam name="TKey">排序字段的类型</typeparam>
        /// <param name="orderby">orderby表达式</param>
        /// <param name="isDesc">是否降序排序，默认升序排序</param>
        /// <returns>orderby表达式对应的sql语句</returns>
        string BuildOrderBy<TSource>(Expression<Func<TSource, object>> orderBy, bool isDesc = false);

        /// <summary>
        /// 解析字段
        /// </summary>
        /// <typeparam name="TSource">数据源类型</typeparam>
        /// <param name="field">字段表达式</param>
        /// <returns>字段名称</returns>
        string BuildField<TSource>(Expression<Func<TSource, object>> field);

        /// <summary>
        /// 解析字段列表
        /// </summary>
        /// <typeparam name="TSource">数据源类型</typeparam>
        /// <param name="fields">字段表达式集合</param>
        /// <returns>字段名称集合</returns>
        List<string> BuildFieldList<TSource>(params Expression<Func<TSource, object>>[] fields);

        /// <summary>
        /// 解析字段列表
        /// </summary>
        /// <typeparam name="TSource">数据源类型</typeparam>
        /// <param name="fields">字段表达式集合</param>
        /// <returns>以英文逗号分隔的字符串</returns>
        string BuildFieldStr<TSource>(params Expression<Func<TSource, object>>[] fields);
    }
}
