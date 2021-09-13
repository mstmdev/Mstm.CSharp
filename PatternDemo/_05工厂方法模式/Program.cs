using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05工厂方法模式
{

    /// <summary>
    /// 工厂方法（Factory Method）：
    ///     定义一个用于创建对象的接口，让子类决定将哪一个类实例化。
    ///     Factory Method使一个类的实例化延迟到子类。
    ///     
    ///     在复杂的业务逻辑中使用简单工厂模式会违反开闭原则
    ///     使工厂类面临频繁修改的风险
    ///     使用工厂方法模式可以使程序更加符合开闭原则的要求
    ///     即我们需要增加新的功能的时候只要添加相应的工厂类和具体的业务类就可以了，
    ///     不会修改原有的工厂和业务类
    ///     需要修改的只有客户端的代码
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IFactory qqFactory = new QQOAuthServiceFactory();
            IOAuthService qqOAuth = qqFactory.GetOAuthService();
            string code = "Xssj67H3df";
            string appId = "127841628";
            string token = qqOAuth.GetTokenByCode(code, appId);
            Console.WriteLine(string.Format("you get the token :{0}", token));
            Console.ReadLine();
        }
    }
}
