using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.QQ
{
    /// <summary>
    /// QQ响应解析器工厂接口
    /// </summary>
    interface IQQResponseAnalysisFactory
    {

        /// <summary>
        /// 获取QQ响应数据解析器实例
        /// </summary>
        /// <returns></returns>
        IQQResponseAnalysis GetQQResponseAnalysisProvider();
    }
}
