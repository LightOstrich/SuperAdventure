using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItem
    {
        public enum ItemCategory
        {
            Miscellaneous,
            Weapon
        }
        public ItemCategory Category { get; }
        public int ItemTypeId { get; }
        public string Name { get; }
        public int Price { get; }
        public bool IsUnique { get; }
        public int MinimumDamage { get; }
        public int MaximumDamage { get; }
        public GameItem(ItemCategory category, int itemTypeId, string name, int price, bool isUnique = false, int minimumDamage = 0, int maximumDamage = 0)
        {
            Category = category;
            ItemTypeId = itemTypeId;
            Name = name;
            Price = price;
            IsUnique = isUnique;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
        public GameItem Clone()
        {
            return new GameItem(Category, ItemTypeId, Name, Price, IsUnique, MinimumDamage, MaximumDamage);
        }
    }
}
