using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{

    /// <summary>
    /// Redis分页查询相关接口
    /// </summary>
    public interface IRedisPageList
    {

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>查询结果集</returns>
        ICollection<T> GetAll<T>(string key);


        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="pageIndex">当前要查询的页索引，从0开始</param>
        /// <param name="pageSize">页大小</param>
        /// <returns>查询结果集</returns>
        ICollection<T> GetPageList<T>(string key, int pageIndex, int pageSize);
    }

}
