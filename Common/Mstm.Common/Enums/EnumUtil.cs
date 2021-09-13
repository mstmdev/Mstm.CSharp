using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Reflection;

namespace Mstm.Common.Enums
{

    /// <summary>
    /// 枚举工具类
    /// </summary>
    public class EnumUtil
    {
        /// <summary>
        /// 获取枚举项对应的文本描述
        /// </summary>
        /// <param name="enumObj"></param>
        /// <returns>枚举项对应的文本描述</returns>
        public static string GetEnumDescription(Enum enumObj)
        {
            var attr = GetEnumAttribute<DescriptionAttribute>(enumObj);
            if (attr == null) { return string.Empty; }
            return attr.Description;
        }


        /// <summary>
        ///获取枚举项对应的操作符 
        /// </summary>
        /// <param name="enumObj">枚举项</param>
        /// <returns>枚举项对应的操作符</returns>
        public static string GetEnumOperation(Enum enumObj)
        {
            var attr = GetEnumAttribute<OperatorAttribute>(enumObj);
            if (attr == null) { return string.Empty; }
            return attr.Operation;
        }


        /// <summary>
        /// 列举枚举中所有的项
        /// TKey:枚举的描述
        /// TValue：枚举的值
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static Dictionary<string, int> GetEnumItems<TEnum>()
        {

            Dictionary<string, int> dict = new Dictionary<string, int>();
            Type enumType = typeof(TEnum);
            Array values = Enum.GetValues(enumType);
            var enumList = values.Cast<Enum>().ToList();
            enumList.ForEach(element =>
            {
                dict.Add(GetEnumDescription(element), Convert.ToInt32(element));
            });
            return dict;
        }



        /// <summary>
        /// 获取枚举上指定的特性
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="enumObj">枚举值</param>
        /// <returns>特性实例</returns>
        private static T GetEnumAttribute<T>(Enum enumObj)
            where T : Attribute
        {
            string enumName = enumObj.ToString();
            Type enumType = enumObj.GetType();
            FieldInfo enumFieldInfo = enumType.GetField(enumName);
            if (enumFieldInfo == null)
            {
                throw new Exception("未获取到指定的枚举项！");
            }
            var descList = enumFieldInfo.GetCustomAttributes<T>(false);
            if (descList == null || descList.Count() == 0)
            {
                return default(T);
            }
            return descList.FirstOrDefault();
        }

    }
}
