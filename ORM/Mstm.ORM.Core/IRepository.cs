using Mstm.ORM.Core.Entity;
using Mstm.ORM.Core.Operator;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Mstm.ORM.Core
{
    /// <summary>
    /// 数据库仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDBReader<T>, IDBWriter<T>, IDBStoredProcedure, IDBFreeSQL, IDBTransaction
        where T : class, IEntity
    {
        /// <summary>
        /// 手动打开数据库连接
        /// </summary>
        void Open();

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        string ConnectionStr { get; }

        /// <summary>
        /// 根据当前的实体T构建where语句
        /// 如果实体实现了IDeleted接口，则进行IsDeleted过滤
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        string BuildWhere(string where = null);

        /// <summary>
        /// 根据指定的实体TEntity构建where语句
        /// 如果实体TEntity实现了IDeleted接口，则进行IsDeleted过滤
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        string BuildWhere<TEntity>(string where = null);

        /// <summary>
        /// 构建包含IsDeleted筛选的where语句
        /// </summary>
        /// <param name="where"></param>
        /// <returns>包含IsDeleted过滤的where语句</returns>
        string BuildIsDeletedWhere(string where = null);
    }
}
