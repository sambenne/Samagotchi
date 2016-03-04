using System;
using System.Collections.Generic;
using Samagotchi.App.Commands;

namespace Samagotchi.App.Helpers
{
    public class Commands
    {
        public Dictionary<string, ICommand> CommandList;

        public Commands()
        {
            CommandList = new Dictionary<string, ICommand>();
        }

        public void Add(string name, ICommand command)
        {
            name = name.ToLower();
            if (!CommandList.ContainsKey(name))
                CommandList.Add(name, command);
        }

        public bool IsValid(string command)
        {
            return CommandList.ContainsKey(command);
        }

        public bool Has(string name)
        {
            return CommandList.ContainsKey(name);
        }

        public ICommand From(string name)
        {
            if (CommandList.ContainsKey(name))
                return CommandList[name];

            throw new Exception("No Command Found");
        }
    }
}