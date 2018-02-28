﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    class Universe
    {
        #region ***** define all lists to be maintained by the Universe object *****

        //
        // list of all locations
        //
        private List<Location> _Locations;

        public List<Location> Locations
        {
            get { return _Locations; }
            set { _Locations = value; }
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
            _Locations = UniverseObjects.Locations;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        public bool IsValidLocationId(int LocationId)
        {
            List<int> LocationIds = new List<int>();

            //
            // create a list of location ids
            //
            foreach (Location stl in _Locations)
            {
                LocationIds.Add(stl.LocationID);
            }

            //
            // determine if the location id is a valid id and return the result
            //
            if (LocationIds.Contains(LocationId))
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
        /// <param name="LocationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int LocationId)
        {
            Location Location = GetLocationById(LocationId);
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
        /// return the next available ID for a Location object
        /// </summary>
        /// <returns>next LocationObjectID </returns>
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
        /// get a Location object using an Id
        /// </summary>
        /// <param name="Id">location Id</param>
        /// <returns>requested location</returns>
        public Location GetLocationById(int Id)
        {
            Location Location = null;

            //
            // run through the location list and grab the correct one
            //
            foreach (Location location in _Locations)
            {
                if (location.LocationID == Id)
                {
                    Location = location;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (Location == null)
            {
                string feedbackMessage = $"The Location ID {Id} does not exist in the current Realm.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return Location;
        }

        #endregion
    }
}