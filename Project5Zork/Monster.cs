using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    public class Monster : Participant
    {
        public bool Spawn { get; set; }
        public Monster() : base()
        {
            Health = 20;
            Name = "Monster";
        }

        public bool MonsterSpawn()
        {
            Random r = new Random();
            int spawnRate = r.Next(1, 2);

            if (spawnRate == 1)
            {
                Spawn = true;
                return true;
            }
            else
            {
                Spawn = false;
                return false;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
