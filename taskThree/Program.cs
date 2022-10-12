namespace taskThree;

public static class Program
{
    private static void Main()
    {
        Console.WriteLine(Convert.ToInt32("3"));
        Console.Write("Expression: ");
        var userInput = Console.ReadLine();
        
        Console.WriteLine("\nTranslation to RPN\n");
        var rpnCalculation = new RpnCalculation(userInput);
        Console.WriteLine("RPN expression: " + rpnCalculation.RpnExpression);
        
        Console.WriteLine("Calculation of expression\n");
        Console.WriteLine("Result: " + rpnCalculation.Calculator());
    }
}

