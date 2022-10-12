using taskTwo;

namespace taskThree;

public class RpnCalculation
{
    private Expression InputExpression { get; }
    public string RpnExpression { get; }

    public RpnCalculation(string? inputExpression)
    {
        InputExpression = new Expression(inputExpression);
        if (InputExpression.Text == null) throw new Exception("Your input is invalid or empty!");
        RpnExpression = TranslateToRpn();
    }

    private string TranslateToRpn()
    {
        var rpnExpression = "";
        var inputLine = InputExpression.Text!;
        var inputLength = inputLine.Length;
        var stack = new NewStack<char>(inputLength);
        for (var i = 0; i < inputLength; i++)
        {
            Console.Write($"{i + 1}) Stack of operators now is: {stack} ");
            Console.WriteLine($"'{inputLine[i]}' checking...\n");
            switch (inputLine[i])
            {
                case '(':
                    stack.Push(inputLine[i]);
                    continue;
                case ')':
                {
                    while (true)
                    {
                        if (stack.Top() == '(')
                        {
                            stack.Pop(); 
                            break;
                        }
                        rpnExpression += stack.Pop();
                    }
                    continue;
                }
            }

            if (!Operators.IsOperator(inputLine[i]))
            {
                rpnExpression += inputLine[i];
            }
            else // here we come only if the symbol is an operator (not an operand or brackets)
            {
                var currentOperator = new Operator(inputLine[i],
                    Operators.GetOperatorPriority(inputLine[i]),
                    Operators.GetOperation(inputLine[i]));
                while (true)
                {
                    if (stack.IsEmpty())
                    {
                        stack.Push(currentOperator.Symbol);
                        break;
                    }
                    if (!currentOperator.HasHigherPriorityThan(stack.Top()))
                    {
                        rpnExpression += stack.Pop();
                        continue;
                    }
                    if (currentOperator.HasHigherPriorityThan(stack.Top()))
                    {
                        stack.Push(currentOperator.Symbol);
                        break;
                    }
                }
            }
        }

        while (!stack.IsEmpty())
        {
            rpnExpression += stack.Pop();
        }

        return rpnExpression;
    }

    public double Calculator()
    {
        var expressionLength = RpnExpression.Length;
        var stack = new NewStack<double>(expressionLength);
        for (var i = 0; i < expressionLength; i++)
        {
            Console.Write($"{i + 1}) Stack of operands now is: {stack} ");
            Console.WriteLine($"'{RpnExpression[i]}' checking...\n");
            if (!Operators.IsOperator(RpnExpression[i]))
            {
                var operand = Convert.ToInt32(RpnExpression[i].ToString()); //ConvertCharToDouble(RpnExpression[i]);
                stack.Push(operand);
            }
            else
            {
                Console.WriteLine($"Completing {RpnExpression[i]}...\n");
                var secondOperand = stack.Pop();
                var firstOperand = stack.Pop();
                var operation = Operators.GetOperation(RpnExpression[i]);
                stack.Push(operation!(firstOperand, secondOperand));
            }
        }
        
        return stack.Pop();
    }
}