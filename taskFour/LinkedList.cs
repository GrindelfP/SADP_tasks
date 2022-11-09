using System;
using System.Collections.Generic;

namespace taskFour
{
    public partial class LinkedList
    {
        private Element<Movie> _startingElement;

        public LinkedList()
        {
            _startingElement = null;
        }

        public void Add(Movie data)
        {
            var newElement = new Element<Movie>(data);
            if (_startingElement == null)
            {
                _startingElement = newElement;
                return;
            }
            var currentPointer = _startingElement;
            while (currentPointer.Next != null) currentPointer = currentPointer.Next;
            currentPointer.Next = newElement;
        }

        public void AddToBeggining(Movie data)
        {
            if (_startingElement == null)
            {
                var newElement = new Element<Movie>(data);
                _startingElement = newElement;
                return;
            }
            var newElementWithNext = new Element<Movie>(data, _startingElement);
            _startingElement = newElementWithNext;
        }

        public void SortedAdd(Movie data)
        {
            if (_startingElement == null)
            {
                AddToBeggining(data);
                return;
            }
            var newElement = new Element<Movie>(data);
            var currentPointer = _startingElement;

            while (currentPointer.Next != null)
            {
                if (currentPointer.Data.Duration < newElement.Data.Duration)
                {
                    currentPointer = currentPointer.Next;
                    continue;
                }
                var temp = currentPointer.Next;
                currentPointer.Next = newElement;
                newElement.Next = temp;

                (currentPointer.Next.Data, currentPointer.Data) = (currentPointer.Data, currentPointer.Next.Data);
                return;
            }
            currentPointer = newElement;
            return;
        }

        public bool Find(string key)
        {
            var found = false;
            var currentPointer = _startingElement;
            while (currentPointer.Next != null)
            {
                if (currentPointer.Data.HasEqualKeyTo(key))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public void Remove(string key)
        {
            if (_startingElement == null) return;
            var currentPointer = _startingElement;
            if (currentPointer.Data.HasEqualKeyTo(key))
            {
                _startingElement = currentPointer.Next;
                return;
            }
            while (currentPointer.Next != null)
            {
                if (currentPointer.Next.Data.HasEqualKeyTo(key))
                {
                    currentPointer.Next = currentPointer.Next.Next;
                    return;
                }
                currentPointer.Next = currentPointer;
            }
        }

        public List<Movie> Show()
        {
            var elements = new List<Movie>();
            if (_startingElement.Next == null) 
            {
                elements.Add(_startingElement.Data);
                return elements;
            } 
            var currentPointer = _startingElement;
            while (currentPointer.Next != null)
            {
                elements.Add(currentPointer.Data);
                currentPointer = currentPointer.Next;
            }
            elements.Add(currentPointer.Data); // for the last one

            return elements;
        }
    }
}