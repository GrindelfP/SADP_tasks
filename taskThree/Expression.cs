namespace taskThree;

public class Expression
{
    private string? _expression;

    public string? Text => _expression;

    public Expression(string? expression)
    {
        _expression = IsValidExpression(expression) ? expression : null;
    }
    
    private bool IsValidExpression(string? expression)
    {
        return expression is {Length: >= 3} && ExpressionHasAnOperator(expression);
    }

    private bool ExpressionHasAnOperator(string expression)
    {
        return expression.Any(Operators.IsOperator);
    }
}