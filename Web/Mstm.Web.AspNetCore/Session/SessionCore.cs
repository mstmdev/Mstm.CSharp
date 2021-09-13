using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.Web.AspNetCore.Session
{

    /// <summary>
    /// 用户会话
    /// </summary>
    public class SessionCore
    {
        /// <summary>
        /// Session对应的Cookie键
        /// </summary>
        private const string SessionIdKey = "ASPNETCORE.SESSIONCORE.SESSIONID";
        private HttpContext _context;
        private ISessionStorage _storage;

        /// <summary>
        /// 私有构造函数
        /// 初始化当前Session的实现方案
        /// </summary>
        private SessionCore()
        {
            try
            {
                _context = new HttpContextAccessor().HttpContext;
            }
            catch (Exception ex)
            {
                throw new Exception("SessionCore初始化异常", ex);
            }
            if (_context == null)
            {
                throw new Exception("SessionCore还未完成初始化");
            }
            _storage = DefaultSessionStorage.Default;
            if (_storage == null)
            {
                throw new Exception("未设置ISessionStorage实例，请检查DefaultSessionStorage.Default是否设置正确");
            }
        }

        /// <summary>
        /// 当前上线文Session
        /// </summary>
        public static SessionCore Session
        {
            get
            {
                return new SessionCore();
            }
        }

        /// <summary>
        /// 获取Session数据
        /// </summary>
        /// <typeparam name="T">返回的数据类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>查询的Sessiion值</returns>
        public T Get<T>(string key)
        {
            key = BuildKey(key);
            return _storage.Get<T>(key);
        }

        /// <summary>
        /// 设置一个Session
        /// </summary>
        /// <typeparam name="T">设置的数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="value">设置的值</param>
        /// <param name="cacheMinutes">缓存时间</param>
        public void Set<T>(string key, T value, int cacheMinutes = 60 * 24)
        {
            key = BuildKey(key);
            _storage.Set<T>(key, value, cacheMinutes);
        }

        /// <summary>
        /// 获取Session中指定键的String值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetString(string key)
        {
            key = BuildKey(key);
            return _storage.GetString(key);
        }

        /// <summary>
        /// 设置一个String类型的Session
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">要保存的字符串</param>
        /// <param name="cacheMinutes">缓存的时间</param>
        public void SetString(string key, string value, int cacheMinutes = 60 * 24)
        {
            key = BuildKey(key);
            _storage.SetString(key, value, cacheMinutes);
        }

        /// <summary>
        /// 构造Session中实际存储的Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string BuildKey(string key)
        {
            string sessionId = _context.Request.Cookies[SessionIdKey];
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                sessionId = BuildNewSessionId();
                _context.Response.Cookies.Append(SessionIdKey, sessionId);
            }
            string realKey = string.Format("{0}.{1}.{2}", SessionIdKey, sessionId, key);
            return realKey;
        }

        /// <summary>
        /// 生成新的SesionId
        /// </summary>
        /// <returns></returns>
        private string BuildNewSessionId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
