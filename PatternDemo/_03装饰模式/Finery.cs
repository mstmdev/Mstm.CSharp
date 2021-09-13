using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03装饰模式
{
    class Finery : Person
    {
        private Person _component;

        public void SetComponent(Person component)
        {
            this._component = component;
        }

        public override void Wear()
        {
            if (_component != null) {
                this._component.Wear();
            }
        }
       
    }
}
