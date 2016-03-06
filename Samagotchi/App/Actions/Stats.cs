using System;
using System.Collections.Generic;
using Samagotchi.App.Helpers;
using Samagotchi.App.Pet;

namespace Samagotchi.App.Actions
{
    public class Stats : IAction
    {
        public const string ActionName = "Stats";

        public void Register(Commands commands, EventManager events)
        {
            commands.Add(ActionName, this);
        }

        public bool CanRun()
        {
            return PetManager.Loaded;
        }

        public void Do(IList<string> args)
        {
            var pet = PetManager.Pet;
            Console.WriteLine("Name: " + pet.Name);
            Console.WriteLine("Animal: " + pet.Type);
            Console.WriteLine("Age: " + pet.Age);
            Console.WriteLine("Health Level: " + pet.Health);
            Console.WriteLine("Hunger Level: " + pet.Hunger);
            Console.WriteLine("Thirst Level: " + pet.Thirst);
            Console.WriteLine("Boredom Level: " + pet.Boredom);
        }

        public string Name()
        {
            return ActionName;
        }
    }
}
