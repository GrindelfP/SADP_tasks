namespace taskThree;

public class Operator
{
    private char _symbol;
    private byte _priority;
    private BinaryOperation? _operation;
    
    public char Symbol => _symbol;
    public byte Priority => _priority;
    public BinaryOperation? Operation => _operation;

    public Operator(char symbol, byte priority, BinaryOperation operation)
    {
        _symbol = symbol;
        _priority = priority;
        _operation = operation;
    }
    public Operator(char symbol, byte priority)
    {
        _symbol = symbol;
        _priority = priority;
        _operation = null;
    }

    public bool IsHigherPriority(Operator @operator)
    {
        return _priority > @operator.Priority;
    }

    public double CompleteOperation(int a, int b)
    {
        return _operation(a, b);
    }

    public bool HasHigherPriorityThan(char @operator)
    {
        return _priority > OperatorsUtil.GetOperatorPriority(@operator);
    }
}

public delegate double BinaryOperation(double a, double b);