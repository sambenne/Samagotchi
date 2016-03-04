using System;
using System.Timers;
using Samagotchi.App.Actions;
using Samagotchi.App.Helpers;
using Samagotchi.App.Pet;

namespace Samagotchi.App
{
    public class Base
    {
        private static Commands _commands;
        private static EventManager _eventManager;
        private static int _ticks;

        public static void Main(string[] args)
        {
            _eventManager = new EventManager();
            _commands = new Commands();
            RegisterCommands();
            RegisterEvents();
            StartUpMessage();

            var timer = new Timer
            {
                Interval = 2000,
                Enabled = true
            };

            timer.Elapsed += OnTimedEvent;
            timer.Start();

            var commandParser = new CommandParser(_commands);
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                try
                {
                    var command = commandParser.From(line);

                    if(command.Action.CanRun())
                        command.Action.Do(command.Args);
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
            _commands.Add(Feed.ActionName, new Feed());
            _commands.Add(Load.ActionName, new Load());
            _commands.Add(Create.ActionName, new Create());
            _commands.Add(Exit.ActionName, new Exit());
            _commands.Add(Stats.ActionName, new Stats());
        }

        private static void RegisterEvents()
        {
            _eventManager.Add("hunger", ticks =>
            {
                if(ticks % 20 == 0 && PetManager.Loaded)
                    PetManager.Pet.LowerHunger();
            });
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs events)
        {
            _eventManager.RunEvents(_ticks);
            _ticks++;
        }
    }
}
