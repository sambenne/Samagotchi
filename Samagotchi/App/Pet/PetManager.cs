using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Samagotchi.App.Pet
{
    public class PetManager
    {
        public const string Folder = "pets";

        private static PetManager _instance;
        public static IPet Pet;
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
                    SetPet(JsonConvert.DeserializeObject<PetObject>(json));
                }
                catch (Exception)
                {
                    Loaded = false;
                }
            }
        }

        private static readonly object Locker = new object();

        public void Save()
        {
            lock (Locker)
            {
                var fileLocation = $"{Folder}/{Pet.Name.ToLower()}.json";
                using (var file = new FileStream(fileLocation, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (var writer = new StreamWriter(file, Encoding.UTF8))
                {
                    writer.Write(JsonConvert.SerializeObject(Pet));
                }
            }
        }

        public void SetPet(PetObject pet)
        {
            Pet = PetFactory.From(pet);
            Loaded = true;
        }
    }
}
