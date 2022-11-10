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
            Attack = 5;
            Name = "Player";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
