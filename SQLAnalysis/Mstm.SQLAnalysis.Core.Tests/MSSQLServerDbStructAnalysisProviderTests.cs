using System;
using Mstm.SQLAnalysis.Core;
using Mstm.SQLAnalysis.MSSQLServer;
using Shouldly;
using Xunit;

namespace Mstm.SQLAnalysis.UnitTests
{
    public class MSSQLServerDbStructAnalysisProviderTests
    {

        IDbStructAnalysisProvider _provider;

        /// <summary>
        /// 单个测试开始前
        /// </summary>
        public MSSQLServerDbStructAnalysisProviderTests()
        {
            ISQLAnalysisFactory factory = new MSSQLServerAnalysisFactory();
            _provider = factory.GetDbStructAnalysisProvider();
        }


        /// <summary>
        /// 单个测试结束后
        /// </summary>
        ~MSSQLServerDbStructAnalysisProviderTests()
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
            string expectSql = "SELECT NAME FROM Master..SysDatabases";
            sql.ShouldBe(expectSql);
        }


        /// <summary>
        /// 构建获取指定数据库下的所有表名的sql语句测试
        /// </summary>
        [Fact]
        public void BuildSelectTablesTest()
        {
            string sql = _provider.BuildSelectTables(null);
            string expectSql = "SELECT NAME FROM SYSOBJECTS WHERE XTYPE='U'";
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
            string expectSql = string.Format("SELECT tb_Column.Name,tb_Type.Name FROM SYSCOLUMNS  tb_Column , SYSTYPES tb_Type WHERE  tb_Column.ID=Object_Id('{0}') AND tb_Column.XTYPE=tb_Type.XUserTYPE", tableName);

            sql.ShouldBe(expectSql);
        }

    }
}
