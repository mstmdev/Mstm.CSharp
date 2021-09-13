using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17单例模式
{
    /// <summary>
    /// 单例模式（Singleton）：
    ///     保证一个类只有一个实例，并提供访问它的全局访问点。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ClassicSingleton classicSingleton1 = ClassicSingleton.GetInstance();
            ClassicSingleton classicSingleton2 = ClassicSingleton.GetInstance();
            Console.WriteLine(classicSingleton1==classicSingleton2);

            SingletonV1 singletonV1_1 = SingletonV1.GetInstance();
            SingletonV1 singletonV1_2 = SingletonV1.GetInstance();
            Console.WriteLine(singletonV1_1==singletonV1_2);

            SingletonV2 singletonV2_1 = SingletonV2.GetInstance();
            SingletonV2 singletonV2_2 = SingletonV2.GetInstance();
            Console.WriteLine(singletonV2_1==singletonV2_2);


            Console.ReadLine();


        }
    }
}
