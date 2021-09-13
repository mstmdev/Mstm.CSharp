using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.MySQL
{
    public class MySQLAnalysisFactory : ISQLAnalysisFactory
    {
        public ISQLSyntaxAnalysisProvider GetSQLSyntaxAnalysisProvider()
        {
            return new MySQLSyntaxAnalysisProvider();
        }


        public IDbStructAnalysisProvider GetDbStructAnalysisProvider()
        {
            return new MySQLDbStructAnalysisProvider();
        }


        public IFieldTypeAnalysisProvider GetFieldTypeAnalysisProvider()
        {
            return new MySQLFieldTypeAnalysisProvider();
        }
    }
}
