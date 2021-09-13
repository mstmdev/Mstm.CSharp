using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync.Core
{

    /// <summary>
    /// 缓存依赖操作接口
    /// </summary>
    public interface ICacheDependency
    {
        /// <summary>
        /// 获取某个节点下的所有子节点，包括当前节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>所有子节点以及当前节点</returns>
        List<string> GetAllChildren(string node);


        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="value">节点数据</param>
        /// <returns>Task</returns>
        Task CreateNode(string node, string value);

        /// <summary>
        /// 使用默认值创建节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>Task</returns>
        Task CreateNodeWithDefaultValue(string node);

        /// <summary>
        /// 创建或更新节点
        /// 节点已存在则更新节点，否则直接创建节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="value">节点数据</param>
        /// <returns>Task</returns>
        Task CreateOrUpdateNode(string node, string value);

        /// <summary>
        /// 使用默认值创建或更新节点
        /// 节点已存在则更新节点，否则直接创建节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>Task</returns>
        Task CreateOrUpdateNodeWithDefaultValue(string node);

        /// <summary>
        /// 监听指定的节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="callback">节点数据更改或者节点被删除时会触发该事件</param>
        Task Listen(string node, CacheCallback<string> callback);


        /// <summary>
        /// 清理指定的缓存依赖节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="clearChildren">是否递归清理所有子节点</param>
        /// <returns>Task</returns>
        Task ClearDependentNode(string node, bool clearChildren = false);

    }
}
