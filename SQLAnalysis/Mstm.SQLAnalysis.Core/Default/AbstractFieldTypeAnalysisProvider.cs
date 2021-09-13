using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{
    public abstract class AbstractFieldTypeAnalysisProvider : IFieldTypeAnalysisProvider
    {
        /// <summary>
        /// 默认类型
        /// </summary>
        public abstract FieldTypeEnum DefaultFieldType { get; }


        /// <summary>
        /// 类型枚举字典
        /// </summary>
        public abstract Dictionary<string, FieldTypeEnum> FieldTypeDict { get; }


        /// <summary>
        /// 将数据库中的类型转换成枚举
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        public virtual FieldTypeEnum GetFieldTypeEnum(string fieldType)
        {
            if (string.IsNullOrWhiteSpace(fieldType) || FieldTypeDict == null || FieldTypeDict.Count == 0)
            {
                return DefaultFieldType;
            }
            fieldType = fieldType.ToUpper();
            if (FieldTypeDict.ContainsKey(fieldType))
            {
                return FieldTypeDict[fieldType];
            }
            else
            {
                return DefaultFieldType;
            }
        }
    }
}
