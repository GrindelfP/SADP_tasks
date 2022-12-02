namespace taskSeven
{
    public sealed class HashTableArray : HashTable
    {
        private readonly string[,] _items;
        private const int NUMBER_OF_COLUMNS = 2;
        public HashTableArray(int capasity) : base(capasity)
        {
            _items = new string[_capacity, NUMBER_OF_COLUMNS];
        }


        public override void Add(string key, object data)
        {
            int indexOfAddition = GenerateHashCode(key);
            while (_items[indexOfAddition, 0] != null)
            {
                if (indexOfAddition == _capacity) { indexOfAddition = 0; continue; }
                indexOfAddition++;
            }
            _items[indexOfAddition, 0] = key;
            _items[indexOfAddition, 1] = data.ToString();
        }

        public override object Find(string key)
        {
            NumberOfTriesInSearch = 0;
            bool foundEmpty = false;
            int indexOfExpectableAddition = GenerateHashCode(key);
            while (key != _items[indexOfExpectableAddition, 0])
            {
                if (_items[indexOfExpectableAddition, 0] == null)
                {
                    foundEmpty = true;
                    break;
                }
                indexOfExpectableAddition++;
                NumberOfTriesInSearch++;
            }

            return !foundEmpty ? _items[indexOfExpectableAddition, 1] : null;
        }
    }
}