using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.MSSQLServer
{


    internal class MSSQLServerPointInTimeWhereRelationDict : RelationDictAbstract<PointInTimeWhereRelationEnum>
    {
        private static MSSQLServerPointInTimeWhereRelationDict _instance;



        public static MSSQLServerPointInTimeWhereRelationDict GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MSSQLServerPointInTimeWhereRelationDict();
            }
            return _instance;
        }

        protected override Dictionary<PointInTimeWhereRelationEnum, string> InitDict()
        {
            var dict = new Dictionary<PointInTimeWhereRelationEnum, string>() { 
                {   PointInTimeWhereRelationEnum.BeforeYear,           string.Format("<= DATEADD(YYYY,-{0}, GETDATE())",Constants.ReplaceValue)      },
                {   PointInTimeWhereRelationEnum.BeforeMonth,          string.Format("<= DATEADD(MM,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.BeforeDay,            string.Format("<= DATEADD(DD,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.BeforeHour,           string.Format("<= DATEADD(HH,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.InYear,               string.Format(">= DATEADD(YYYY,-{0}, GETDATE())",Constants.ReplaceValue)      },
                {   PointInTimeWhereRelationEnum.InMonth,              string.Format(">= DATEADD(MM,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.InDay,                string.Format(">= DATEADD(DD,-{0}, GETDATE())",Constants.ReplaceValue)        },
                {   PointInTimeWhereRelationEnum.InHour,               string.Format(">= DATEADD(HH,-{0}, GETDATE())",Constants.ReplaceValue)        },
            };
            return dict;
        }
    }

}
