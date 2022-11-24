using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    public class Monster : Participant
    {

        public Monster() : base()
        {
            Dead = false;
            Health = 20;
            Name = "Monster";
            Weapon = new Weapon(4, "Unarmed");
        }

        public void SetHealth(int health)
        {
            Health = health;
        }

        public override int CalcDamage(Player player, Monster monster)
        {
            if(player.HasStick)
            {
                Health = Health - 6;
            }
            else if(player.HasSword)
            {
                Health = Health - 8;
            }
            else
            {
                Health = Health - 5;
            }
            Console.WriteLine($"The Monster has taken damage!\nHealth: {Health}");

            if (Health <= 0)
            {
                Console.WriteLine($"The Monster has died.");
                Console.WriteLine("VICTORY");
                Dead = true;
            }
            return Health;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
