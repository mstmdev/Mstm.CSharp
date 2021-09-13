using Mstm.ORM.Core.Metadata;
using Mstm.ORM.Core.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mstm.ORM.Core.Tests
{
    public class TableInfoTests
    {
        [Fact]
        public void GetTableInfoTest()
        {
            var tableInfo = TableInfo.GetTableInfo<UserInfoEntity>();
        }
    }
}
