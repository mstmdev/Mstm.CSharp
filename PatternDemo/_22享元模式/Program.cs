using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _22享元模式
{

    /// <summary>
    /// 享元模式（Flyweight）：
    ///     利用共享技术有效的支持大量细粒度的对象。
    ///     
    ///     一般在每个类型需要创建大量的实例对象并且其对象中的数据能够抽取到类型外部的时候，可以将这个对象的创建利用享元模式来实现
    ///     这样可以减少对象的创建，提高性能
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            FlyWeightFactory factory = new FlyWeightFactory();
            var sharedObjA = factory.GetSharedFlyWeight("A");
            var sharedObjB = factory.GetSharedFlyWeight("B");
            var sharedObjC = factory.GetSharedFlyWeight("A");

            sharedObjA.Execute(new ProductInfo() { ProductName = "Ipad pro", ProductPrice = 7000.1m });
            sharedObjB.Execute(new ProductInfo() { ProductName = "Surface book", ProductPrice = 20000.4m });
            sharedObjC.Execute(new ProductInfo() { ProductName = "XiaoMI 5", ProductPrice = 3800m });

            var unsharedObj = factory.GetUnSharedFlyWeight();
            unsharedObj.Execute(new ProductInfo() { ProductName = "Mac Book Pro 15", ProductPrice = 18000m });


            Console.WriteLine("共享对象总数为：{0}", factory.GetSharedFlyWeightCount());

            Console.ReadLine();

        }
    }
}
