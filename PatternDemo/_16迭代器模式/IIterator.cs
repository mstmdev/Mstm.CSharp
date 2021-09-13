using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16迭代器模式
{

    /// <summary>
    /// 迭代器接口
    /// </summary>
    interface IIterator
    {
        /// <summary>
        /// 获取第一个元素
        /// </summary>
        /// <returns></returns>
        object First();

        /// <summary>
        /// 获取下一个元素
        /// </summary>
        /// <returns></returns>
        void Next();

        /// <summary>
        /// 获取当前的元素
        /// </summary>
        /// <returns></returns>
        object Current();

        /// <summary>
        /// 是否已经迭代到最后一个
        /// </summary>
        /// <returns></returns>
        bool IsLast();

        /// <summary>
        /// 重置索引位置
        /// </summary>
        void Reset();
    }
}
