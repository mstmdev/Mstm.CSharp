using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18桥接模式
{
    abstract class Product
    {
        private string _name;
        private decimal _price;
        public Product(string name, decimal price)
        {
            this._name = name;
            this._price = price;
        }
        public decimal Price
        {
            get { return _price; }
        }

        public string ProductName
        {
            get { return _name; }
        }

        public abstract void Show();
    }
}
