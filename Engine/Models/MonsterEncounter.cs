using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class MonsterEncounter
    {
        public int MonsterId { get; set; }
        public int ChanceOfEncountering { get; set; }
        public MonsterEncounter(int monsterId, int chanceOfEncountering)
        {
            MonsterId = monsterId;
            ChanceOfEncountering = chanceOfEncountering;
        }
    }
}
