using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11抽象工厂模式
{
    /// <summary>
    /// User表操作的MySQL实现
    /// </summary>
    class UserTableByMySQL : IUser
    {
        public void Add(User model)
        {
            throw new NotImplementedException();
        }

        public int Update(User model)
        {
            throw new NotImplementedException();
        }

        public int Delete(long key)
        {
            throw new NotImplementedException();
        }

        public User SelectById(long key)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> SelectAll()
        {
            throw new NotImplementedException();
        }
    }
}
