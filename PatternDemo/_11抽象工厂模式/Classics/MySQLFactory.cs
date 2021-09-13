using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11抽象工厂模式.Classics
{
    /// <summary>
    /// MySQL数据库工厂
    /// </summary>
    public class MySQLFactory : IFactory
    {
        public IUser CreateUserInstance()
        {
            return new UserTableByMySQL();
        }

        public IProduct CreateProductInstance()
        {
            return new ProductTableByMySQL();
        }
    }
}
