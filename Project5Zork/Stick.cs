////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project5Zork
// File Name: Stick.cs
// Description: Stick weapon that deals 
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
    /// Implementation of the stick class that inherits from Weapon
    /// </summary>
    public class Stick : Weapon
    {
        /// <summary>
        /// Default stick constructor that creates a new stick
        /// </summary>
        /// <param name="attack">Stick's attack value</param>
        /// <param name="name">Stick's name</param>
        public Stick() : base()
        {
            Attack = 6;
            Name = "Stick";
        }

        /// <summary>
        /// Parameterized Stick constructor that creates a new 
        /// stick object with the given parameters
        /// </summary>
        /// <param name="attack">Given attack value</param>
        /// <param name="name">Given weapon name</param>
        public Stick(int attack, string name) : base(attack, name)
        {
            Attack = attack;  
            Name = name;
        }

        /// <summary>
        /// Copy Stick constructor that creates a new Stick
        /// that is a copy of an existing Stick
        /// </summary>
        /// <param name="existingStick">A created Stick object</param>
        public Stick(Stick existingStick)
        {
            Attack = existingStick.Attack;
            Name = existingStick.Name;
        }
    }
}
