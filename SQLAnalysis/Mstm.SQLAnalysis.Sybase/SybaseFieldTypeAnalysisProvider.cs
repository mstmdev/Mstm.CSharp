using Mstm.SQLAnalysis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Sybase
{
    internal class SybaseFieldTypeAnalysisProvider : AbstractFieldTypeAnalysisProvider
    {

        //类型枚举字典
        readonly static Dictionary<string, FieldTypeEnum> _dict = new Dictionary<string, FieldTypeEnum>()
        {
            //时间
            { "BIGDATETIME",                 FieldTypeEnum.DateTime        },
            { "BIGDATETIMEN",                FieldTypeEnum.DateTime        },
            { "BIGTIME",                     FieldTypeEnum.DateTime        },
            { "BIGTIMEN",                    FieldTypeEnum.DateTime        },
            { "DATE",                        FieldTypeEnum.DateTime        },
            { "DATEN",                       FieldTypeEnum.DateTime        },
            { "DATETIME",                    FieldTypeEnum.DateTime        },
            { "DATETIMN",                    FieldTypeEnum.DateTime        },
            { "SMALLDATETIME",               FieldTypeEnum.DateTime        },
            { "TIME",                        FieldTypeEnum.DateTime        },
            { "TIMEN",                       FieldTypeEnum.DateTime        },
            { "TIMESTAMP",                   FieldTypeEnum.DateTime        },



            //数值
            { "BIGINT",                      FieldTypeEnum.Number          },
            { "BIT",                         FieldTypeEnum.Number          },
            { "DECIMAL",                     FieldTypeEnum.Number          },
            { "DECIMALN",                    FieldTypeEnum.Number          },
            { "FLOAT",                       FieldTypeEnum.Number          },
            { "FLOATN",                      FieldTypeEnum.Number          },
            { "INT",                         FieldTypeEnum.Number          },
            { "INTN",                        FieldTypeEnum.Number          },
            { "MONEY",                       FieldTypeEnum.Number          },
            { "MONEYN",                      FieldTypeEnum.Number          },
            { "NUMERIC",                     FieldTypeEnum.Number          },
            { "NUMERICN",                    FieldTypeEnum.Number          },
            { "REAL",                        FieldTypeEnum.Number          },
            { "SMALLINT",                    FieldTypeEnum.Number          },
            { "SMALLMONEY",                  FieldTypeEnum.Number          },
            { "TINYINT",                     FieldTypeEnum.Number          },
            { "UBIGINT",                     FieldTypeEnum.Number          },
            { "UINT",                        FieldTypeEnum.Number          },
            { "UINTN",                       FieldTypeEnum.Number          },
            { "USMALLINT",                   FieldTypeEnum.Number          },


            //字符
            { "BINARY",                      FieldTypeEnum.Text            },
            { "CHAR",                        FieldTypeEnum.Text            },
            { "LONGSYSNAME",                 FieldTypeEnum.Text            },
            { "NCHAR",                       FieldTypeEnum.Text            },
            { "NVARCHAR",                    FieldTypeEnum.Text            },
            { "SYSNAME",                     FieldTypeEnum.Text            },
            { "TEXT",                        FieldTypeEnum.Text            },
            { "TEXT_LOCATOR",                FieldTypeEnum.Text            },
            { "UNICHAR",                     FieldTypeEnum.Text            },
            { "UNITEXT",                     FieldTypeEnum.Text            },
            { "UNITEXT_LOCATOR",             FieldTypeEnum.Text            },
            { "UNIVARCHAR",                  FieldTypeEnum.Text            },
            { "VARBINARY",                   FieldTypeEnum.Text            },
            { "VARCHAR",                     FieldTypeEnum.Text            },


            //其他
            { "EXTENDED TYPE",               FieldTypeEnum.Text            },
            { "IMAGE",                       FieldTypeEnum.Text            },
            { "IMAGE_LOCATOR",               FieldTypeEnum.Text            },

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
