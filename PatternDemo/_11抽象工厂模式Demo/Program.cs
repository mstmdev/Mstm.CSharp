using _11抽象工厂模式;
using _11抽象工厂模式.Classics;
using _11抽象工厂模式.SimpleFactoryV1;
using _11抽象工厂模式.SimpleFactoryV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11抽象工厂模式Demo
{
    /// <summary>
    /// 抽象工厂模式（Abstract Factory）：
    ///     抽象工厂模式用于提供一个创建一些列相关或相互依赖对象的接口，而无需指定它们具体的类。
    ///     
    ///     如下例子，通过抽象工厂提供特定数据库的一些列数据表的操作实例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Classics Demo
            ClassicsDemo();


            //SimpleFactoryV1 Demo
            SimpleFactoryV1Demo();

            //SimpleFactoryV2 Demo
            SimpleFactoryV2Demo();

        }


        /// <summary>
        ///使用典型的抽象工厂模式创建需要的对象
        /// </summary>
        static void ClassicsDemo()
        {
            IFactory factory = new MySQLFactory();
            IUser userInstance = factory.CreateUserInstance();
            IProduct productInstance = factory.CreateProductInstance();
        }


        /// <summary>
        /// 使用简单工厂模式创建一系列所需的对象
        /// 这里需要对每个表对应的操作类型进行配置文件的配置
        /// </summary>
        static void SimpleFactoryV1Demo()
        {
            IUser userInstance = DataSourceFactoryV1.CreateUserInstance();
            IProduct productInstance = DataSourceFactoryV1.CreateProductInstance();
        }

        /// <summary>
        /// 使用简单工厂对于抽象工厂进行封装
        /// 使配置文件中只需要配置相应的工厂而不需要为每个表的操作类型进行配置
        /// </summary>
        static void SimpleFactoryV2Demo()
        {
            IUser userInstance = DataSourceFactoryV2.CreateUserInstance();
            IProduct productInstance = DataSourceFactoryV2.CreateProductInstance();
        }
    }
}
