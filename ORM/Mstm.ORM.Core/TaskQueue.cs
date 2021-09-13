using Mstm.ORM.Core.Common;
using Mstm.ORM.Core.Entity;
using Mstm.ORM.Core.Metadata;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mstm.ORM.Core
{
    public static class TaskQueue
    {
        private static ConcurrentQueue<Task> _queue = new ConcurrentQueue<Task>();
        private static bool _start = false;

        public static void UpdateRecordHash<T>(T entity, IRepository<T> repository)
            where T : class, IEntity
        {
            if (entity == null || repository == null) { return; }
            var task = new Task(() =>
            {
                var tableInfo = TableInfo.GetTableInfo<T>();
                if (entity != null && repository != null && tableInfo.IsIModifyRecord)
                {
                    if (tableInfo.PKList == null || tableInfo.PKList.Count == 0)
                    {
                        //没有主键则不进行更新，以免出错
                        //这里进行记录日志预警
                        return;
                    }
                    var dataDict = EntityUtility.GetEntityDict<T>(entity);
                    if (dataDict == null || dataDict.Count == 0) { return; }
                    string where = "1=1";
                    foreach (var pk in tableInfo.PKList)
                    {
                        if (dataDict.ContainsKey(pk) == false) { return; }
                        where += string.Format(" AND {0}='{1}'", pk, dataDict[pk]);
                    }
                    string hash = EntityUtility.GetEntityHash<T>(entity);
                    string sql = string.Format("UPDATE {0} SET RecordHash='{1}' WHERE {2}", tableInfo.TableName, hash, where);
                    var repoType = repository.GetType();
                    var newRepo = Assembly.GetAssembly(repoType).CreateInstance(repoType.FullName, true, BindingFlags.Public | BindingFlags.Instance, null, new object[] { repository.ConnectionStr }, CultureInfo.CurrentCulture, null) as IRepository<T>;
                    newRepo.ExecuteNonQueryAsync(sql);
                }
            });
            _queue.Enqueue(task);
        }

        /// <summary>
        /// 启动任务队列
        /// </summary>
        /// <returns></returns>
        public static Task Run()
        {
            _start = true;
            var task = Task.Run(() =>
            {
                while (_start)
                {
                    while (_queue.Count > 0 && _start)
                    {
                        Task work;
                        bool isSuccess = _queue.TryDequeue(out work);
                        if (isSuccess && work != null)
                        {
                            work.Start();
                        }
                    }
                    Thread.Sleep(3000);
                }

            });
            return task;
        }

        /// <summary>
        /// 暂停任务队列
        /// </summary>
        /// <returns></returns>
        public static void Stop()
        {
            _start = false;
        }
    }
}
