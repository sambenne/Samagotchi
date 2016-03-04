using System;
using Samagotchi.App.Commands;
using Samagotchi.App.Helpers;
using Samagotchi.App.Models;

namespace Samagotchi.App
{
    public class Base
    {
        private static Helpers.Commands _commands;

        public static void Main(string[] args)
        {
            _commands = new Helpers.Commands();
            RegisterCommands();
            StartUpMessage();

            var commandParser = new CommandParser(_commands);
            while (true)
            {
                try
                {
                    var command = commandParser.From(Console.ReadLine());

                    if (command.Action == "exit")
                        Environment.Exit(0);

                    if(_commands.IsValid(command.Action) && command.Action == "load")
                        command.Commander.Do(command.Args);
                    else if (_commands.IsValid(command.Action) && command.Action == "create")
                        command.Commander.Do(command.Args);
                    else if (PetLoader.Loaded && _commands.IsValid(command.Action))
                        command.Commander.Do(command.Args);
                    else
                        ConsoleHelpers.ErrorMessage("Command invalid!");
                }
                catch (Exception exception)
                {
                    ConsoleHelpers.ErrorMessage(exception.Message);
                }
            }
        }

        private static void StartUpMessage()
        {
            Console.WriteLine("Welcome to Samagotchi!");
            Console.WriteLine("Load pet or create a new one (load Barry or create Terry)");
        }

        private static void RegisterCommands()
        {
            _commands.Add("feed", new Feed());
            _commands.Add("load", new Load());
            _commands.Add("create", new Create());
        }
    }
}
