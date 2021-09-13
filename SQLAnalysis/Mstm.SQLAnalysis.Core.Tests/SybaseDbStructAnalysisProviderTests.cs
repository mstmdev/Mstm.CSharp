using System;
using Xunit;
using Mstm.SQLAnalysis.Core;
using Mstm.SQLAnalysis.Sybase;
using Shouldly;

namespace Mstm.SQLAnalysis.UnitTests
{
    public class SybaseDbStructAnalysisProviderTests
    {

        IDbStructAnalysisProvider _provider;

        /// <summary>
        /// 单个测试开始前
        /// </summary>
        public SybaseDbStructAnalysisProviderTests()
        {
            ISQLAnalysisFactory factory = new SybaseAnalysisFactory();
            _provider = factory.GetDbStructAnalysisProvider();
        }


        /// <summary>
        /// 单个测试结束后
        /// </summary>
        ~SybaseDbStructAnalysisProviderTests()
        {
            _provider = null;
        }


        /// <summary>
        /// 构建获取当前所有的数据库名的sql语句测试
        /// </summary>
        [Fact]
        public void BuildSelectDatabasesTest()
        {
            string sql = _provider.BuildSelectDatabases();
            string expectSql = "SELECT name FROM master..sysdatabases";
            sql.ShouldBe(expectSql);
        }


        /// <summary>
        /// 构建获取指定数据库下的所有表名的sql语句测试
        /// </summary>
        [Fact]
        public void BuildSelectTablesTest()
        {
            string dbName = "alluser";
            string sql = _provider.BuildSelectTables(dbName);
            string expectSql = string.Format("SELECT name FROM {0}..sysobjects WHERE type='U'", dbName);
            sql.ShouldBe(expectSql);
        }


        /// <summary>
        /// 构建获取当前表中所有字段信息的sql语句测试
        /// </summary>
        [Fact]
        public void BuildSelectFieldsTest()
        {
            string tableName = "userinfo";
            string sql = _provider.BuildSelectFields(null, tableName);
            string expectSql = string.Format("SELECT tb_col.name,tb_type.name FROM syscolumns as tb_col,systypes as tb_type WHERE tb_col.id = OBJECT_ID('{0}')  AND tb_col.usertype=tb_type.usertype", tableName);

            sql.ShouldBe(expectSql);
        }

    }
}
