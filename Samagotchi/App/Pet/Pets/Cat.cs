using Samagotchi.App.Models;

namespace Samagotchi.App.Pet.Pets
{
    public class Cat : Pet
    {
        public Cat(PetObject petObject)
        {
            Type = PetTypes.Cat;
            Age = petObject.Age;
            Map(petObject);
        }

        public override bool Feed(string item)
        {
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
            throw new System.NotImplementedException();
        }
    }
}
