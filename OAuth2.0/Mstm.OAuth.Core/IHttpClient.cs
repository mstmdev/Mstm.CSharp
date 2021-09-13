using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.OAuth.Core
{

    /// <summary>
    /// Http客户端接口
    /// </summary>
    public interface IHttpClient
    {

        /// <summary>
        /// 发起Get请求
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <returns></returns>
        string GetString(string requestUrl);

        /// <summary>
        /// 发起Post请求
        /// </summary>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="data">请求的数据</param>
        /// <returns>响应结果</returns>
        TResult Post<TResult>(string requestUrl, Dictionary<string, string> data);


        /// <summary>
        /// 发起Get请求并反序列化对象
        /// </summary>
        /// <typeparam name="TResult">返回类型</typeparam>
        /// <param name="requestUrl">请求地址</param>
        /// <returns>响应结果</returns>
        TResult GetAsJson<TResult>(string requestUrl);

        /// <summary>
        /// 以Json数据格式发起Post请求
        /// </summary>
        /// <typeparam name="TResult">响应结果类型</typeparam>
        /// <typeparam name="TRequestBody">请求体Model类型</typeparam>
        /// <param name="requestUrl">请求地址</param>
        /// <param name="data">请求体</param>
        /// <returns>响应结果</returns>
        TResult PostAsJson<TResult, TRequestBody>(string requestUrl, TRequestBody data);
    }
}
