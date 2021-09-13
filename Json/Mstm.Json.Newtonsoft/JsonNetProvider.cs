using Mstm.Json.Core;
using Newtonsoft.Json;
using System;

namespace Mstm.Json.Newtonsoft
{

    /// <summary>
    /// Json.Net序列化器实现
    /// </summary>
    public class JsonNetProvider : IJsonProvider
    {
        /// <summary>
        /// 将指定的对象序列化为Json字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="data">对象实例</param>
        /// <returns>序列化后的Json串</returns>
        public string SerializeObject<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 将Json字符串反序列化为指定的类型实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="jsonStr">待反序列化的Json字符串</param>
        /// <returns>反序列化后的对象实例</returns>
        public T DeserializeObject<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }
}
