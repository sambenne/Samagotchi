using System;
using System.Collections.Generic;
using Samagotchi.App.Actions;

namespace Samagotchi.App.Helpers
{
    public class Commands
    {
        public Dictionary<string, IAction> CommandList;

        public Commands()
        {
            CommandList = new Dictionary<string, IAction>();
        }

        public void Add(string name, IAction action)
        {
            name = name.ToLower();
            if (!CommandList.ContainsKey(name))
                CommandList.Add(name, action);
        }

        public bool IsValid(string command)
        {
            return CommandList.ContainsKey(command);
        }

        public bool Has(string name)
        {
            return CommandList.ContainsKey(name);
        }

        public IAction From(string name)
        {
            if (CommandList.ContainsKey(name))
                return CommandList[name];

            throw new Exception("No Command Found");
        }
    }
}