using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15组合模式
{
    /// <summary>
    /// 叶子节点组件
    /// 不允许继续添加子节点
    /// </summary>
    class LeafComponent : Component
    {
        public LeafComponent(string componentName)
            : base(componentName)
        {

        }
        public override void Add(Component component)
        {
            throw new NotSupportedException("不支持Add操作！");
        }

        public override void RemoveAt(Component component)
        {
            throw new NotSupportedException("不支持RemoveAt操作！");
        }

        public override void Show()
        {
            Console.WriteLine(_componentName);
        }
    }
}
