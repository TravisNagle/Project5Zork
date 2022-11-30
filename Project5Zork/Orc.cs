using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    public class Orc : Monster
    {
        public Orc() : base()
        {
            Dead = false;
            Health = 25;
            Name = "Orc";
            Weapon = new Weapon(8, "Axe");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
