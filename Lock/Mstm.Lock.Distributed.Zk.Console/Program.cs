using Mstm.Lock.Distributed.ZK.Tests;
using System;
using Ctrl = System.Console;

namespace Mstm.Lock.Distributed.Zk.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ZKLockProviderTests test = new ZKLockProviderTests();
            test.LockTest();
            Ctrl.ReadLine();
        }
    }
}
