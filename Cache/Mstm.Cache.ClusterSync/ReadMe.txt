使用示例：

//##########################################应用全局配置############################################

//使用MemoryCache作为缓存存储  默认使用HttpRuntime.Cache，需要依赖System.Web  必要时可以进行自由切换
GlobalCacheProviderFactory.Instance.SetDefaultCacheProviderFactory(new MemoryCacheProviderFactory());
//默认使用HttpRuntime.Cache，可不用配置
//GlobalCacheProviderFactory.Instance.SetDefaultCacheProviderFactory(new HttpRuntimeCacheProviderFactory());
//修改缓存提供器后需要手动重置才能启用
DefaultCacheFactory.Reset();

//设置zookeeper连接信息
GlobalZKCacheDependencyOption.Instance.SetDefaultZKCacheDependencyOption("zk1.mstmdev.online:2181,zk2.mstmdev.online:2181,zk3.mstmdev.online:2181,zk4.mstmdev.online:2181");

//其他自定义设置（可选）
//自定义置默认缓存策略
GlobalCachePolicy.Instance.SetDefaultCachePolicy(new CachePolicy() { AbsoluteExpiration = TimeSpan.FromMinutes(30) });
//自定义缓存依赖接口组件 默认使用zookeeper
ICacheDependency dependency=null; //实例化你自己的缓存依赖组件
GlobalCacheDependency.Instance.SetDefaultCacheDependency(dependency);

//##########################################应用全局配置############################################

//添加缓存
DefaultCacheFactory.DefaultCache.Add("/user/1001/name", "test_user");

//读取缓存
var value = DefaultCacheFactory.DefaultCache.Get<string>("/user/1001/name");

//清除指定的缓存
DefaultCacheFactory.DefaultCache.ClearOne("/user/1001/name");

//递归清除指定节点下的所有缓存
DefaultCacheFactory.DefaultCache.Clear("/user");

//递归清除当前应用的所有缓存
DefaultCacheFactory.DefaultCache.ClearAll();

//使用自定义的策略添加缓存  例：30秒滑动过期
DefaultCacheFactory.DefaultCache.Add("/user/1001/name", "test_user", new CachePolicy() { SlidingExpiration = TimeSpan.FromSeconds(30) });