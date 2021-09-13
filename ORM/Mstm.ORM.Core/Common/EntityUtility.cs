using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Mstm.Common.Text;
using Mstm.Json.Core;
using Mstm.ORM.Core.Metadata;
using Mstm.ORM.Core.Entity;

namespace Mstm.ORM.Core.Common
{
    /// <summary>
    /// 实体相关操作的工具类
    /// </summary>
    class EntityUtility
    {
        /// <summary>
        /// 计算行记录的哈希值
        /// 1-32位为表结构的哈希值，33-64位为数据的哈希值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="onlyStruct">仅计算表结构的哈希</param>
        /// <returns></returns>
        public static string GetEntityHash<T>(T entity, bool onlyStruct = false)
        {
            IJsonProvider jsonProvider = JsonFactory.GetProvider();
            var tableInfo = TableInfo.GetTableInfo<T>();
            string structMD5 = EncryptUtil.GetMD5(tableInfo.GetColumnsStr());
            if (onlyStruct) { return structMD5; }
            //计算数据的MD5时应该忽略BaseEntity中的所有可能的字段
            var dataDict = GetEntityDict(entity, true);
            string dataMD5 = EncryptUtil.GetMD5(jsonProvider.SerializeObject(dataDict));
            return string.Format("{0}{1}", structMD5, dataMD5);
        }

        /// <summary>
        /// 将实体转化为字典
        /// </summary>
        /// <typeparam name="T">待转换的实体类型</typeparam>
        /// <param name="entity">待转换的实体</param>
        /// <param name="filterBase">是否要过滤掉BaseEntity实现的所有接口中的属性</param>
        /// <returns></returns>
        public static Dictionary<string, object> GetEntityDict<T>(T entity, bool filterBase = false)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            var properties = TableInfo.GetTableInfo<T>().Properties;
            foreach (var item in properties)
            {
                if (filterBase && IsPropertyInBaseEntity(item.Name)) { continue; }
                object value = item.GetValue(entity);
                dict.Add(item.Name, value);
            }
            return dict;
        }

        /// <summary>
        /// 指定的属性是否在BaseEntity中定义
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static bool IsPropertyInBaseEntity(string propertyName)
        {
            var properties = TableInfo.GetTableInfo<BaseEntity>().Properties;
            bool isContain = properties.Count(a => a.Name == propertyName) > 0;
            return isContain;
        }
    }
}
