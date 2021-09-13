using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22享元模式
{

    /// <summary>
    /// 创建享元对象的工厂
    /// </summary>
    class FlyWeightFactory
    {
        private Dictionary<string, FlyWeight> _flyWeightDict;


        /// <summary>
        /// 获取共享的对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public FlyWeight GetSharedFlyWeight(string key)
        {
            if (string.IsNullOrEmpty(key) || _flyWeightDict == null) { _flyWeightDict = new Dictionary<string, FlyWeight>(); }
            if (!_flyWeightDict.ContainsKey(key))
            {
                _flyWeightDict.Add(key, new SharedConcreteFlyWeight());
            }
            return _flyWeightDict[key];
        }


        /// <summary>
        /// 获取不共享的对象
        /// </summary>
        /// <returns></returns>
        public FlyWeight GetUnSharedFlyWeight()
        {
            return new UnSharedConcreteFlyWeight();
        }


        /// <summary>
        /// 获取共享对象总数
        /// </summary>
        /// <returns></returns>
        public int GetSharedFlyWeightCount()
        {
            if (_flyWeightDict == null) { return 0; }
            return _flyWeightDict.Count;
        }
    }
}
