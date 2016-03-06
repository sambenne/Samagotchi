using System;
using Samagotchi.App.Helpers;

namespace Samagotchi.App
{
    public class Base
    {
        private static Commands _commands;
        private static EventManager _eventManager;
        private static bool _quit;

        public static void Main(string[] args)
        {
            Console.Title = "Samagotchi";

            _eventManager = new EventManager();
            _commands = new Commands();
            _commands.RegisterCommands(_eventManager);
            _eventManager.StartTimer();
            StartUpMessage();

            Console.CancelKeyPress += Console_CancelKeyPress;
            MainLoop();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs eventArgs)
        {
            Console.WriteLine("{0} hit, quitting...", eventArgs.SpecialKey);
            _quit = true;
            eventArgs.Cancel = true;
        }

        private static void MainLoop()
        {
            string line;
            var commandParser = new CommandParser(_commands);

            while (!string.IsNullOrEmpty(line = Console.ReadLine()) && !_quit)
            {
                commandParser.Dispose();
                if (_quit) continue;

                HandleInput(commandParser, line);
            }
        }

        private static void HandleInput(CommandParser commandParser, string line)
        {
            try
            {
                var command = commandParser.From(line);

                if (command.Action.CanRun())
                    command.Action.Do(command.Args);
                else
                    ConsoleHelpers.ErrorMessage("Command invalid!");
            }
            catch (Exception exception)
            {
                ConsoleHelpers.ErrorMessage(exception.Message);
            }
        }

        private static void StartUpMessage()
        {
            string[] lines =
            {
                @"   _____ ___    __  ______   __________  ______________  ______",
                @"  / ___//   |  /  |/  /   | / ____/ __ \/_  __/ ____/ / / /  _/",
                @"  \__ \/ /| | / /|_/ / /| |/ / __/ / / / / / / /   / /_/ // /  ",
                @" ___/ / ___ |/ /  / / ___ / /_/ / /_/ / / / / /___/ __  // /   ",
                @"/____/_/  |_/_/  /_/_/  |_\____/\____/ /_/  \____/_/ /_/___/   ",
                @"                                                               ",
                @"                           (c).-.(c)                           ",
                @"                            / ._. \                            ",
                @"                          __\( Y )/__                          ",
                @"                         (_.-/'-'\-._)                         ",
                @"                            ||   ||                            ",
                @"                          _.' `-' '._                          ",
                @"                         (.-./`-`\.-.)                         ",
                @"                          `-'     `-'                          "
            };
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
