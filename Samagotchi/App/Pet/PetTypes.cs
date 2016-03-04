using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Samagotchi.App.Models
{
    public class PetTypes
    {
        public const string Dog = "dog";
        public const string Cat = "cat";
        public const string Pig = "pig";

        public override string ToString()
        {
            var petTypes = Types();
            return string.Join(", ", petTypes);
        }

        public bool IsValid(string type)
        {
            var types = Types();
            return types.Contains(type);
        }

        private static IEnumerable<string> Types()
        {
            var fieldInfos = typeof(PetTypes).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy).ToList();
            return fieldInfos.Select(fieldInfo => fieldInfo.Name).ToList();
        } 
    }
}
