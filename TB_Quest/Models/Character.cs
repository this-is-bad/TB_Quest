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

        public enum RaceType
        {
            None,
            Human,
            Elf,
            Vogon
        }

        #endregion

        #region FIELDS

        //private string _name;
        //private int _locationID;
        private int _age;
        private RaceType _race;
        //private Dictionary<objectId, Description> _inventory;

        #endregion

        #region PROPERTIES

        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}

        //public int LocationID
        //{
        //    get { return _locationID; }
        //    set { _locationID = value; }
        //}

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int locationID)
        {
            base.Name = name;
            _race = race;
            base.LocationID = locationID;
        }

        #endregion

        #region METHODS

        public virtual string Greeting()
        {
            return $"Hello, my name is {base.Name} and I am a {_race}.";
        }

        #endregion
    }
}
