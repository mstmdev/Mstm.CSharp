using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06原型模式
{
    class RoleInfo : ICloneable
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<ModuleInfo> Modules { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
