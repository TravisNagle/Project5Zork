using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    public class Weapon
    {
        public int Attack { get; set; }
        public string Name { get; set; }

        public Weapon(int attack, string name)
        {
            Attack = attack;
            Name = name;
        }

        public int GetAttack()
        {
            return Attack;
        }

        public override string ToString()
        {
            string info = $"\nName: {Name}";
            info += $"\nAttack: {Attack}";

            return info;
        }
    }
}
