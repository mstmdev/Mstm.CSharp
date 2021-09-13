using Mstm.ORM.Core.Common;
using Mstm.ORM.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.ORM.Core
{
    public abstract partial class Repository<T> : IRepository<T>
         where T : class, IEntity, new()
    {
        #region Abstract

        /// <summary>
        /// 查询行数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public abstract Task<long> OnCountAsync(string where);

        /// <summary>
        /// 获取指定的单行，如果未找到则返回null，如果存在多行则抛出异常
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public abstract Task<T> OnGetSingleAsync(string where);

        /// <summary>
        /// 获取指定的数据集中的第一行
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public abstract Task<T> OnGetFirstAsync(string where, string orderBy);

        /// <summary>
        /// 筛选指定的数据行
        /// </summary>
        /// <param name="where">过滤条件</param>
        /// <returns>查询结果集</returns>
        public abstract Task<IList<T>> OnGetListAsync(string where);

        /// <summary>
        /// 筛选指定的数据行
        /// </summary>
        /// <param name="where">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <returns>查询结果集</returns>
        public abstract Task<IList<T>> OnGetListAsync(string where, string orderBy);

        /// <summary>
        /// 插入行
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public abstract Task<int> OnInsertAsync(params T[] entities);

        /// <summary>
        /// 逻辑删除指定的行
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public abstract Task<int> OnLogicalRemoveAsync(string where);

        /// <summary>
        /// 强制物理删除制定的行
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public abstract Task<int> OnForceRemoveAsync(string where);

        /// <summary>
        /// 更新指定的行
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="where"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public abstract Task<int> OnUpdateAsync(T entity, string where, params Expression<Func<T, object>>[] fields);

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parms">SQL参数</param>
        /// <returns></returns>
        public abstract Task<int> OnExecuteNonQueryAsync(string sql, object parms = null);

        /// <summary>
        /// 执行SQL语句返回IDataReader对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parms">SQL参数</param>
        /// <returns>返回IDataReader对象</returns>
        public abstract Task<IDataReader> OnExecuteReaderAsync(string sql, object parms = null);


        /// <summary>
        /// 执行SQL语句返回第一行第一列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parms">SQL参数</param>
        /// <returns>返回第一行第一列</returns>
        public abstract Task<object> OnExecuteScalarAsync(string sql, object parms = null);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public abstract Task<Page<T>> OnGetPageListAsync(int pageNum, int pageSize, string where);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public abstract Task<Page<T>> OnGetPageListAsync(int pageNum, int pageSize, string where, string orderby);
        #endregion

    }
}
