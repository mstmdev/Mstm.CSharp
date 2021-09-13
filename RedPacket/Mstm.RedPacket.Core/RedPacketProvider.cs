using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace Mstm.RedPacket.Core
{

    /// <summary>
    /// 发红包服务类
    /// 红包根据上限Ceiling与下限Floor进行分配 尽量保证红包总金额在指定的红包数内分发完毕
    /// 以下情况下，红包分发可能存在误差
    ///     1、上限或者下限为0时，如果红包均分时无法除尽，则会有部分金额剩余
    ///     2、如果总金额不足以按照最低红包大小进行分发时，整个红包池都为0
    /// </summary>
    public class RedPacketProvider
    {

        /// <summary>
        /// 记录红包池
        /// </summary>
        private static ConcurrentQueue<decimal> packagePool;

        /// <summary>
        /// 记录当前活动的配置
        /// </summary>
        private static RedPacketConfig redPacketConfig;


        /// <summary>
        /// 获取红包
        /// </summary>
        /// <param name="func">获取当前红包活动配置的委托</param>
        /// <returns>当前红包的金额，如果为0则活动结束</returns>
        public static decimal GetOneRedPacket(Func<RedPacketConfig> func)
        {
            lock (lockObj)
            {
                decimal money = 0;

                //首先检查配置
                //获取红包相关配置
                var currentConfig = func.Invoke();
                DateTime now = DateTime.Now;
                if (currentConfig == null)
                {
                    return 0;
                }

                //检查配置 是否需要更新 保证配置是最新的
                CheckRedPackageConfig(currentConfig);

                //活动已结束或者活动未开始
                if (currentConfig.StartTime > now || currentConfig.EndTime < now)
                {
                    packagePool = null;
                    return 0;
                }

                //红包已发完也直接退出
                if (redPacketConfig.CurrentPackageCount >= redPacketConfig.PacketCount || redPacketConfig.CurrentAmount >= redPacketConfig.Amount)
                {
                    return 0;
                }


                if (packagePool == null)
                {
                    //当红包池为空时根据配置重新生成红包池
                    InitPackagePool(redPacketConfig.Amount - redPacketConfig.CurrentAmount, redPacketConfig.PacketCount - redPacketConfig.CurrentPackageCount, redPacketConfig.Ceiling, redPacketConfig.Floor);
                }

                //获取单个红包
                money = GetOnePkg();

                //更新本地红包统计
                if (money > 0 && redPacketConfig != null)
                {
                    redPacketConfig.CurrentPackageCount++;
                    redPacketConfig.CurrentAmount += money;
                }

                return money;
            }
        }



        /// <summary>
        /// 尝试初始化红包池
        /// 可用于提前初始化红包池  减少第一位用户的等待时间
        /// </summary>
        /// <param name="func">获取当前红包活动配置的委托</param>
        /// <returns>当前红包的金额，如果为0则活动结束</returns>
        public static void TryInitPackagePool(Func<RedPacketConfig> func)
        {
            if (packagePool == null)
            {
                //当红包池为空时根据配置重新生成红包池
                //获取红包相关配置
                var redPacketConfig = func.Invoke();
                //为获取到配置则直接退出
                if (redPacketConfig == null) { return; }

                //红包已发完也直接退出
                if (redPacketConfig.CurrentPackageCount >= redPacketConfig.PacketCount || redPacketConfig.CurrentAmount >= redPacketConfig.Amount)
                {
                    return;
                }

                InitPackagePool(redPacketConfig.Amount - redPacketConfig.CurrentAmount, redPacketConfig.PacketCount - redPacketConfig.CurrentPackageCount, redPacketConfig.Ceiling, redPacketConfig.Floor);
            }

            return;
        }

        /// <summary>
        /// 检查配置，判断是否需要更新当前配置并清空红包池
        /// </summary>
        /// <param name="newestConfig">当前最新的实时配置信息</param>
        private static void CheckRedPackageConfig(RedPacketConfig newestConfig)
        {
            //当前配置为空或者本地配置中红包已经发放完毕则更新配置并重置红包池
            if (redPacketConfig == null || redPacketConfig.CurrentPackageCount >= redPacketConfig.PacketCount || redPacketConfig.CurrentAmount >= redPacketConfig.Amount)
            {
                redPacketConfig = newestConfig;
                packagePool = null;
                return;
            }

            //活动标识不一致 说明配置信息需要更新了
            if (newestConfig.RedPacketIdentity != redPacketConfig.RedPacketIdentity)
            {
                redPacketConfig = newestConfig;
                packagePool = null;
                return;
            }

            //处理如果在活动进行中修改了活动配置中的总金额、红包总数、红包浮动上限、红包浮动下限
            //这里更新配置并清空红包池  等待重新生成红包池
            if (redPacketConfig.Amount != newestConfig.Amount || redPacketConfig.PacketCount != newestConfig.PacketCount || redPacketConfig.Ceiling != newestConfig.Ceiling || redPacketConfig.Floor != newestConfig.Floor)
            {
                redPacketConfig = newestConfig;
                packagePool = null;
                return;
            }
        }


        static object lockObj = new object();

        /// <summary>
        /// 初始化红包池
        /// </summary>
        /// <param name="amount">红包总额</param>
        /// <param name="packageCount">红包总数</param>
        /// <param name="ceiling">浮动上限（0-100)</param>
        /// <param name="floor">浮动下限（0-100）</param>
        private static void InitPackagePool(decimal amount, int packageCount, decimal ceiling, decimal floor)
        {

            lock (lockObj)
            {
                if (packagePool != null) { return; }
                if (amount <= 0 || packageCount <= 0 || ceiling < 0 || ceiling > 100 || floor < 0 || floor > 100)
                {
                    return;
                }
                Console.WriteLine("Init---" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                packagePool = new ConcurrentQueue<decimal>();
                lock (packagePool)
                {
                    #region 处理红包均分时的情况

                    //如果上下限中有一个为零  那么红包只能进行均分
                    if (ceiling * floor == 0) { floor = 0; ceiling = 0; }
                    //如果是均分红包及floor与ceiling都为0 则直接分配 如果有剩余则直接舍弃
                    if (floor == 0 && ceiling == 0)
                    {
                        //计算均分的红包大小，保证不会进行五入操作
                        var pkg = Math.Floor(Math.Floor(amount * 100) / packageCount) / 100;
                        for (int i = 0; i < packageCount; i++)
                        {
                            packagePool.Enqueue(pkg);
                        }
                        return;
                    }
                    #endregion


                    //乘以100，去掉小数点
                    amount = Math.Round(amount, 2) * 100;

                    //计算当前可随机分配的值  保留红包的最低金额
                    var randAmount = amount * floor / 100;

                    //分发时去除余数  减轻小数的影响
                    decimal amountMod = amount % packageCount;
                    randAmount -= amountMod;


                    //分发的红包可能出现0.01级别的误差
                    //这里对红包的界限进行进位处理

                    //均分红包
                    decimal avgPkg = Math.Ceiling((amount - amountMod) / packageCount);
                    //最小红包
                    decimal minPkg = Math.Ceiling(avgPkg * (100 - floor) / 100);
                    //最大红包
                    decimal maxPkg = Math.Ceiling(avgPkg * (100 + ceiling) / 100);

                    //两个红包间可能的最大差值
                    decimal diffValue = maxPkg - minPkg;

                    //随机分配一次红包  总数为packageCount
                    AssignRedPacket(diffValue, packageCount);


                    //第一次分配完之后  红包总数可能超过或者小于总金额的限定
                    //这里对剩余或者溢出的情况进行处理
                    while (true)
                    {
                        //计算剩余或者溢出的部分
                        var otherSection = randAmount - packagePool.Sum();

                        //如果剩余或者溢出的部分被均分后小于1（实际就是小于0.01，即最小精度），则舍弃剩余或者溢出的部分
                        //否则就会陷入死循环
                        if (otherSection / packageCount < 1)
                        {
                            break;
                        }

                        //处理剩余或者溢出的部分
                        if (otherSection > 0)
                        {
                            //剩余
                            ProcessRemainSection(diffValue, otherSection);
                        }
                        else if (otherSection < 0)
                        {
                            //溢出了
                            ProcessOverflowSection(diffValue, Math.Abs(otherSection));
                        }
                        else
                        {
                            //等于0则处理完毕
                            break;
                        }
                    }

                    //所以这里要将所有红包恢复到正常的值  将附加的状态都恢复正常
                    ReNormal(minPkg);


                    //处理因除不尽导致的误差
                    ProcessPrecisionError(amount / 100, maxPkg / 100, minPkg / 100);
                }
            }
        }




        /// <summary>
        /// 按照红包总数分配一次红包
        /// 如果递归  maxCount超过1W左右容易溢出 这里改为循环
        /// </summary>
        /// <param name="diffValue">红包间最大的差值</param>
        /// <param name="packetCount">红包总数</param>
        private static void AssignRedPacket(decimal diffValue, int packetCount)
        {
            for (int i = 0; i < packetCount; i++)
            {
                packagePool.Enqueue(GetRandMoney(0, (int)diffValue));
            }
        }


        /// <summary>
        /// 处理溢出
        /// </summary>
        /// <param name="diffValue">红包间最大的差值</param>
        /// <param name="otherSection">溢出的值，取绝对值</param>
        private static void ProcessOverflowSection(decimal diffValue, decimal otherSection)
        {
            while (true)
            {
                decimal value;
                bool isSuccess = packagePool.TryDequeue(out value);
                decimal randValue = GetRandMoney(0, (int)diffValue);
                if (randValue < value)
                {
                    otherSection -= value - randValue;
                }
                else
                {
                    randValue = value;
                }

                if (otherSection == 0)
                {
                    packagePool.Enqueue(randValue);
                    break;
                }
                //减过头了
                else if (otherSection < 0)
                {
                    randValue = randValue + Math.Abs(otherSection);
                    packagePool.Enqueue(randValue);
                    break;
                }
                packagePool.Enqueue(randValue);


            }
        }


        /// <summary>
        /// 处理红包分配一次后总金额仍有剩余的情况
        /// </summary>
        /// <param name="diffValue">红包间最大的差值</param>
        /// <param name="otherSection">多余的值，取绝对值</param>
        private static void ProcessRemainSection(decimal diffValue, decimal otherSection)
        {
            while (true)
            {
                decimal value;
                bool isSuccess = packagePool.TryDequeue(out value);
                decimal randValue = GetRandMoney(0, (int)diffValue);
                if (randValue > value)
                {
                    otherSection -= randValue - value;
                }
                else
                {
                    randValue = value;
                }

                if (otherSection == 0)
                {
                    packagePool.Enqueue(randValue);
                    break;
                }
                //加过头了
                else if (otherSection < 0)
                {
                    randValue = randValue - Math.Abs(otherSection);
                    packagePool.Enqueue(randValue);
                    break;
                }
                packagePool.Enqueue(randValue);

            }
        }


        /// <summary>
        /// 将红包恢复到正常值
        /// 将红包的值除以100，并取两位小数，并加上红包的封底金额
        /// 初步获得最终的红包
        /// </summary>
        /// <param name="minPkg">单个红包保留的最小值</param>
        private static void ReNormal(decimal minPkg)
        {
            int count = packagePool.Count;
            for (int i = 0; i < count; i++)
            {
                decimal value;
                var isSuccess = packagePool.TryDequeue(out value);
                if (!isSuccess)
                {
                    value = 0;
                }
                packagePool.Enqueue(Math.Round((value + minPkg) / 100, 2));

            }
        }


        /// <summary>
        /// 获取随机金额
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>随机红包金额</returns>
        private static int GetRandMoney(int min, int max)
        {
            //使用GUID的哈希值作为随机种子
            var guid_hashcode = Guid.NewGuid().GetHashCode();
            Random rand = new Random(guid_hashcode);

            int randValue = rand.Next(min, max);
            return randValue;
        }


        /// <summary>
        /// 处理精度问题等导致的误差
        /// </summary>
        /// <param name="amount">账户总额</param>
        /// <param name="max">红包最大值</param>
        /// <param name="min">红包最小值</param>
        private static void ProcessPrecisionError(decimal amount, decimal max, decimal min)
        {
            decimal currentSum = packagePool.Sum();
            //注意  此处可能因为红包数量增加而导致误差可能会大于max最大值或者小于0 导致循环处理不能退出
            decimal precisionErrorSum = amount - currentSum;
            //没有误差则直接结束处理
            if (precisionErrorSum == 0) { return; }

            //将误差拆分后保存到队列中
            ConcurrentQueue<decimal> precisionErrorQueue = new ConcurrentQueue<decimal>();

            //误差分块
            //每次处理误差不大于(max - min)/subsection
            //将误差进行拆分使命中率提高  该值越大命中率越高  但执行次数越多  最好通过算法动态设置
            int subsection = GetPrecisionErrorSubsection(precisionErrorSum, max, min);

            //每个误差的大小
            decimal onePrecisionError = Math.Round((max - min) / subsection, 2);
            if (onePrecisionError == 0) { onePrecisionError = Math.Round((max - min), 2); }
            if (onePrecisionError == 0) { return; }

            //误差有可能是负数
            if (precisionErrorSum < 0) { onePrecisionError = onePrecisionError * -1; }

            //误差值为onePrecisionError的误差总数 
            decimal precisionErrorCount = Math.Abs(Math.Floor(Math.Abs(precisionErrorSum) / onePrecisionError));

            //误差被拆分后剩下的余数
            decimal precisionErrorMod = precisionErrorSum - onePrecisionError * precisionErrorCount;

            //将相同误差区块加入队列
            for (int i = 0; i < precisionErrorCount; i++)
            {
                precisionErrorQueue.Enqueue(onePrecisionError); //会不会有精度问题
            }

            //将误差余数加入误差队列
            if (precisionErrorMod != 0)
            {
                precisionErrorQueue.Enqueue(precisionErrorMod);
            }



            //循环处理误差队列中的误差
            while (true)
            {
                //当前处理的误差值
                decimal currentPrecisionError;
                bool peekSuccess = precisionErrorQueue.TryPeek(out currentPrecisionError);
                //失败说明误差队列已经被全部处理了  退出循环
                if (peekSuccess == false) { break; }

                //记录当前取出的红包的值
                decimal onePkg;
                bool isSuccess = packagePool.TryDequeue(out onePkg);

                //加上误差值后的红包
                decimal endPkg = onePkg + currentPrecisionError;
                if (isSuccess)
                {
                    //如果当前最终计算的红包没有超出规则的限定则重置这个红包，否则将红包的原始值重新附加到队列的最后
                    if (endPkg >= min && endPkg <= max)
                    {
                        //当前误差处理成功
                        packagePool.Enqueue(endPkg);
                        //移除当前已经处理的这个误差
                        decimal temp;
                        precisionErrorQueue.TryDequeue(out temp);
                        //继续处理误差队列中的数据
                        continue;
                    }
                    else
                    {
                        packagePool.Enqueue(onePkg);
                    }
                }
            }


        }

        /// <summary>
        /// 获取精度误差的分块大小
        /// 该算法待优化 此处为估计的值
        /// </summary>
        /// <param name="precisionErrorSum">误差的总数</param>
        /// <param name="max">红包最大值</param>
        /// <param name="min">红包最小值</param>
        /// <returns>分块大小</returns>
        private static int GetPrecisionErrorSubsection(decimal precisionErrorSum, decimal max, decimal min)
        {
            //这里暂时取值1-80之间
            int subsection = 10;
            decimal value = Math.Abs(max - min);
            int subsectionMax = (int)Math.Floor((value) / 0.01M);
            if (value < 10 || subsectionMax < subsection)
            {
                subsection = subsectionMax;
                if (subsection >= 80)
                {
                    subsection = 80;
                }

            }
            return subsection > 0 ? subsection : 1;
        }

        /// <summary>
        /// 获取单个红包
        /// </summary>
        /// <returns>从红包池中拿到的红包金额，如果红包拿完了，则返回0</returns>
        private static decimal GetOnePkg()
        {
            if (packagePool == null || packagePool.IsEmpty)
            {
                return 0;
            }
            lock (packagePool)
            {
                decimal money;
                bool isSuccess = packagePool.TryDequeue(out money);
                if (isSuccess)
                {
                    //红包保留两位小数
                    return Math.Round(money, 2);
                }
                else
                {
                    return 0;
                }
            }
        }



        /// <summary>
        /// 重置红包池
        /// </summary>
        public static void Reset()
        {
            packagePool = null;
            redPacketConfig = null;
        }
    }
}
