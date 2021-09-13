using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Lock.Core
{
    /// <summary>
    /// 锁提供器抽象类，所有锁的实现应继承该类
    /// </summary>
    public abstract class AbstractLockProvider : ILockProvider
    {
        /// <summary>
        /// 某个锁的唯一标识，业务需要保证改值为全局唯一
        /// </summary>
        public string IdentityName { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="identityName">当前锁的唯一标识</param>
        public AbstractLockProvider(string identityName)
        {
            IdentityName = identityName;
        }

        /// <summary>
        /// 获取锁操作
        /// </summary>
        /// <returns>返回锁的操作句柄</returns>
        public abstract ILockerHandle Lock();

        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="handler">Lock时获取的锁句柄</param>
        public abstract void UnLock(ILockerHandle handler);
    }
}
