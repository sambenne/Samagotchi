﻿using System.Collections.Generic;
using Samagotchi.App.Helpers;
using Samagotchi.App.Pet;

namespace Samagotchi.App.Actions
{
    public class Play : IAction
    {
        public const string ActionName = "Play";

        public void Register(Commands commands, EventManager events)
        {
            commands.Add(ActionName, this);

            events.Add("boredom", ticks =>
            {
                if (ticks % 20 == 0 && PetManager.Loaded)
                    PetManager.Pet.IncreaseBoredom();
            });
        }

        public bool CanRun()
        {
            return PetManager.Loaded;
        }

        public void Do(IList<string> args)
        {
            var pet = PetManager.Pet;
            pet.Play("");
            PetManager.Instance.Save();
        }

        public string Name()
        {
            return ActionName;
        }
    }
}
