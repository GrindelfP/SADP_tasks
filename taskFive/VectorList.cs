using System.Collections.Generic;
using System.Windows.Forms;

namespace taskFive
{
    public class VectorList
    {
        private readonly Movie[] _vector;
        public int Size { get; private set; }
        public int Count { get; private set; }

        public VectorList(int size)
        {
            Size = size;
            _vector = new Movie[size];
            Count = 0;
        }

        public bool AddToBeggining(Movie data)
        {
            if (Count >= Size) return false;
            if (Count == 0)
            {
                _vector[Count] = data;
                Count++;
                return true;
            }
            for (int i = Count; i >= 0; i--)
            {
                _vector[i + 1] = _vector[i];
            }
            _vector[0] = data;
            Count++;
            return true;
        }

        public bool Append(Movie data)
        {
            if (Count >= Size) return false;
            _vector[Count] = data;
            Count++;
            return true;
        }

        public bool SortedAdd(Movie data)
        {
            if (Count >= Size) return false;
            if (Count == 0)
            {
                _vector[Count] = data;
                Count++;
                return true;
            }
            int indexOfBreak = 0;
            for (int i = 0; i <= Count; i++)
            {
                if (_vector[i] == null || _vector[i].Duration > data.Duration)
                {
                    indexOfBreak = i;
                    break;
                }
            }

            for (int i = Count; i >= indexOfBreak; i--)
            {
                _vector[i] = _vector[i - 1];
            }
            _vector[indexOfBreak] = data;
            Count++;
            return true;
        }

        public Movie Find(string key)
        {
            if (Count == 0) return null;
            foreach (Movie item in _vector)
            {
                if (item.Name == key) return item;
            }
            return null;
        }

        public bool Remove(string key)
        {
            if (Count == 0) return false;
            int indexOfBreak = 0;
            for (int i = 0; i < Count; i++)
            {
                if (_vector[i].Name == key)
                {
                    indexOfBreak = i;
                    break;
                }
            }
            for (int i = indexOfBreak; i < Count; i++)
            {
                if (i == Count - 1) _vector[i] = null;
                else _vector[i] = _vector[i + 1];
            }
            Count--;
            return true;
        }

        public void Show(ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (Movie item in _vector)
            {
                if (item != null) listBox.Items.Add(item);
            }
        }
    }
}