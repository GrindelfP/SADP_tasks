namespace taskFour
{
    public partial class LinkedList
    {
        private class Element<T>
        {
            public T Data { get; set; }
            public Element<T> Next { get; set; }

            internal Element(T data)
            {
                Data = data;
                Next = null;
            }

            internal Element(T data, Element<T> next)
            {
                Data = data;
                Next = next;
            }
        }
    }
}
