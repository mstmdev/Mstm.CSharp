using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20职责链模式
{

    /// <summary>
    /// 请求处理者抽象类
    /// </summary>
    abstract class Handler
    {
        /// <summary>
        /// 下一个处理者
        /// </summary>
        protected Handler NextHandler;
        protected string Name;

        public Handler(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 设置下一个处理者
        /// 如果请求当前无法处理，则传递给一下处理者进行进一步处理
        /// </summary>
        /// <param name="handler"></param>
        public void SetNextHandler(Handler handler)
        {
            this.NextHandler = handler;
        }

        /// <summary>
        /// 提交请求
        /// </summary>
        /// <param name="level">请求等级</param>
        public abstract void Handle(int level);
    }
}
