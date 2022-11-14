namespace Project5Zork
{
    public abstract class Participant
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public bool Dead { get; set; } = false;

        public Participant()
        {
            Health = 0;
            Name = "";
            Weapon = new Weapon(0, null);
        }

        public Participant(int health, string name, Weapon weapon)
        {
            Health = health;
            Name = name;
            Weapon = weapon;
        }

        public Participant(Participant existingParticipant)
        {
            Name = existingParticipant.Name;
            Health = existingParticipant.Health;
            Weapon = existingParticipant.Weapon;
        }

        public bool IsDead()
        {
            Dead = true;

            return Dead;
        }

        public abstract int CalcDamage();

        public override string ToString()
        {
            string info = "Participant---------------";
            info += $"\nName: {Name}";
            info += $"\nHealth: {Health}";
            info += $"\nWeapon--------------------{Weapon}";

            return info;
        }
    }
}
