////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project5Zork
// File Name: Weapon.cs
// Description: Creates the weapon class with all weapon information
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
    /// Implementation of the Weapon class with Attack and Name attributes
    /// </summary>
    public class Weapon
    {
        public int Attack { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Default Weapon constructor that creates an empty weapon
        /// </summary>
        public Weapon()
        {
            Attack = 0;
            Name = "";
        }

        /// <summary>
        /// Parameterized Weapon constructor that creates a new weapon
        /// </summary>
        /// <param name="attack">The attack value of the weapon</param>
        /// <param name="name">The name of the weapon</param>
        public Weapon(int attack, string name)
        {
            Attack = attack;
            Name = name;
        }

        /// <summary>
        /// Copy Weapon constructor that creates a copy of an existing weapon
        /// </summary>
        /// <param name="existingWeapon">An already created weapon</param>
        public Weapon(Weapon existingWeapon)
        {
            Attack = existingWeapon.Attack;
            Name = existingWeapon.Name;
        }

        /// <summary>
        /// GetAttack method that returns the attack value of the weapon
        /// </summary>
        /// <returns>Weapon attack value</returns>
        public int GetAttack()
        {
            return Attack;
        }

        /// <summary>
        /// ToString method that displays the name and attack values
        /// </summary>
        /// <returns>Weapon info as a string</returns>
        public override string ToString()
        {
            string info = $"\nName: {Name}";
            info += $"\nAttack: {Attack}";

            return info;
        }
    }
}
