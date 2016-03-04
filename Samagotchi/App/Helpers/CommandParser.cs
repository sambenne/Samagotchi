using System.Collections.Generic;
using System.Linq;

namespace Samagotchi.App.Helpers
{
    public class CommandParser
    {
        private readonly Command _command;
        private readonly Commands _commands;

        public CommandParser(Commands commands)
        {
            _command = new Command();
            _commands = commands;
        }

        public Command From(string input)
        {
            var parts = input.Split(' ').ToList();
            var action = parts[0].ToLower();
            if (parts.Count > 1)
            {
                parts.Remove(action);
                _command.Args = parts;
            }
            else
            {
                _command.Args = new List<string>();
            }

            if (_commands.Has(action))
            {
                _command.Action = _commands.From(action);
            }

            return _command;
        }

        public bool HasAction()
        {
            return !string.IsNullOrEmpty(_command.Action.Name());
        }
    }
}