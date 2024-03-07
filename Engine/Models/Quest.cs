using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Quest
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public List<ItemQuantity> ItemsToComplete { get; }
        public int RewardExpreiencePoints { get; }
        public int RewardGold { get; }
        public List<ItemQuantity> RewardItems { get; }

        public Quest(int iD, string name, string description, List<ItemQuantity> itemsToComplete,
                     int rewardExpreiencePoints, int rewardGold, List<ItemQuantity> rewardItems)
        {
            ID = iD;
            Name = name;
            Description = description;
            ItemsToComplete = itemsToComplete;
            RewardExpreiencePoints = rewardExpreiencePoints;
            RewardGold = rewardGold;
            RewardItems = rewardItems;
        }
    }
}
