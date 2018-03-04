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
                Description = "You are currently in your room in your master's tower.\n"  +
                "It is a sparse room, containing nothing more than a bed, a desk, a light,\n" +
                "and a small wardrobe -- an appropriate room for an apprentice.\n" +
                " \n" +
                "Before you begin your quest, you must prepare for your journey.\n" +
                " \n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.",
        IsAccessible = true,
                AccessTo =  new List<int>(){ 2 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Wizard's Tower - Master's Magical Menagerie",
                LocationID = 2,
                Description = "You stand in your master's magical menagerie: a collection of magical artifacts, materials, books, contraptions, and even automata.  " +
                    "While not a true menageries, containing no living things or even preserved specimens, the master's magical menagerie is a good bit of alliteration.  " +
                    "So, you can take your semantics and shove them." +
                    "In front of you is the section of the menagerie that contains the things you are allowed to touch.",
                //GeneralContents = "- stuff in the room -",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 1, 3 }
                //ExperiencePoints = 10
            },

            new Location
            {
               Name = "Wizard's Tower - Entry Hall",
                LocationID = 3,
                Description = "You stand in the entry hall of your master's tower -- a modest room that portends nothing of the wondrous quest ahead of you.  " +
                              "On the other side of the front door, your journey awaits.\n" +
                              " \n " +
                              "Step through the door when you are ready to begin your quest: a quest in which you will certainly perish.",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 2, 4 }
                //ExperiencePoints = 20
            },

            new Location
            {
               Name = "The Wall",
                LocationID = 4,

                Description = "You have traveled many weeks to get here.  You crossed the Pits of Evil Fire.  " +
                              "You scaled the Cliffs of Modest Scalability.  You perservered through Hodeg's " +
                              "Valley of Cute Puppies and Cuddly Kittens.  You survived the interminable boredom " +
                              "of the Featureless Plains.  You waded through the Swamp of the Indifferent Gators.  " +
                              "You bested Cludar in an Indecision dance-off." +
                              "  ",
                //GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 3, 5 }
                //ExperiencePoints = 10
            },

             new Location
            {
               Name = "Magic Hedge Maze - Entrance",
                LocationID = 5,

                Description = "You stand in the first room of the magical hedge maze.  Somewhere in this maze " +
                              "lies a path to the lair of the dragon Jeedub'ex.  You are beginning to feel the " + 
                              "weight of your quest.  Jeedub'ex is a powerful dragon that will surely kill you.\n" +
                              " \n " +
                              "Paths lead off to your left and right." +
                              "",
                //GeneralContents = "",
                IsAccessible = false,
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
