using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13适配器模式
{
    /// <summary>
    /// MS公司的产品模型
    /// </summary>
    class MSProductInfo
    {
        public long MSProductId { get; set; }

        public string ProductName { get; set; }

        public decimal SellPrice { get; set; }

        public string MainPicture { get; set; }
    }
}
