using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Monster : BaseNotificationClass
    {
        private int _hitPoints;

        public Monster(string name, string imageName,
                       int maxiumHitPoints, int hitPoints,
                       int minimumDamage, int maximumDamage,
                       int rewardExperiencePoints, int rewardGold
            )
        {
            Name = name;
            ImageName = string.Format("/Engine;component/Images/Monsters/{0}", imageName);
            MaxiumHitPoints = maxiumHitPoints;
            HitPoints = hitPoints;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            Inventory = new ObservableCollection<ItemQuantity>();
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }

        public string Name { get; private set; }
        public string ImageName { get; set; }
        public int MaxiumHitPoints { get; private set; }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int RewardExperiencePoints { get; private set; }
        public int RewardGold { get; private set; }
        public ObservableCollection<ItemQuantity> Inventory { get; set; }

    }
}
