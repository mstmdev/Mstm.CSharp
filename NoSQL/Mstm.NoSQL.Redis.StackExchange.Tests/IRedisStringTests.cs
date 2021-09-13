using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using System.Configuration;
using Mstm.NoSQL.Redis.Core;
using Xunit;

namespace Mstm.NoSQL.Redis.StackExchange.Tests
{

    /// <summary>
    /// IRedisString接口测试
    /// </summary>
    public class IRedisStringTests : AbstractRedisTests
    {

        private IRedisString _provider;

        public IRedisStringTests()
        {
            _provider = RedisFactory.GetProvider();
        }


        [Fact]
        public void GetStringTest_KeyIsNotExist_Fail()
        {
            string key = "GetStringTest_KeyIsNotExist_Fail";
            string value = _provider.GetString(key);
            value.ShouldBeNull();
        }

        [Fact]
        public void GetStringTest_KeyIsExist_Success()
        {
            string key = "GetStringTest_KeyIsExist_Success";
            _provider.SetString(key, "IRedisStringTests");
            string value = _provider.GetString(key);
            value.ShouldBe("IRedisStringTests");
        }


        [Fact]
        public void SetStringTest_Success()
        {
            string key = "SetStringTest_Success";
            _provider.SetString(key, "IRedisStringTests.SetStringTest_Success", 1);
            var value = _provider.GetString(key);
            value.ShouldBe("IRedisStringTests.SetStringTest_Success");
        }


        [Fact]
        public void SetDataTest_Normal_Success()
        {
            string key = "SetDataTest_Normal_Success";
            _provider.SetData<Person>(key, new Person()
            {
                Name = "张三",
                Age = 19
            }, 1);
        }


        [Fact]
        public void SetDataTest_DataIsNull_SetNullStr()
        {
            string key = "SetDataTest_DataIsNull_SetNullStr";
            _provider.SetData<Person>(key, null, 1);
        }


        [Fact]
        public void GetDataTest_Normal_Success()
        {
            string key = "GetDataTest_Normal_Success";
            _provider.SetData<Person>(key, new Person()
            {
                Name = "李四",
                Age = 23
            }, 1);
            Person p = _provider.GetData<Person>(key);
            p.ShouldNotBeNull();
            p.Name.ShouldBe("李四");
        }

        [Fact]
        public void GetDataTest_DataIsNull_ReturnNull()
        {
            string key = "GetDataTest_DataIsNull_ReturnNull";
            _provider.SetData<Person>(key, null, 1);
            Person p = _provider.GetData<Person>(key);
            p.ShouldBeNull();
        }


        [Fact]
        public void IsExistStringTest_KeyIsExist_ReturnTrue()
        {
            string key = "IsExistString_KeyIsExist_ReturnTrue";
            _provider.SetString(key, key, 1);
            bool isExist = _provider.IsExistString(key);
            isExist.ShouldBeTrue();
        }

        [Fact]
        public void IsExistStringTest_KeyIsNotExist_ReturnFalse()
        {
            string key = "IsExistStringTest_KeyIsNotExist_ReturnFalse";
            bool isExist = _provider.IsExistString(key);
            isExist.ShouldBeFalse();
        }

        [Fact]
        public void DeleteStringTest_KeyIsNotExist_ReturnFalse()
        {
            string key = "DeleteStringTest_KeyIsNotExist_ReturnFalse";
            bool isSuccess = _provider.DeleteString(key);
            isSuccess.ShouldBeFalse();
        }


        [Fact]
        public void DeleteStringTest_KeyIsExist_ReturnTrue()
        {
            string key = "DeleteStringTest_KeyIsExist_ReturnTrue";
            _provider.SetString(key, key, 1);
            bool isSuccess = _provider.DeleteString(key);
            isSuccess.ShouldBeTrue();
        }

        [Fact]
        public void AppendStringTest_KeyIsExist_Success()
        {
            string key = "AppendStringTest_KeyIsExist_Success";
            _provider.SetString(key, key, 1);
            string result = _provider.AppendString(key, "hello");
            result.ShouldBe(key + "hello");
        }

        [Fact]
        public void AppendStringTest_KeyIsNotExist_Success()
        {
            string key = "AppendStringTest_KeyIsNotExist_Success";
            _provider.DeleteString(key);
            string result = _provider.AppendString(key, "hello");
            result.ShouldBe("hello");
        }


        [Fact]
        public void GetBytesTest_KeyIsNotExist_ReturnNull()
        {
            string key = "GetBytesTest_KeyIsNotExist_ReturnNull";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(key);
            var value = _provider.GetBytes(key);
            value.ShouldBeNull();
        }


        [Fact]
        public void GetBytesTest_KeyIsExist_Success()
        {
            string key = "GetBytesTest_KeyIsExist_Success";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(key);
            _provider.SetBytes(key, bytes, 1);
            var value = _provider.GetBytes(key);
            value.ShouldBe(bytes);
        }


        [Fact]
        public void SetBytesTest_Success()
        {
            string key = "SetBytesTest_Success";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(key);
            _provider.SetBytes(key, bytes, 1);
        }



        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
