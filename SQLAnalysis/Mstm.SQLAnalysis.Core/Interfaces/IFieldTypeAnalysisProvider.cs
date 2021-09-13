using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.SQLAnalysis.Core
{

    /// <summary>
    /// 字段类型解析器
    /// </summary>
    public interface IFieldTypeAnalysisProvider
    {
        /// <summary>
        /// 将数据库中的类型转换成枚举
        /// </summary>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        FieldTypeEnum GetFieldTypeEnum(string fieldType);
    }



    /// <summary>
    /// 字段类型解析器扩展
    /// </summary>
    public static class FieldTypeAnalysisProviderExtension
    {

        /// <summary>
        /// 将数据库类型转换成枚举值
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static int GetFieldTypeInt(this IFieldTypeAnalysisProvider provider, string dbType)
        {
            return (int)provider.GetFieldTypeEnum(dbType);
        }

        /// <summary>
        /// 将数据库类型转换成C#类型
        /// </summary>
        /// <param name="provider">字段类型解析器</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static Type GetFieldType(this IFieldTypeAnalysisProvider provider, string dbType)
        {
            FieldTypeEnum typeEnum = provider.GetFieldTypeEnum(dbType);
            Type type = null;
            switch (typeEnum)
            {
                case FieldTypeEnum.Text:
                    type = typeof(string);
                    break;
                case FieldTypeEnum.DateTime:
                    type = typeof(DateTime);
                    break;
                case FieldTypeEnum.Number:
                    type = typeof(float);
                    break;
            }

            return type;
        }
    }
}
