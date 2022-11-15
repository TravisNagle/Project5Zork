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
            int numOfRooms = rand.Next(5, 11);
            bool weaponSpawned = false;
            int weaponLocation = -1;

            List<string> rooms = new List<string>();
            rooms.Add("|P___|");

            for(int i = 0; i < numOfRooms - 1; i++)
            {
                int monsterSpawn = rand.Next(0, 2);
                int monsterLocation = -1;

                if(monsterSpawn == 1)
                {
                    rooms.Add("|_M__|");
                    monsterLocation = i;
                }
                else if(weaponSpawned = false && monsterSpawn == 0)
                {
                    int weaponSpawn = rand.Next(0, 2);
                    if(weaponSpawn == 1)
                    {
                        rooms.Add("|__St|");
                        weaponLocation = i;
                        weaponSpawned = true;
                    }
                    else if(weaponSpawn == 2)
                    {
                        rooms.Add("|__Sw|");
                        weaponLocation = i;
                        weaponSpawned = true;
                    }
                    else if(i == rooms.Count - 1)
                    {
                        if(weaponSpawn == 1)
                        {
                            rooms.Add("|__St|");
                            weaponLocation = i;
                            weaponSpawned = true;
                        }
                        else if(weaponSpawn == 0)
                        {
                            rooms.Add("|__Sw|");
                            weaponLocation = i;
                            weaponSpawned = true;
                        }
                    }
                }
                else
                {
                    rooms.Add("|____|");
                }
            }

            foreach (string room in rooms)
            {
                Console.Write($"{room} ");
            }


        }
    }
}