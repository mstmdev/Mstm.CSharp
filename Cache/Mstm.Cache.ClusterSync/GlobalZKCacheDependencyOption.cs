using Rabbit.Zookeeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync
{
    /// <summary>
    /// ZKCacheDependency的全局配置选项
    /// </summary>
    public class GlobalZKCacheDependencyOption
    {
        private GlobalZKCacheDependencyOption() { }
        private static GlobalZKCacheDependencyOption _instance = new GlobalZKCacheDependencyOption();
        //存储zk的相关配置信息
        private ZookeeperClientOptions _zkOption;

        /// <summary>
        /// 当前类型的实例 单例模式
        /// </summary>
        public static GlobalZKCacheDependencyOption Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// 获取zookeeper缓存依赖配置
        /// </summary>
        /// <returns>zookeeper缓存依赖配置信息</returns>
        public ZookeeperClientOptions GetDefaultZKCacheDependencyOption()
        {
            if (_zkOption == null || string.IsNullOrWhiteSpace(_zkOption.ConnectionString))
            {
                throw new ArgumentException("缓存ZK配置不正确，请检查响应的ZK配置!");
            }
            return _zkOption;
        }


        /// <summary>
        /// 设置zookeeper缓存依赖配置
        /// </summary>
        /// <param name="connectionString">zookeeper连接信息</param>
        public void SetDefaultZKCacheDependencyOption(string connectionString)
        {
            _zkOption = new ZookeeperClientOptions()
            {
                ConnectionString = connectionString,
            };
        }

        /// <summary>
        /// 设置zookeeper缓存依赖配置
        /// </summary>
        /// <param name="connectionString">zookeeper连接信息</param>
        /// <param name="basePath">基本路径</param>
        public void SetDefaultZKCacheDependencyOption(string connectionString, string basePath)
        {
            _zkOption = new ZookeeperClientOptions()
            {
                ConnectionString = connectionString,
                BasePath = basePath
            };
        }

        /// <summary>
        /// 设置zookeeper缓存依赖配置
        /// </summary>
        /// <param name="connectionString">zookeeper连接信息</param>
        /// <param name="basePath">基本路径</param>
        /// <param name="connTimeout">连接超时时间</param>
        public void SetDefaultZKCacheDependencyOption(string connectionString, string basePath, TimeSpan connTimeout)
        {
            _zkOption = new ZookeeperClientOptions()
            {
                ConnectionString = connectionString,
                BasePath = basePath,
                ConnectionTimeout = connTimeout
            };
        }

        /// <summary>
        /// 设置zookeeper缓存依赖配置
        /// </summary>
        /// <param name="connectionString">zookeeper连接信息</param>
        /// <param name="basePath">基本路径</param>
        /// <param name="connTimeout">连接超时时间</param>
        /// <param name="operaTimeout">操作超时时间</param>
        public void SetDefaultZKCacheDependencyOption(string connectionString, string basePath, TimeSpan connTimeout, TimeSpan operaTimeout)
        {
            _zkOption = new ZookeeperClientOptions()
            {
                ConnectionString = connectionString,
                BasePath = basePath,
                ConnectionTimeout = connTimeout,
                OperatingTimeout = operaTimeout
            };
        }

        /// <summary>
        /// 设置zookeeper缓存依赖配置
        /// </summary>
        /// <param name="connectionString">zookeeper连接信息</param>
        /// <param name="basePath">基本路径</param>
        /// <param name="connTimeout">连接超时时间</param>
        /// <param name="operaTimeout">操作超时时间</param>
        /// <param name="isReadonly">是否只读</param>
        public void SetDefaultZKCacheDependencyOption(string connectionString, string basePath, TimeSpan connTimeout, TimeSpan operaTimeout, bool isReadonly)
        {
            _zkOption = new ZookeeperClientOptions()
            {
                ConnectionString = connectionString,
                BasePath = basePath,
                ConnectionTimeout = connTimeout,
                OperatingTimeout = operaTimeout,
                ReadOnly = isReadonly
            };
        }


        /// <summary>
        /// 设置zookeeper缓存依赖配置
        /// </summary>
        /// <param name="connectionString">zookeeper连接信息</param>
        /// <param name="basePath">基本路径</param>
        /// <param name="connTimeout">连接超时时间</param>
        /// <param name="operaTimeout">操作超时时间</param>
        /// <param name="isReadonly">是否只读</param>
        /// <param name="sessionId">会话Id</param>
        /// <param name="sessionPwd">会话密码</param>
        /// <param name="sessionTimeout">会话超时时间</param>
        public void SetDefaultZKCacheDependencyOption(string connectionString, string basePath, TimeSpan connTimeout, TimeSpan operaTimeout, bool isReadonly, long sessionId, byte[] sessionPwd, TimeSpan sessionTimeout)
        {
            _zkOption = new ZookeeperClientOptions()
            {
                ConnectionString = connectionString,
                BasePath = basePath,
                ConnectionTimeout = connTimeout,
                OperatingTimeout = operaTimeout,
                ReadOnly = isReadonly,
                SessionId = sessionId,
                SessionPasswd = sessionPwd,
                SessionTimeout = sessionTimeout
            };
        }
    }
}
