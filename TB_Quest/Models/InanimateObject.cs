using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    public class InanimateObject : GameObject
    {
#region FIELDS

        private bool _canInventory;
        private InanimateObjectType _inanimateObjType;
        private bool _isConsumable;
        private bool _isVisible;
        private int _value;
        private string _pickUpMessage;
        private string _putDownMessage;
        private int _locationID;

        #endregion

        #region PROPERTIES

        public override string Description { get; set; }
        public override string Name { get; set; }
        public override int ObjectID { get; set; }
        public override int ExperiencePoints { get; set; }

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

        /// <summary>
        /// message to display when an item is picked up
        /// </summary>
        public string PickUpMessage
        {
            get { return _pickUpMessage; }
            set { _pickUpMessage = value; }
        }

        /// <summary>
        /// message to display when an item is put down
        /// </summary>
        public string PutDownMessage
        {
            get { return _putDownMessage; }
            set { _putDownMessage = value; }
        }

        /// <summary>
        /// location ID of the object
        /// </summary>
        public override int LocationID
        {
            get { return _locationID; }
            set
            {
                _locationID = value;
                if (value == 0)
                {
                    OnObjectAddedToInventory();
                }
            }
        }
   
        #endregion

        #region CONSTRUCTORS
        public InanimateObject()
        {
        }
        #endregion

        #region EVENT HANDLERS
        public event EventHandler ObjectAddedToInventory;

        #endregion

        #region METHODS
        public void OnObjectAddedToInventory() => ObjectAddedToInventory?.Invoke(this, EventArgs.Empty);
        #endregion
    }
}
