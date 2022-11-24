using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    public class Player : Participant
    {
        public bool HasStick { get; set; } = false;
        public bool HasSword { get; set; } = false;
        public Player() : base()
        {
            Dead = false;
            Health = 100;
            Name = "Player";
            Weapon = new Weapon(5, "Unarmed");
        }

        public override int CalcDamage(Player player, Monster monster)
        {
            Health = Health - 100;
            Console.WriteLine($"The Player has taken damage!\nHealth: {Health}");

            if (Health <= 0)
            {
                Console.WriteLine($"The Player has died.\nGame Over");
                Dead = true;
            }
            return Health;
        }

        public void GetWeapon()
        {
            if (HasStick)
                Weapon = new Weapon(6, "Stick");
            else if (HasSword)
                Weapon = new Weapon(8, "Sword");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
