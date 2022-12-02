using System;

namespace taskSeven
{
    public sealed class HashTableTuple : HashTable
    {
        private readonly Tuple<string, object>[] _items;
      
        public HashTableTuple(int capacity) : base(capacity)
        {
            _items = new Tuple<string, object>[_capacity];
            NumberOfTriesInSearch = 0;
        }

        public override void Add(string key, object data)
        {
            int indexOfAddition = GenerateHashCode(key);
            while (_items[indexOfAddition] != null)
            {
                if (indexOfAddition == _capacity) { indexOfAddition = 0; continue; }
                indexOfAddition++;
            }
            _items[indexOfAddition] = Tuple.Create(key, data);
        }

        public override object Find(string key)
        {
            NumberOfTriesInSearch = 0;
            bool foundEmpty = false;
            int indexOfExpectableAddition = GenerateHashCode(key);
            while (key != _items[indexOfExpectableAddition].Item1)
            {
                if (_items[indexOfExpectableAddition] == null)
                {
                    foundEmpty = true;
                    break;
                }
                indexOfExpectableAddition++;
                NumberOfTriesInSearch++;
            }
            
            return !foundEmpty ? _items[indexOfExpectableAddition].Item2 : null;
        }
    }
}