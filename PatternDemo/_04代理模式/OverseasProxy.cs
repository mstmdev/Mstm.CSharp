using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04代理模式
{
    class OverseasProxy : IShoping
    {
        private Customer customer;

        public OverseasProxy()
        {
            customer = new Customer();
        }
        public void Buy(Product product)
        {
            Purchases(product);
            customer.Buy(product);
        }

        private void Purchases(Product product)
        {
            product.Price *= 1.1m;
        }
    }
}
