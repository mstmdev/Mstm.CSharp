using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.MySQL
{
    internal class MySQLFieldTypeAnalysisProvider : AbstractFieldTypeAnalysisProvider
    {

        //类型枚举字典
        readonly static Dictionary<string, FieldTypeEnum> _dict = new Dictionary<string, FieldTypeEnum>()
        {
            //时间
            { "DATE",                      FieldTypeEnum.DateTime        },
            { "TIME",                      FieldTypeEnum.DateTime        },
            { "DATETIME",                  FieldTypeEnum.DateTime        },
            { "TIMESTAMP",                 FieldTypeEnum.DateTime        },
            { "YEAR",                      FieldTypeEnum.DateTime        },


            //数值
            { "TINYINT",                   FieldTypeEnum.Number          },
            { "SMALLINT",                  FieldTypeEnum.Number          },
            { "MEDIUMINT",                 FieldTypeEnum.Number          },
            { "INT",                       FieldTypeEnum.Number          },
            { "BIGINT",                    FieldTypeEnum.Number          },
            { "DECIMAL",                   FieldTypeEnum.Number          },
            { "FLOAT",                     FieldTypeEnum.Number          },
            { "DOUBLE",                    FieldTypeEnum.Number          },
            { "BIT",                       FieldTypeEnum.Number          },


            //字符
            { "CHAR",                      FieldTypeEnum.Text            },
            { "VARCHAR",                   FieldTypeEnum.Text            },
            { "BINARY",                    FieldTypeEnum.Text            },
            { "VARBINARY",                 FieldTypeEnum.Text            },
            { "TINYBLOB",                  FieldTypeEnum.Text            },
            { "BLOB",                      FieldTypeEnum.Text            },
            { "MEDIUMBLOB",                FieldTypeEnum.Text            },
            { "LONGBLOB",                  FieldTypeEnum.Text            },
            { "TINYTEXT",                  FieldTypeEnum.Text            },
            { "TEXT",                      FieldTypeEnum.Text            },
            { "MEDIUMTEXT",                FieldTypeEnum.Text            },
            { "LONGTEXT",                  FieldTypeEnum.Text            },
            { "ENUM",                      FieldTypeEnum.Text            },
            { "SET",                       FieldTypeEnum.Text            },


            //其他
            { "GEOMETRY",                  FieldTypeEnum.Text            },
            { "POINT",                     FieldTypeEnum.Text            },
            { "LINESTRING",                FieldTypeEnum.Text            },
            { "POLYGON",                   FieldTypeEnum.Text            },
            { "GEOMETRYCOLLECTION",        FieldTypeEnum.Text            },
            { "MULTILINESTRING",           FieldTypeEnum.Text            },
            { "MULTIPOINT",                FieldTypeEnum.Text            },
            { "MULTIPOLYGON",              FieldTypeEnum.Text            },

        };


        public override FieldTypeEnum DefaultFieldType
        {
            get { return FieldTypeEnum.Text; }
        }

        public override Dictionary<string, FieldTypeEnum> FieldTypeDict
        {
            get { return _dict; }
        }
    }
}
