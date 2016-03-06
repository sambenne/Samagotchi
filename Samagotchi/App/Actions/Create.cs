using System;
using System.Collections.Generic;
using System.Linq;
using Samagotchi.App.Helpers;
using Samagotchi.App.Pet;

namespace Samagotchi.App.Actions
{
    public class Create : IAction
    {
        public const string ActionName = "Create";

        public void Register(Commands commands, EventManager events)
        {
            commands.Add(ActionName, this);
        }

        public bool CanRun()
        {
            return !PetManager.Loaded;
        }

        public void Do(IList<string> args)
        {
            var pet = new PetObject();

            var typeResponse = ConsoleHelpers.GetResponse($"Select pet type ({new PetTypes()})");
            pet.Type = PetTypes.From(typeResponse);
            var genderResponse = ConsoleHelpers.GetResponse("Is your pet a Boy or Girl?");
            pet.Gender = GenderTypes.From(genderResponse);

            pet.Name = FirstCharToUpper(ConsoleHelpers.GetResponse("What do you want to call your pet?"));

            ConsoleHelpers.SuccessMessage($"{pet.Name} was born");
            PetManager.Instance.SetPet(pet);
            PetManager.Instance.Save();
        }

        public string Name()
        {
            return ActionName;
        }

        private static string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
