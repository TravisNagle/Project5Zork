////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project5Zork
// File Name: Goblin.cs
// Description: Goblin monster that inherits from the monster class
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Travis Nagle, naglet@etsu.edu, Department of Computing, East Tennessee State University
// Created: 11/30/22
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
    /// Implementation of the goblin class that inherits from monster
    /// </summary>
    public class Goblin : Monster
    {
        /// <summary>
        /// Creates the default goblin object
        /// </summary>
        public Goblin() : base()
        {
            Dead = false;
            Health = 15;
            Name = "Goblin";
            Weapon = new Weapon(6, "Knife");
        }

        /// <summary>
        /// Sets goblin info to a string
        /// </summary>
        /// <returns>Goblin as a string</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
