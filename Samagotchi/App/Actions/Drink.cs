using System.Collections.Generic;
using Samagotchi.App.Helpers;
using Samagotchi.App.Pet;

namespace Samagotchi.App.Actions
{
    public class Drink : IAction
    {
        public const string ActionName = "Drink";

        public void Register(Commands commands, EventManager events)
        {
            commands.Add(ActionName, this);
            events.Add("thirst", ticks =>
            {
                if (ticks % 30 == 0 && PetManager.Loaded)
                    PetManager.Pet.LowerThirst();
            });
        }

        public bool CanRun()
        {
            return PetManager.Loaded;
        }

        public void Do(IList<string> args)
        {
            if(PetManager.Pet.Drink(""))
                ConsoleHelpers.SuccessMessage(PetManager.Pet.Name + " drank.");
            else
                ConsoleHelpers.ErrorMessage(PetManager.Pet.Name + " didn't drink.");

            PetManager.Instance.Save();
        }

        public string Name()
        {
            return ActionName;
        }
    }
}
