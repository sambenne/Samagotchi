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

        public static void WarnMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
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

        public static void PlayNote(Tone tone, Duration duration)
        {
            Console.Beep((int)tone, (int)duration);
        }

        private const int PartWidth = 14;

        public static void WriteLineTabbed(string partOne, string partTwo)
        {
            var tabsLength = PartWidth - partOne.Length;
            var tabs = new string(' ', tabsLength);
            Console.WriteLine($"{partOne}{tabs}{partTwo}");
        }

        public static string WriteLineTabbedIn(string partOne, string partTwo)
        {
            var tabsLength = PartWidth - partOne.Length;
            var tabs = new string(' ', tabsLength - 1);
            return $"  {partOne}{tabs}{partTwo}";
        }
    }

    public enum Tone
    {
        Rest = 0,
        GbelowC = 196,
        A = 220,
        Asharp = 233,
        B = 247,
        C = 262,
        Csharp = 277,
        D = 294,
        Dsharp = 311,
        E = 330,
        F = 349,
        Fsharp = 370,
        G = 392,
        Gsharp = 415,
    }

    public enum Duration
    {
        Whole = 1600,
        Half = Whole / 2,
        Quarter = Half / 2,
        Eighth = Quarter / 2,
        Sixteenth = Eighth / 2,
    }
}
