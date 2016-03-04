using System.Data;
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

        public override bool Water(string item)
        {
            return true;
        }

        public override bool Play(string game)
        {
            return true;
        }

        public override string CanEat()
        {
            return $"{_foodItems.CanEat(Type)}";
        }
    }
}
