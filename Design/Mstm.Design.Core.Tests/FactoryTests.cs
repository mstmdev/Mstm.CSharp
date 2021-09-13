using System;
using Mstm.Design.Core;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace Mstm.Design.UnitTests
{
    public class FactoryTests
    {
        IFactory<string, FactoryImpl> _factory;


        /// <summary>
        /// 单个测试开始前
        /// </summary>
        public FactoryTests()
        {
            _factory = new FactoryImpl();
        }


        /// <summary>
        /// 单个测试结束后
        /// </summary>

        ~FactoryTests()
        {
            _factory = null;
        }


        /// <summary>
        /// 测试正常的输入
        /// </summary>
        [Fact]
        public void GetProviderTest_NotNull()
        {
            var f1 = _factory.GetProvider("F1");
            var f2 = _factory.GetProvider("F2");
            var f3 = _factory.GetProvider("F3");
            f1.ShouldNotBeNull();
            f2.ShouldNotBeNull();
            f3.ShouldNotBeNull();
        }


        /// <summary>
        /// 测试未获取到指定键的情况
        /// </summary>
        [Fact]
        public void GetProviderTest_IsNull()
        {
            IFactory<string, FactoryImpl> f6 = _factory.GetProvider("F6");
            f6.ShouldBeNull<IFactory<string, FactoryImpl>>();
        }


        /// <summary>
        /// 测试键为空的情况
        /// </summary>
        [Fact]
        public void GetProviderTest_ArgIsNull()
        {
            IFactory<string, FactoryImpl> f6 = _factory.GetProvider(null);
            f6.ShouldBeNull<IFactory<string, FactoryImpl>>();
        }
    }


    class FactoryImpl : Factory<string, FactoryImpl>
    {


        protected override Dictionary<string, FactoryImpl> Init()
        {
            var dict = new Dictionary<string, FactoryImpl>()
            {
                {"F1",new FactoryImpl()},
                {"F2",new FactoryImpl()},
                {"F3",new FactoryImpl()},
                {"F4",new FactoryImpl()},
                {"F5",new FactoryImpl()},
            };
            return dict;
        }
    }
}
