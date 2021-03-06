﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character : GameObject
    {
        #region ENUMERABLES

        /// <summary>
        /// available character races
        /// </summary>
        public enum RaceType
        {
            None,
            Human,
            Elf,
            Vogon
        }

        #endregion

        #region FIELDS
        
        private int _age;
        private int _health;
        private RaceType _race;
        private List<InanimateObject> _inventory;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// the character's description
        /// </summary>
        public override string Description { get; set; }

        /// <summary>
        /// the character's location ID
        /// </summary>
        public override int LocationID { get; set; }

        /// <summary>
        /// the character's name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// the character's object ID
        /// </summary>
        public override int ObjectID { get; set; }

        /// <summary>
        /// the character's experience points
        /// </summary>
        public override int ExperiencePoints { get; set; }

        /// <summary>
        /// the character's age
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        /// <summary>
        /// the character's health
        /// </summary>
        public virtual int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        /// <summary>
        /// the character's race
        /// </summary>
        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {
            _inventory = new List<InanimateObject>();
        }

        public Character(string name, RaceType race, int locationID)
        {
            Name = name;
            _race = race;
            LocationID = locationID;
            _inventory = new List<InanimateObject>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// default greeting message from the character
        /// </summary>
        /// <returns>string</returns>
        public virtual string Greeting()
        {
            return $"Hello, my name is {Name} and I am a {_race}.";
        }

        #endregion
    }
}
