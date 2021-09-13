using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04代理模式
{
    class Customer : IShoping
    {
        public void Buy(Product product)
        {
            Console.WriteLine("you get it-->" + product.ProductName + " this price is " + product.Price);
        }
    }
}
