using System;
using System.Linq;

namespace Samagotchi.App.Helpers
{
    public class CommandParser
    {
        private Command _command;
        private readonly Commands _commands;

        public CommandParser(Commands commands)
        {
            _commands = commands;
        }

        public Command From(string input)
        {
            _command = new Command();

            var parts = input.Split(' ').ToList();
            var action = parts[0].ToLower();
            if (parts.Count > 1)
            {
                parts.Remove(action);
                _command.Args = parts;
            }

            if (!_commands.Has(action))
                throw new Exception("Command does not exist.");
            _command.Action = _commands.From(action);

            return _command;
        }

        public bool HasAction()
        {
            return !string.IsNullOrEmpty(_command.Action.Name());
        }

        public void Dispose()
        {
            _command = null;
        }
    }
}