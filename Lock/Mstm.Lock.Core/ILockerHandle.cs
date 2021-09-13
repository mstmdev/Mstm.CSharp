using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Lock.Core
{
    /// <summary>
    /// 锁句柄接口
    /// </summary>
    public interface ILockerHandle
    {
        /// <summary>
        /// 释放锁
        /// </summary>
        void UnLock();
    }
}
