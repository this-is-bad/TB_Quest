﻿using System;
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
        private Dictionary<int, int> _locationAccessList;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// list of locations
        /// </summary>
        public List<Location> LocationList
        {
            get { return _locationList; }
            set { _locationList = value; }
        }

        /// <summary>
        /// dictionary that contains
        /// </summary>
        public Dictionary<int, int> LocationAccessList
        {
            get { return _locationAccessList; }
            set { _locationAccessList = value; }
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

