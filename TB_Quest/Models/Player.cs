using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Player : Character
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS
        private string _homeVillage;
        private int _lives;
        private List<int> _locationsVisited;
        private bool _verboseGreeting;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// the player's home village
        /// </summary>
        public string HomeVillage
        {
            get { return _homeVillage; }
            set { _homeVillage = value; }
        }

        /// <summary>
        /// the player's lives
        /// </summary>
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        /// <summary>
        /// the locations visited by the player
        /// </summary>
        public List<int> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        /// <summary>
        /// boolean that determines whether to use the default character greeting or the more verbose player greeting
        /// </summary>
        public bool VerboseGreeting
        {
            get { return _verboseGreeting; }
            set { _verboseGreeting = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<int>();
           // _inventory = new List<InanimateObject>();
        }

        public Player(string name, RaceType race, int locationID) : base(name, race, locationID)
        {
            _locationsVisited = new List<int>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// a more verbose greeting that overrides the bash character greeting
        /// </summary>
        /// <returns>string</returns>
        public override string Greeting()
        {
            if (_verboseGreeting)
            {
                return $"Hello, my name is {base.Name}.  I am a {base.Race} and I am from {_homeVillage}.";

            }
            else
            {
                return base.Greeting();
            }
        }

        /// <summary>
        /// determines whether the player has visited a location
        /// </summary>
        /// <param name="_locationID"></param>
        /// <returns>bool</returns>
        public bool HasVisited(int _locationID)
        {
            if (LocationsVisited.Contains(_locationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
