using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    public class Dragon : Monster
    {
        public Dragon() : base()
        {
            Random rand = new Random();
            Dead = false;
            int type = rand.Next(0, 3);

            switch (type)
            {
                case 0:
                    Name = "Blue Dragon";
                    Health = 30;
                    Weapon = new Weapon(10, "Blue Dragon Breath");
                    break;

                case 1:
                    Name = "Black Dragon";
                    Health = 35;
                    Weapon = new Weapon(12, "Black Dragon Breath");
                    break;

                case 2:
                    Name = "Red Dragon";
                    Health = 40;
                    Weapon = new Weapon(5, "Red Dragon Claws");
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
