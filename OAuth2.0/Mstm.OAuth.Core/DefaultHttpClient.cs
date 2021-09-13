using Mstm.Json.Core;
using Mstm.Json.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Core
{

#if NET47

    /// <summary>
    /// 默认Http客户端
    /// 使用微软的HttpClient和Microsoft.AspNet.WebApi.Client相关扩展实现
    /// </summary>
    public class DefaultHttpClient : IHttpClient
    {

        HttpClient client;
        IJsonProvider jsonProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DefaultHttpClient()
        {
            jsonProvider = JsonFactory.GetProvider();
            client = new HttpClient();
        }

        /// <summary>
        ///发起Get请求，获取JSON数据，结果序列化为对象
        /// </summary>
        /// <typeparam name="TResult">请求的结果类型</typeparam>
        /// <param name="requestUrl">请求地址</param>
        /// <returns>响应结果</returns>
        public TResult GetAsJson<TResult>(string requestUrl)
        {
            HttpResponseMessage response = null;
            response = client.GetAsync(requestUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<TResult>().Result;
                return result;
            }
            else
            {
                var strException = Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result);
                throw new Exception(strException);
            }
        }

        /// <summary>
        /// 发起Post请求，获取JSON数据，结果序列化为对象
        /// </summary>
        /// <typeparam name="TResult">请求的结果类型</typeparam>
        /// <typeparam name="TRequestBody">Post提交的数据类型</typeparam>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="data">Pos提交的数据</param>
        /// <returns>响应结果</returns>
        public TResult PostAsJson<TResult, TRequestBody>(string requestUrl, TRequestBody data)
        {
            HttpResponseMessage response = null;
            response = client.PostAsJsonAsync<TRequestBody>(requestUrl, data).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<TResult>().Result;
                return result;
            }
            else
            {
                var strException = Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result);
                throw new Exception(strException);
            }
        }

        /// <summary>
        /// 发起Get请求，获取字符串结果
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <returns>响应结果</returns>
        public string GetString(string requestUrl)
        {
            HttpResponseMessage response = null;
            response = client.GetAsync(requestUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                var strException = Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result);
                throw new Exception(strException);
            }
        }

        /// <summary>
        /// 发起Post请求
        /// </summary>
        /// <typeparam name="TResult">响应结果类型</typeparam>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="data">发送的字典数据</param>
        /// <returns>响应结果</returns>
        public TResult Post<TResult>(string requestUrl, Dictionary<string, string> data)
        {
            HttpContent content = null;
            if (data == null)
            {
                data = new Dictionary<string, string>();
            }
            content = new FormUrlEncodedContent(data);

            HttpResponseMessage response = null;
            response = client.PostAsync(requestUrl, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var str = response.Content.ReadAsStringAsync().Result;
                TResult result = jsonProvider.DeserializeObject<TResult>(str);
                return result;
            }
            else
            {
                var strException = Encoding.UTF8.GetString(response.Content.ReadAsByteArrayAsync().Result);
                throw new Exception(strException);
            }

        }
    }
#endif
}
