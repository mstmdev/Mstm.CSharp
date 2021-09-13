using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Mstm.Log.Core;
using System.Diagnostics;
using System.Threading.Tasks;
using Mstm.ORM.Core.Entity;
using Mstm.ORM.Core.Metadata;
using Mstm.ORM.Core.Common;
using System.Data;

namespace Mstm.ORM.Core
{
    /// <summary>
    /// 仓储基础实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract partial class Repository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        protected TableInfo tableInfo;
        protected DbConnection conn;
        private Func<AccessUser> _resolveAssessUser;
        private AccessUser _accessUser;
        public ILogProvider Logger;
        public ILogProvider MonitorLogger;

        protected AccessUser AccessUser
        {
            get
            {
                return _accessUser ?? AccessUser.DefaultUser;
            }
        }
        private string _connStr;

        public Repository(string connStr)
            : this(connStr, null)
        {
        }

        public Repository(string connStr, AccessUser accessUser)
        {
            this._accessUser = accessUser;
            tableInfo = TableInfo.GetTableInfo<T>();
            _connStr = connStr;
            Logger = DefaultLog.GetLogger(this.GetType());
            MonitorLogger = DefaultLog.GetMonitorLogger(this.GetType());
        }

        public string ConnectionStr
        {
            get { return _connStr; }
        }

        public void Open()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public async Task<long> CountAsync()
        {
            return await this.CountAsync(string.Empty);
        }

        public async Task<long> CountAsync(string where)
        {
            long count = 0;

            #region PreExecute
            var watch = StartMonitor();
            where = BuildWhere(where);
            #endregion

            #region Executing
            count = await this.OnCountAsync(where);
            #endregion

            #region Executed
            Monitoring("Count", "查询总数", where, watch);
            #endregion

            return count;
        }

