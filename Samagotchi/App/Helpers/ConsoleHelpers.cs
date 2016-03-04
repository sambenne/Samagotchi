using System;

namespace Samagotchi.App.Helpers
{
    public class ConsoleHelpers
    {
        public const string Arrow = " > ";

        public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(Arrow + message);
            Console.ResetColor();
        }

        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(Arrow + message);
            Console.ResetColor();
        }

        public static string GetResponse(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
