using System;
using System.Collections.Generic;
using Samagotchi.App.Helpers;

namespace Samagotchi.App.Actions
{
    public class Exit : IAction
    {
        public const string ActionName = "Exit";
        public string PetName;

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
            Environment.Exit(0);
        }

        public string Name()
        {
            return ActionName;
        }
    }
}
