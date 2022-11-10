using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    public class Player : Participant
    {
        public Player() : base()
        {
            Health = 100;
            Name = "Player";
            Weapon = new Weapon(5, "Unarmed");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
