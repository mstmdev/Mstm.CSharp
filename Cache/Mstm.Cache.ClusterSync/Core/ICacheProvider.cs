using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync.Core
{

    /// <summary>
    /// 缓存操作接口
    /// </summary>
    public interface ICacheProvider
    {

        /// <summary>
        /// 根节点名称
        /// </summary>
        string RootNode { get; set; }

        /// <summary>
        ///强制清除所有缓存
        /// </summary>
        /// <returns>Task</returns>
        Task ClearAll();


        /// <summary>
        /// 递归清除指定节点及子节点的缓存信息
        /// </summary>
        /// <param name="node">缓存节点，如/cache/user/1001/address</param>
        /// <returns>Task</returns>
        Task Clear(string node);


        /// <summary>
        /// 清理单个缓存节点对象
        /// </summary>
        /// <param name="node">缓存节点，如/cache/user/1001/address</param>
        Task ClearOne(string node);

        /// <summary>
        /// 添加缓存信息
        /// 如果缓存已经存在则进行覆盖
        /// </summary>
        /// <param name="node">缓存节点信息</param>
        /// <param name="value">缓存的数据</param>
        /// <returns>Task</returns>
        Task Add(string node, object value);

        /// <summary>
        /// 添加缓存信息
        /// 如果缓存已经存在则进行覆盖
        /// </summary>
        /// <param name="node">缓存节点信息</param>
        /// <param name="value">缓存的数据</param>
        /// <param name="dependency">缓存策略</param>
        /// <returns>Task</returns>
        Task Add(string node, object value, CachePolicy dependency);

        /// <summary>
        /// 获取缓存信息
        /// </summary>
        /// <typeparam name="TResult">返回的对象类型</typeparam>
        /// <param name="node">缓存节点信息</param>
        /// <returns>缓存数据</returns>
        TResult Get<TResult>(string node);


    }
}
