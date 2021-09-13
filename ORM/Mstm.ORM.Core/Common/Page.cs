using System;
using System.Collections.Generic;
using System.Text;

namespace Mstm.ORM.Core.Common
{
    /// <summary>
    /// 分页数据
    /// </summary>
    /// <typeparam name="T">分页数据类型</typeparam>
    public class Page<T>
    {
        /// <summary>
        /// 当前页码，从1开始
        /// </summary>
        public int PageNum { get; set; }

        /// <summary>
        /// 数据总数
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// 分页总数
        /// </summary>
        public long PageCount { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 分页数据
        /// </summary>
        public IList<T> Items { get; set; }

        /// <summary>
        /// 用户自定义的上下文数据
        /// </summary>
        public object Context { get; set; }
    }
}
