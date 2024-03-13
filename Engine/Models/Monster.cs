namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        public string ImageName { get; }
        public int RewardExperiencePoints { get; }
        public Monster(string name, string imageName,
                      int maxiumHitPoints, int currenthitPoints,
                      int rewardExperiencePoints, int gold
           ) : base(name, maxiumHitPoints, currenthitPoints, gold)
        {
            ImageName = $"/Engine;component/Images/Monsters/{imageName}";
            RewardExperiencePoints = rewardExperiencePoints;
        }

    }
}
