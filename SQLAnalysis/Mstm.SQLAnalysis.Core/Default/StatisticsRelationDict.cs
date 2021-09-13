using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{
    public class StatisticsRelationDict : RelationDictAbstract<StatisticsRelationEnum>
    {

        private static StatisticsRelationDict _instance;


        public static StatisticsRelationDict GetInstance()
        {
            if (_instance == null)
            {
                _instance = new StatisticsRelationDict();
            }
            return _instance;
        }


        protected override Dictionary<StatisticsRelationEnum, string> InitDict()
        {
            // (SELECT Min(Userid)   from userinfo)
            string sql = "{0}({1}{0}{2}({3}){0}{4}{0}{5})";
            var dict = new Dictionary<StatisticsRelationEnum, string>() { 
                {   StatisticsRelationEnum.Count,             string.Format(sql,Constants.WhiteSpace,Constants.Select,"COUNT","*",Constants.From,Constants.ReplaceTableName)                             },
                {   StatisticsRelationEnum.Sum,               string.Format(sql,Constants.WhiteSpace,Constants.Select,"SUM",Constants.ReplaceFieldName,Constants.From,Constants.ReplaceTableName)        },
                {   StatisticsRelationEnum.Max,               string.Format(sql,Constants.WhiteSpace,Constants.Select,"MAX",Constants.ReplaceFieldName,Constants.From,Constants.ReplaceTableName)        },
                {   StatisticsRelationEnum.Min,               string.Format(sql,Constants.WhiteSpace,Constants.Select,"MIN",Constants.ReplaceFieldName,Constants.From,Constants.ReplaceTableName)        },
                {   StatisticsRelationEnum.Avg,               string.Format(sql,Constants.WhiteSpace,Constants.Select,"AVG",Constants.ReplaceFieldName,Constants.From,Constants.ReplaceTableName)        },
            };

            return dict;
        }
    }
}
