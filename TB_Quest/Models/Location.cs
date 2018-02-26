using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// base class for game objects
    /// </summary>
    public class Location : GameObject
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        private List<int> _accessibleTo;


        #endregion

        #region PROPERTIES

        public List<int> AccessibleTo
        {
            get { return _accessibleTo; }
            set { _accessibleTo = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Location()
        {

        }

        public Location(string description, int locationID, string name, int objectID)
        {
            base.Description = description;
            base.LocationID = locationID;
            base.Name = name;
            base.ObjectID = objectID;

        }

        #endregion

        #region METHODS

        #endregion
    }
}
