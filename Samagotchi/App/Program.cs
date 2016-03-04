using System;
using System.Threading;
using System.Timers;
using Samagotchi.App.Actions;
using Samagotchi.App.Helpers;

namespace Samagotchi.App
{
    public class Base
    {
        private static Helpers.Commands _commands;
        private static EventManager _eventManager;
        private static DateTime _startUp;

        public static void Main(string[] args)
        {
            _startUp = DateTime.Now;
            _eventManager = new EventManager();
            _commands = new Helpers.Commands();
            RegisterCommands();
            RegisterEvents();
            StartUpMessage();

            var timer = new System.Timers.Timer
            {
                Interval = 2000,
                Enabled = true
            };

            timer.Elapsed += OnTimedEvent;
            timer.Start();

            var commandParser = new CommandParser(_commands);
            while (true)
            {
                try
                {
                    var command = commandParser.From(Console.ReadLine());

                    if(command.Action.CanRun())
                        command.Action.Do(command.Args);
                    else
                        ConsoleHelpers.ErrorMessage("Command invalid!");

                    _eventManager.RunEvents();
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

        private static void RegisterEvents()
        {
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _eventManager.RunEvents();
        }
    }
}
