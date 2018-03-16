using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    public class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****


        private List<Character> _characters;

        private List<GameObject> _gameObjects;

        private List<Item> _items;

        private List<Location> _locations;

        private List<Treasure> _treasures;

        //
        // list of all characters
        //
        public List<Character> Characters
        {
            get { return _characters; }
            set { _characters = value; }
        }

        //
        // list of all objects in the game
        //
        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        //
        // list of all items
        //
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        //
        // list of all locations
        //
        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }

        //
        // list of all treasures
        //
        public List<Treasure> Treasures
        {
            get { return _treasures; }
            set { _treasures = value; }
        }

        #endregion

        #region ***** constructor *****

        //
        // default Universe constructor
        //
        public Universe()
        {
            //
            // add all of the universe objects to the game
            // 
            IntializeUniverse();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the universe with all of the locations
        /// </summary>
        private void IntializeUniverse()
        {
            _locations = UniverseObjects.Locations;
            _gameObjects = UniverseObjects.GameObjects;
            _items = UniverseObjects.Items;
            _treasures = UniverseObjects.Treasures;
            _characters = UniverseObjects.Characters;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// verify that location ID is valid
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>bool</returns>
        public bool IsValidLocationId(int locationId)
        {
            List<int> LocationIds = new List<int>();

            //
            // create a list of location ids
            //
            foreach (Location loc in _locations)
            {
                LocationIds.Add(loc.LocationID);
            }

            //
            // determine if the location id is a valid id and return the result
            //
            if (LocationIds.Contains(locationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int locationId)
        {
            Location Location = GetLocationById(locationId);
            if (Location.IsAccessible == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// return the max available ID for a Location object
        /// </summary>
        /// <returns>next Location.LocationID </returns>
        public int GetMaxLocationId()
        {
            int MaxId = 0;

            foreach (Location Location in Locations)
            {
                if (Location.LocationID > MaxId)
                {
                    MaxId = Location.LocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// checks for valid location ID
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns>boolean</returns>
        public bool IsValidLocation(int locationId)
        {
            List<int> locationIds = new List<int>();

            //
            // create a list of location IDs
            // 
            foreach (Location l in _locations)
            {
                locationIds.Add(l.LocationID);
            }

            //
            // determine if the location ID is a valid ID and return the result
            //
            if (locationIds.Contains(locationId))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// get a Location object using an Id
        /// </summary>
        /// <param name="Id">location Id</param>
        /// <returns>requested location</returns>
        public Location GetLocationById(int id)
        {
            Location location = null;

            //
            // run through the location list and grab the correct one
            //
            foreach (Location loc in _locations)
            {
                if (loc.LocationID == id)
                {
                    location = loc;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw an exception
            //
            if (location == null)
            {
                string feedbackMessage = $"The Location ID {id} does not exist in the current realm.";
                throw new ArgumentException(id.ToString(), feedbackMessage);
            }

            return location;
        }

        /// <summary>
        /// get a list of locations accessible from the current location
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List<location></location></returns>
        public List<Location> GetLocationsFromCurrentLocationID(int id)
        {
            Location location = GetLocationById(id);

            List<Location> locations = new List<Location>(); ;

            foreach (int locationId in location.AccessTo)
            {
                locations.Add(GetLocationById(locationId));
            }

            return locations;
        }

        /// <summary>
        /// get a list of location IDs for locations that are accessible from the current location
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List<location></location></returns>
        public List<int> GetLocationIDsFromCurrentLocationID(int id)
        {
            Location location = GetLocationById(id);

            List<int> locations = new List<int>(); ;

            foreach (int locationId in location.AccessTo)
            {
                locations.Add(locationId);
            }

            return locations;
        }

        /// <summary>
        /// determine if the game object ID is a valid ID for the current location and return the result
        /// </summary>
        /// <param name="gameObjectId"></param>
        /// <param name="currentLocationId"></param>
        /// <returns>bool</returns>
        public bool IsValidObjectByLocationId(int gameObjectId, int currentLocationId)
        {
            List<int> gameObjectIds = new List<int>();

            //
            // create a list of game object IDs in the current location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationID == currentLocationId)
                {
                    gameObjectIds.Add(gameObject.ObjectID);
                }
            }

            //
            // determine if the game object ID is a valid ID and return the result
            //
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// get a GameObject that matches the ID passed to it
        /// </summary>
        /// <param name="iD"></param>
        /// <returns>GameObject</returns>
        public GameObject GetGameObjectById(int iD)
        {
            GameObject gameObjectToReturn = null;

            //
            // run through the game object list and grab the correct one
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.ObjectID == iD)
                {
                    gameObjectToReturn = gameObject; 
                }
            }

            //
            // the specified ID was not found in the universe
            // throw an exception
            //
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Game Object ID {iD} does not exist in the current Universe.";
                throw new ArgumentException(feedbackMessage, iD.ToString());
            }

            return gameObjectToReturn;

        }

        /// <summary>
        /// get a list of locations accessible from the current location
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List<location></location></returns>
        public List<GameObject> GetLocationsByLocationID(int locationId)
        {
            List<GameObject> gameObjects = new List<GameObject>(); ;

            foreach (GameObject gameObject in gameObjects)
            {
                if (gameObject.LocationID == locationId)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        /// <summary>
        /// get a list of GameObjects for the current location ID
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns> List<GameObject></returns>
        public List<GameObject> GetGameObjectsByLocationId(int locationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //
            // run through the game object list and grab all that are in the current location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationID == locationId)
                {
                    GameObjects.Add(gameObject);
                }
            }
            return gameObjects;
        }
        #endregion
    }
}
