////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project5Zork
// File Name: Sword.cs
// Description: Creates a new sword object with constructors and inheritance from Weapon
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
    /// Implementation of the Sword class that inherits from Weapon
    /// </summary>
    public class Sword : Weapon
    {
        /// <summary>
        /// Default Sword Constructor that creates a default sword
        /// </summary>
        public Sword() : base()
        {
            Attack = 8;
            Name = "Sword";
        }

        /// <summary>
        /// Parameterized Sword Constructor that creates a new sword
        /// with the given parameters
        /// </summary>
        /// <param name="attack">Given attack value</param>
        /// <param name="name">Given weapon name</param>
        public Sword(int attack, string name) : base(attack, name)
        {
            Attack = attack;
            Name = name;
        }

        /// <summary>
        /// Copy Sword Constructor that creates a new sword
        /// copied from an existing sword object
        /// </summary>
        /// <param name="existingSword">Already created sword object</param>
        public Sword(Sword existingSword)
        {
            Attack = existingSword.Attack;
            Name = existingSword.Name;
        }

        /// <summary>
        /// ToString method for the sword class
        /// </summary>
        /// <returns>Sword info as a string</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
