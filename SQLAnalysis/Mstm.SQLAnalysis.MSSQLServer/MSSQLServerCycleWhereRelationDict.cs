using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.MSSQLServer
{
    internal class MSSQLServerCycleWhereRelationDict : RelationDictAbstract<CycleWhereRelationEnum>
    {
        private static MSSQLServerCycleWhereRelationDict _instance;


        public static MSSQLServerCycleWhereRelationDict GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MSSQLServerCycleWhereRelationDict();
            }
            return _instance;
        }


        protected override Dictionary<CycleWhereRelationEnum, string> InitDict()
        {
            var dict = new Dictionary<CycleWhereRelationEnum, string>() { 
                {   CycleWhereRelationEnum.Month,           string.Format("DATEPART(MONTH,{0})",Constants.ReplaceFieldName)           },
                {   CycleWhereRelationEnum.Week,            string.Format("DATEPART(WEEKDAY,{0})",Constants.ReplaceFieldName)         },
                {   CycleWhereRelationEnum.Day,             string.Format("DATEPART(DAY,{0})",Constants.ReplaceFieldName)             },
                {   CycleWhereRelationEnum.Hour,            string.Format("DATEPART(HOUR,{0})",Constants.ReplaceFieldName)            },
            };
            return dict;
        }
    }
}
