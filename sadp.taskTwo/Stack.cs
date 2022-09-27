namespace sadp.taskTwo;

public class Stack<T>
{
    // fields
    private readonly T[] _stack;
    private int _size;
    private int _maxIndex;
    
    // properties
    public int Size
    {
        get => _size;
        set => _size = value;
    }
    
    // constructors
    public Stack(int size)
    // constructor with parameter of stack's size
    {
        _size = size;
        _stack = new T[size];
        _maxIndex = -1;
    }

    public Stack(T[] stack)
    // constructor with parameter of stack containment as a array of type T
    {
        _size = stack.Length;
        _stack = stack;
        _maxIndex = _size - 1;
    }

    public Stack()
    // default constructor
    {
        _size = 0;
        _stack = new T[_size];
        _maxIndex = -1;
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

    public void ForEach(ForEachFunction<T> forEachFunction)
    // completes lambda-expression for each not-null element of stack
    {
        for (var i = 0; i < _size; i++)
        {
            if (_stack[i] is not null) forEachFunction(_stack[i]);
        }
    }

    public Stack<T> Map(MapFunction<T> forEachFunction)
    {
        var updatedStack = new Stack<T>(_size);
        ForEach(element =>
        {
            updatedStack.Push(forEachFunction(element));
        });
        
        return updatedStack;
    }

    public Stack<T> Filter(FilterFunction<T> condition)
    {
        var filteredStack = new Stack<T>(_size);
        ForEach(element =>
        {
            if (condition(element)) filteredStack.Push(element);
        });
        
        return filteredStack;
    }

    public override string ToString()
    // overrides ToString method for stack
    {
        var strOfElements = "[";
        for (var i = 0; i < _size - 1; i++)
        {
            if (_stack[i] is not null) strOfElements += _stack[i] + ", ";
            else strOfElements += "null, ";
        }
        strOfElements += _stack[_size - 1] is not null ? _stack[_size - 1] + "]" : "null]";
        
        return strOfElements;
    }

    public override int GetHashCode()
    // returns stack's hash code 
    {
        return _stack.GetHashCode();
    }
    
}

public delegate void ForEachFunction<in T> (T parameter);

public delegate T MapFunction<T>(T parameter);

public delegate bool FilterFunction<in T>(T parameter);
