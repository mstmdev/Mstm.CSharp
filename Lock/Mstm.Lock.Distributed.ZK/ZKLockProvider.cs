using Mstm.Lock.Core;
using org.apache.zookeeper;
using org.apache.zookeeper.data;
using org.apache.zookeeper.recipes.@lock;
using Rabbit.Zookeeper;
using Rabbit.Zookeeper.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mstm.Lock.Distributed.ZK
{
    /// <summary>
    /// ZK分布式锁提供器
    /// </summary>
    public class ZKLockProvider : AbstractLockProvider
    {
        IZookeeperClient _zkClient;
        private readonly static List<ACL> ACL = ZooDefs.Ids.OPEN_ACL_UNSAFE;
        /// <summary>
        /// zookeeper配置信息
        /// </summary>
        protected ZKConfig ZKConfig;

        /// <summary>
        /// 当前锁在zk中的节点信息
        /// </summary>
        private string NodeName
        {
            get
            {
                string nodeName;
                if (ZKConfig.LockZKRoot.EndsWith("/"))
                {
                    nodeName = ZKConfig.LockZKRoot + this.IdentityName;
                }
                else
                {
                    nodeName = ZKConfig.LockZKRoot + "/" + this.IdentityName;
                }
                return nodeName;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="identity">当前锁的唯一标识</param>
        public ZKLockProvider(string identity)
            : base(identity)
        {
            ZKConfig = ZKConfig.New();
            _zkClient = new ZookeeperClient(ZKConfig.ConnStr);
            if (_zkClient.ExistsAsync(NodeName).Result == false)
            {
                _zkClient.CreateRecursiveAsync(NodeName, ZKConfig.LockZKValue.Bytes());
            }
        }

        /// <summary>
        /// 获取锁
        /// </summary>
        /// <returns>锁操作句柄</returns>
        public override ILockerHandle Lock()
        {
            WriteLock locker = new WriteLock(_zkClient.ZooKeeper, NodeName, ACL);
            locker.Lock().Wait();
            while (true)
            {
                if (locker.Owner) { return new ZKLockHandle(locker); }
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="handler">Lock时获取的锁操作句柄</param>
        public override void UnLock(ILockerHandle handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler), "解锁失败，handler为空，当前NodeName为" + NodeName);
            }
            handler.UnLock();
        }
    }
}
