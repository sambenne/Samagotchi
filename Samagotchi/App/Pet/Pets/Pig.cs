namespace Samagotchi.App.Pet.Pets
{
    public class Pig : Pet
    {
        public Pig(PetObject petObject)
        {
            Type = PetTypes.Pig;
            Age = petObject.Age;
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
