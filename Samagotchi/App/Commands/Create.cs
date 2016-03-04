using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Samagotchi.App.Helpers;
using Samagotchi.App.Models;

namespace Samagotchi.App.Commands
{
    public class Create : ICommand
    {
        public const string Name = "Create";

        public void Do(IList<string> args)
        {
            var pet = new PetObject
            {
                Name = FirstCharToUpper(args[0]),
                Type = ConsoleHelpers.GetResponse("Select pet type (dog, cat, pig)")
            };

            ConsoleHelpers.SuccessMessage("A pet was born");
            PetLoader.Instance.SetPet(pet);
            var storage = JsonConvert.SerializeObject(pet);
            System.IO.File.WriteAllText("pets/" + pet.Name.ToLower() + ".json", storage);
        }

        private static string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
