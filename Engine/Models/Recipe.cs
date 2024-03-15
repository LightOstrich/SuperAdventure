using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Models
{
    public class Recipe
    {
        public int ID { get; }
        public string Name { get; }
        public List<ItemQuantity> Ingredients { get; } = new List<ItemQuantity>();
        public List<ItemQuantity> OutputItems { get; } = new List<ItemQuantity>();
        public string ToolTipContents =>
           "Ingredients" + Environment.NewLine +
           "===========" + Environment.NewLine +
           string.Join(Environment.NewLine, Ingredients.Select(i => i.QuantityItemDescription)) +
           Environment.NewLine + Environment.NewLine +
           "Creates" + Environment.NewLine +
           "===========" + Environment.NewLine +
           string.Join(Environment.NewLine, OutputItems.Select(i => i.QuantityItemDescription));
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
