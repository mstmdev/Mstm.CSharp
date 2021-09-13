using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Mstm.Lock.Core;

namespace Mstm.Lock.Distributed.ZK.Tests
{
    public class ZKLockProviderTests
    {

        [Fact]
        public void LockTest()
        {
            var locker = LockFactory.GetProvider("ZKLockProvider");
            //var locker = new ZKLockProvider("/ZKLockProvider");

            int workCount = 10;
            for (int i = 0; i < workCount; i++)
            {
                new Worker().DoWork("Woker" + i, locker);
            }

        }
    }
}
