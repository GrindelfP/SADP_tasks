namespace taskThree;

public class Operator
{
    public char Symbol { get; }
    public byte Priority { get; }
    public BinaryOperation? Operation { get; }

    public Operator(char symbol, byte priority, BinaryOperation? operation)
    {
        Symbol = symbol;
        Priority = priority;
        Operation = operation;
    }
    
    public Operator(char symbol, byte priority)
    {
        Symbol = symbol;
        Priority = priority;
        Operation = null;
    }

    public bool HasHigherPriorityThan(char @operator)
    {
        return Priority > Operators.GetOperatorPriority(@operator);
    }
}

public delegate double BinaryOperation(double a, double b);