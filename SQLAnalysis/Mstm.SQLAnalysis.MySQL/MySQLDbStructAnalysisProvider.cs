using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.MySQL
{
    internal class MySQLDbStructAnalysisProvider : IDbStructAnalysisProvider
    {
        public string BuildSelectDatabases()
        {
            string sql = "SELECT SCHEMA_NAME FROM information_schema.SCHEMATA";
            return sql;
        }

        public string BuildSelectTables(string dbName)
        {
            if (string.IsNullOrWhiteSpace(dbName))
            {
                throw new ArgumentException("数据库名称不能为空！", "dbNaMme");
            }
            string sql = string.Format("SELECT `TABLE_NAME` FROM information_schema.`TABLES` WHERE `TABLE_SCHEMA`='{0}'", dbName);
            return sql;
        }

        public string BuildSelectFields(string dbName, string tableName)
        {
            if (string.IsNullOrWhiteSpace(dbName))
            {
                throw new ArgumentException("数据库名称不能为空！", "dbNaMme");
            }
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("数据表名称不能为空！", "tableName");
            }
            string sql = string.Format("SELECT `COLUMN_NAME`,`DATA_TYPE` FROM information_schema.`COLUMNS` WHERE `TABLE_SCHEMA`='{0}' and `TABLE_NAME`='{1}'", dbName, tableName);
            return sql;
        }
    }
}
