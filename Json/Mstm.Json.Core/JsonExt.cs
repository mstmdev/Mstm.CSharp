using Mstm.Json.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class JsonExt
    {
        /// <summary>
        /// 将当前对象序列化为JSON字符串
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson<TSource>(this TSource obj)
        {
            var provider = JsonFactory.GetProvider();
            if (provider == null)
            {
                return obj.ToString();
            }
            else
            {
                try
                {
                    return provider.SerializeObject(obj);
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 将当前对象转化为其他类型，转化失败返回null
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TResult ToObject<TResult>(this object obj)
        {
            string json;
            var provider = JsonFactory.GetProvider();
            if (provider == null)
            {
                return default(TResult);
            }

            try
            {
                if (obj is string)
                {
                    json = obj.ToString();
                }
                else
                {
                    json = provider.SerializeObject(obj);
                }
                return provider.DeserializeObject<TResult>(json);
            }
            catch (Exception)
            {
                return default(TResult);
            }

        }
    }
}
