using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11抽象工厂模式
{

    /// <summary>
    /// User表操作接口
    /// 在这里可以自定义User表独有的操作接口
    /// </summary>
    public interface IUser : IBaseOperation<User>
    {
    }
}
