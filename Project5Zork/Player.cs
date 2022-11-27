////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project5Zork
// File Name: Player.cs
// Description: Player object that keeps track of player info (Health, Weapon, Name)
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Travis Nagle, naglet@etsu.edu, Department of Computing, East Tennessee State University
// Created: 11/26/2022
// Copyright: Travis Nagle, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5Zork
{
    /// <summary>
    /// Implementation of the Player class that inherits from Participant. 
    /// Created once the player starts the game.
    /// </summary>
    public class Player : Participant
    {
        public bool HasStick { get; set; } = false;
        public bool HasSword { get; set; } = false;

        /// <summary>
        /// Default Player constructor that creates the player with the standard
        /// amount of health an "Unarmed" weapon.
        /// </summary>
        public Player() : base()
        {
            Dead = false;
            Health = 100;
            Name = "Player";
            Weapon = new Weapon(5, "Unarmed");
        }

        /// <summary>
        /// Overrides the CalcDamage abstract method from Participant that
        /// calculates the number of damage the player has taken and, if 
        /// health reaches <= 0, the player is considered "dead".
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="monster">The monster the player is fighting</param>
        /// <returns>The health of the player at the end of each attack</returns>
        public override int CalcDamage(Player player, Monster monster)
        {
            Health = Health - monster.GetWeapon().Attack;
            Console.WriteLine($"The Player has taken damage!\nHealth: {Health}");

            if (Health <= 0)
            {
                Console.WriteLine($"The Player has died.\nGame Over");
                Dead = true;
            }
            return Health;
        }

        /// <summary>
        /// GetWeapon method that sets the players weapon to whichever
        /// weapon the player has picked up.
        /// </summary>
        public void PlayerWeapon()
        {
            if (HasStick)
                Weapon = new Weapon(6, "Stick");
            else if (HasSword)
                Weapon = new Weapon(8, "Sword");
        }

        /// <summary>
        /// Player ToString method that displays the players information
        /// </summary>
        /// <returns>Player info as a string</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
