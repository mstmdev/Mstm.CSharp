using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Sybase
{

    internal class SybaseCycleWhereRelationDict : RelationDictAbstract<CycleWhereRelationEnum>
    {
        private static SybaseCycleWhereRelationDict _instance;


        public static SybaseCycleWhereRelationDict GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SybaseCycleWhereRelationDict();
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
