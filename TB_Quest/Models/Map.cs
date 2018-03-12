using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
     /// <summary>
     /// class for the game map 
     /// </summary>
    public class Map : GameObject
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS
        private List<Location> _locationList;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// determines whether the location is accessible
        /// </summary>
        public List<Location> LocationList
        {
            get { return _locationList; }
            set { _locationList = value; }
        }


        #endregion

        #region CONSTRUCTORS

        public Map()
        {

        }

        #endregion

        #region METHODS

        #endregion
    }
}

