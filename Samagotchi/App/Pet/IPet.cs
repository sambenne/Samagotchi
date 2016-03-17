namespace Samagotchi.App.Pet
{
    public interface IPet
    {
        string Type { get; set; }
        string Name { get; set; }
        Gender Gender { get; set; }
        int Health { get; set; }
        int Hunger { get; set; }
        int Thirst { get; set; }
        int Boredom { get; set; }
        int Age { get; set; }
        int MaxHunger { get; set; }

        PetObject ToPetObject();
        void Map(PetObject petObject);
        void LowerHunger();
        void LowerThirst();
        void IncreaseBoredom();
        void IncreaseAge();
        bool Feed(string item);
        bool Drink(string item);
        bool Play(string game);
        string CanEat();
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class GenderTypes
    {
        public static Gender From(string sexInput)
        {
            switch (sexInput.ToLower())
            {
                case "male":
                case "boy":
                    return Gender.Male;
                default:
                    return Gender.Female;
            }
        }
    }
}
