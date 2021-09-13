using Mstm.Cache.ClusterSync;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Cache.ClusterSync.TestConsole
{
    class Program
    {
        static string cacheProviderName = "MemoryCache";
        static void Main(string[] args)
        {
            //使用MemoryCache作为缓存存储  默认使用HttpRuntime.Cache，需要依赖System.Web  必要时可以进行自由切换
            GlobalCacheProviderFactory.Instance.SetDefaultCacheProviderFactory(new MemoryCacheProviderFactory());

            //设置zookeeper连接信息
            string zkConns = ConfigurationManager.AppSettings["zk_cache_quorums"];
            GlobalZKCacheDependencyOption.Instance.SetDefaultZKCacheDependencyOption(zkConns);

            string node = "/CacheConsole/Test";
            //更新数据
            UpdateData();

            //打印帮助信息
            PrintHelpInfo();

            while (true)
            {
                var input = Console.ReadKey().KeyChar;
                if (input == 'c')
                {
                    DefaultCacheFactory.DefaultCache.ClearOne(node);
                    Console.WriteLine("缓存清理请求已提交，node-->" + node);
                }
                else if (input == 'g')
                {
                    string value = DefaultCacheFactory.DefaultCache.Get<string>(node);
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        value = ReadData();
                        DefaultCacheFactory.DefaultCache.Add(node, value);
                        value = DefaultCacheFactory.DefaultCache.Get<string>(node);
                    }
                    Console.WriteLine("查询到节点{0}的缓存数据值为{1}", node, value);
                }
                else if (input == 'a')
                {
                    string newValue = ReadData();
                    DefaultCacheFactory.DefaultCache.Add(node, newValue);
                    Console.WriteLine("节点{0}的缓存数据已更新，写入值为:{1}", node, newValue);
                }
                else if (input == 'u')
                {
                    string newValue = UpdateData();
                    Console.WriteLine("文件data.zk已更新，新值为:{0}", newValue);
                }
                else if (input == 'r')
                {
                    string newValue = UpdateData();
                    Console.WriteLine("文件data.zk已更新，新值为:{0}", newValue);
                    DefaultCacheFactory.DefaultCache.ClearOne(node);
                    Console.WriteLine("缓存清理请求已提交，node-->" + node);
                }
                else if (input == 'm')
                {
                    GlobalCacheProviderFactory.Instance.SetDefaultCacheProviderFactory(new MemoryCacheProviderFactory());
                    DefaultCacheFactory.Reset();
                    cacheProviderName = "MemoryCache";
                    Console.WriteLine("已切换为MemoryCache作为缓存存储！");
                }
                else if (input == 'd')
                {
                    GlobalCacheProviderFactory.Instance.SetDefaultCacheProviderFactory(new HttpRuntimeCacheProviderFactory());
                    DefaultCacheFactory.Reset();
                    cacheProviderName = "HttpRuntime.Cache";
                    Console.WriteLine("已切换为HttpRuntime.Cache作为缓存存储！");
                }
                else if (input == 'q')
                {
                    Console.WriteLine("再次按任意键退出!");
                    Console.ReadKey();
                    return;
                }
                else if (input == 'h')
                {
                    PrintHelpInfo();
                }
                else
                {
                    PrintHelpInfo();
                }
            }
        }

        static void PrintHelpInfo()
        {
            Console.WriteLine();
            Console.WriteLine("欢迎设置缓存测试工具，当前使用的缓存为" + cacheProviderName);
            Console.WriteLine("参数说明如下,请输入相应的指令进行操作：");
            Console.WriteLine("c-->清理缓存");
            Console.WriteLine("g-->获取缓存");
            Console.WriteLine("a-->更新缓存");
            Console.WriteLine("u-->更新数据");
            Console.WriteLine("r-->更新数据并清理缓存");
            Console.WriteLine("m-->使用MemoryCache提供缓存存储");
            Console.WriteLine("d-->使用HttpRuntime.Cache提供缓存存储");
            Console.WriteLine("h-->显示帮助信息");
            Console.WriteLine("q-->退出操作");
        }

        static string UpdateData()
        {
            string newValue = "cache test " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            File.WriteAllText("data.zk", newValue);
            return newValue;
        }

        static string ReadData()
        {
            try
            {
                string newValue = File.ReadAllText("data.zk");
                return newValue;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
