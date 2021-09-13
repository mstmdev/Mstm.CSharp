using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16迭代器模式
{
    /// <summary>
    /// 自定义集合的接口
    /// 定义一个提供迭代器的方法
    /// </summary>
    interface IAggregate
    {
        /// <summary>
        /// 获取一个迭代器
        /// </summary>
        /// <returns></returns>
        IIterator GetIterator();
    }
}
