using System.Collections.Generic;
using Samagotchi.App.Helpers;
using Samagotchi.App.Pet;

namespace Samagotchi.App.Actions
{
    public class Feed : IAction
    {
        public const string ActionName = "Feed";
        public Dictionary<string, FoodItem> FoodItems; 

        public bool CanRun()
        {
            return PetManager.Loaded;
        }

        public void Do(IList<string> args)
        {
            string item;
            if (args.Count == 0)
            {
                item = ConsoleHelpers.GetResponse("Please select (" + PetManager.Pet.CanEat() + ")");
                if (item == "")
                {
                    ConsoleHelpers.ErrorMessage("You need to select an Item");
                    return;
                }
            }
            else
            {
                item = args[0];
            }

            if(PetManager.Pet.Feed(item))
                ConsoleHelpers.SuccessMessage(PetManager.Pet.Name + " fed.");
            else
                ConsoleHelpers.ErrorMessage(PetManager.Pet.Name + " not fed.");

            PetManager.Instance.Save();
        }

        public string Name()
        {
            return ActionName;
        }
    }

    public class FoodItem
    {
        public string Name { get; set; }
        public string Animal { get; set; }
        public int Hunger { get; set; }
    }
}
