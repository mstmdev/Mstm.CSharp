using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Sybase
{
    public class SybaseAnalysisFactory : ISQLAnalysisFactory
    {
        public ISQLSyntaxAnalysisProvider GetSQLSyntaxAnalysisProvider()
        {
            return new SybaseSyntaxAnalysisProvider();
        }


        public IDbStructAnalysisProvider GetDbStructAnalysisProvider()
        {
            return new SybaseDbStructAnalysisProvider();
        }


        public IFieldTypeAnalysisProvider GetFieldTypeAnalysisProvider()
        {
            return new SybaseFieldTypeAnalysisProvider();
        }
    }
}
