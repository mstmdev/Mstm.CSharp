using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.ORM.Core.Operator
{
    /// <summary>
    /// 数据库写操作接口
    /// </summary>
    public interface IDBWriter<T>
    {
        Task<int> InsertAsync(params T[] entities);

        Task<int> UpdateAsync(T entity, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] fields);

        Task<int> UpdateAsync(T entity, string where, params Expression<Func<T, object>>[] fields);

        Task<int> RemoveAsync(string where);

        Task<int> RemoveAsync(Expression<Func<T, bool>> where);

        Task<int> ForceRemoveAsync(string where);

        Task<int> ForceRemoveAsync(Expression<Func<T, bool>> where);
    }
}
