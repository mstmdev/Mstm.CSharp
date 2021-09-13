using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Mstm.ORM.Core.Linq;
using Mstm.ORM.Core.Tests.Common;

namespace Mstm.ORM.Core.Tests
{
    public class LinqBuilderTests
    {
        ILinqBuilder _builder;

        public LinqBuilderTests()
        {
            _builder = new LinqBuilder();
        }


        [Fact]
        public void BuildFieldTest()
        {
            var fieldName = _builder.BuildField<UserInfoEntity>(a => a.ModifyTime);
            fieldName.ShouldBe("ModifyTime");
        }


        [Fact]
        public void BuildFieldListTest()
        {
            var fieldNameList = _builder.BuildFieldList<UserInfoEntity>(a => a.ModifyTime, a => a.Password);
            fieldNameList.ShouldContain("ModifyTime");
            fieldNameList.ShouldContain("Password");
            fieldNameList.Count.ShouldBe(2);
        }

        [Fact]
        public void BuildFieldListDistinctTest()
        {
            var fieldNameList = _builder.BuildFieldList<UserInfoEntity>(a => a.ModifyTime, a => a.Password, a => a.ModifyTime, a => a.ModifyTime);
            fieldNameList.ShouldContain("ModifyTime");
            fieldNameList.ShouldContain("Password");
            fieldNameList.Count.ShouldBe(2);
        }

        [Fact]
        public void BuildFieldStrDistinctTest()
        {
            string fieldStr = _builder.BuildFieldStr<UserInfoEntity>(a => a.ModifyTime, a => a.Password, a => a.ModifyTime, a => a.ModifyTime);
            fieldStr.ShouldBe("ModifyTime,Password");
        }

        [Fact]
        public void BuildOrderByTest()
        {
            string orderby = _builder.BuildOrderBy<UserInfoEntity>(a => a.Password);
            orderby.Trim().ShouldBe("ORDER BY Password ASC");
        }
    }
}
