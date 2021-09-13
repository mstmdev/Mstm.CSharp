using Mstm.RedPacket.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mstm.RedPacket.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RunWithMultiThread();
        }


        /// <summary>
        /// 单一线程下运行
        /// </summary>
        static void RunWithSingleThread()
        {
            Func<RedPacketConfig> func = new Func<RedPacketConfig>(GetRedPacketConfig);
            var config = func.Invoke();
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

                System.Console.WriteLine(money + "");
            }
            System.Console.WriteLine("Sum:{0},Max:{1},Min:{2},Avg:{3},Error:{4},Count:{5}", Math.Round(currentAmount, 2), maxPkg, minPkg, avgPkg, errorCount, currentPackageCount);
            foreach (var item in errorList)
            {
                //System.Console.WriteLine("错误:{0}",item);
            }
            System.Console.ReadKey();
        }

        /// <summary>
        /// 控制配置的读写保持数据一致
        /// </summary>
        static object configRWLock = new object();

        /// <summary>
        /// 多线程下运行
        /// </summary>
        static void RunWithMultiThread()
        {

            Func<RedPacketConfig> func = new Func<RedPacketConfig>(GetRedPacketConfig);

            RedPacketConfig config = null;
            lock (configRWLock)
            {
                config = func.Invoke();
            }

            //尝试提前初始化红包池
            RedPacketProvider.TryInitPackagePool(func);

            for (int i = 0; i < config.PacketCount + 10; i++)
            {
                Thread thread = new Thread(() =>
                {
                    lock (configRWLock)
                    {
                        var money = RedPacketProvider.GetOneRedPacket(func);
                        System.Console.WriteLine(money + "");

                        //模拟红包池意外清空的情况
                        if (i == 100 || i == 60 || i == 210)
                        {
                            RedPacketProvider.Reset();
                        }


                        //模拟活动变更的情况
                        if (i == 190 || i == 105)
                        {
                            redPacketIdentity = Guid.NewGuid().ToString();
                        }

                        //模拟数据库  更新当前已发的红包总金额与总数
                        currentAmount += money;
                        currentPackageCount++;
                    }
                });

                thread.Start();
            }

            System.Console.WriteLine("正在统计总金额...");
            //暂停三秒 保证已经统计了所有金额
            Thread.Sleep(3000);
            System.Console.WriteLine("Sum:{0},Count:{1}", currentAmount, currentPackageCount);
            System.Console.ReadKey();
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

            //模拟活动进行时配置更改
            if (currentPackageCount >= 200)
            {
                amount += 200;
                packageCount += 6;
                ceiling = 5;
                //floor = 0;
            }

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
