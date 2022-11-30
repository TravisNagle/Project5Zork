////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project5Zork
// File Name: Dragon.cs
// Description: Creates a Dragon object that can be one of three types with different properties
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
    /// Implementation of the dragon class that inherits from monster
    /// </summary>
    public class Dragon : Monster
    {
        /// <summary>
        /// Creates a default dragon object that can be of one of
        /// three types
        /// </summary>
        public Dragon() : base()
        {
            Random rand = new Random();
            Dead = false;
            int type = rand.Next(0, 3);

            switch (type)
            {
                case 0:
                    Name = "Blue Dragon";
                    Health = 30;
                    Weapon = new Weapon(10, "Blue Dragon Breath");
                    break;

                case 1:
                    Name = "Black Dragon";
                    Health = 35;
                    Weapon = new Weapon(12, "Black Dragon Breath");
                    break;

                case 2:
                    Name = "Red Dragon";
                    Health = 40;
                    Weapon = new Weapon(5, "Red Dragon Claws");
                    break;
            }
        }

        /// <summary>
        /// Converts dragon info to a string
        /// </summary>
        /// <returns>Dragon as a string</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
