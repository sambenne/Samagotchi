using Samagotchi.App.Helpers;

namespace Samagotchi.App.Pet
{
    public abstract class Pet : IPet
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Health { get; set; }
        public int Hunger { get; set; }
        public int Thirst { get; set; }
        public int Boredom { get; set; }
        public int Age { get; set; }
        public int MaxHunger { get; set; }

        public PetObject ToPetObject()
        {
            return new PetObject
            {
                Name = Name,
                Type = Type,
                Health = Health,
                Hunger = Hunger,
                Boredom = Boredom,
                Thirst = Thirst,
                Age = Age,
                Gender = Gender
            };
        }

        public void Map(PetObject petObject)
        {
            Name = petObject.Name;
            Boredom = petObject.Boredom;
            Health = petObject.Health;
            Hunger = petObject.Hunger;
            Thirst = petObject.Thirst;
            Age = petObject.Age;
        }

        public void LowerHunger()
        {
            Hunger -= Hunger == 0 ? 0 : 1;
            PetManager.Instance.Save();
            if (Hunger == 0)
            {
                ConsoleHelpers.ErrorMessage(PetManager.Pet.Name + " is starving!");
                LowerHealth();
                ConsoleHelpers.PlayNote(Tone.A, Duration.Quarter);
                return;
            }

            if (Hunger >= 3) return;
            ConsoleHelpers.WarnMessage(PetManager.Pet.Name + " is getting really hungry!");
            ConsoleHelpers.PlayNote(Tone.Dsharp, Duration.Quarter);
        }

        public void LowerThirst()
        {
            Thirst -= Thirst == 0 ? 0 : 1;
            PetManager.Instance.Save();
            if (Thirst == 0)
            {
                ConsoleHelpers.ErrorMessage(PetManager.Pet.Name + " is really thirsty!");
                LowerHealth();
                ConsoleHelpers.PlayNote(Tone.A, Duration.Quarter);
                return;
            }

            if (Thirst >= 3) return;
            ConsoleHelpers.WarnMessage(PetManager.Pet.Name + " is getting really thirsty!");
            ConsoleHelpers.PlayNote(Tone.Dsharp, Duration.Quarter);
        }

        public void IncreaseBoredom()
        {
            Boredom += Boredom == 10 ? 0 : 1;
            PetManager.Instance.Save();
            if (Boredom == 10)
            {
                ConsoleHelpers.ErrorMessage(PetManager.Pet.Name + " is depressed!");
                ConsoleHelpers.PlayNote(Tone.A, Duration.Quarter);
                return;
            }

            if (Boredom <= 7) return;
            ConsoleHelpers.WarnMessage(PetManager.Pet.Name + " is getting really bored!");
            ConsoleHelpers.PlayNote(Tone.Dsharp, Duration.Quarter);
        }

        public void IncreaseAge()
        {
            Age += 1;
        }

        public void LowerHealth()
        {
            Health -= Health == 0 ? 0 : 1;
            PetManager.Instance.Save();
        }

        public abstract bool Feed(string item);

        public abstract bool Drink(string item);

        public abstract bool Play(string game);

        public abstract string CanEat();
    }
}
