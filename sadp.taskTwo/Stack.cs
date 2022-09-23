namespace sadp.taskTwo;

public class Stack<T>
{
    public Stack(int size)
    {
        _size = size;
        _stack = new T[size];
    }
    public Stack()
    {
        _size = 0;
        _stack = new T[_size];
    }
    
    private readonly T[] _stack;
    private readonly int _size;
    private int _maxIndex;
    
    public int Size { get; private set; }
    public int MaxIndex => _maxIndex;
    
    public bool Push(T element)
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
    {
        _maxIndex--;
        var excludedElement = _stack[_maxIndex];
        _stack[_maxIndex] = default!;
        return excludedElement;
    }

    public bool IsEmpty()
    {
        return _maxIndex != 0;
    }

    public void SetStackSize(int value)
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
}