using Samagotchi.App.Model;
using Samagotchi.App.Models;

namespace Samagotchi.App.Pet.Pets
{
    public class Dog : Pet
    {
        private readonly FoodItems _foodItems;

        public Dog(PetObject petObject)
        {
            Type = PetTypes.Dog;
            MaxHunger = 10;
            Map(petObject);

            _foodItems = new FoodItems();
            _foodItems.Add(new FoodItem { Animal = PetTypes.Dog, Name = "Biscuits", Hunger = 1 });
            _foodItems.Add(new FoodItem { Animal = PetTypes.Dog, Name = "Sandwich", Hunger = 3 });
            _foodItems.Add(new FoodItem { Animal = PetTypes.Dog, Name = "Steak", Hunger = 5 });
        }

        public override bool Feed(string item)
        {
            if (!_foodItems.Exists(item) || Hunger >= MaxHunger) return false;

            Hunger += _foodItems.For(item).Hunger;
            Hunger = (Hunger > 10 ? 10 : Hunger);
            return true;
        }

        public override bool Drink(string item)
        {
            if (Thirst >= 10) return false;
            Thirst += (Thirst > 10 ? 0 : 2);

            return true;
        }

        public override bool Play(string game)
        {
            if (Boredom <= 0) return false;
            Boredom -= (Boredom < 0 ? 0 : 4);
            Boredom = (Boredom < 0 ? 0 : Boredom);

            return true;
        }

        public override string CanEat()
        {
            return $"{_foodItems.CanEat(Type)}";
        }
    }
}
