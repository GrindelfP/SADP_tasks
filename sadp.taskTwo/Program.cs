namespace sadp.taskTwo;

public static class Program
{
    private static void Main()
    {
        
        var s = new Stack<int>(14);
        for (int i = 0; i < 3; i++)
        {
            s.Push(i);
        }
        Print(s.StackSize);
        Print(s.NumberOfElements);
        Print(s.IsEmpty());
        var l = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            l.Add(s.Pop());
        }
        Print(s.StackSize);
        Print(s.NumberOfElements);
        Print(s.IsEmpty());
    }

    private static void Print(object? obj)
    {
        Console.WriteLine(obj);
    }
}

