using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Lock.Core
{

    /// <summary>
    /// 锁提供器核心接口
    /// </summary>
    public interface ILockProvider
    {
        /// <summary>
        /// 获取锁操作
        /// </summary>
        /// <returns>返回锁的操作句柄</returns>
        ILockerHandle Lock();

        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="handle">Lock时获取的锁句柄</param>
        void UnLock(ILockerHandle handle);
    }
}
