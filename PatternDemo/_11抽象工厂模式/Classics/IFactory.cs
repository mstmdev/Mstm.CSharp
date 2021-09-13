using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11抽象工厂模式.Classics
{

    /// <summary>
    /// 经典抽象工厂接口
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// 创建User表操作的实例
        /// </summary>
        /// <returns></returns>
        IUser CreateUserInstance();

        /// <summary>
        /// 创建Product表操作的实例
        /// </summary>
        /// <returns></returns>
        IProduct CreateProductInstance();

    }
}
