using System;
using Samagotchi.App.Models;
using Samagotchi.App.Pet.Pets;

namespace Samagotchi.App.Pet
{
    public class PetFactory
    {
        public static IPet From(PetObject petObject)
        {
            switch (petObject.Type)
            {
                case PetTypes.Dog:
                    return new Dog(petObject);
                case PetTypes.Cat:
                    return new Cat(petObject);
                case PetTypes.Pig:
                    return new Pig(petObject);
                default:
                    throw new Exception("No Pet Type Found");
            }
        }
    }
}
