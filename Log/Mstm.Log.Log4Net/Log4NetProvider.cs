using log4net;
using log4net.Config;
using log4net.Repository;
using Mstm.Log.Core;
using System;
using System.IO;
using System.Collections.Concurrent;

namespace Mstm.Log.Log4Net
{
    /// <summary>
    /// ILogProvider日志组件实现类，使用Log4Net实现
    /// </summary>
    public class Log4NetProvider : AbstractLogProvider
    {
        private static ConcurrentDictionary<string, ILoggerRepository> _repoDict = new ConcurrentDictionary<string, ILoggerRepository>();
        log4net.ILog innerLogger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type">当前日志操作所在的类型</param>
        public Log4NetProvider(LogProviderConfig config, Type type)
            : base(config)
        {
            ILoggerRepository repository = null;
            string repoName = string.Format("{0}:{1}", LogConfig.ModuleName, LogConfig.GroupName);
            _repoDict.TryGetValue(repoName, out repository);
            if (repository == null)
            {
                repository = LogManager.CreateRepository(repoName);
                _repoDict.TryAdd(repoName, repository);
            }
            FileInfo file = new FileInfo(LogConfig.LogConfigFile);
            if (file.Exists == false)
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string fileFullPath = basePath + LogConfig.LogConfigFile;
                if (basePath.EndsWith("/") == false && basePath.EndsWith(@"\") == false)
                {
                    //Win32NT Unix
                    string platform = Environment.OSVersion.Platform.ToString();
                    if (platform == "Win32NT")
                    {
                        fileFullPath = basePath + @"\" + LogConfig.LogConfigFile;
                    }
                    else
                    {
                        fileFullPath = basePath + "/" + LogConfig.LogConfigFile;
                    }
                }
                file = new FileInfo(fileFullPath);
                if (file.Exists == false)
                {
                    throw new ArgumentException(string.Format("未找到log4net的配置文件，配置文件为{0},当前搜索的路径为{1}", LogConfig.LogConfigFile, fileFullPath));
                }
            }
            XmlConfigurator.Configure(repository, file);
            innerLogger = LogManager.GetLogger(repository.Name, type);
        }

        #region 具体日志操作

        public override void Debug(object msg)
        {
            innerLogger.Debug(msg);
        }

        public override void Debug(object msg, Exception ex)
        {
            innerLogger.Debug(msg, ex);
        }

        public override void DebugFormat(string log, params object[] args)
        {
            innerLogger.DebugFormat(log, args);
        }

        public override void Error(object msg)
        {
            innerLogger.Error(msg);
        }

        public override void Error(object msg, Exception ex)
        {
            innerLogger.Error(msg, ex);
        }

        public override void ErrorFormat(string msg, params object[] args)
        {
            innerLogger.ErrorFormat(msg, args);
        }

        public override void Fatal(object msg)
        {
            innerLogger.Fatal(msg);
        }

        public override void Fatal(object msg, Exception ex)
        {
            innerLogger.Fatal(msg, ex);
        }

        public override void FatalFormat(string msg, params object[] args)
        {
            innerLogger.FatalFormat(msg, args);
        }

        public override void Info(object msg)
        {
            innerLogger.Info(msg);
        }

        public override void Info(object msg, Exception ex)
        {
            innerLogger.Info(msg, ex);
        }

        public override void InfoFormat(string msg, params object[] args)
        {
            innerLogger.InfoFormat(msg, args);
        }

        public override void Warn(object msg)
        {
            innerLogger.Warn(msg);
        }

        public override void Warn(object msg, Exception ex)
        {
            innerLogger.Warn(msg, ex);
        }

        public override void WarnFormat(string msg, params object[] args)
        {
            innerLogger.WarnFormat(msg, args);
        }

        #endregion
    }
}
