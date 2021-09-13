using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06原型模式
{
    class ModuleInfo : ICloneable
    {
        public long ModuleId { get; set; }
        public string ModuleName { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
