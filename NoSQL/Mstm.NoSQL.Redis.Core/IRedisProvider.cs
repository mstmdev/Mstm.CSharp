using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mstm.NoSQL.Redis.Core
{

    /// <summary>
    /// Redis客户端操作接口
    /// </summary>
    public interface IRedisProvider : IRedisString, IRedisKey
    {
    }
}
