using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var fileLocation = $"{Folder}/{Pet.Name.ToLower()}.json";
            if (File.Exists(fileLocation))
                File.Delete(fileLocation);

            FileStream file = null;
            try
            {
                lock (Locker)
                {
                    using (file = File.Create(fileLocation, 1024))
                    {
                        var info = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(Pet));
                        file.Write(info, 0, info.Length);
                    }
                }
            }
            finally
            {
                file?.Dispose();
            }
        }

        public void SetPet(PetObject pet)
        {
            Pet = PetFactory.From(pet);
            Loaded = true;
        }

        public static IList<string> DiscoverPets()
        {
            var files = Directory.GetFiles(Folder, "*.json");
            var petNames = files.ToList();


            return petNames.Select(ExtractNameFromPath).ToList();
        }

        private static string ExtractNameFromPath(string path)
        {
            path = path.Replace($"{Folder}\\", "").Replace(".json", "");
            return char.ToUpper(path[0]) + path.Substring(1);
        }
    }
}
