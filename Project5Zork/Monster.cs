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
            Health = 20;
            Attack = 4;
            Name = "Monster";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
