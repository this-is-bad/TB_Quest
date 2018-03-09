﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    public class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all characters
        //
        private List<Character> _characters;

        //
        // list of all items
        //
        private List<Item> _items;

        //
        // list of all locations
        //
        private List<Location> _locations;

        //
        // list of all treasures
        //
        private List<Treasure> _treasures;

        public List<Character> Characters
        {
            get { return _characters; }
            set { _characters = value; }
        }

        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }

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

        #endregion
    }
}
