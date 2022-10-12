using taskTwo;

namespace taskThree;

public class RpnCalculation
{
    private readonly string _rpnExpression;

    public string RpnExpression => _rpnExpression;

    public RpnCalculation(string inputLine)
    {
        if (inputLine is null) throw new Exception("Expression was not entered!");
        _rpnExpression = TranslateToRpn(inputLine);
    }

    public string TranslateToRpn(string inputLine)
    {
        var rpnExpression = "";
        var inputLength = inputLine.Length;
        var stack = new NewStack<char>(inputLength);
        for (var i = 0; i < inputLength; i++)
        {
            Console.Write($"{i}) Stack of operators now is: {stack} ");
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

            if (!OperatorsUtil.IsOperator(inputLine[i]))
            {
                rpnExpression += inputLine[i];
            }
            else // here we come only if the symbol is an operator (not an operand or brackets)
            {
                var currentOperator = new Operator(inputLine[i],
                    OperatorsUtil.GetOperatorPriority(inputLine[i]),
                    OperatorsUtil.GetOperation(inputLine[i]));
                while (true)
                {
                    if (stack.IsEmpty())
                    {
                        stack.Push(currentOperator.Symbol);
                        break;
                    }
                    else
                    {
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
        }


        while (!stack.IsEmpty())
        {
            rpnExpression += stack.Pop();
        }

        return rpnExpression;
    }

    public double Calculator(string rpnExpression)
    {
        var expressionLength = rpnExpression.Length;
        var stack = new NewStack<double>(expressionLength);
        for (var i = 0; i < expressionLength; i++)
        {
            if (!OperatorsUtil.IsOperator(rpnExpression[i]))
            {
                var operand = ConvertCharToDouble(rpnExpression[i]);
                stack.Push(operand);
            }
            else
            {
                var secondOperand = stack.Pop();
                var firstOperand = stack.Pop();
                var operation = OperatorsUtil.GetOperation(rpnExpression[i]);
                stack.Push(operation!(firstOperand, secondOperand));
            }
        }
        
        return stack.Pop();
    }

    private static double ConvertCharToDouble(char @char)
    {
        return @char switch
        {
            '0' => 0.0,
            '1' => 1.0,
            '2' => 2.0,
            '3' => 3.0,
            '4' => 4.0,
            '5' => 5.0,
            '6' => 6.0,
            '7' => 7.0,
            '8' => 8.0,
            _ => 9.0
        };
    }
    
}