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
            if (_startingElement == null) AddToBeggining(data);
            var newElement = new Element<Movie>(data);
            var currentPointer = _startingElement;
            while (currentPointer.Next != null) currentPointer = currentPointer.Next;
            currentPointer.Next = newElement;
        }

        public void AddToBeggining(Movie data)
        {
            if (_startingElement == null)
            {
                var link = new Element<Movie>(data);
                _startingElement = link;
            }
            else
            {
                var link = new Element<Movie>(data, _startingElement);
                _startingElement = link;
            }
        }

        public void AddToSorted(Movie data)
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
                if (newElement.Data.Duration < currentPointer.Data.Duration)
                {
                    currentPointer = currentPointer.Next;
                    continue;
                }
                var temp = currentPointer.Next;
                currentPointer.Next = newElement;
                newElement.Next = temp;
                return;
            }
            Add(data);
            return;
        }

        public bool Find(string key)
        {
            if (key == null) throw new Exception("Tried to compare null and not null"); // IS THIS A PROBLEM??
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
            if (!Find(key) || _startingElement == null) throw new Exception("No such element in a LinkedList instance!");
            var currentPointer = _startingElement;
            while (currentPointer.Next != null)
            {
                if (currentPointer.Next.Data.HasEqualKeyTo(key))
                {
                    currentPointer.Next = currentPointer.Next.Next;
                }
            }
        }

        public List<Movie> Show()
        {
            var elements = new List<Movie>();
            var currentPointer = _startingElement;
            while (currentPointer.Next != null)
            {
                elements.Add(currentPointer.Data);
            }

            return elements;
        }

        /*private void RunByList(Action<Movie> action)
        {
            var currentPointer = _startingElement;
            while (currentPointer.Next != null)
            {
                action(currentPointer);
                currentPointer = currentPointer.Next;
            }
        }

        private delegate void Action<Movie>(LinkedList.Element<Movie> parameter);*/
    }
}