namespace Chat.Client_Console { public static class CLI
{
    private static ConsoleColor info = ConsoleColor.Blue;
    private static ConsoleColor success = ConsoleColor.Green;
    private static ConsoleColor error = ConsoleColor.Red;
    
    private static void Print(string message, ConsoleColor color, Action<string> action)
    {
        Console.ForegroundColor = color;
        action.Invoke(message);
        Console.ResetColor();
    }

    public static string? Input(string message)
    {
        Print(message, info, Console.Write);
        return Console.ReadLine();
    }

    public static void PrintInfo(string message)
    {
        Print(message, info, Console.WriteLine);
    }
}
}

