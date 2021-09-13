using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06原型模式
{

    /// <summary>
    /// 原型模式（Prototype）：
    ///     用原型实例指定创建对象的种类，并通过拷贝这个原型来创建新的对象。
    ///     
    ///     原型模式就是从原有的对象实例中获取到一个实例的副本
    ///     这里通过一个自定义的IDeepCloneable接口来实现深克隆
    ///     ICloneable实现浅克隆
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            UserInfo userInfo = new UserInfo()
            {
                UserId = 1001,
                UserName = "Tor",
                Roles = new List<RoleInfo>()
            };

            RoleInfo role1 = new RoleInfo()
            {
                RoleId = 2001,
                RoleName = "注册用户",
                Modules = new List<ModuleInfo>()
            };

            userInfo.Roles.Add(role1);

            ModuleInfo m1 = new ModuleInfo()
            {
                ModuleId = 3001,
                ModuleName = "查看个人信息"
            };

            ModuleInfo m2 = new ModuleInfo()
            {
                ModuleId = 3002,
                ModuleName = "发送私信"
            };

            role1.Modules.Add(m1);
            role1.Modules.Add(m2);

            //浅克隆
            //UserInfo userInfo2 = userInfo.Clone() as UserInfo;

            //深克隆
            UserInfo userInfo2 = userInfo.DeepClone() as UserInfo;

            userInfo2.UserName = "Shop";

            RoleInfo role2 = new RoleInfo()
            {
                RoleId = 2002,
                RoleName = "企业用户",
                Modules = new List<ModuleInfo>()
            };

            ModuleInfo m3 = new ModuleInfo()
            {
                ModuleId = 3003,
                ModuleName = "发布商品"
            };

            ModuleInfo m4 = new ModuleInfo()
            {
                ModuleId = 3004,
                ModuleName = "购买商品"
            };

            userInfo2.Roles.Where(a => a.RoleId == 2001).FirstOrDefault().Modules.Add(m4);


            role2.Modules.Add(m3);

            userInfo2.Roles.Add(role2);

            Console.ReadLine();



        }
    }
}
