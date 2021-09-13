using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.MySQL
{
    internal class MySQLCycleWhereRelationDict : RelationDictAbstract<CycleWhereRelationEnum>
    {
        private static MySQLCycleWhereRelationDict _instance;


        public static MySQLCycleWhereRelationDict GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MySQLCycleWhereRelationDict();
            }
            return _instance;
        }


        protected override Dictionary<CycleWhereRelationEnum, string> InitDict()
        {
            var dict = new Dictionary<CycleWhereRelationEnum, string>() { 
                {   CycleWhereRelationEnum.Month,           string.Format("MONTH({0})",Constants.ReplaceFieldName)           },
                {   CycleWhereRelationEnum.Week,            string.Format("DAYOFWEEK({0})",Constants.ReplaceFieldName)       },
                {   CycleWhereRelationEnum.Day,             string.Format("DAY({0})",Constants.ReplaceFieldName)             },
                {   CycleWhereRelationEnum.Hour,            string.Format("HOUR({0})",Constants.ReplaceFieldName)            },
            };
            return dict;
        }
    }
}
