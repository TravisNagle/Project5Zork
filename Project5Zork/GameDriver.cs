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
            List<Weapon> weapons = new List<Weapon>();
            characters.Add(new Player());

            int numOfRooms = rand.Next(5, 11);
            int weaponChance = rand.Next(1, 4);
            int playerLocation = 0;
            int weaponLocation = -1;
            List<int> monsterLocations = new List<int>();

            string[] rooms = new string[numOfRooms];
            rooms[0] = "|P___|";

            if(weaponChance % 2 != 0)
            {
                weaponLocation = rand.Next(1, numOfRooms - 1);
                rooms[weaponLocation] = "|__St|";
                weapons.Add(new Stick(6, "Stick"));
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
                    characters.Add(new Monster());
                    rooms[i] = ("|_M__|");
                    monsterLocations.Add(i);
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

            string playerChoice = "";
            bool invalidMovement = false;
            bool gameOver = false;
            while((playerChoice != "left" && playerChoice != "right") || invalidMovement || !gameOver)
            {
                Console.Write("\nGo (left/right) ");
                playerChoice = Console.ReadLine();

                if(playerChoice != "left" && playerChoice != "right")
                {
                    Console.WriteLine("That was not a valid movement, please enter \"left\" or \"right\"");
                }
                else if(playerChoice == "left" && playerLocation == 0)
                {
                    Console.WriteLine("There is nowhere to move left!");
                    invalidMovement = true;
                }
                else if(playerChoice == "right" && playerLocation == numOfRooms - 1)
                {
                    Console.WriteLine("You have escaped!");
                    break;
                }
                else
                {
                    playerLocation++;
                    rooms[playerLocation - 1] = "|____|";
                    rooms[playerLocation] = "|P___|";
                    foreach(string room in rooms)
                        Console.Write($"{room} ");

                    if(monsterLocations.Contains(playerLocation))
                    {
                        Console.WriteLine("\n------------BATTLE------------");
                    }

                    if(playerLocation == weaponLocation)
                    {
                        Console.WriteLine("\n------------WEAPON PICKUP------------");
                        if (weapons[0] is Stick)
                            Console.WriteLine("You have obtained a Stick!");
                        else if (weapons[0] is Sword)
                            Console.WriteLine("You have obtained a Sword!");
                    }
                }
            }
        }
    }
}