using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Recipe
    {
        public int ID { get; }
        public string Name { get; }
        public List<ItemQuantity> Ingredients { get; } = new List<ItemQuantity>();
        public List<ItemQuantity> OutputItems { get; } = new List<ItemQuantity>();
        public Recipe(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public void AddIngredient(int itemId, int quantity)
        {
            if (!Ingredients.Any(x => x.ItemID == itemId))
            {
                Ingredients.Add(new ItemQuantity(itemId, quantity));
            }
        }
        public void AddOutputItem(int itemId, int quantity)
        {
            if (!OutputItems.Any(x => x.ItemID == itemId))
            {
                OutputItems.Add(new ItemQuantity(itemId, quantity));
            }
        }
    }
}
