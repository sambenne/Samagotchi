namespace Samagotchi.App.Pet.Pets
{
    public class Cat : Pet
    {
        public Cat(PetObject petObject)
        {
            Type = PetTypes.Cat;
            MaxHunger = 10;
            Map(petObject);
        }

        public override bool Feed(string item)
        {
            return true;
        }

        public override bool Drink(string item)
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
