using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18桥接模式
{
    class InsuranceCart:Cart
    {
        public override void Show()
        {
            foreach (var item in this._products)
            {
                Console.WriteLine("您购买了一件保险：");
                item.Show();
            }
        }
    }
}
