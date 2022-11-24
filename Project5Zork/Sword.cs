using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    public class Sword : Weapon
    {
        public Sword(int attack, string name) : base(attack, name)
        {
            Attack = attack;
            Name = name;
        }

        public int GetAttack()
        {
            return Attack;
        }
    }
}
