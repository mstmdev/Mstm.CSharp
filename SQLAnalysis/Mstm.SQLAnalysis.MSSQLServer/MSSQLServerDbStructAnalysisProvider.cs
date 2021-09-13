using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.MSSQLServer
{
    internal class MSSQLServerDbStructAnalysisProvider : IDbStructAnalysisProvider
    {
        public string BuildSelectDatabases()
        {
            string sql = "SELECT NAME FROM Master..SysDatabases";
            return sql;
        }

        public string BuildSelectTables(string dbName)
        {
            string sql = "SELECT NAME FROM SYSOBJECTS WHERE XTYPE='U'";
            return sql;
        }

        public string BuildSelectFields(string dbName, string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException("数据表名称不能为空！", "tableName");
            }
            string sql = string.Format("SELECT tb_Column.Name,tb_Type.Name FROM SYSCOLUMNS  tb_Column , SYSTYPES tb_Type WHERE  tb_Column.ID=Object_Id('{0}') AND tb_Column.XTYPE=tb_Type.XUserTYPE", tableName);
            return sql;
        }
    }
}
