using Mstm.Log.Core;
using System;
using Xunit;

namespace Mstm.Log.Core.Test
{
    public class Log4NetProviderTests
    {
        [Fact]
        public void GetLoggerDefaultTest()
        {
            var logger = LogFactory.GetProvider<Log4NetProviderTests>();
            logger.Info("hello Info  from Default");
            logger.Debug("hello Debug from Default");
            logger.Warn("hello Warn from Default");
            logger.Error("hello Error from Default");
            logger.Fatal("hello Fatal from Default");
        }

        [Fact]
        public void GetLoggerDefault2Test()
        {
            var logger = LogFactory.GetProvider<Log4NetProviderTests>("Default2");
            logger.Info("hello Info from Default2");
            logger.Debug("hello Debug  from Default2");
            logger.Warn("hello Warn  from Default2");
            logger.Error("hello Error  from Default2");
            logger.Fatal("hello Fatal  from Default2");
        }

        [Fact]
        public void GetLoggerDefault3Test()
        {
            var logger = LogFactory.GetProvider<Log4NetProviderTests>("Default3");
            logger.Info("hello Info from Default3");
            logger.Debug("hello Debug  from Default3");
            logger.Warn("hello Warn  from Default3");
            logger.Error("hello Error  from Default3");
            logger.Fatal("hello Fatal  from Default3");
        }
    }
}
