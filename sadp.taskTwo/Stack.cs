namespace sadp.taskTwo;

public class Stack<T>
{
    // fields
    private readonly T[] _stack;
    private readonly int _size;
    private int _maxIndex;
    
    // properties
    public int Size { get; private set; }
    public int MaxIndex => _maxIndex;
    
    // constructors
    public Stack(int size)
    // constructor with parameter of stack's size
    {
        _size = size;
        _stack = new T[size];
    }

    public Stack(T[] stack)
    // constructor with parameter of stack containment as a array of type T
    {
        _stack = stack;
        _size = stack.Length;
    }

    public Stack()
    // default constructor
    {
        _size = 0;
        _stack = new T[_size];
    }
    
    // main methods
    public bool Push(T element)
    // adds element to stack, returns true if element was added, false - if not
    {
        try
        {
            _maxIndex++;
            _stack[_maxIndex] = element;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public T Pop()
    // removes element form stack and returns it
    {
        _maxIndex--;
        return _stack[_maxIndex];
    }

    public bool IsEmpty()
    // returns true if stack is empty, false - if not
    {
        return _maxIndex == 0;
    }
    
    // additional methods
    public void SetStackSize(int value)
    // sets stack size (if user wants to set size lesser than stack containment returns Exception
    {
        if (value >= _size)
        {
            Size = value;
        }
        else
        {
            throw new Exception("Cannot make stack smaller than its containment!");
        }
    }

    public void ConsolePrint()
    // prints elements of stack split by ',' in console
    {
        foreach (var element in _stack)
        {
            Console.Write(element + ", ");
        }
    }

    public override string ToString()
    // overrides ToString method for stack
    {
        var strOfElements = _stack.Aggregate("[", (current, element) => current + (element + ", "));
        strOfElements += "]";
        
        return strOfElements;
    }

    public bool Equals(object[] array)
    // returns true if stack's elements equal to given array's elements, false - if not, false if stack is empty
    {
        if (_maxIndex == 0) return false;
        for (var i = 0; i < _size; i++)
        {
            if (!_stack[i]!.Equals(array[i])) return false;
        }
        return true;
    }

    public override int GetHashCode()
    // returns stack's hash code 
    {
        return _stack.GetHashCode();
    }
    
}

public delegate T ForEachFunction<T> (T parameter);
