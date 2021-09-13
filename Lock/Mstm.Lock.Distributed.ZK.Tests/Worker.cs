using Mstm.Lock.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Lock.Distributed.ZK.Tests
{
    /// <summary>
    /// 工作模拟类
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// 开始工作
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="locker"></param>
        public void DoWork(string tag, ILockProvider locker)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Task.Run(() =>
            {
                var handler = locker.Lock();
                foreach (var item in list)
                {
                    string content = tag + "-->" + item;
                    Console.WriteLine(content);
                }
                locker.UnLock(handler);
            });
        }
    }
}
