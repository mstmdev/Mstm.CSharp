using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.Log.Core
{
    /// <summary>
    /// 日志提供器组件
    /// </summary>
    public interface ILogProvider
    {
        void Info(object msg);

        void Debug(object msg);

        void Warn(object msg);

        void Error(object msg);

        void Fatal(object msg);

        void Info(object msg, Exception ex);

        void Debug(object msg, Exception ex);

        void Warn(object msg, Exception ex);

        void Error(object msg, Exception ex);

        void Fatal(object msg, Exception ex);

        void InfoFormat(string msg, params object[] args);

        void DebugFormat(string msg, params object[] args);

        void WarnFormat(string msg, params object[] args);

        void ErrorFormat(string msg, params object[] args);

        void FatalFormat(string msg, params object[] args);
    }
}
