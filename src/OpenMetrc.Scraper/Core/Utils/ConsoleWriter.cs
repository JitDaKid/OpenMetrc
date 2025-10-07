using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMetrc.Scraper.Core.Utils;
internal class ConsoleWriter
{
    public static void Write(string message)
    {
        WriteWithColor($"Error: {message}", ConsoleColor.Red);
    }

    public static void WriteLine(string message)
    {
        WriteLineWithColor($"Error: {message}", ConsoleColor.Red);
    }

    public static void WriteLines(params string[] messages)
    {
        if (messages == null || messages.Length == 0)
            return;

        Console.ForegroundColor = ConsoleColor.Red;

        if (messages.Length == 1)
        {
            Console.WriteLine($"\nError: {messages[0]}");
        }
        else
        {
            Console.WriteLine("\nError:");
            foreach (var message in messages)
            {
                Console.WriteLine($"  {message}");
            }
        }

        Console.ResetColor();
    }

    public static void WriteBlockError(string title, params string[] messages)
    {
        WriteBlock(title, ConsoleColor.Red, messages);
    }

    public static void WriteBlock(string title, ConsoleColor? color, params string[] messages)
    {
        Console.ForegroundColor = color ?? ConsoleColor.Red;

        Console.WriteLine($"\n╔{"".PadRight(70, '═')}╗");
        Console.WriteLine($"║ {title.PadRight(68)} ║");
        Console.WriteLine($"╠{"".PadRight(70, '═')}╣");

        foreach (var message in messages)
        {
            Console.WriteLine($"║ {message.PadRight(68)} ║");
        }

        Console.WriteLine($"╚{"".PadRight(70, '═')}╝");
        Console.ResetColor();
    }

    private static void WriteWithColor(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }

    private static void WriteLineWithColor(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
