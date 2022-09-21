namespace sadp.taskTwo;

public class Stack<T>
{
    private readonly T[] _stack;
    private readonly int _stackSize;
    private int _numberOfElements;
    
    public int StackSize => _stackSize;
    public int NumberOfElements => _numberOfElements;
    
    public bool Push(T element)
    {
        try
        {
            _numberOfElements++;
            _stack[_numberOfElements] = element;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public T Pop()
    {
        var excludedElement = _stack[_numberOfElements];
        _stack[_numberOfElements] = default!;
        _numberOfElements--;
        return excludedElement;
    }

    public bool IsEmpty()
    {
        return _numberOfElements != 0;
    }
    
    public Stack(int stackSize)
    {
        _stackSize = stackSize;
        _stack = new T[stackSize];
    }
}