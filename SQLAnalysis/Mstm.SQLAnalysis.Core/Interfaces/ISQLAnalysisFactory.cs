using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// SQL解析工厂接口
    /// </summary>
    public interface ISQLAnalysisFactory
    {

        /// <summary>
        /// 获取SQL解析提供程序
        /// </summary>
        /// <returns></returns>
        ISQLSyntaxAnalysisProvider GetSQLSyntaxAnalysisProvider();


        /// <summary>
        /// 获取数据库结构信息分析提供程序
        /// </summary>
        /// <returns></returns>
        IDbStructAnalysisProvider GetDbStructAnalysisProvider();


        /// <summary>
        /// 获取字段类型解析提供程序
        /// </summary>
        /// <returns></returns>
        IFieldTypeAnalysisProvider GetFieldTypeAnalysisProvider();
    }
}
