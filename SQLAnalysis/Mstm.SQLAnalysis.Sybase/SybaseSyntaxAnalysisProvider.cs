using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Sybase
{
    internal class SybaseSyntaxAnalysisProvider : DefaultSQLSyntaxAnalysisProvider
    {
        protected override RelationDictAbstract<NormalWhereRelationEnum> WhereRelationDictData
        {
            get { return new NormalWhereRelationDict(); }
        }

        protected override RelationDictAbstract<CycleWhereRelationEnum> CycleRelationDictData
        {
            get { return new SybaseCycleWhereRelationDict(); }
        }

        protected override RelationDictAbstract<PointInTimeWhereRelationEnum> PointInTimeRelationDictData
        {
            get { return new SybasePointInTimeWhereRelationDict(); }
        }

        protected override RelationDictAbstract<StatisticsRelationEnum> StatisticsRelationDictData
        {
            get { return new StatisticsRelationDict(); }
        }

        protected override string GetSafeParam(string param)
        {
            return string.Format("[{0}]", param);
        }
    }
}
