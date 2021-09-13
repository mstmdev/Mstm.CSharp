using Mstm.SQLAnalysis.Core;
using Mstm.SQLAnalysis.MSSQLServer;
using Mstm.SQLAnalysis.MySQL;
using Mstm.SQLAnalysis.Sybase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.UnitTests
{
    /// <summary>
    /// SQLAnalysis简单工厂
    /// </summary>
    public class SQLAnalysisFactory
    {
        public static IDbStructAnalysisProvider GetDbStructAnalysisProvider(DbTypeEnum dbType)
        {
            ISQLAnalysisFactory factory = GetSQLAnalysisFactory(dbType);
            return factory.GetDbStructAnalysisProvider();
        }

        public static ISQLSyntaxAnalysisProvider GetSQLSyntaxAnalysisProvider(DbTypeEnum dbType)
        {
            ISQLAnalysisFactory factory = GetSQLAnalysisFactory(dbType);
            return factory.GetSQLSyntaxAnalysisProvider();
        }

        public static IFieldTypeAnalysisProvider GetFieldTypeAnalysisProvider(DbTypeEnum dbType)
        {
            ISQLAnalysisFactory factory = GetSQLAnalysisFactory(dbType);
            return factory.GetFieldTypeAnalysisProvider();
        }

        public static IDbStructAnalysisProvider GetDbStructAnalysisProvider(int dbType)
        {
            try
            {
                ISQLAnalysisFactory factory = GetSQLAnalysisFactory((DbTypeEnum)dbType);
                return factory.GetDbStructAnalysisProvider();
            }
            catch (Exception)
            {
                throw new ArgumentException("不支持的数据库类型！", "dbType");
            }
        }

        public static ISQLSyntaxAnalysisProvider GetSQLSyntaxAnalysisProvider(int dbType)
        {
            try
            {
                ISQLAnalysisFactory factory = GetSQLAnalysisFactory((DbTypeEnum)dbType);
                return factory.GetSQLSyntaxAnalysisProvider();
            }
            catch (Exception)
            {
                throw new ArgumentException("不支持的数据库类型！", "dbType");
            }
        }

        public static IFieldTypeAnalysisProvider GetFieldTypeAnalysisProvider(int dbType)
        {
            try
            {
                ISQLAnalysisFactory factory = GetSQLAnalysisFactory((DbTypeEnum)dbType);
                return factory.GetFieldTypeAnalysisProvider();
            }
            catch (Exception)
            {
                throw new ArgumentException("不支持的数据库类型！", "dbType");
            }
        }

        static ISQLAnalysisFactory GetSQLAnalysisFactory(DbTypeEnum dbType)
        {
            ISQLAnalysisFactory factory = null;
            switch (dbType)
            {
                case DbTypeEnum.MySQL:
                    factory = new MySQLAnalysisFactory();
                    break;
                case DbTypeEnum.Sybase:
                    factory = new SybaseAnalysisFactory();
                    break;
                case DbTypeEnum.MSSQLServer:
                    factory = new MSSQLServerAnalysisFactory();
                    break;
                case DbTypeEnum.Oracle:
                    throw new NotImplementedException("暂不支持Oracle数据库！");
            }

            return factory;
        }
    }
}
