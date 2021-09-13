using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22享元模式
{
    /// <summary>
    /// Product信息模型
    /// 用于存储享元实例的外部数据
    /// </summary>
    class ProductInfo
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
