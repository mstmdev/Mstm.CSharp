using System;
using Mstm.RedPacket.Core;
using System.Collections.Generic;
using Xunit;
using Shouldly;

namespace Mstm.RedPacket.Tests
{
    public class RedPacketProviderTests
    {
        [Fact]
        public void GetOneRedPacketTestLoop()
        {
            for (int i = 0; i < 100; i++)
            {
                GetOneRedPacketTest();
                RedPacketProvider.Reset();
            }
        }

        [Fact]
        public void GetOneRedPacketTestSingle()
        {
            GetOneRedPacketTest();
        }

        /// <summary>
        /// 控制配置的读写保持数据一致
        /// </summary>
        static object configRWLock = new object();

        private void GetOneRedPacketTest()
        {
            Func<RedPacketConfig> func = new Func<RedPacketConfig>(GetRedPacketConfig);
            RedPacketConfig config = null;
            lock (configRWLock)
            {
                config = func.Invoke();
            }
            int errorCount = 0;
            List<decimal> errorList = new List<decimal>();

            //均分红包
            decimal avgPkg = Math.Round(config.Amount / config.PacketCount, 2);
            //最大红包
            decimal maxPkg = Math.Round(avgPkg * (100 + config.Ceiling) / 100, 2);
            //最小红包
            decimal minPkg = Math.Round(avgPkg * (100 - config.Floor) / 100, 2);


            while (true)
            {
                lock (configRWLock)
                {
                    var money = RedPacketProvider.GetOneRedPacket(func);
                    if (money <= 0) { break; }
                    if (money > maxPkg || money < minPkg)
                    {
                        errorList.Add(money);
                        errorCount++;
                    }
                    //模拟数据库  更新当前已发的红包总金额与总数
                    currentAmount += money;
                    currentPackageCount++;
                }
            }

            config.Amount.ShouldBe(currentAmount);
            errorCount.ShouldBe(0);
        }



        //当前已发红包总金额
        static decimal currentAmount = 0;
        //当前已发红包总数
        static int currentPackageCount = 0;
        //活动标识
        static string redPacketIdentity = "1001";

        /// <summary>
        /// 获取红包配置
        /// </summary>
        /// <returns></returns>
        static RedPacketConfig GetRedPacketConfig()
        {
            //总金额
            decimal amount = 300 * 300 + 100;
            //100 * 81 + 17  有3.32  小于最小值3.33
            //总红包数
            int packageCount = 250;
            //上限
            decimal ceiling = 20;
            //下限
            decimal floor = 30;
            //均分红包
            decimal avgPkg = Math.Round(amount / packageCount, 2);
            //最大红包
            decimal maxPkg = Math.Round(avgPkg * (100 + ceiling) / 100, 2);
            //最小红包
            decimal minPkg = Math.Round(avgPkg * (100 - floor) / 100, 2);

            RedPacketConfig config = new RedPacketConfig()
            {
                Amount = amount,
                PacketCount = packageCount,
                CurrentAmount = currentAmount,
                CurrentPackageCount = currentPackageCount,
                Ceiling = ceiling,
                Floor = floor,
                StartTime = DateTime.Now.AddMinutes(-10),
                EndTime = DateTime.Now.AddMinutes(10),
                RedPacketIdentity = redPacketIdentity
            };
            return config;


        }
    }
}
