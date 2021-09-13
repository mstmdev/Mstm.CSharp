using _11抽象工厂模式.Classics;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;


namespace _11抽象工厂模式.SimpleFactoryV2
{

    /// <summary>
    /// 利用简单工厂封装经典的抽象工厂
    /// 并利用反射+配置文件的方式动态获取所需的工厂
    /// </summary>
    public class DataSourceFactoryV2
    {
        static IConfigurationRoot config;

        static DataSourceFactoryV2()
        {
            config = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json").Build();
            factoryAssemblyName = config["SimpleFactoryV2:DataSourceFactoryAssemblyName"];
            factoryClassFullName = config["SimpleFactoryV2:DataSourceFactoryClassFullName"];
        }

        private static readonly string factoryAssemblyName;
        private static readonly string factoryClassFullName;

        public static IUser CreateUserInstance()
        {
            IUser userInsrance = GetFactory().CreateUserInstance();
            return userInsrance;
        }

        public static IProduct CreateProductInstance()
        {
            IProduct productInstance = GetFactory().CreateProductInstance();
            return productInstance;
        }

        private static IFactory GetFactory()
        {
            IFactory factory = CreateInstance<IFactory>(factoryAssemblyName, factoryClassFullName);
            return factory;
        }

        private static T CreateInstance<T>(string assemblyName, string classFullName)
           where T : class
        {
            try
            {
                T result = Assembly.Load(assemblyName).CreateInstance(classFullName) as T;
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
