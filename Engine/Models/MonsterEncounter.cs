namespace Engine.Models
{
    public class MonsterEncounter
    {
        public int MonsterId { get; }
        public int ChanceOfEncountering { get; set; }
        public MonsterEncounter(int monsterId, int chanceOfEncountering)
        {
            MonsterId = monsterId;
            ChanceOfEncountering = chanceOfEncountering;
        }
    }
}
