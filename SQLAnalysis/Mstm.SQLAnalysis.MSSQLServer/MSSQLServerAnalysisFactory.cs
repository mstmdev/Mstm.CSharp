using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.MSSQLServer
{
    public class MSSQLServerAnalysisFactory : ISQLAnalysisFactory
    {

        public ISQLSyntaxAnalysisProvider GetSQLSyntaxAnalysisProvider()
        {
            return new MSSQLServerSyntaxAnalysisProvider();
        }



        public IDbStructAnalysisProvider GetDbStructAnalysisProvider()
        {
            return new MSSQLServerDbStructAnalysisProvider();
        }


        public IFieldTypeAnalysisProvider GetFieldTypeAnalysisProvider()
        {
            return new MSSQLServerFieldTypeAnalysisProvider();
        }
    }
}
