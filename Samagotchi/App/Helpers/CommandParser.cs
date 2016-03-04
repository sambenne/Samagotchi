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
            _command.Action = parts[0].ToLower();
            if (parts.Count > 1)
            {
                parts.Remove(_command.Action);
                _command.Args = parts;
            }

            if (_commands.Has(_command.Action))
            {
                _command.Commander = _commands.From(_command.Action);
            }

            return _command;
        }

        public bool HasAction()
        {
            return !string.IsNullOrEmpty(_command.Action);
        }
    }
}