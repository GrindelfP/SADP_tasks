using System;

namespace taskSeven
{
    /// <summary>
    /// <para>Hash table is a array-based data structure, which by provided key value generates
    /// a hash-code and then places both the key and value data in the array according to generated hash-code.</para>
    /// </summary>
    public class HashTable
    {
        private readonly Tuple<string, object>[] _items;
        private readonly int _capacity;
        public HashTable(int capasity)
        {
            _capacity = capasity;
            _items = new Tuple<string, object>[_capacity];
        }

        public void Add(string key, object data)
        {
            int indexOfAddition = GenerateHashCode(key);
            while (_items[indexOfAddition] != null)
            {
                if (indexOfAddition == _capacity) { indexOfAddition = 0; continue; }
                indexOfAddition++;
            }
            _items[indexOfAddition] = new Tuple<string, object>(key, data);
        }

        public object Find(string key)
        {
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
            }
            return !foundEmpty ? _items[indexOfExpectableAddition].Item2 : null;
        }

        private int GenerateHashCode(string key)
        {
            int hashCode = 0;
            for (int index = 0; index < key.Length; index++)
            {
                hashCode += key[index] * index;
            }
            return hashCode % _capacity;
        }
    }
}