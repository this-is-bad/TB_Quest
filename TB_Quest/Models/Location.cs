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

        private List<int> _accessTo;
        private bool _isAccessible;
        private string _generalContents;


        #endregion

        #region PROPERTIES

        public override string Description { get; set; }
        public override int LocationID { get; set; }
        public override string Name { get; set; }
        public override int ObjectID { get; set; }
        public override int ExperiencePoints { get; set; }

        /// <summary>
        /// locations that the current location can be accessed from
        /// </summary>
        public List<int> AccessTo
        {
            get { return _accessTo; }
            set { _accessTo = value; }
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
        /// the objects in the location
        /// </summary>
        public string GeneralContents
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Location()
        {
      
        }

        public Location(string description, int locationID, string name, int objectID)
        {
            Description = description;
            LocationID = locationID;
            Name = name;
            ObjectID = objectID;

        }

        #endregion

        #region METHODS

        #endregion
    }
}
