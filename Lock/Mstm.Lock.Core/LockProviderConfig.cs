using Mstm.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Lock.Core
{
    /// <summary>
    /// 锁组件的配置信息
    /// </summary>
    public class LockProviderConfig : BaseProviderConfig
    {
        /// <summary>
        /// 当前模块名称
        /// </summary>
        public override string ModuleName => "LockProvider";

        /// <summary>
        /// 私有构造函数，禁止外部构造
        /// </summary>
        /// <param name="groupName">组名称</param>
        private LockProviderConfig(string groupName)
            : base(groupName)
        {

        }

        /// <summary>
        /// 创建一个新的配置
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static LockProviderConfig New(string groupName = null)
        {
            return new LockProviderConfig(groupName);
        }
    }
}
