using System.Collections.Generic;
using Samagotchi.App.Helpers;
using Samagotchi.App.Pet;

namespace Samagotchi.App.Actions
{
    public class Load : IAction
    {
        public const string ActionName = "Load";
        public string PetName;

        public bool CanRun()
        {
            return true;
        }

        public void Do(IList<string> args)
        {
            PetName = args[0];
            var petLoader = PetManager.Instance;
            petLoader.Load(PetName);
            ConsoleHelpers.SuccessMessage("Pet Name: " + PetManager.Pet.Name);  
            ConsoleHelpers.SuccessMessage("Pet Type: " + PetManager.Pet.Type);  
        }

        public string Name()
        {
            return ActionName;
        }
    }
}
