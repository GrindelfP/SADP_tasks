using System.Collections.Generic;

namespace taskFour
{
    public partial class LinkedList
    {
        private Element<Movie> _startingElement; // start point of the list

        public LinkedList() // default constructor
        {
            _startingElement = null;
        }

        public void Append(Movie data) // adds element to the end
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

        public void AddToBeggining(Movie data) // adds element to the beggining
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

        public void SortedAdd(Movie data) // adds element to a sorted list without disturbing it's order
        {
            Element<Movie> newElement = new Element<Movie>(data);
            if (_startingElement == null) // if is empty
            {
                _startingElement = newElement; // adds to begginig
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
                else // adds in the middle
                {
                    newElement.Next = currentPointer.Next;
                    (currentPointer.Data, newElement.Data) = (newElement.Data, currentPointer.Data);
                    currentPointer.Next = newElement;
                    return;

                }
            }
            previousPointer.Next = newElement; // appends
        }

        public Movie? Find(string key) // finds and returns occurences simmilar to the key
        {
            Element<Movie> currentPointer = _startingElement;
            while (currentPointer != null)
            {
                if (currentPointer.Data.HasEqualKeyTo(key)) return currentPointer.Data;
                currentPointer = currentPointer.Next;
            }
            return null;
        }

        public void Remove(string key) // removes an occurance simmilar to the key
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

        public List<Movie> Show() // shows current state of the list
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