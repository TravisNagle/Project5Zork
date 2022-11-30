////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project5Zork
// File Name: GameDriver.cs
// Description: Driver for the Zork game that takes care of menu functions, dungeon layout, and battle functions
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Travis Nagle, naglet@etsu.edu, Department of Computing, East Tennessee State University
// Created: 11/26/22
// Copyright: Travis Nagle, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////

using System;
using System.Numerics;

namespace Project5Zork
{
    /// <summary>
    /// Driver class that takes care of user input and menu functions
    /// </summary>
    public class GameDriver
    {
        /// <summary>
        /// Main method that calls the menu
        /// </summary>
        public static void Main()
        {
            Menu();
        }

        /// <summary>
        /// Menu for the Zork game that allows the player to enter the game or exit the game
        /// </summary>
        public static void Menu()
        {
            int userChoice = -1;
            bool validChoice = false;

            while(!validChoice || userChoice < 1 || userChoice > 2)
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

        /// <summary>
        /// PlayGame method that creates the unique dungeon layout
        /// for each Zork game and creates the player and monsters
        /// for the game.
        /// </summary>
        public static void PlayGame()
        {
            Random rand = new Random();
            int numOfRooms = rand.Next(5, 11);
            Weapon weapon = new Weapon(4, "Unarmed");
            bool stickSpawn = false;
            bool swordSpawn = false;

            Player player = new Player();
            Monster[] monsters = new Monster[numOfRooms];

            int playerLocation = 0;
            int weaponLocation = -1;
            List<int> monsterLocations = new List<int>();

            string[] rooms = new string[numOfRooms];
            rooms[0] = "|P___|";

            if(rand.Next(10000) < 5000) //50% chance of stick
            {
                weaponLocation = rand.Next(1, numOfRooms - 2);
                rooms[weaponLocation] = "|__St|";
                weapon = new Stick();
                stickSpawn = true;
            }
            else //50% chance of sword
            {
                weaponLocation = rand.Next(1, numOfRooms - 2);
                rooms[weaponLocation] = "|__Sw|";
                weapon = new Sword();
                swordSpawn = true;
            }

            for(int i = 1; i < rooms.Length; i++)
            {
                int monsterSpawn = rand.Next(0, 5);

                switch(monsterSpawn)
                {
                    case 1:
                        monsters[i] = new Monster();
                        rooms[i] = ("|_M__|");
                        monsterLocations.Add(i);

                        if (monsterLocations.Contains(weaponLocation))
                        {
                            if (stickSpawn)
                                rooms[weaponLocation] = ("|_MSt|");
                            else if (swordSpawn)
                                rooms[weaponLocation] = ("|_MSw|");
                        }
                        break;

                    case 2:
                        monsters[i] = new Goblin();
                        rooms[i] = ("|_G__|");
                        monsterLocations.Add(i);

                        if (monsterLocations.Contains(weaponLocation))
                        {
                            if (stickSpawn)
                                rooms[weaponLocation] = ("|_GSt|");
                            else if (swordSpawn)
                                rooms[weaponLocation] = ("|_GSw|");
                        }
                        break;

                    case 3:
                        monsters[i] = new Orc();
                        rooms[i] = ("|_O__|");
                        monsterLocations.Add(i);

                        if (monsterLocations.Contains(weaponLocation))
                        {
                            if (stickSpawn)
                                rooms[weaponLocation] = ("|_OSt|");
                            else if (swordSpawn)
                                rooms[weaponLocation] = ("|_OSw|");
                        }
                        break;

                    default:
                        if (i != weaponLocation)
                        {
                            rooms[i] = "|____|";
                        }
                        break;
                }
            }

            if(!monsterLocations.Contains(numOfRooms - 1))
            {
                monsters[numOfRooms - 1] = new Dragon();
                rooms[numOfRooms - 1] = ("|_D__|");
                monsterLocations.Add(numOfRooms - 1);
            }

            PlayerMovement(rooms, player, weapon, monsters, playerLocation, weaponLocation, monsterLocations);
            Menu();
        }

        /// <summary>
        /// PlayerMovement method that takes care of all player movements 
        /// and determining if a player will battle, pick up a weapon, enter 
        /// an empty room, and exit the dungeon.
        /// </summary>
        /// <param name="rooms">Every room in the dungeon</param>
        /// <param name="player">The player</param>
        /// <param name="weapon">The weapon that the player may pick up</param>
        /// <param name="monsters">Each monster in the dungeon</param>
        /// <param name="playerLocation">Variable that keeps track of player's location</param>
        /// <param name="weaponLocation">Variable that keeps track of the weapon's location</param>
        /// <param name="monsterLocations">Variable that keeps track of each monster location</param>
        public static void PlayerMovement(string[] rooms, Player player, Weapon weapon, Monster[] monsters, int playerLocation,
                                         int weaponLocation, List<int> monsterLocations)
        {
            string playerChoice = "";
            bool invalidMovement = false;
            while ((playerChoice != "go west" && playerChoice != "go east") || invalidMovement || !player.Dead) //Checks if the player movement is valid and if the player is dead
            {
                if (player.Dead)
                    break;

                foreach (string room in rooms) //Displays each room
                {
                    Console.Write($"{room} ");
                }
                Console.WriteLine($"\nYour remaining health points: {player.GetHealth()}"); //Displays the players remaining health points

                Console.Write("\nWhat would you like to do next? Your choices are 'go east' and 'go west'. "); //Asks for the direction the player would like to move
                playerChoice = Console.ReadLine();

                if (playerChoice != "go west" && playerChoice != "go east") //If player enters choice other than "go east" or "go west", ask again
                {
                    Console.WriteLine("\nI do not know what you mean.\n");
                }
                else if (playerChoice == "go west" && playerLocation == 0) //If player is unable to "go west" from the start, for example, the player must choose again
                {
                    Console.WriteLine("\nSorry, but I can't go that direction.\n");
                    invalidMovement = true;
                }
                else if (playerChoice == "go east" && playerLocation == rooms.Length - 1) //Checks if player will go past the final room of fthe dungeon
                {
                    Console.WriteLine("\nYou have beaten the dungeon!\n");
                    break;
                }
                else if (playerChoice == "go east") //Moves player one spot east by swapping room values
                {
                    playerLocation++;
                    rooms[playerLocation - 1] = "|____|";
                    rooms[playerLocation] = "|P___|";

                    if (playerLocation == weaponLocation)
                    {
                        weaponLocation = -1;
                        Console.WriteLine("\n------------WEAPON PICKUP------------");
                        if (weapon is Stick)
                        {
                            Console.WriteLine("You have obtained a Stick!\n");
                            player.HasStick = true;
                            player.PlayerWeapon();
                        }
                        else if (weapon is Sword)
                        {
                            Console.WriteLine("You have obtained a Sword!\n");
                            player.HasSword = true;
                            player.PlayerWeapon();
                        }
                    }

                    if (monsterLocations.Contains(playerLocation)) //Checks if playerlocation = monsterlocation
                    {
                        Console.WriteLine("There is a monster here!");
                        Battle(player, monsters[monsterLocations.First()]);
                        monsterLocations.Remove(playerLocation);
                    }
                }
                else //Moves player one spot west by swapping room values
                {
                    playerLocation--;
                    rooms[playerLocation + 1] = "|____|";
                    rooms[playerLocation] = "|P___|";
                }
            }
        }

        /// <summary>
        /// Battle method that takes care of hit chances and calling each
        /// participants CalcDamage method
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="monster">The monster the player is currently fighting</param>
        public static void Battle(Player player, Monster monster)
        {
            Random rand = new Random();
            Console.WriteLine("\n------------BATTLE------------");
            while(!player.Dead && !monster.Dead)
            {
                if(rand.Next(10000) < 1000) //10% chance of missing
                {
                    Console.WriteLine("A miss!");
                    Console.ReadLine();
                }
                else
                {

                    monster.CalcDamage(player, monster); //Monster takes damage
                    Console.WriteLine($"The {monster.GetName()} has taken damage!\nHealth: {monster.GetHealth()}");
                    Console.ReadLine();

                    if (monster.Dead)
                    {
                        Console.WriteLine($"The {monster.GetName()} has died.\n");
                        Console.WriteLine("VICTORY\n");
                        break;
                    }
                }

                if(rand.Next(10000) < 2000) //20% chance of missing
                {
                    Console.WriteLine($"The {monster.GetName()} missed the player.");
                    Console.ReadLine();
                }
                else
                {
                    player.CalcDamage(player, monster); //Player takes damage
                    Console.WriteLine($"The Player has taken damage!\nHealth: {player.GetHealth()}");
                    Console.ReadLine();
                    if(player.Dead)
                    {
                        Console.WriteLine($"The Player has died.\nGame Over\n");
                        break;
                    }
                }
            }
        }
    }
}