using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03装饰模式
{
    abstract class Person
    {

        protected string _name;
        public Person(string name)
        {
            this._name = name;
        }

        public Person()
        {

        }

        public abstract void Wear();
    }
}
