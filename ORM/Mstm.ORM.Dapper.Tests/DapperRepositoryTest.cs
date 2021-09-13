using Mstm.ORM.Core;
using Mstm.ORM.Core.Tests.Common;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using Xunit;

namespace Mstm.ORM.Dapper.Tests
{
    public class DapperRepositoryTest
    {
        IRepository<UserInfoEntity> repo = new DapperRepository<UserInfoEntity>("Server=127.0.0.1;Database=game;User Id=sa;Password =1qaz@WSX;");

        public DapperRepositoryTest()
        {
            TaskQueue.Run();
        }

        [Fact]
        public void GetListTest()
        {
            var list = repo.GetListAsync().Result;
        }

        [Fact]
        public void GeCountTest()
        {
            long count = repo.CountAsync().Result;
        }

        [Fact]
        public void InsertTest()
        {
            var count = repo.InsertAsync(new UserInfoEntity() { UserName = "BiuBiu", Password = "123", State = 1, ModifyUserName = "system", ModifyUserId = 1, IsDeleted = false, ModifyTime = DateTime.Now, CreateTime = DateTime.Now, CreateUserId = 1, CreateUserName = "system" }).Result;
        }

        [Fact]
        public void InsertMultiTest()
        {
            var count = repo.InsertAsync(
                new UserInfoEntity() { UserName = "BiuBiu1", Password = "123", State = 1, ModifyUserName = "system", ModifyUserId = 1, IsDeleted = false, ModifyTime = DateTime.Now, CreateTime = DateTime.Now, CreateUserId = 1, CreateUserName = "system" },
                new UserInfoEntity() { UserName = "BiuBiu2", Password = "123", State = 1, ModifyUserName = "system", ModifyUserId = 1, IsDeleted = false, ModifyTime = DateTime.Now, CreateTime = DateTime.Now, CreateUserId = 1, CreateUserName = "system" },
                new UserInfoEntity() { UserName = "BiuBiu3", Password = "123", State = 1, ModifyUserName = "system", ModifyUserId = 1, IsDeleted = false, ModifyTime = DateTime.Now, CreateTime = DateTime.Now, CreateUserId = 1, CreateUserName = "system" },
                new UserInfoEntity() { UserName = "BiuBiu4", Password = "123", State = 1, ModifyUserName = "system", ModifyUserId = 1, IsDeleted = false, ModifyTime = DateTime.Now, CreateTime = DateTime.Now, CreateUserId = 1, CreateUserName = "system" }
                ).Result;
        }

        [Fact]
        public void RemoveTest()
        {
            var count = repo.RemoveAsync("UserName='BiuBiu1'").Result;
        }

        [Fact]
        public void ForceRemoveTest()
        {
            var count = repo.ForceRemoveAsync("UserName='BiuBiu2'").Result;
        }

        [Fact]
        public void UpdateTest()
        {
            UserInfoEntity userInfo = new UserInfoEntity()
            {
                Password = "666111666"
            };
            var count = repo.UpdateAsync(userInfo, "UserName='BiuBiu3'", a => a.Password).Result;
        }

        #region ExecuteNonQueryAsync
        [Fact]
        public void ExecuteNonQueryAsyncTest()
        {
            string sql = "UPDATE UserInfo SET State=0 WHERE UserName='BiuBiu4'";
            var count = repo.ExecuteNonQueryAsync(sql).Result;
        }

        [Fact]
        public void ExecuteNonQueryAsyncWithParamsTest()
        {
            string sql = "UPDATE UserInfo SET State=9 WHERE UserName=@UserName";
            var count = repo.ExecuteNonQueryAsync(sql, new { UserName = "BiuBiu4" }).Result;
        }
        #endregion

        #region ExecuteReaderAsync
        [Fact]
        public void ExecuteReaderAsyncTest()
        {
            string sql = "SELECT * FROM UserInfo WHERE UserId=1";
            var reader = repo.ExecuteReaderAsync(sql).Result;
        }

        [Fact]
        public void ExecuteReaderAsyncWithParamsTest()
        {
            string sql = "SELECT * FROM UserInfo WHERE UserId=@UserId";
            var reader = repo.ExecuteReaderAsync(sql, new { UserId = 1 }).Result;
        }
        #endregion

        #region ExecuteScalarAsync
        [Fact]
        public void ExecuteScalarAsyncTest()
        {
            string sql = "SELECT UserName FROM UserInfo WHERE UserId>1";
            var userName = repo.ExecuteScalarAsync(sql).Result;
        }

        [Fact]
        public void ExecuteScalarAsyncWithParamsTest()
        {
            string sql = "SELECT UserName FROM UserInfo WHERE UserId=@UserId";
            var userName = repo.ExecuteScalarAsync(sql, new { UserId = 1 }).Result;
        }
        #endregion

        #region GetListAsync
        [Fact]
        public void GetListAsyncTest()
        {
            var list = repo.GetListAsync().Result;
        }

        [Fact]
        public void GetListAsyncWithWhereTest()
        {
            var list = repo.GetListAsync("UserId=1").Result;
        }

        [Fact]
        public void GetListAsyncWithOrderByTest()
        {
            var list = repo.GetListAsync("UserId>1", "UserId DESC").Result;
        }
        #endregion

        [Fact]
        public void UpdateRecordHashTest()
        {
            var list = repo.GetListAsync().Result;
            Thread.Sleep(10000);
        }

        [Fact]
        public void GetSingleTest()
        {
            var entity = repo.GetSingleAsync("UserId=42").Result;
            Thread.Sleep(3000);
        }
    }
}
