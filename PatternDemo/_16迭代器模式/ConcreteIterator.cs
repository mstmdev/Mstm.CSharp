using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16迭代器模式
{
    class AggregateIterator : IIterator
    {
        ConcreteAggregate _aggregate;
        int _index;

        public AggregateIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
            _index = 0;
        }

        public object First()
        {
            return this._aggregate[0];
        }

        public void Next()
        {
            _index++;
        }

        public object Current()
        {
            return this._aggregate[_index];
        }

        public bool IsLast()
        {
            return this._index == this._aggregate.Count();
        }


        public void Reset()
        {
            this._index = 0;
        }
    }
}
