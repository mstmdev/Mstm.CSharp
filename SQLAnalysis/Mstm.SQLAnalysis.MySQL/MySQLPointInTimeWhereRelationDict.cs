using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.MySQL
{
    internal class MySQLPointInTimeWhereRelationDict : RelationDictAbstract<PointInTimeWhereRelationEnum>
    {
        private static MySQLPointInTimeWhereRelationDict _instance;



        public static MySQLPointInTimeWhereRelationDict GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MySQLPointInTimeWhereRelationDict();
            }
            return _instance;
        }

        protected override Dictionary<PointInTimeWhereRelationEnum, string> InitDict()
        {
            var dict = new Dictionary<PointInTimeWhereRelationEnum, string>() { 
                {   PointInTimeWhereRelationEnum.BeforeYear,           string.Format("<= DATE_ADD(NOW(),INTERVAL -{0} YEAR)",Constants.ReplaceValue)      },
                {   PointInTimeWhereRelationEnum.BeforeMonth,          string.Format("<= DATE_ADD(NOW(),INTERVAL -{0} MONTH)",Constants.ReplaceValue)     },
                {   PointInTimeWhereRelationEnum.BeforeDay,            string.Format("<= DATE_ADD(NOW(),INTERVAL -{0} DAY)",Constants.ReplaceValue)       },
                {   PointInTimeWhereRelationEnum.BeforeHour,           string.Format("<= DATE_ADD(NOW(),INTERVAL -{0} HOUR)",Constants.ReplaceValue)      },
                {   PointInTimeWhereRelationEnum.InYear,               string.Format(">= DATE_ADD(NOW(),INTERVAL -{0} YEAR)",Constants.ReplaceValue)      },
                {   PointInTimeWhereRelationEnum.InMonth,              string.Format(">= DATE_ADD(NOW(),INTERVAL -{0} MONTH)",Constants.ReplaceValue)     },
                {   PointInTimeWhereRelationEnum.InDay,                string.Format(">= DATE_ADD(NOW(),INTERVAL -{0} DAY)",Constants.ReplaceValue)       },
                {   PointInTimeWhereRelationEnum.InHour,               string.Format(">= DATE_ADD(NOW(),INTERVAL -{0} HOUR)",Constants.ReplaceValue)      },
            };
            return dict;
        }
    }
}
