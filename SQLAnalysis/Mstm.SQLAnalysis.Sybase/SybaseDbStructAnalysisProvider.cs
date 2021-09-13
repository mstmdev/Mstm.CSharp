using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Sybase
{
    internal class SybaseDbStructAnalysisProvider : IDbStructAnalysisProvider
    {
        public string BuildSelectDatabases()
        {
            string sql = "SELECT name FROM master..sysdatabases";
            return sql;
        }

        public string BuildSelectTables(string dbName)
        {
            if (string.IsNullOrWhiteSpace(dbName))
            {
                throw new ArgumentException("数据库名称不能为空！", "dbNaMme");
            }
            string sql = string.Format("SELECT name FROM {0}..sysobjects WHERE type='U'", dbName);
            return sql;
        }

        public string BuildSelectFields(string dbName, string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("数据表名称不能为空！", "tableName");
            }
            string sql = string.Format("SELECT tb_col.name,tb_type.name FROM syscolumns as tb_col,systypes as tb_type WHERE tb_col.id = OBJECT_ID('{0}')  AND tb_col.usertype=tb_type.usertype", tableName);
            return sql;
        }
    }
}
