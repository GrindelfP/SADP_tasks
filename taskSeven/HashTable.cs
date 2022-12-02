using System;

namespace taskSeven
{
    /// <summary>
    /// <para>Hash table is a array-based data structure, which by provided 
    /// key value generates a hash-code and then places both the key and value 
    /// data in the array according to generated hash-code.</para>
    /// </summary>
    public abstract class HashTable
    {
        public readonly int _capacity;
        private readonly Random randomDividend;
        private readonly Random randomDiviser;
        private const int MaxDivider = 255; // ascii cirillic я
        private const int MinDivider = 32; // ascii space
        public int NumberOfTriesInSearch { get; protected set; }
        protected HashTable(int capacity) 
        { 
            _capacity = capacity; 
            randomDividend = new Random();
            randomDiviser = new Random();
        }
        public abstract void Add(string key, object data);

        public abstract object Find(string key);

        /// <summary>
        /// This method generates a hash-code by multiplying each character of pased as
        /// a parameter <param name="key"></param> string to a certain constants
        /// and than gets sum of the products. 
        /// </summary>
        /// <returns>Integer - a unique hash-code for unique passed string</returns>
        protected int GenerateHashCode(string key)
        {
            int hashCode = 0;
            foreach (char symbol in key)
            {
                hashCode += Equaision(symbol);
            }
            return hashCode % _capacity;
        }

        /// <summary>
        /// This method generates a hash-code of a parameter <param name="key"></param> 
        /// </summary>
        /// <returns>Integer - a unique hash-code for unique passed character</returns>
        protected int GenerateHashCode(char key)
        {
            int hashCode = Equaision(key);
            return hashCode % _capacity;
        }

        private int Equaision(char x) => x * Convert.ToInt32(
                (double)randomDividend.Next(0, _capacity)
                / randomDiviser.Next(MinDivider, MaxDivider)
            );
    }
}