        public async Task<long> CountAsync(Expression<Func<T, bool>> where)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<TEntity> ExecuteAsync<TEntity>(string sql, object parms = null)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<IList<TEntity>> ExecuteListAsync<TEntity>(string sql, object parms = null)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, object parms = null)
        {
            int count = -1;
            #region PreExecute
            var watch = StartMonitor();
            if (string.IsNullOrWhiteSpace(sql)) { return count; }
            #endregion

            #region Executing
            count = await OnExecuteNonQueryAsync(sql, parms);
            #endregion

            #region Executed
            Monitoring("ExecuteNonQueryAsync", "执行指定的SQL语句，返回受影响的行数", sql, watch);
            #endregion

            return count;
        }

        public async Task<IDataReader> ExecuteReaderAsync(string sql, object parms = null)
        {
            IDataReader dataReader = null;
            #region PreExecute
            var watch = StartMonitor();
            if (string.IsNullOrWhiteSpace(sql)) { return dataReader; }
            #endregion

            #region Executing
            dataReader = await OnExecuteReaderAsync(sql, parms);
            #endregion

            #region Executed
            Monitoring("ExecuteReaderAsync", "执行指定的SQL语句，返回IDataReader实例", sql, watch);
            #endregion

            return dataReader;
        }

        public async Task<object> ExecuteScalarAsync(string sql, object parms = null)
        {
            object obj = null;
            #region PreExecute
            var watch = StartMonitor();
            if (string.IsNullOrWhiteSpace(sql)) { return obj; }
            #endregion

            #region Executing
            obj = await OnExecuteScalarAsync(sql, parms);
            #endregion

            #region Executed
            Monitoring("ExecuteScalarAsync", "执行指定的SQL语句，返回第一行第一列数据", sql, watch);
            #endregion

            return obj;
        }

        public async Task<int> ForceRemoveAsync(string where)
        {
            int deleteCount = 0;

            #region PreExecute
            var watch = StartMonitor();
            where = BuildWhere(where);
            #endregion

            #region Executing
            deleteCount = await OnForceRemoveAsync(where);
            #endregion

            #region Executed
            Monitoring("ForceRemove", "强制物理删除指定的数据", where, watch);
            #endregion

            return deleteCount;
        }

        public async Task<int> ForceRemoveAsync(Expression<Func<T, bool>> where)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<IList<T>> GetListAsync()
        {
            return await GetListAsync(string.Empty);
        }

        public async Task<IList<T>> GetListAsync(string where)
        {
            return await this.GetListAsync(where, null);
        }

        public async Task<IList<T>> GetListAsync(string where, string orderby)
        {
            IList<T> list = null;

            #region PreExecute
            var watch = StartMonitor();
            where = BuildWhere(where);
            #endregion

            #region Executing
            if (string.IsNullOrWhiteSpace(orderby))
            {
                list = await this.OnGetListAsync(where);
            }
            else
            {
                list = await this.OnGetListAsync(where, orderby);
            }
            #endregion

            #region Executed
            ProcessRecordHash(list.ToArray());
            Monitoring("GetListAsync", "筛选指定的数据行", where, watch);
            #endregion

            return list;
        }

        public async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, string orderby)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<Page<T>> GetPageListAsync(int pageNum, int pageSize)
        {
            #region PreExecute
            var watch = StartMonitor();
            Page<T> page = null;
            string where = BuildWhere();
            #endregion

            #region Executing
            page = await OnGetPageListAsync(pageNum, pageSize, where);
            #endregion

            #region Executed
            Monitoring("GetPageList", "分页查询，返回分页结果", where, watch);
            #endregion

            return page;
        }

        public async Task<Page<T>> GetPageListAsync(int pageNum, int pageSize, string where)
        {
            #region PreExecute
            var watch = StartMonitor();
            Page<T> page = null;
            where = BuildWhere(where);
            #endregion

            #region Executing
            page = await OnGetPageListAsync(pageNum, pageSize, where);
            #endregion

            #region Executed
            Monitoring("GetPageList", "分页查询，返回分页结果", where, watch);
            #endregion

            return page;
        }

        public async Task<Page<T>> GetPageListAsync(int pageNum, int pageSize, string where, string orderby)
        {
            #region PreExecute
            var watch = StartMonitor();
            Page<T> page = null;
            where = BuildWhere(where);
            #endregion

            #region Executing
            page = await OnGetPageListAsync(pageNum, pageSize, where, orderby);
            #endregion

            #region Executed
            Monitoring("GetPageList", "分页查询，返回分页结果", where, watch);
            #endregion

            return page;
        }

        public async Task<Page<T>> GetPageListAsync(int pageNum, int pageSize, Expression<Func<T, bool>> where)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<Page<T>> GetPageListAsync(int pageNum, int pageSize, Expression<Func<T, bool>> where, string orderby)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<T> GetSingleAsync(string where)
        {
            T entity = null;

            #region PreExecute
            var watch = StartMonitor();
            where = BuildWhere(where);
            #endregion

            #region Executing
            entity = await OnGetSingleAsync(where);
            #endregion

            #region Executed
            ProcessRecordHash(entity);
            Monitoring("GetSingle", "查询指定的单个数据", where, watch);
            #endregion

            return entity;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> where)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<T> GetFirstAsync(string where, string orderBy)
        {
            T entity = null;
            #region PreExecute
            var watch = StartMonitor();
            where = BuildWhere(where);
            #endregion

            #region Executing
            entity = await OnGetFirstAsync(where, orderBy);
            #endregion

            #region Executed
            ProcessRecordHash(entity);
            Monitoring("GetFirst", "查询指定数据集中的第一个匹配项", where, watch);
            #endregion
            return entity;
        }

        public async Task<int> InsertAsync(params T[] entities)
        {
            int insertCount = 0;

            #region PreExecute
            var watch = StartMonitor();
            if (entities == null || entities.Length == 0) { return 0; }
            if (entities != null && entities.Length > 0 && (tableInfo.IsICreateRecord || tableInfo.IsIModifyRecord))
            {
                foreach (T entity in entities)
                {
                    DateTime now = DateTime.Now;
                    if (tableInfo.IsICreateRecord)
                    {
                        var insertEntity = (ICreateRecord)entity;
                        insertEntity.CreateTime = now;
                        insertEntity.CreateUserId = AccessUser.UserId;
                        insertEntity.CreateUserName = AccessUser.UserName;
                    }
                    if (tableInfo.IsIModifyRecord)
                    {
                        var modifyEntity = (IModifyRecord)entity;
                        modifyEntity.ModifyTime = now;
                        modifyEntity.ModifyUserId = AccessUser.UserId;
                        modifyEntity.ModifyUserName = AccessUser.UserName;
                        modifyEntity.RecordHash = EntityUtility.GetEntityHash<T>(entity);
                    }
                }
            }
            #endregion

            #region Executing
            insertCount = await OnInsertAsync(entities);
            #endregion

            #region Executed
            Monitoring("Insert", "插入一条或多条数据", entities.ToJson(), watch);
            #endregion

            return insertCount;
        }

        public async Task<int> RemoveAsync(string where)
        {
            int deleteCount = 0;

            #region PreExecute
            var watch = StartMonitor();
            where = BuildWhere(where);
            #endregion

            #region Executing
            //如果实体实现了IDeleted接口，则进行逻辑删除，否则进行物理删除
            if (tableInfo.IsIDeleted == false)
            {
                deleteCount = await OnForceRemoveAsync(where);
            }
            else
            {
                deleteCount = await OnLogicalRemoveAsync(where);
            }
            #endregion

            #region Executed
            Monitoring("Remove", "数据删除，根据IDeleted接口自动处理", where, watch);
            #endregion

            return deleteCount;
        }

        public async Task<int> RemoveAsync(Expression<Func<T, bool>> where)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(T entity, Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] fields)
        {
            #region PreExecute

            #endregion

            #region Executing

            #endregion

            #region Executed

            #endregion

            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(T entity, string where, params Expression<Func<T, object>>[] fields)
        {
            int updateCount = 0;

            #region PreExecute
            var watch = StartMonitor();
            //重新构建where
            where = BuildWhere(where);

            //处理IModifyRecord
            if (fields != null && fields.Length > 0 && tableInfo.IsIModifyRecord)
            {
                var fieldList = fields.ToList();
                Expression<Func<T, object>> expression = a => (a as IModifyRecord).ModifyTime;
                fieldList.Add(expression as Expression<Func<T, object>>);
                expression = a => (a as IModifyRecord).ModifyUserId;
                fieldList.Add(expression as Expression<Func<T, object>>);
                expression = a => (a as IModifyRecord).ModifyUserName;
                fieldList.Add(expression as Expression<Func<T, object>>);
                expression = a => (a as IModifyRecord).RecordHash;
                fieldList.Add(expression as Expression<Func<T, object>>);

                var baseEntity = entity as IModifyRecord;
                baseEntity.ModifyTime = DateTime.Now;
                if (this.AccessUser != null)
                {
                    baseEntity.ModifyUserId = this.AccessUser.UserId;
                    baseEntity.ModifyUserName = this.AccessUser.UserName;
                }
                baseEntity.RecordHash = EntityUtility.GetEntityHash<T>(entity, true);
                fields = fieldList.Distinct(new FieldExpressionComparer<T>()).ToArray();
            }
            #endregion

            #region Executing
            updateCount = await OnUpdateAsync(entity, where, fields);
            #endregion

            #region Executed
            Monitoring("Update", "数据更新", string.Format("要更新的数据为[{0}],过滤条件为[{1}]，要更新的字段为[{2}]", entity.ToJson(), where, fields.ToJson()), watch);
            #endregion

            return updateCount;
        }


        /// <summary>
        /// 构建where语句
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public string BuildWhere<TEntity>(string where = null)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" 1=1");
            var table = TableInfo.GetTableInfo<TEntity>();
            if (table.IsIDeleted)
            {
                builder.Append(" AND IsDeleted=0");
            }
            if (string.IsNullOrWhiteSpace(where) == false)
            {
                builder.AppendFormat(" AND {0}", where);
            }
            return builder.ToString();
        }

        /// <summary>
        /// 构建where语句
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public string BuildWhere(string where = null)
        {
            return BuildWhere<T>(where);
        }

        /// <summary>
        /// 构建包含IsDeleted筛选的where语句
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public string BuildIsDeletedWhere(string where = null)
        {
            if (string.IsNullOrWhiteSpace(where))
            {
                where = " IsDeleted=0";
            }
            else
            {
                where = string.Format(" IsDeleted=0 AND {0}", where);
            }
            return where;
        }

        #region 私有方法
        /// <summary>
        /// 处理RecordHash的更新
        /// </summary>
        /// <param name="list"></param>
        private void ProcessRecordHash(params T[] entities)
        {
            if (entities != null && tableInfo.IsIModifyRecord)
            {
                entities.AsParallel().ForAll(entity =>
                {
                    if (entity == null) { return; }
                    var modifyEntity = ((IModifyRecord)entity);
                    if (modifyEntity.RecordHash == null || modifyEntity.RecordHash.Length <= 32)
                    {
                        modifyEntity.RecordHash = EntityUtility.GetEntityHash(entity);
                        TaskQueue.UpdateRecordHash<T>(entity, this);
                    }
                });
            }
        }

        /// <summary>
        /// 记录监视结果
        /// </summary>
        /// <param name="method">监视的方法名</param>
        /// <param name="desc">操作描述信息</param>
        /// <param name="data">相关信息数据，实体信息或者sql等</param>
        /// <param name="watch">Stopwatch实例</param>
        /// <param name="reset">记录监视信息后，是否重置当前Stopwatch</param>
        protected virtual void Monitoring(string method, string desc, string data, Stopwatch watch, bool reset = true)
        {
            if (watch == null)
            {
                Logger.WarnFormat("检测到监控计时器为空，所在方法为【{0}】", method);
                return;
            }
            watch.Stop();
            MonitorLogger.DebugFormat("【{0}】 【{1}】 表名为【{2}】 耗时【{3}】毫秒 相关信息【{4}】", method, desc, tableInfo.TableName, watch.ElapsedMilliseconds, data);
            if (reset)
            {
                watch.Reset();
            }
            watch.Start();
        }

        /// <summary>
        /// 启动一个Stopwatch，并返回其实例对象
        /// </summary>
        /// <returns></returns>
        protected Stopwatch StartMonitor()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            return watch;
        }
        #endregion
    }
}
