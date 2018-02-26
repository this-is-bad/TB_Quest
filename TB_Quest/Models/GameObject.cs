using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// base class for all game objects
    /// </summary>
    public class GameObject
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        private string _description;
        private int _locationID;
        private string _name;
        private int _objectID;


        #endregion

        #region PROPERTIES

        /// <summary>
        /// the descrition of the object
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        /// <summary>
        /// the current location ID of the object
        /// </summary>
        public int LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

        /// <summary>
        /// the unique ID of the object
        /// </summary>
        public int ObjectID
        {
            get { return _objectID; }
            set { _objectID = value; }
        }

        /// <summary>
        /// the name of the object
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public GameObject()
        {

        }

        public GameObject(string description, int locationID, string name, int objectID)
        {
            _description = description;
            _locationID = locationID;
            _name = name;
            _objectID = objectID;

        }

        #endregion

        #region METHODS

        #endregion
    }
}
