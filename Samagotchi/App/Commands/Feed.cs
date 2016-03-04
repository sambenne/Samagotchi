using System.Collections.Generic;
using Samagotchi.App.Helpers;
using Samagotchi.App.Models;

namespace Samagotchi.App.Commands
{
    public class Feed : ICommand
    {
        public const string Name = "Feed";

        public void Do(IList<string> args)
        {
            ConsoleHelpers.SuccessMessage(PetLoader.Pet.Name + " fed.");  
        }
    }
}
