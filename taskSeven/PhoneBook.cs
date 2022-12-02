using System;
using System.IO;

namespace taskSeven
{
    internal class PhoneBook
    {
        private const string PATH_PHONE_BOOK_FILE = 
            @"C:\Users\kampa\OneDrive\Документы\MEGA\programming
            \c#\SADP_tasks\taskSeven\PhoneBookFiles\ASTRA.txt";
        private readonly HashTable _hashTable;

        public PhoneBook(bool isTupleTable)
        {
            string[] contacts = File.ReadAllLines(PATH_PHONE_BOOK_FILE);
            if (isTupleTable) _hashTable = new HashTableTuple(contacts.Length);
            else _hashTable = new HashTableArray(contacts.Length);
            FillHashTable(contacts);
        }

        public Tuple<string, int> GetContact(string key)
        {
            string contact = _hashTable.Find(key).ToString();
            int numberOfTries = _hashTable.NumberOfTriesInSearch;
            return Tuple.Create(contact, numberOfTries);
        }

        private void FillHashTable(string[] contacts)
        {
            foreach (string contact in contacts)
            {
                string key = GetKey(contact);
                string value = contact.Substring(key.Length);
                _hashTable.Add(key, value);
            }
        }

        private string GetKey(string contact)
        {
            // TODO: find out how file is working and implement method
            throw new NotImplementedException();
        }
    }
}
