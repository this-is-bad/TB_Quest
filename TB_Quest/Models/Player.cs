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

        private bool _verboseGreeting;
        #endregion


        #region PROPERTIES
        public string HomeVillage
        {
            get { return _homeVillage; }
            set { _homeVillage = value; }
        }

        public bool VerboseGreeting
        {
            get { return _verboseGreeting; }
            set { _verboseGreeting = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Player()
        {

        }

        public Player(string name, RaceType race, int locationID) : base(name, race, locationID)
        {

        }

        #endregion


        #region METHODS

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
        #endregion
    }
}
