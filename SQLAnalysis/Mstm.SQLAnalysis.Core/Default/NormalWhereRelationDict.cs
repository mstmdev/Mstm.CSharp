using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{
    public class NormalWhereRelationDict : RelationDictAbstract<NormalWhereRelationEnum>
    {
        private static NormalWhereRelationDict _instance;


        public static NormalWhereRelationDict GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NormalWhereRelationDict();
            }
            return _instance;
        }


        protected override Dictionary<NormalWhereRelationEnum, string> InitDict()
        {
            var dict = new Dictionary<NormalWhereRelationEnum, string>() { 
                {   NormalWhereRelationEnum.Equal,                 "="                                                        },
                {   NormalWhereRelationEnum.LessThan,              "<"                                                        },
                {   NormalWhereRelationEnum.LessThanOrEqual,       "<="                                                       },
                {   NormalWhereRelationEnum.MoreThan,              ">"                                                        },
                {   NormalWhereRelationEnum.MoreThanOrEqual,       ">="                                                       },
                {   NormalWhereRelationEnum.NotEqual,              "<>"                                                       },
                {   NormalWhereRelationEnum.In,                    "IN"                                                       },
                {   NormalWhereRelationEnum.IsNotNull,             "IS NOT NULL"                                              },
                {   NormalWhereRelationEnum.IsNull,                "IS NULL"                                                  },
                {   NormalWhereRelationEnum.Like,                  string.Format("LIKE '%{0}%'",Constants.ReplaceValue)       },
                {   NormalWhereRelationEnum.LikePrefix,            string.Format("LIKE '%{0}'",Constants.ReplaceValue)        },
                {   NormalWhereRelationEnum.LikeSuffix,            string.Format("LIKE '{0}%'",Constants.ReplaceValue)        },
                {   NormalWhereRelationEnum.NotLike,               string.Format("NOT LIKE '%{0}%'",Constants.ReplaceValue)   },
                {   NormalWhereRelationEnum.NotLikePrefix,         string.Format("NOT LIKE '%{0}'",Constants.ReplaceValue)    },
                {   NormalWhereRelationEnum.NotLikeSuffix,         string.Format("NOT LIKE '{0}%'",Constants.ReplaceValue)    },
            };

            return dict;
        }
    }
}
