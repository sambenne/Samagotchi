namespace Samagotchi.App.Pet
{
    public class PetObject
    {
        public PetObject()
        {
            Health = 10;
            Hunger = 10;
            Thirst = 10;
            Boredom = 0;
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Health { get; set; }
        public int Hunger { get; set; }
        public int Thirst { get; set; }
        public int Boredom { get; set; }
        public int Age { get; set; }
    }
}