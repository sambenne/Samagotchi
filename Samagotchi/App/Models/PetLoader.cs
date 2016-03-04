using System;
using System.IO;
using Newtonsoft.Json;
using Samagotchi.App.Commands;

namespace Samagotchi.App.Models
{
    public class PetLoader
    {
        private static PetLoader _instance;
        public static PetObject Pet = new PetObject();
        public static bool Loaded;

        private PetLoader() { }

        public static PetLoader Instance => _instance ?? (_instance = new PetLoader());

        public void Load(string name)
        {
            using (var r = new StreamReader(name + ".json"))
            {
                var json = r.ReadToEnd();
                try
                {
                    Pet = JsonConvert.DeserializeObject<PetObject>(json);
                    Loaded = true;
                }
                catch (Exception)
                {
                    Loaded = false;
                }
            }
        }

        public void SetPet(PetObject pet)
        {
            Pet = pet;
            Loaded = true;
        }
    }
}
