using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17单例模式
{
    class SingletonV2
    {
        private static SingletonV2 _instance;
        private static readonly object lockObj = new object();

        private SingletonV2() { }


        /// <summary>
        /// 获取线程安全的单例实例
        /// 在第一次调用的时候创建单例实例
        /// </summary>
        /// <returns></returns>
        public static SingletonV2 GetInstance()
        {
            //使用锁来保证线程安全
            if (_instance == null)
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonV2();
                    }
                }
            }
            return _instance;
        }
    }
}
