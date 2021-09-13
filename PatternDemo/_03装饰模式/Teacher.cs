using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03装饰模式
{
    class Teacher : Person
    {
        public Teacher(string name)
            : base(name)
        { }


        public override void Wear()
        {
            Console.WriteLine("the teacher " + this._name + "  Wear Start !");
        }
    }
}
