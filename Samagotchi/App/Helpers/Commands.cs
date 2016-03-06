using System;
using System.Collections.Generic;
using System.Linq;
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

        public void RegisterCommands(EventManager events)
        {
            var type = typeof(IAction);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.Namespace != null && type.IsAssignableFrom(p) && p.IsClass && !p.Namespace.Contains("Tests"));

            foreach (var type1 in types)
            {
                var temp = (IAction)Activator.CreateInstance(type1);
                temp.Register(this, events);
            }
        }
    }
}