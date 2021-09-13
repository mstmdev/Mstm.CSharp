using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15组合模式
{
    public abstract class Component
    {
        protected string _componentName;
        public Component(string componentName)
        {
            _componentName = componentName;
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="component"></param>
        public abstract void Add(Component component);

        /// <summary>
        /// 删除指定的节点
        /// </summary>
        /// <param name="component"></param>
        public abstract void RemoveAt(Component component);


        /// <summary>
        /// 展示节点信息
        /// </summary>
        public abstract void Show();

    }
}
