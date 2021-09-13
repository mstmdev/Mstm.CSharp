using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11抽象工厂模式.Classics
{

    /// <summary>
    /// SQLService数据库操作工厂
    /// </summary>
    public class SQLServiceFactory : IFactory
    {
        public IUser CreateUserInstance()
        {
            return new UserTableBySQLService();
        }

        public IProduct CreateProductInstance()
        {
            return new ProductTableBySQLService();
        }
    }
}
