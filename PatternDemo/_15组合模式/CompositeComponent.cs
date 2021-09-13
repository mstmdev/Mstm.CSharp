using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15组合模式
{

    /// <summary>
    /// 复合组件
    /// 可以添加任意子节点
    /// </summary>
    class CompositeComponent : Component
    {
        public CompositeComponent(string componentName)
            : base(componentName)
        {
            _componentList = new List<Component>();
        }

        private List<Component> _componentList;

        public override void Add(Component component)
        {
            _componentList.Add(component);
        }

        public override void RemoveAt(Component component)
        {
            _componentList.Remove(component);
        }

        public override void Show()
        {
            Console.WriteLine(_componentName);
            foreach (var item in _componentList)
            {
                item.Show();
            }
        }

    }
}
