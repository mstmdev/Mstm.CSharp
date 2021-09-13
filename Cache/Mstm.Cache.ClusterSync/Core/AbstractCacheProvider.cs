using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync.Core
{

    /// <summary>
    /// 封装缓存处理的抽象提供器，提供基本的缓存操作
    /// </summary>
    public abstract class AbstractCacheProvider : ICacheProvider
    {
        //根节点的名称
        private string _rootNode = "/mstmdev_cache";
        //缓存依赖操作接口
        private ICacheDependency _dependency;

        /// <summary>
        /// 构造函数
        /// </summary>
        public AbstractCacheProvider()
            : this(null)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dependency">缓存依赖操作接口</param>
        public AbstractCacheProvider(ICacheDependency dependency)
        {
            _dependency = dependency ?? GlobalCacheDependency.Instance.GetDefaultCacheDependency();
        }


        /// <summary>
        /// 根节点名称
        /// </summary>
        public virtual string RootNode
        {
            get { return _rootNode; }
            set
            {
                if (IsLegalNode(value) == false) { throw new Exception("无效的根节点信息," + value); }
                _rootNode = value;
            }
        }

        /// <summary>
        /// 清理所有根节点下的缓存数据
        /// </summary>
        public virtual Task ClearAll()
        {
            return this.Clear(_rootNode);
        }

        /// <summary>
        /// 递归清理指定节点缓存数据
        /// </summary>
        /// <param name="node">节点名称</param>
        public virtual Task Clear(string node)
        {
            node = BuildNode(node);
            if (IsLegalNode(node))
            {
                List<string> nodeList = this.GetAllChildren(node);
                return this.Clear(nodeList);
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// 清理单个缓存对象
        /// 通过清理zk节点数据触发缓存更新
        /// </summary>
        /// <param name="node">缓存节点名称</param>
        public virtual Task ClearOne(string node)
        {
            node = BuildNode(node);
            if (IsLegalNode(node))
            {
                //1.本地清理
                //手动清理本地的缓存，通过清理依赖节点来清理缓存是异步的，可能存在延迟
                this.ClearOneRealCache(node);

                //2.集群缓存清理
                //通过清理依赖的节点来统一清理所有主机上的缓存信息
                return this._dependency.ClearDependentNode(node);
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// 使用默认设置添加缓存
        /// </summary>
        /// <param name="node">缓存的节点名称，即Key</param>
        /// <param name="value">缓存的数据</param>
        public virtual Task Add(string node, object value)
        {
            CachePolicy policy = GlobalCachePolicy.Instance.GetDefaultCachePolicy();
            return this.Add(node, value, policy);
        }

        /// <summary>
        /// 使用自定义的缓存策略添加缓存
        /// </summary>
        /// <param name="node">缓存的节点名称，即Key</param>
        /// <param name="value">缓存的数据</param>
        /// <param name="policy">自定义的缓存策略</param>
        public virtual Task Add(string node, object value, CachePolicy policy)
        {
            node = BuildNode(node);
            //如果自定义的缓存策略为空，则获取全局默认配置
            policy = policy ?? GlobalCachePolicy.Instance.GetDefaultCachePolicy();
            if (policy.AbsoluteExpiration != TimeSpan.Zero && policy.SlidingExpiration != TimeSpan.Zero)
            {
                throw new Exception("AbsoluteExpiration或SlidingExpiration必须有一个设置为TimeSpan.Zero");
            }

            InsertCore(node, value, policy);

            //如果节点不存在则尝试使用默认值创建节点
            _dependency.CreateNodeWithDefaultValue(node).Wait();
            //每台主机缓存数据时  都会监听节点 节点更新时,更新各自主机的缓存数据
            if (policy.IsListenChildren)
            {
                return _dependency.Listen(node, this.ClearRealCache);
            }
            else
            {
                return _dependency.Listen(node, this.ClearOneRealCache);
            }


        }


        /// <summary>
        /// 通过键获取缓存数据
        /// </summary>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="node">缓存节点名称</param>
        /// <returns>缓存的数据结果</returns>
        public virtual TResult Get<TResult>(string node)
        {
            node = BuildNode(node);
            if (IsLegalNode(node))
            {
                try
                {
                    var obj = GetCore(node);
                    if (obj == null)
                    {
                        return default(TResult);
                    }
                    return (TResult)obj;
                }
                catch (Exception)
                {
                    return default(TResult);
                }
            }
            else
            {
                return default(TResult);
            }
        }



        #region 抽象方法 处理不同之间的缓存处理差异

        /// <summary>
        /// 写入缓存数据
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <param name="value">缓存数据</param>
        /// <param name="policy">缓存策略</param>
        public abstract void InsertCore(string node, object value, CachePolicy policy);

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>缓存数据</returns>
        public abstract object GetCore(string node);

        /// <summary>
        /// 移除缓存数据
        /// </summary>
        /// <param name="node">节点名称</param>
        public abstract void RemoveCacheCore(string node);

        #endregion


        #region 私有方法 处理内部事宜
        /// <summary>
        /// 循环清理多个节点的缓存
        /// </summary>
        /// <param name="nodeList"></param>
        private Task Clear(List<string> nodeList)
        {
            List<Task> taskList = new List<Task>();
            if (nodeList != null)
            {
                foreach (var node in nodeList)
                {
                    taskList.Add(ClearOne(node));
                }
            }
            return Task.WhenAll(taskList);
        }

        /// <summary>
        /// 获取某个节点下的所有子节点，包括当前节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>所有子节点以及当前节点</returns>
        private List<string> GetAllChildren(string node)
        {
            try
            {
                List<string> nodeList = this._dependency.GetAllChildren(node);
                return nodeList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 是否为合法的节点名称
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>是否合法</returns>
        private bool IsLegalNode(string node)
        {
            //校验节点是否合法  检验方式待加强
            bool isLegal = string.IsNullOrWhiteSpace(node) == false && node.StartsWith("/");
            return isLegal;
        }


        /// <summary>
        /// 构造最终的节点信息
        /// </summary>
        /// <param name="node">传递的节点信息</param>
        /// <returns>加上根节点的节点信息</returns>
        private string BuildNode(string node)
        {
            if (IsLegalNode(node) == false) { throw new Exception("无效的节点信息," + node); }
            if (node.StartsWith(this._rootNode) == false)
            {
                return string.Format("{0}{1}", this._rootNode, node);
            }
            else
            {
                return node;
            }
        }

        /// <summary>
        /// 清理单个真实存储的缓存对象
        /// </summary>
        /// <param name="node">缓存节点名称</param>
        private void ClearOneRealCache(string node)
        {
            node = BuildNode(node);
            if (IsLegalNode(node))
            {
                //直接清除本地内存
                this.RemoveCacheCore(node);
            }
        }



        /// <summary>
        /// 递归清理节点下的真实存储的缓存对象，包括子节点
        /// </summary>
        /// <param name="node">缓存节点名称</param>
        private void ClearRealCache(string node)
        {
            if (IsLegalNode(node))
            {
                List<string> nodeList = this.GetAllChildren(node);
                if (nodeList == null) { return; }
                foreach (var item in nodeList)
                {
                    ClearOneRealCache(item);
                }
            }
        }
        #endregion
    }
}
