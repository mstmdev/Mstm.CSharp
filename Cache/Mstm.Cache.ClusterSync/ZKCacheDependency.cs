using Mstm.Cache.ClusterSync.Core;
using org.apache.zookeeper;
using Rabbit.Zookeeper;
using Rabbit.Zookeeper.Implementation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{

    /// <summary>
    /// 使用Zookeeper作为缓存依赖实现的组件
    /// </summary>
    internal class ZKCacheDependency : ICacheDependency
    {
        private IZookeeperClient _zkClient;

        public ZKCacheDependency(ZookeeperClientOptions option)
        {
            if (option == null || string.IsNullOrWhiteSpace(option.ConnectionString))
            {
                throw new ArgumentException("无效的zookeeper配置参数，请检查配置!");
            }
            _zkClient = new ZookeeperClient(option);
        }


        /// <summary>
        /// 获取某个节点下的所有子节点，包括当前节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>所有子节点以及当前节点</returns>
        public List<string> GetAllChildren(string node)
        {
            List<string> result = new List<string>();
            result.Add(node);
            var childList = _zkClient.GetChildrenAsync(node).Result;
            if (childList != null && childList.Count() > 0)
            {
                foreach (var childNode in childList)
                {
                    string fullNode = string.Format("{0}/{1}", node, childNode);
                    result.AddRange(GetAllChildren(fullNode));
                }
            }
            return result;
        }

        //存储所有监听事件的引用，用于取消监听事件
        ConcurrentDictionary<string, NodeDataChangeHandler> _handlerRecord = new ConcurrentDictionary<string, NodeDataChangeHandler>();

        /// <summary>
        /// 监听指定的节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="callback">节点数据更改或者节点被删除时会触发该事件</param>
        /// <returns>Task</returns>
        public Task Listen(string node, CacheCallback<string> callback)
        {
            NodeDataChangeHandler handler = null;
            handler = (ct, args) =>
           {
               //节点被删除或者节点数据改动时清理该节点对应的缓存数据
               if (args.Type == Watcher.Event.EventType.NodeDataChanged || args.Type == Watcher.Event.EventType.NodeDeleted)
               {
                   if (callback != null)
                   {
                       callback(args.Path);
                   }
               }
               return Task.CompletedTask;
           };


            NodeDataChangeHandler handlerLast = null;
            if (_handlerRecord.ContainsKey(node))
            {
                handlerLast = _handlerRecord[node];
            }
            if (handlerLast != null)
            {
                //取消侦听
                _zkClient.UnSubscribeDataChange(node, handlerLast);
            }
            _handlerRecord[node] = handler;
            Task task = _zkClient.SubscribeDataChange(node, handler);
            return task;
        }


        /// <summary>
        /// 清理指定的缓存依赖节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="clearChildren">是否递归清理所有子节点</param>
        /// <returns>Task</returns>
        public Task ClearDependentNode(string node, bool clearChildren = false)
        {

            if (clearChildren)
            {
                return _zkClient.DeleteRecursiveAsync(node);
            }
            else
            {
                string value = GetDefaultValue();
                return _zkClient.SetDataAsync(node, Encoding.UTF8.GetBytes(value));
            }
        }


        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="value">节点数据</param>
        /// <returns>Task</returns>
        public Task CreateNode(string node, string value)
        {
            if (string.IsNullOrWhiteSpace(node) || node.StartsWith("/") == false)
            {
                return Task.FromException(new Exception("无效的node"));
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                return Task.FromException(new Exception("无效的value"));
            }
            return _zkClient.CreateRecursiveAsync(node, Encoding.UTF8.GetBytes(value));

        }


        /// <summary>
        /// 使用默认值创建节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>Task</returns>
        public Task CreateNodeWithDefaultValue(string node)
        {
            string value = GetDefaultValue();
            return CreateNode(node, value);
        }


        /// <summary>
        /// 创建或更新节点
        /// 节点已存在则更新节点，否则直接创建节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="value">节点数据</param>
        /// <returns>Task</returns>
        public Task CreateOrUpdateNode(string node, string value)
        {
            if (string.IsNullOrWhiteSpace(node) || node.StartsWith("/") == false)
            {
                return Task.FromException(new Exception("无效的node"));
            }
            if (string.IsNullOrWhiteSpace(value))
            {
                return Task.FromException(new Exception("无效的value"));
            }
            if (_zkClient.ExistsAsync(node).Result)
            {
                return _zkClient.SetDataAsync(node, Encoding.UTF8.GetBytes(value));
            }
            else
            {
                return CreateNode(node, value);
            }

        }

        /// <summary>
        /// 使用默认值创建或更新节点
        /// 节点已存在则更新节点，否则直接创建节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>Task</returns>
        public Task CreateOrUpdateNodeWithDefaultValue(string node)
        {
            string value = GetDefaultValue();
            return CreateOrUpdateNode(node, value);
        }


        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <returns>以当前时间作为默认值</returns>
        private string GetDefaultValue()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

    }
}
