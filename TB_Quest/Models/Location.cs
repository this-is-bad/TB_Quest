using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// class for location objects
    /// </summary>
    public class Location : GameObject
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        private List<int> _accessibleTo;
        private bool _isAccessible;
        private int _experiencePoints;


        #endregion

        #region PROPERTIES
        /// <summary>
        /// locations that the current location can be accessed from
        /// </summary>
        public List<int> AccessibleTo
        {
            get { return _accessibleTo; }
            set { _accessibleTo = value; }
        }

        /// <summary>
        /// determines whether the location is accessible
        /// </summary>
        public bool IsAccessible
        {
            get { return _isAccessible; }
            set { _isAccessible = value; }
        }

        /// <summary>
        /// the number of experience points to be gained by visiting the location
        /// </summary>
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
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
