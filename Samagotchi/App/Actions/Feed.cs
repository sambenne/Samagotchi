using System.Collections.Generic;
using Samagotchi.App.Helpers;
using Samagotchi.App.Models;

namespace Samagotchi.App.Actions
{
    public class Feed : IAction
    {
        public const string ActionName = "Feed";

        public bool CanRun()
        {
            return PetManager.Loaded;
        }

        public void Do(IList<string> args)
        {
            ConsoleHelpers.SuccessMessage(PetManager.Pet.Name + " fed.");  
        }

        public string Name()
        {
            return ActionName;
        }
    }
}
