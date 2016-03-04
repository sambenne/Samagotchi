using System.Collections.Generic;
using Samagotchi.App.Helpers;
using Samagotchi.App.Models;

namespace Samagotchi.App.Commands
{
    public class Load : ICommand
    {
        public const string Name = "Load";
        public string PetName;

        public void Do(IList<string> args)
        {
            PetName = args[0];
            var petLoader = PetLoader.Instance;
            petLoader.Load(PetName);
            ConsoleHelpers.SuccessMessage("Pet Name: " + PetLoader.Pet.Name);  
            ConsoleHelpers.SuccessMessage("Pet Type: " + PetLoader.Pet.Type);  
        }
    }
}
