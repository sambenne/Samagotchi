using System;
using System.Collections.Generic;
using System.Linq;
using Samagotchi.App.Helpers;
using Samagotchi.App.Models;
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
            if (args.Count == 0)
            {
                ConsoleHelpers.ErrorMessage("You need to enter a name for your pet.");
                return;
            }

            var pet = new PetObject
            {
                Name = FirstCharToUpper(args[0]),
                Type = ConsoleHelpers.GetResponse($"Select pet type ({new PetTypes()})")
            };

            ConsoleHelpers.SuccessMessage("A pet was born");
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
