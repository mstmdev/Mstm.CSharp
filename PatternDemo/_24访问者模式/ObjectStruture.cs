using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24访问者模式
{

    /// <summary>
    /// 统一管理和记录所有的元素对象
    /// </summary>
    class ObjectStruture
    {
        private List<Element> _list = new List<Element>();


        /// <summary>
        /// 添加一个Element
        /// </summary>
        /// <param name="element"></param>
        public void Attach(Element element)
        {
            _list.Add(element);
        }

        /// <summary>
        /// 移除一个Element
        /// </summary>
        /// <param name="element"></param>
        public void Detach(Element element)
        {
            _list.Remove(element);
        }


        /// <summary>
        /// 接收一个访问者，使所有的Element都执行这个动作
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(Visitor visitor)
        {
            foreach (var item in _list)
            {
                item.Accept(visitor);
            }
        }
    }
}
