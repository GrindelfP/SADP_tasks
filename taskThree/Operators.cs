namespace taskThree;

public static class Operators
{
    private static readonly Operator[] AvailableOperators =
    {
        new('(', 0),
        new(')', 1),
        new('+', 2, (a, b) => a + b),
        new('-', 2, (a, b) => a - b),
        new('*', 3, (a, b) => a * b),
        new('/', 3, (a, b) =>
        {
            if (b == 0) throw new Exception("Division by zero!");
            return a / b;
        }),
        new('^', 4, Math.Pow)
    };

    public static bool IsOperator(char symbol)
    {
        return AvailableOperators.Any(@operator => symbol == @operator.Symbol);
    }

    public static byte GetOperatorPriority(char symbol)
    {
        foreach (var @operator in AvailableOperators)
        {
            if (symbol == @operator.Symbol) return @operator.Priority;
        }

        throw new Exception("Operator not available!");
    }

    public static BinaryOperation? GetOperation(char symbol)
    {
        foreach (var @operator in AvailableOperators)
        {
            if (symbol == @operator.Symbol) return @operator.Operation;
        }

        throw new Exception("Operator doesn't have an available operation!");
    }
}