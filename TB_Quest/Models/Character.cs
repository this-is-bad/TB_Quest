using System;
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

        private int _experiencePoints;
        private int _age;
        private int _health;
        private RaceType _race;
        private List<InanimateObject> _inventory;

        #endregion

        #region PROPERTIES

        public override string Description { get; set; }
        public override int LocationID { get; set; }
        public override string Name { get; set; }
        public override int ObjectID { get; set; }
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
        public int Health
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

        /// <summary>
        /// the character's inventory
        /// </summary>
        public List<InanimateObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
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
