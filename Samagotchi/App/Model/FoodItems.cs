using System;
using System.Collections.Generic;
using System.Linq;

namespace Samagotchi.App.Model
{
    public class FoodItems
    {
        public static IList<FoodItem> Items;

        private static readonly Lazy<FoodItems> Lazy = new Lazy<FoodItems>(() => new FoodItems());

        public FoodItems Instance => Lazy.Value;

        public FoodItems()
        {
            Items = new List<FoodItem>();
        }

        public void Add(FoodItem item)
        {
            Items.Add(item);
        }

        public bool Exists(string name)
        {
            return Items.Count(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase)) == 1;
        }

        public FoodItem For(string name)
        {
            return Items.First(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }

        public string CanEat(string animalType)
        {
            var items = Items.Where(x => string.Equals(x.Animal, animalType, StringComparison.CurrentCultureIgnoreCase))
                    .Select(x => x.Name)
                    .ToList();

            return string.Join(", ", items);
        }
    }

    public class FoodItem
    {
        public string Name { get; set; }
        public string Animal { get; set; }
        public int Hunger { get; set; }
    }
}
