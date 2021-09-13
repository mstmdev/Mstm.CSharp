using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17单例模式
{
    sealed class SingletonV1
    {
        private static readonly SingletonV1 _instance = new SingletonV1();

        private SingletonV1() { }

        /// <summary>
        /// 获取单例实例
        /// 在第一次应用类的任何成员的时候就会创建实例
        /// </summary>
        /// <returns></returns>
        public static SingletonV1 GetInstance()
        {
            return _instance;
        }
    }
}
