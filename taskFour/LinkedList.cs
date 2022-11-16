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
            Element<Movie> newElement = new Element<Movie>(data);
            if (_startingElement == null)
            {
                _startingElement = newElement;
                return;
            }
            Element<Movie> currentPointer = _startingElement;
            while (currentPointer.Next != null) currentPointer = currentPointer.Next;
            currentPointer.Next = newElement;
        }

        public void AddToBeggining(Movie data)
        {
            if (_startingElement == null)
            {
                Element<Movie> newElement = new Element<Movie>(data);
                _startingElement = newElement;
                return;
            }
            Element<Movie> newElementWithNext = new Element<Movie>(data, _startingElement);
            _startingElement = newElementWithNext;
        }

        public void SortedAdd(Movie data)
        {
            Element<Movie> newElement = new Element<Movie>(data);
            if (_startingElement == null)
            {
                _startingElement = newElement;
                return;
            }
            Element<Movie> currentPointer = _startingElement;
            Element<Movie> previousPointer = _startingElement;
            while (currentPointer != null)
            {
                if (currentPointer.Data.Duration < newElement.Data.Duration) 
                {
                    previousPointer = currentPointer;
                    currentPointer = currentPointer.Next;
                } 
                else
                {
                    Element<Movie> tmp = currentPointer.Next;
                    currentPointer.Next = newElement;
                    currentPointer.Next.Next = tmp;
                    (currentPointer.Data, currentPointer.Next.Data) = (currentPointer.Next.Data, currentPointer.Data);
                    return;

                }
            }
            previousPointer.Next = newElement; // append
        }

        public Movie? Find(string key)
        {
            Element<Movie> currentPointer = _startingElement;
            while (currentPointer != null)
            {
                if (currentPointer.Data.HasEqualKeyTo(key)) return currentPointer.Data;
                currentPointer = currentPointer.Next;
            }
            return null;
        }

        public void Remove(string key)
        {
            if (_startingElement == null) return;
            Element<Movie> currentPointer = _startingElement;
            if (currentPointer.Data.HasEqualKeyTo(key)) // for the first
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
                currentPointer = currentPointer.Next;
            }
        }

        public List<Movie> Show()
        {
            List<Movie> elements = new List<Movie>();
            Element<Movie> currentPointer = _startingElement;
            while (currentPointer != null)
            {
                elements.Add(currentPointer.Data);
                currentPointer = currentPointer.Next;
            }
            return elements;
        }
    }
}