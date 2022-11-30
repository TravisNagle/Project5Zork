////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project5Zork
// File Name: Participant.cs
// Description: Creates the participant class that keeps track of all participant information
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Travis Nagle, naglet@etsu.edu, Department of Computing, East Tennessee State University
// Created: 11/26/22
// Copyright: Travis Nagle, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////

namespace Project5Zork
{
    /// <summary>
    /// Implementation of the abstract participation class
    /// </summary>
    public abstract class Participant
    {
        protected int Health { get; set; }
        protected string Name { get; set; }
        protected Weapon Weapon { get; set; }
        public bool Dead { get; set; } = false;

        /// <summary>
        /// Default constructor for participant that creates
        /// an empty participant object.
        /// </summary>
        public Participant()
        {
            Health = 0;
            Name = "";
            Weapon = new Weapon(0, null);
        }

        /// <summary>
        /// Parameterized constructor that creates a participant
        /// with the given parameters
        /// </summary>
        /// <param name="health">Participant's health</param>
        /// <param name="name">Name of participant</param>
        /// <param name="weapon">Weapon participan is using</param>
        public Participant(int health, string name, Weapon weapon)
        {
            Health = health;
            Name = name;
            Weapon = weapon;
        }

        /// <summary>
        /// Copy constructor that creates a copy of an existing participant
        /// </summary>
        /// <param name="existingParticipant"></param>
        public Participant(Participant existingParticipant)
        {
            Name = existingParticipant.Name;
            Health = existingParticipant.Health;
            Weapon = existingParticipant.Weapon;
        }

        /// <summary>
        /// GetHealth method that returns the participant's health
        /// </summary>
        /// <returns>Participant's remaining health</returns>
        public int GetHealth()
        {
            return Health;
        }

        /// <summary>
        /// GetWeapon method that returns the participant's weapon
        /// </summary>
        /// <returns>Participant's current weapon</returns>
        public Weapon GetWeapon()
        {
            return Weapon;
        }

        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// Boolean that checks if a participant is dead
        /// </summary>
        /// <returns>the participant as dead</returns>
        public bool IsDead()
        {
            Dead = true;

            return Dead;
        }

        /// <summary>
        /// Abstract method that calculates the damage a participant
        /// is taking in a battle
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="monster">The monster the player is fighting</param>
        /// <returns>The remaining health of the participant</returns>
        public abstract int CalcDamage(Player player, Monster monster);

        /// <summary>
        /// ToString method that converts the participant's info to a string
        /// </summary>
        /// <returns>Participant info as string</returns>
        public override string ToString()
        {
            string info = "Participant---------------";
            info += $"\nName: {Name}";
            info += $"\nHealth: {Health}";
            info += $"\nWeapon--------------------{Weapon}";

            return info;
        }
    }
}
