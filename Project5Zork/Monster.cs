////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project5Zork
// File Name: Monster.cs
// Description: Monster object that keeps track of monster information
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Travis Nagle, naglet@etsu.edu, Department of Computing, East Tennessee State University
// Created: 11/26/22
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
    /// Implementation of the monster class
    /// </summary>
    public class Monster : Participant
    {
        /// <summary>
        /// Default Monster constructor that sets health to 20
        /// and uses an "Unarmed" weapon with 4 damage
        /// </summary>
        public Monster() : base()
        {
            Dead = false;
            Health = 20;
            Name = "Monster";
            Weapon = new Weapon(4, "Unarmed");
        }

        public void SetHealth(int health)
        {
            Health = health;
        }

        /// <summary>
        /// CalcDamage method that keeps track of the players weapon
        /// to take the correct number of health away from the monster
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="monster">The monster the player is fighting</param>
        /// <returns></returns>
        public override int CalcDamage(Player player, Monster monster)
        {
            Health = Health - player.GetWeapon().Attack;
            Console.WriteLine($"The Monster has taken damage!\nHealth: {Health}");

            if (Health <= 0)
            {
                Console.WriteLine($"The Monster has died.");
                Console.WriteLine("VICTORY");
                Dead = true;
            }
            return Health;
        }

        /// <summary>
        /// Monster ToString method that converts monster information to string
        /// </summary>
        /// <returns>Monster info as a string</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
