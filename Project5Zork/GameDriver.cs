using System;

namespace Project5Zork
{
    public class GameDriver
    {
        public static void Main()
        {
            Player player = new Player();
            Monster monster = new Monster();

            Console.WriteLine(player);
            Console.WriteLine();
            Console.WriteLine(monster);

            Menu();
        }

        public static void Menu()
        {
            int userChoice = -1;
            bool validChoice = false;

            while(!validChoice)
            {
                try
                {
                    Console.WriteLine("------------ZORK------------");
                    Console.WriteLine();

                    Console.WriteLine("1. Play Game\n2. Exit Game");
                    userChoice = int.Parse(Console.ReadLine());
                    validChoice = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"\nThat is not a valid option, please try again.\n");
                }
            }

            switch(userChoice)
            {
                case 1:
                    PlayGame();
                    break;
                case 2:
                    Console.WriteLine("Thank you for playing!");
                    break;
            }
        }

        public static void PlayGame()
        {
            Random rand = new Random();
            List<Participant> characters = new List<Participant>();
            Player player = new Player();
            Monster monster = new Monster();


            characters.Add(player);
            characters.Add(monster);
            characters[0].CalcDamage(player, monster);
            characters[0].CalcDamage(player, monster);

            characters[0].CalcDamage(player, monster);

            characters[0].CalcDamage(player, monster);
            characters[0].CalcDamage(player, monster);


            int numOfRooms = rand.Next(5, 11);
            int weaponChance = rand.Next(1, 4);
            int playerLocation = 0;
            int weaponLocation = -1;
            int monsterLocation = -1;

            string[] rooms = new string[numOfRooms];
            rooms[0] = "|P___|";

            if(weaponChance % 2 != 0)
            {
                weaponLocation = rand.Next(1, numOfRooms - 1);
                rooms[weaponLocation] = "|__St|";
            }
            else
            {
                weaponLocation = rand.Next(1, numOfRooms);
                rooms[weaponLocation] = "|__Sw|";
            }

            for(int i = 1; i < rooms.Length; i++)
            {
                int monsterSpawn = rand.Next(0, 2);

                if(monsterSpawn == 1 && i != weaponLocation)
                {
                    rooms[i] = ("|_M__|");
                    monsterLocation = i;
                }
                else if(i != weaponLocation)
                {
                    rooms[i] = "|____|";
                }
            }

            foreach (string room in rooms)
            {
                Console.Write($"{room} ");
            }
        }
    }
}