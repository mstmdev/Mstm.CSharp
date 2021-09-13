using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18桥接模式
{
    class Shoes : Product
    {
        public Shoes(string name, decimal price,int size )
            : base(name, price)
        {
            Size = size;
        }

        public int Size { get; set; }

        public override void Show()
        {
            Console.WriteLine(string.Format("{0} ： 价格 {1}  大小 {2}码", this.ProductName, this.Price, this.Size));
        }
    }
}
