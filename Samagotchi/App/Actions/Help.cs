using System;
using System.Collections.Generic;
using System.Linq;
using Samagotchi.App.Helpers;

namespace Samagotchi.App.Actions
{
    public class Help : IAction
    {
        private readonly HelpCommands _commands;
        public const string ActionName = "Help";

        public Help() : this (new HelpCommands()) {}

        public Help(HelpCommands commands)
        {
            _commands = commands;
            _commands.Commands.Add(new HelpCommand
            {
                Name = "CREATE",
                ShortDescription = "Creates a pet.",
                LongDescription = new []
                {
                    @"Creates a pet to play with.\n",
                    @"CREATE [string]\n",
                    ConsoleHelpers.WriteLineTabbedIn("string", "The name of the pet."),
                }
            });
            _commands.Commands.Add(new HelpCommand
            {
                Name = "DRINK",
                ShortDescription = "Gives the pet something to drink."
            });
            _commands.Commands.Add(new HelpCommand {Name = "EXIT", ShortDescription = "Exits the game."});
            _commands.Commands.Add(new HelpCommand {Name = "FEED", ShortDescription = "Feeds the pet."});
            _commands.Commands.Add(new HelpCommand
            {
                Name = "LOAD",
                ShortDescription = "Gives the pet something to play with."
            });
            _commands.Commands.Add(new HelpCommand
            {
                Name = "PLAY",
                ShortDescription = "Gives the pet something to play with."
            });
            _commands.Commands.Add(new HelpCommand
            {
                Name = "STATS",
                ShortDescription = "Displays the current pet stats."
            });
        }

        public void Register(Commands commands, EventManager events)
        {
            commands.Add(ActionName, this);
        }

        public bool CanRun()
        {
            return true;
        }

        public void Do(IList<string> args)
        {
            Console.WriteLine("Help" + (args.Count == 0 ? "" : " " + args[0]));
            if (args.Count == 0)
            {
                Console.WriteLine("For more information on a speific command, type HELP command-name");
                foreach (var command in _commands.Commands)
                {
                    ConsoleHelpers.WriteLineTabbed(command.Name, command.ShortDescription);
                }
                return;
            }
            if (!_commands.Exists(args[0]))
            {
                ConsoleHelpers.ErrorMessage($"No command called {args[0]}");
                return;
            }

            var helpCommand = _commands.For(args[0]);
            foreach (var line in helpCommand.LongDescription)
            {
                Console.WriteLine(line);
            }
        }

        public string Name()
        {
            return ActionName;
        }

        public class HelpCommands
        {
            public IList<HelpCommand> Commands;

            public HelpCommands()
            {
                Commands = new List<HelpCommand>();
            }

            public bool Exists(string commandName)
            {
                return Commands.Count(x => string.Equals(x.Name, commandName, StringComparison.CurrentCultureIgnoreCase)) != 0;
            }

            public HelpCommand For(string commandName)
            {
                return Commands.First(x => string.Equals(x.Name, commandName, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public class HelpCommand
        {
            public string Name { get; set; }
            public string ShortDescription { get; set; }
            public string[] LongDescription { get; set; }
        }
    }
}
