using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Common.Thread
{
    /// <summary>
    /// 锁类型枚举
    /// </summary>
    public enum LockType
    {
        Monitor = 1,
        Mutex = 2,
        EventWaitHandle = 3,
        AutoResetEvent = 4,
        ManualResetEvent = 5,
        Semaphore = 6,
        ManualResetEventSlim = 7,
        ReaderWriterLockSlim = 8,
        CountdownEvent = 9,
        Barrier = 10
    }
}
