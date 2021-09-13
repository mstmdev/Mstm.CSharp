using Mstm.Lock.Core;
using org.apache.zookeeper.recipes.@lock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Lock.Distributed.ZK
{
    /// <summary>
    /// ZK分布式锁的处理句柄
    /// </summary>
    public class ZKLockHandle : ILockerHandle
    {
        /// <summary>
        /// 内部实现使用的实际锁对象
        /// </summary>
        WriteLock _locker;

        /// <summary>
        ///构造函数
        /// </summary>
        /// <param name="locker">当前WriteLock实例</param>
        public ZKLockHandle(WriteLock locker) => _locker = locker ?? throw new ArgumentNullException(nameof(locker), "当前WriteLock锁为空");

        /// <summary>
        /// 释放锁
        /// </summary>
        public void UnLock()
        {
            _locker.unlock();
        }
    }
}
