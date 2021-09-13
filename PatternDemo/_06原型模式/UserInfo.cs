using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06原型模式
{
    class UserInfo : ICloneable, IDeepCloneable
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<RoleInfo> Roles { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public object DeepClone()
        {
            UserInfo userInfo = new UserInfo()
            {
                UserId = this.UserId,
                UserName = this.UserName,
                Roles = new List<RoleInfo>()
            };

            foreach (var role in this.Roles)
            {
                RoleInfo newRole = new RoleInfo()
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    Modules = new List<ModuleInfo>()
                };

                userInfo.Roles.Add(newRole);

                foreach (var module in role.Modules)
                {
                    newRole.Modules.Add(module);
                }
            }

            return userInfo;

        }
    }
}
