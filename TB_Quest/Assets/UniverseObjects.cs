using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// static class to hold all objects in the game universe; locations, game objects, npc's
    /// </summary>
    class UniverseObjects
    {
        private static List<Location> locations = new List<Location>()
        {

            new Location
            {
               Name = "Wizard's Tower - Your Room",
                LocationID = 1,
                Description = "" +
                    "" +
                    "",
                IsAccessible = true,
                AccessibleTo =  new List<int>(){ 2 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Wizard's Tower - Master's Magical Menagerie",
                LocationID = 2,
                Description = "" +
                    "" +
                    "",
                //GeneralContents = "- stuff in the room -",
                IsAccessible = true,
                AccessibleTo =  new List<int>(){ 1, 3 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Wizard's Tower - Entry Hall",
                LocationID = 3,
                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = false,
                AccessibleTo =  new List<int>(){ 2, 4 }
                //ExperiencePoints = 20
            },

                        new Location
            {
               Name = "The Wall",
                LocationID = 4,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessibleTo =  new List<int>(){ 3, 5 }
                //ExperiencePoints = 10
            }
        };

        public static List<Location> Locations { get => locations; set => locations = value; }
    }
}
