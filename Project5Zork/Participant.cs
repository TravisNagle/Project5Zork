using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    public abstract class Participant
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public string Name { get; set; }

        public Participant()
        {
            Health = 0;
            Attack = 0;
            Name = "";
        }

        public Participant(int health, int attack, string name)
        {
            Health = health;
            Attack = attack;
            Name = name;
        }

        public Participant(Participant existingParticipant)
        {
            Name = existingParticipant.Name;
            Health = existingParticipant.Health;
            Attack = existingParticipant.Attack;
        }

        public override string ToString()
        {
            string info = $"Name: {Name}";
            info += $"Health: {Health}";
            info += $"Attack: {Attack}";

            return info;
        }
    }
}
