using System;
using System.Threading;

namespace Lottery
{
    public static class ConsoleHelper
    {
        public static void WriteLineColerful(object text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void WriteColerful(object text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void WriteInTypingStyle(object text, int typingSpeedMilliseconds, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Thread.Sleep(typingSpeedMilliseconds);
        }
        public static void WriteLineInTypingStyle(object text, int typingSpeedMilliseconds, ConsoleColor color = ConsoleColor.Gray)
        {
            foreach (char letter in (string)text)
            {
                Console.ForegroundColor = color;
                Console.Write(letter);
                Thread.Sleep(typingSpeedMilliseconds);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
