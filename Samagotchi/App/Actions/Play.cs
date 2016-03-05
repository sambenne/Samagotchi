using System.Collections.Generic;
using Samagotchi.App.Pet;

namespace Samagotchi.App.Actions
{
    public class Play : IAction
    {
        public const string ActionName = "Play";

        public bool CanRun()
        {
            return PetManager.Loaded;
        }

        public void Do(IList<string> args)
        {
            var pet = PetManager.Pet;
            pet.Play(args[0]);
        }

        public string Name()
        {
            return ActionName;
        }
    }
}
