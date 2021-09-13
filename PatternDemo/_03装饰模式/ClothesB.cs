using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03装饰模式
{
    class ClothesB : Finery
    {
        public override void Wear()
        {
            base.Wear();
            Console.WriteLine("Wear Clothes B");
            OtherThing();
        }

        public void OtherThing()
        {
            Console.WriteLine("wait a moment!");
        }
    }
}
