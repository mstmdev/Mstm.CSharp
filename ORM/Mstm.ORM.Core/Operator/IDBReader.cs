using Mstm.ORM.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.ORM.Core.Operator
{
    /// <summary>
    /// 数据库读操作接口
    /// </summary>
    public interface IDBReader<T>
    {
        Task<IList<T>> GetListAsync();

        Task<IList<T>> GetListAsync(string where);

        Task<IList<T>> GetListAsync(string where, string orderby);

        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where);

        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, string orderby);

        Task<Page<T>> GetPageListAsync(int pageNum, int pageSize);

        Task<Page<T>> GetPageListAsync(int pageNum, int pageSize, string where);

        Task<Page<T>> GetPageListAsync(int pageNum, int pageSize, string where, string orderby);

        Task<Page<T>> GetPageListAsync(int pageNum, int pageSize, Expression<Func<T, bool>> where);

        Task<Page<T>> GetPageListAsync(int pageNum, int pageSize, Expression<Func<T, bool>> where, string orderby);

        Task<T> GetSingleAsync(string where);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> where);

        Task<T> GetFirstAsync(string where, string orderBy);

        Task<long> CountAsync();

        Task<long> CountAsync(string where);

        Task<long> CountAsync(Expression<Func<T, bool>> where);
    }
}
