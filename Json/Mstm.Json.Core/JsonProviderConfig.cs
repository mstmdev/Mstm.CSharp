using Mstm.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Json.Core
{
    public class JsonProviderConfig : BaseProviderConfig
    {
        /// <summary>
        /// 当前模块名称
        /// </summary>
        public override string ModuleName => "JsonProvider";

        /// <summary>
        /// 私有构造函数，禁止外部构造
        /// </summary>
        /// <param name="groupName">组名称</param>
        private JsonProviderConfig(string groupName)
            : base(groupName)
        {

        }

        /// <summary>
        /// 创建一个新的配置
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static JsonProviderConfig New(string groupName = null)
        {
            return new JsonProviderConfig(groupName);
        }
    }
}
