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
    public abstract class GameObject
    {
        #region ENUMERABLES

        #endregion

        #region FIELDS

        #endregion

        #region PROPERTIES

        public abstract string Description { get; set; }
        public abstract int LocationID { get; set; }
        public abstract string Name { get; set; }
        public abstract int ObjectID { get; set; }
        public abstract int ExperiencePoints { get; set; }

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        #endregion
    }
}
