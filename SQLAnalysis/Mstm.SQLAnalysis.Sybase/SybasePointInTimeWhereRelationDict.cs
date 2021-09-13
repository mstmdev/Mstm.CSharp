using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Sybase
{

    internal class SybasePointInTimeWhereRelationDict : RelationDictAbstract<PointInTimeWhereRelationEnum>
    {
        private static SybasePointInTimeWhereRelationDict _instance;



        public static SybasePointInTimeWhereRelationDict GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SybasePointInTimeWhereRelationDict();
            }
            return _instance;
        }

        protected override Dictionary<PointInTimeWhereRelationEnum, string> InitDict()
        {
            var dict = new Dictionary<PointInTimeWhereRelationEnum, string>() { 
                {   PointInTimeWhereRelationEnum.BeforeYear,           string.Format("<= DATEADD(YEAR,-{0}, GETDATE())",Constants.ReplaceValue)      },
                {   PointInTimeWhereRelationEnum.BeforeMonth,          string.Format("<= DATEADD(MONTH,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.BeforeDay,            string.Format("<= DATEADD(DAY,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.BeforeHour,           string.Format("<= DATEADD(HOUR,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.InYear,               string.Format(">= DATEADD(YEAR,-{0}, GETDATE())",Constants.ReplaceValue)      },
                {   PointInTimeWhereRelationEnum.InMonth,              string.Format(">= DATEADD(MONTH,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.InDay,                string.Format(">= DATEADD(DAY,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.InHour,               string.Format(">= DATEADD(HOUR,-{0}, GETDATE())",Constants.ReplaceValue)        },
            };
            return dict;
        }
    }

}
