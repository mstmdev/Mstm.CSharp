using Mstm.ORM.Core;
using System;
using System.Data.Common;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mstm.ORM.Core.Operator;
using Mstm.ORM.Core.Entity;
using Mstm.ORM.Core.Common;
using System.Data;

namespace Mstm.ORM.Dapper
{
    public class DapperRepository<T> : Repository<T>
         where T : class, IEntity, new()
    {

        public DapperRepository(string connStr)
            : this(connStr, null)
        {
        }

        public DapperRepository(string connStr, AccessUser accessUser)
         : base(connStr)
        {
            conn = new System.Data.SqlClient.SqlConnection(connStr);
        }

        public override async Task<long> OnCountAsync(string where)
        {
            string sql = string.Format("SELECT COUNT(1) FROM {0} WHERE {1}", tableInfo.TableName, where);
            int count = (int)await conn.ExecuteScalarAsync(sql);
            return count;
        }

        public override async Task<T> OnGetSingleAsync(string where)
        {
            string sql = string.Format("SELECT {0} FROM {1} WHERE {2}", tableInfo.GetColumnsStr(), tableInfo.TableName, where);
            var entity = await conn.QuerySingleOrDefaultAsync<T>(sql);
            return entity;
        }

        public override async Task<T> OnGetFirstAsync(string where, string orderBy)
        {
            string sql = string.Format("SELECT TOP(1) {0} FROM {1} WHERE {2} ORDER BY {3}", tableInfo.GetColumnsStr(), tableInfo.TableName, where, orderBy);
            //QueryFirstOrDefault不会在服务器端过滤数据，必须自己加TOP(1)
            var entity = await conn.QueryFirstOrDefaultAsync<T>(sql);
            return entity;
        }

        public override async Task<IList<T>> OnGetListAsync(string where)
        {
            string sql = string.Format("SELECT {0} FROM {1} WHERE {2}", tableInfo.GetColumnsStr(), tableInfo.TableName, where);
            return (await conn.QueryAsync<T>(sql)).ToList();
        }

        public override async Task<IList<T>> OnGetListAsync(string where, string orderBy)
        {
            string sql = string.Format("SELECT {0} FROM {1} WHERE {2} ORDER BY {3} ", tableInfo.GetColumnsStr(), tableInfo.TableName, where, orderBy);
            return (await conn.QueryAsync<T>(sql)).ToList();
        }

        public override async Task<int> OnInsertAsync(params T[] entities)
        {
            int addCount = 0;
            if (entities == null || entities.Count() == 0) { return addCount; }
            string sql = string.Format("INSERT INTO {0}({1}) VALUES({2})", tableInfo.TableName, tableInfo.GetColumnsStr(false), tableInfo.GetColumnsStr(false, "@"));
            addCount = await conn.ExecuteAsync(sql, entities);
            return addCount;
        }

        public override async Task<int> OnForceRemoveAsync(string where)
        {
            int deleteCount = 0;
            string sql = string.Format("DELETE FROM {0} WHERE {1}", tableInfo.TableName, where);
            deleteCount = await conn.ExecuteAsync(sql);
            return deleteCount;
        }

        public override async Task<int> OnLogicalRemoveAsync(string where)
        {
            int deleteCount = 0;
            T entity = new T();
            var deletedEntity = (IDeleted)entity;
            deletedEntity.IsDeleted = true;
            Expression<Func<T, object>> field = a => (a as IDeleted).IsDeleted;
            deleteCount = await this.UpdateAsync(entity, where, field);
            return deleteCount;
        }

        public override async Task<int> OnUpdateAsync(T entity, string where, params Expression<Func<T, object>>[] fields)
        {
            int updateCount = 0;
            if (fields == null || fields.Length == 0) { return updateCount; }
            StringBuilder updateContent = new StringBuilder();
            for (int i = 0; i < fields.Length; i++)
            {
                string fieldName = "";
                MemberExpression body = null;
                if (fields[i].Body.NodeType == ExpressionType.Convert)
                {
                    body = (fields[i].Body as UnaryExpression).Operand as MemberExpression;
                }
                else
                {
                    body = fields[i].Body as MemberExpression;
                }
                fieldName = body.Member.Name;
                updateContent.AppendFormat("{0}=@{0},", fieldName);
            }
            string updateContentStr = updateContent.ToString();
            if (updateContentStr.EndsWith(",")) { updateContentStr = updateContentStr.Substring(0, updateContentStr.Length - 1); }
            string sql = string.Format("UPDATE {0} SET {1} WHERE {2}", tableInfo.TableName, updateContentStr, where);
            updateCount = await conn.ExecuteAsync(sql, entity);
            return updateCount;
        }

        public override async Task<int> OnExecuteNonQueryAsync(string sql, object parms)
        {
            return await conn.ExecuteAsync(sql, parms);
        }

        public override async Task<IDataReader> OnExecuteReaderAsync(string sql, object parms = null)
        {
            return await conn.ExecuteReaderAsync(sql, parms);
        }

        public override async Task<object> OnExecuteScalarAsync(string sql, object parms = null)
        {
            return await conn.ExecuteScalarAsync(sql, parms);
        }

        public override async Task<Page<T>> OnGetPageListAsync(int pageNum, int pageSize, string where)
        {
            if (tableInfo.PKList == null || tableInfo.PKList.Count == 0)
            {
                throw new Exception(string.Format("{0}表未设置主键信息，请手动设置排序字段", tableInfo.TableName));
            }
            var pk = tableInfo.PKList.FirstOrDefault();
            return await OnGetPageListAsync(pageNum, pageSize, where, string.Format("{0} ASC", pk));
        }

        public override async Task<Page<T>> OnGetPageListAsync(int pageNum, int pageSize, string where, string orderby)
        {
            if (string.IsNullOrWhiteSpace(where)) { where = " 1=1 "; }
            Page<T> page = new Page<T>();
            page.PageNum = pageNum;
            page.PageSize = pageSize;
            page.Count = await this.OnCountAsync(where);
            if (page.Count > 0)
            {
                page.PageCount = page.Count % pageSize == 0 ? page.Count % pageSize : page.Count / pageSize + 1;
                int startNum = pageSize * (pageNum - 1) + 1;
                int endNum = pageSize * pageNum;
                string sql = "SELECT {0} FROM (SELECT {0},ROW_NUMBER_TAG=row_number()over(order by {1}) FROM {2} WHERE {3})as tb_tmp WHERE tb_tmp.ROW_NUMBER_TAG BETWEEN {4} AND {5}";
                page.Items = (await conn.QueryAsync<T>(string.Format(sql, tableInfo.GetColumnsStr(), orderby, tableInfo.TableName, where, startNum, endNum))).ToList();
            }
            return page;
        }
    }
}
