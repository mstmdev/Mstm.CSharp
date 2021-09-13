using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16迭代器模式
{
    /// <summary>
    /// 自定义的集合类型实现
    /// </summary>
    class ConcreteAggregate : IAggregate
    {
        /// <summary>
        /// 存储内部数据
        /// </summary>
        List<object> _innerData;

        public ConcreteAggregate()
        {
            _innerData = new List<object>();
        }

        /// <summary>
        /// 获取一个迭代器
        /// </summary>
        /// <returns></returns>
        public IIterator GetIterator()
        {
            return new AggregateIterator(this);
        }

        /// <summary>
        /// 添加一个元素
        /// </summary>
        /// <param name="obj"></param>
        public void Add(object obj)
        {
            _innerData.Add(obj);
        }

        /// <summary>
        /// 删除一个元素
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Remove(object obj)
        {
            return _innerData.Remove(obj);
        }


        /// <summary>
        /// 当前元素总数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _innerData.Count;
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object this[int index]
        {
            get
            {
                return this._innerData[index];
            }
            set
            {
                this._innerData[index] = value;
            }
        }

    }
}
