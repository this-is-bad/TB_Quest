using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    class InanimateObject : GameObject
    {
#region FIELDS

        private bool _canInventory;

        private InanimateObjectType _inanimateObjType;

        private bool _isConsumable;

        private bool _isVisible;

        private int _value;
        
        #endregion

        #region PROPERTIES

        public override string Description { get; set; }
        public override int LocationID { get; set; }
        public override string Name { get; set; }
        public override int ObjectID { get; set; }

        /// <summary>
        /// can the InanimateObject be added to inventory?
        /// </summary>
        public bool CanInventory
        {
            get { return _canInventory; }
            set { _canInventory = value; }
        }

        /// <summary>
        /// the type of the InanimateObject
        /// </summary>
        public InanimateObjectType InanimateObjType
        {
            get { return _inanimateObjType; }
            set { _inanimateObjType = value; }
        }

        /// <summary>
        /// is the InanimateObject consumable?
        /// </summary>
        public bool IsConsumable
        {
            get { return _isConsumable; }
            set { _isConsumable = value; }
        }

        /// <summary>
        /// is the InanimateObject visible?
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

        /// <summary>
        /// the monetary value of the InanimateObject
        /// </summary>
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

#endregion

    }
}
