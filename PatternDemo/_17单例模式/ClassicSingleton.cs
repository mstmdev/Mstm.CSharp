using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17单例模式
{
    class ClassicSingleton
    {
        private ClassicSingleton() { }

        private static ClassicSingleton _instance;

        /// <summary>
        /// 获取单例实例
        /// 经典的单例模式 不是线程安全的 存在并发的问题
        /// </summary>
        /// <returns></returns>
        public static ClassicSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClassicSingleton();
            }
            return _instance;
        }
    }
}
