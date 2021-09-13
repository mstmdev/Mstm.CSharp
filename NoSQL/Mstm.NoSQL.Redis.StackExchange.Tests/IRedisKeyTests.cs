using Mstm.NoSQL.Redis.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace Mstm.NoSQL.Redis.StackExchange.Tests
{

    /// <summary>
    /// IRedisKey接口测试
    /// </summary>
    public class IRedisKeyTests : AbstractRedisTests
    {
        private IRedisKey _provider;

        public IRedisKeyTests()
        {
            _provider = RedisFactory.GetProvider();
        }

        [Fact]
        public void GetTTLTest_IsAlive()
        {
            string key = "GetTTLTest_IsAlive";
            SetString(key);
            _provider.SetExpireKey(key, 1000);
            var ttl = _provider.GetTTL(key);
            ttl.ShouldBeGreaterThan(1);
        }


        [Fact]
        public void IsExistKeyTest_IsExist()
        {
            string key = "IsExistKeyTest_IsExist";
            SetString(key);
            var isExist = _provider.IsExistKey(key);
            isExist.ShouldBeTrue();
        }


        [Fact]
        public void IsExistKeyTest_NotExist()
        {
            string key = "IsExistKeyTest_NotExist";
            _provider.DeleteKey(key);
            var isExist = _provider.IsExistKey(key);
            isExist.ShouldBeFalse();
        }


        [Fact]
        public void DeleteKeyTest_DeleteSuccess()
        {
            string[] keys = new string[] { "DeleteKeyTest_DeleteSuccess_1", "DeleteKeyTest_DeleteSuccess_2" };
            SetString("DeleteKeyTest_DeleteSuccess_1", "good1");
            SetString("DeleteKeyTest_DeleteSuccess_2", "good2");
            long count = _provider.DeleteKey(keys);
            count.ShouldBe(keys.Length);
        }

        [Fact]
        public void DeleteKeyTest_KeyNotExist_ReturnZero()
        {
            string[] keys = new string[] { "DeleteKeyTest_KeyNotExist_ReturnZero", "DeleteKeyTest_KeyNotExist_ReturnZero" };
            long count = _provider.DeleteKey(keys);
            count.ShouldBe(0);
        }


        [Fact]
        public void ReNameKeyWithCoverTest_Success()
        {
            string oldKey = "ReNameKeyWithCoverTest_Success_Old";
            string newKey = "ReNameKeyWithCoverTest_Success_New";
            SetString(oldKey, "good1");
            SetString(newKey, "good2");
            bool isSuccess = _provider.ReNameKeyWithCover(oldKey, newKey);
            isSuccess.ShouldBeTrue();
            var value = (_provider as IRedisString).GetString(newKey);
            value.ShouldBe("good1");
        }

        [Fact]
        public void ReNameKeyWithCoverTest_KeyNotExist_ThrowException()
        {
            try
            {
                string oldKey = "ReNameKeyWithCoverTest_KeyNotExist_ThrowException_Old";
                string newKey = "ReNameKeyWithCoverTest_KeyNotExist_ThrowException_New";
                bool isSuccess = _provider.ReNameKeyWithCover(oldKey, newKey);
            }
            catch (Exception)
            {
                return;
            }
            Assert.True(false);

        }


        [Fact]
        public void ReNameKeyWithOutCoverTest_Success()
        {
            string oldKey = "ReNameKeyWithOutCoverTest_Success_Old";
            string newKey = "ReNameKeyWithOutCoverTest_Success_New";
            SetString(oldKey, "good1");
            _provider.DeleteKey(newKey);
            bool isSuccess = _provider.ReNameKeyWithOutCover(oldKey, newKey);
            isSuccess.ShouldBeTrue();
            var value = (_provider as IRedisString).GetString(newKey);
            value.ShouldBe("good1");
        }

        [Fact]
        public void ReNameKeyWithOutCoverTest_OldKeyNotExist_ThrowException()
        {
            try
            {
                string oldKey = "ReNameKeyWithOutCoverTest_OldKeyNotExist_ThrowException_Old";
                string newKey = "ReNameKeyWithOutCoverTest_OldKeyNotExist_ThrowException_New";
                _provider.ReNameKeyWithOutCover(oldKey, newKey);
            }
            catch (Exception)
            {
                return;
            }
            Assert.True(false);
        }

        [Fact]
        public void ReNameKeyWithOutCoverTest_NewKeyIsExisted_Fail()
        {
            string oldKey = "ReNameKeyWithOutCoverTest_NewKeyIsExisted_Fail_Old";
            string newKey = "ReNameKeyWithOutCoverTest_NewKeyIsExisted_Fail_New";
            SetString(oldKey, "good1");
            SetString(newKey, "good2"); ;
            bool isSuccess = _provider.ReNameKeyWithOutCover(oldKey, newKey);
            isSuccess.ShouldBeFalse();
        }


        [Fact]
        public void PersistKeyTest_KeyNotExist_Fail()
        {
            string key = "PersistKeyTest_KeyNotExist_Fail";
            bool isSuccess = _provider.PersistKey(key);
            isSuccess.ShouldBeFalse();
        }


        [Fact]
        public void PersistKeyTest_KeyIsNotExpire_Fail()
        {
            string key = "PersistKeyTest_KeyIsNotExpire_Fail";
            SetString(key);
            bool isSuccess = _provider.PersistKey(key);
            isSuccess.ShouldBeFalse();
        }


        [Fact]
        public void PersistKeyTest_KeyIsExpire_Success()
        {
            string key = "PersistKeyTest_KeyIsExpire_Success";
            SetString(key);
            _provider.SetExpireKey(key, 100);
            bool isSuccess = _provider.PersistKey(key);
            isSuccess.ShouldBeTrue();
        }


        [Fact]
        public void SetExpireKeyTest_KeyIsNotExist_Fail()
        {
            string key = "SetExpireKeyTest_KeyIsNotExist_Fail";
            bool isSuccess = _provider.SetExpireKey(key, 10);
            isSuccess.ShouldBeFalse();
        }

        [Fact]
        public void SetExpireKeyTest_KeyIsExist_Success()
        {
            string key = "SetExpireKeyTest_KeyIsExist_Success";
            SetString(key);
            bool isSuccess = _provider.SetExpireKey(key, 10);
            isSuccess.ShouldBeTrue();
        }


        [Fact]
        public void SetExpireatKeyTest_KeyIsNotExist_Fail()
        {
            string key = "SetExpireatKeyTest_KeyIsNotExist_Fail";
            long timestamp = (DateTime.Now.AddMinutes(1).ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            bool isSuccess = _provider.SetExpireatKey(key, timestamp);
            isSuccess.ShouldBeFalse();
        }

        [Fact]
        public void SetExpireatKeyTest_KeyIsExist_Success()
        {
            string key = "SetExpireatKeyTest_KeyIsExist_Success";
            SetString(key);
            long timestamp = (DateTime.Now.AddMinutes(1).ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            bool isSuccess = _provider.SetExpireatKey(key, timestamp);
            isSuccess.ShouldBeTrue();
        }


        [Fact]
        public void GetRandomKeyTest()
        {
            string key = _provider.GetRandomKey();
            key.ShouldNotBeNull();
        }

        [Fact]
        public void GetKeyTypeTest_KeyIsNotExist_Fail()
        {
            string key = "GetKeyTypeTest_KeyIsNotExist_Fail";
            var type = _provider.GetKeyType(key);
            type.ShouldBe(RedisDataType.None);
        }

        [Fact]
        public void GetKeyTypeTest_KeyIsExist_Success()
        {
            string key = "GetKeyTypeTest_KeyIsExist_Success";
            SetString(key);
            var type = _provider.GetKeyType(key);
            type.ShouldBe(RedisDataType.String);
        }

        /// <summary>
        /// 添加一个字符串类型的KV
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        private void SetString(string key, string value = "good")
        {
            (_provider as IRedisString).SetString(key, value);
        }
    }
}
