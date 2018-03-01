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
                AccessTo =  new List<int>(){ 2 }
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
                AccessTo =  new List<int>(){ 1, 3 }
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
                AccessTo =  new List<int>(){ 2, 4 }
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
                AccessTo =  new List<int>(){ 3, 5 }
                //ExperiencePoints = 10
            },

             new Location
            {
               Name = "Magic Hedge Maze - Entrance",
                LocationID = 5,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 6, 9 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 6,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 4, 5, 7 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 7,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 6, 8, 11 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze - Dead End",
                LocationID = 8,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 7 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 9,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 5, 10, 13 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 10,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 9, 14 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 11,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 7, 12, 15 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 12,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 11, 16 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze - Dead End",
                LocationID = 13,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 9 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 14,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 10, 17 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze - Dead End",
                LocationID = 15,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 11 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze - Dead End",
                LocationID = 16,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 12 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Lake of Acid",
                LocationID = 17,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = false,
                AccessTo =  new List<int>(){ 16, 18 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Ancient Battlefield",
                LocationID = 18,

                Description = "" +
                              "" +
                              "",
                //GeneralContents = "",
                IsAccessible = false,
                AccessTo =  new List<int>(){ }
                //ExperiencePoints = 10
            }
        };

        public static List<Location> Locations { get => locations; set => locations = value; }
    }
}
