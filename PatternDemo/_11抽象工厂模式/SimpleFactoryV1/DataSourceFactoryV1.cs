using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace _11抽象工厂模式.SimpleFactoryV1
{
    /// <summary>
    /// 利用简单工厂和反射+配置文件的方式动态创建所需的操作实例
    /// </summary>
    public class DataSourceFactoryV1
    {
        static IConfigurationRoot config;
        static DataSourceFactoryV1()
        {
            config = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json").Build();
            userAssemblyName = config["SimpleFactoryV1:UserAssemblyName"];
            userClassFullName = config["SimpleFactoryV1:UserClassFullName"];
            productAssemblyName = config["SimpleFactoryV1:ProductAssemblyName"];
            productClassFullName = config["SimpleFactoryV1:ProductClassFullName"];
        }

        private static readonly string userAssemblyName;
        private static readonly string userClassFullName;
        private static readonly string productAssemblyName;
        private static readonly string productClassFullName;

        public static IUser CreateUserInstance()
        {
            IUser userInsrance = CreateInstance<IUser>(userAssemblyName, userClassFullName);
            return userInsrance;
        }

        public static IProduct CreateProductInstance()
        {
            IProduct productInstance = CreateInstance<IProduct>(productAssemblyName, productClassFullName);
            return productInstance;
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
