using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.QQ
{

    /// <summary>
    /// 默认QQ响应数据解析器工厂
    /// </summary>
    class DefaultQQResponseAnalysisFactory : IQQResponseAnalysisFactory
    {

        /// <summary>
        /// 获取QQ消息解析器IQQResponseAnalysis的实例
        /// </summary>
        /// <returns></returns>
        public IQQResponseAnalysis GetQQResponseAnalysisProvider()
        {
            return new DefaultQQResponseAnalysis();
        }
    }
}
