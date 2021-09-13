using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18桥接模式
{
    /// <summary>
    /// 合成/聚合原则：
    ///     尽量使用合成/聚合，尽量不要使用类继承
    /// 合成（组合）：
    ///     A包含B，B使A得必要组成部分，两者是一种强拥有的关系
    /// 聚合：
    ///     A包含B，但B不是A的一部分，两者是一种弱拥有的关系
    ///     
    /// 桥接模式（Bridge）：
    ///     将抽象部分与它的实现部分分离，使它们都可以独立的变化。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new SupermarketCart();
            Product nike = new Shoes("耐克运动鞋", 102.2m, 41);
            cart.Add(nike);
            cart.Show();

            Cart insuranceCart = new InsuranceCart();
            Product insurance = new Insurance("中国人寿", 1000, DateTime.Now, DateTime.Now.AddDays(300));
            insuranceCart.Add(insurance);
            insuranceCart.Show();

            Console.ReadLine();
        }
    }
}
