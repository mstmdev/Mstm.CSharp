using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19命令模式
{

    /// <summary>
    /// 服务员
    /// 作为调用者发起命令请求
    /// </summary>
    class Waiter
    {
        private string _name;

        private List<CookingCommand> cmds;

        public Waiter(string name)
        {
            this._name = name;
            cmds = new List<CookingCommand>();
        }

        /// <summary>
        /// 开始点餐
        /// </summary>
        /// <param name="cmd"></param>
        public void StartOrder(CookingCommand cmd)
        {
            cmds.Add(cmd);
        }

        /// <summary>
        /// 撤销某个要求
        /// </summary>
        /// <param name="cmd"></param>
        public void CancelOrder(CookingCommand cmd)
        {
            cmds.Remove(cmd);
        }


        /// <summary>
        /// 取消所有点的菜
        /// </summary>
        public void ResetOrder()
        {
            cmds = new List<CookingCommand>();
        }


        /// <summary>
        /// 下单 开始做菜
        /// </summary>
        public void StartCook()
        {
            foreach (var cmd in cmds)
            {
                cmd.Execute();
            }
        }
    }
}
