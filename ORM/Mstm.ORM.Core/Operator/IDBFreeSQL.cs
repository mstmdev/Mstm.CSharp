using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.ORM.Core.Operator
{
    /// <summary>
    /// 复杂自由的SQL语句执行接口
    /// </summary>
    public interface IDBFreeSQL
    {
        /// <summary>
        /// 执行SQL语句返回受影响的行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parms">参数</param>
        /// <returns>受影响的行数</returns>
        Task<int> ExecuteNonQueryAsync(string sql, object parms = null);

        /// <summary>
        /// 执行SQL语句返回IDataReader对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parms">SQL参数</param>
        /// <returns>返回IDataReader对象</returns>
        Task<IDataReader> ExecuteReaderAsync(string sql, object parms = null);

        /// <summary>
        /// 执行SQL语句返回第一行第一列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parms">SQL参数</param>
        /// <returns>返回第一行第一列</returns>
        Task<object> ExecuteScalarAsync(string sql, object parms = null);

        Task<TEntity> ExecuteAsync<TEntity>(string sql, object parms = null);

        Task<IList<TEntity>> ExecuteListAsync<TEntity>(string sql, object parms = null);
    }
}
