using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11抽象工厂模式
{

    /// <summary>
    /// 数据库操作基本接口
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IBaseOperation<TModel>
    {
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        void Add(TModel model);

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(TModel model);

        /// <summary>
        /// 根据主键Id删除一条记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int Delete(long key);

        /// <summary>
        /// 根据主键Id查询一条记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TModel SelectById(long key);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns></returns>
        ICollection<TModel> SelectAll();
    }
}
