using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{
    /// <summary>
    /// 数据库结构信息分析接口
    /// </summary>
    public interface IDbStructAnalysisProvider
    {

        /// <summary>
        /// 构建获取当前所有的数据库名的sql语句
        /// </summary>
        /// <returns>查询所有数据库名称的sql语句</returns>
        string BuildSelectDatabases();

        /// <summary>
        /// 构建获取指定数据库下的所有表名的sql语句
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns>查询指定数据库中所有表名的sql语句</returns>
        string BuildSelectTables(string dbName);


        /// <summary>
        /// 构建获取当前表中所有字段信息的sql语句
        /// 返回字段的名称和字段的类型（不包含长度）
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tableName">表名</param>
        /// <returns>查询指定表中字段信息的sql语句</returns>
        string BuildSelectFields(string dbName, string tableName);
    }
}
