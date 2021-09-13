using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18桥接模式
{
    abstract class Cart
    {
        protected List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public abstract void Show();
    }
}
