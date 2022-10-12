namespace taskThree;

public static class Program
{
    private static void Main()
    {
        Console.Write("Expression: ");
        var userInput = Console.ReadLine();
        Console.WriteLine("\nTranslation to RPN\n");
        var rpnCalculation = new RpnCalculation(userInput);
        var rpnExpr = rpnCalculation.RpnExpression;
        Console.WriteLine(rpnExpr);
        Console.WriteLine(rpnCalculation.Calculator(rpnExpr));
    }
}

