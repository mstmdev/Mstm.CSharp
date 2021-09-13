using System;
namespace Mstm.Cache.ClusterSync.Tests
{
    interface ICacheProviderTests
    {
        void AddTest();
        void AddWithCachePolicy_AbsoluteExpiration_IsExpire_Test();
        void AddWithCachePolicy_AbsoluteExpiration_IsNotExpire_Test();
        void AddWithCachePolicy_SlidingExpiration_IsExpire_Test();
        void AddWithCachePolicy_SlidingExpiration_IsNotExpire_Test();
        void ClearAllTest();
        void ClearOneTest();
        void ClearTest();
        void GetTest();
        void RootNodeTest();
    }
}
