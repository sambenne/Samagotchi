using System;
using System.Collections.Generic;
using System.Linq;
using Samagotchi.App.Commands;
using Samagotchi.App.Helpers;
using Samagotchi.App.Models;

namespace Samagotchi.App.Actions
{
    public class Create : IAction
    {
        public const string ActionName = "Create";

        public bool CanRun()
        {
            return !PetManager.Loaded;
        }

        public void Do(IList<string> args)
        {
            var pet = new PetObject
            {
                Name = FirstCharToUpper(args[0]),
                Type = ConsoleHelpers.GetResponse("Select pet type (dog, cat, pig)")
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
