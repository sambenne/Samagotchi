using System;
using System.Collections.Generic;
using Samagotchi.App.Helpers;
using Samagotchi.App.Pet;

namespace Samagotchi.App.Actions
{
    public class Load : IAction
    {
        public const string ActionName = "Load";
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
            if (args.Count > 0)
            {

                PetName = args[0];
                var petLoader = PetManager.Instance;
                petLoader.Load(PetName);
                ConsoleHelpers.SuccessMessage("Pet Name: " + PetManager.Pet.Name);
                Console.Title = $"Samagotchi - {PetManager.Pet.Name}";
                return;
            }

            var pets = PetManager.DiscoverPets();
            if (pets.Count > 0)
            {
                Console.WriteLine("Pets found");
                foreach (var pet in pets)
                    Console.WriteLine($"> {pet}");
            }
            else
            {
                Console.WriteLine("No pets found");
            }
            
        }

        public string Name()
        {
            return ActionName;
        }
    }
}
