namespace taskTwo;

public class NewStack<T>
{
    // fields
    private readonly T?[] _stack;

    // properties
    public int Size { get; private set; }
    public int MaxIndex { get; private set; }
    

    // constructors
    public NewStack(int size)
        // constructor with parameter of stack's size
    {
        if (size < 0) throw new Exception("Size cannot be negative!");
        Size = size;
        _stack = new T?[size];
        MaxIndex = 0;
    }

    public NewStack(T?[] stack)
        // constructor with parameter of stack containment as a array of type T
    {
        Size = stack.Length;
        _stack = stack;
        MaxIndex = Size;
    }

    public NewStack()
        // default constructor
    {
        Size = 0;
        _stack = new T?[Size];
        MaxIndex = 0;
    }

    // main methods
    public bool Push(T? element)
        // adds element to stack, returns true if element was added, false - if not
    {
        if (MaxIndex > Size) return false;
        _stack[MaxIndex] = element;
        MaxIndex++;
        return true;
    }

    public T? Pop()
        // removes element form stack and returns it
    {
        return IsEmpty() ? default : _stack[--MaxIndex];
    }

    public bool IsEmpty()
        // returns true if stack is empty, false - if not
    {
        return MaxIndex == 0;
    }

    // additional methods
    public void SetStackSize(int value)
        // sets stack size (if user wants to set size lesser than stack containment returns Exception
    {
        if (value >= Size)
        {
            Size = value;
        }
        else
        {
            throw new Exception("Cannot make stack smaller than its containment!");
        }
    }

    public T? Top()
        // returns last element of stack
    {
        return IsEmpty() ? default : _stack[MaxIndex - 1];
    }

    public void ForEach(ForEachFunction<T> forEachFunction)
        // completes lambda-expression for each not-null element of stack
    {
        for (var i = 0; i < Size; i++)
        {
            forEachFunction(_stack[i]);
        }
    }

    public Stack<T> Map(MapFunction<T> mapFunction)
        // returns new stack of the same size containing result of some given in parameter function on elements of initial stack  
    {
        var updatedStack = new Stack<T>(Size);
        ForEach(element => { updatedStack.Push(mapFunction(element)); });

        return updatedStack;
    }

    public Stack<T> Filter(Condition<T> condition)
        // returns new stack of the same size containing elements of initial stack fitting the condition given in parameter 
    {
        var filteredStack = new Stack<T>(Size);
        ForEach(element =>
        {
            if (condition(element)) filteredStack.Push(element);
        });

        return filteredStack;
    }

    public override string ToString()
        // overrides ToString method for stack
    {
        if (IsEmpty()) return "[]";
        var strOfElements = "[";
        for (var i = 0; i < Size - 1; i++)
        {
            if (_stack[i] != null) strOfElements += _stack[i] + ", ";
            else strOfElements += "null, ";
        }

        strOfElements += _stack[Size - 1] != null ? _stack[Size - 1] + "]" : "null]";

        return strOfElements;
    }

    public override int GetHashCode()
        // returns stack's hash code 
    {
        return _stack.GetHashCode();
    }
}

public delegate void ForEachFunction<in T>(T parameter);

public delegate T MapFunction<T>(T parameter);

public delegate bool Condition<in T>(T parameter);