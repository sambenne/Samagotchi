using System;
using System.IO;
using Newtonsoft.Json;
using Samagotchi.App.Commands;

namespace Samagotchi.App.Models
{
    public class PetManager
    {
        public const string Folder = "pets";

        private static PetManager _instance;
        public static PetObject Pet = new PetObject();
        public static bool Loaded;

        private PetManager() { }

        public static PetManager Instance => _instance ?? (_instance = new PetManager());

        public void Load(string name)
        {
            var fileLocation = $"{Folder}/{name}.json";
            Loaded = false;
            if (!File.Exists(fileLocation)) return;

            using (var r = new StreamReader(fileLocation))
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

        public void Save()
        {
            var fileLocation = $"{Folder}/{Pet.Name}.json";
            var petJson = JsonConvert.SerializeObject(Pet);
            File.WriteAllText(fileLocation, petJson);
        }

        public void SetPet(PetObject pet)
        {
            Pet = pet;
            Loaded = true;
        }
    }
}
