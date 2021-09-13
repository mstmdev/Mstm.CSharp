using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03装饰模式
{
    class ClothesC : Finery
    {
        public override void Wear()
        {
            base.Wear();
            Console.WriteLine("Wear ClothesC");
        }
    }
}
