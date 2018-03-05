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
                AccessTo =  new List<int>(){ 2 },
                ExperiencePoints = 10
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
                AccessTo =  new List<int>(){ 1, 3 },
                ExperiencePoints = 5
            },

            new Location
            {
               Name = "Wizard's Tower - Entry Hall",
                LocationID = 3,
                Description = "You stand in the entry hall of your master's tower -- a modest room that portends nothing of the wondrous quest ahead of you.  " +
                              "On the other side of the front door, your journey awaits.\n" +
                              " \n " +
                              "Step through the door when you are ready to begin your quest: a quest in which you will certainly perish.",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 2, 4 },
                ExperiencePoints = 5
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
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 3, 6 },
                ExperiencePoints = 10
            },

             new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 5,

                Description = "Another room in the hedge maze." +
                              "" +
                              "\n" +
                              " \n " +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 6, 9 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze - Entrance",
                LocationID = 6,

                Description = "You stand in the first room of the magical hedge maze.  Somewhere in this maze " +
                              "lies a path to the lair of the dragon Jeedub'ex.  You are beginning to feel the " +
                              "weight of your quest.  Jeedub'ex is a powerful dragon that will surely kill you.\n" +
                              " \n " +
                              "Paths lead off to your left and right." +
                              "",
                GeneralContents = "",
                IsAccessible = true, // false,
                AccessTo =  new List<int>(){ 4, 5, 7 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 7,

                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 6, 8, 11 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 8,

                Description = "Another dead end." +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 7 },
                ExperiencePoints = -10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 9,

                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 5, 10, 13 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 10,

                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 9, 14 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 11,

                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 7, 12, 15 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 12,

                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 11, 16 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 13,

                Description = "Another dead end." +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 9 },
                ExperiencePoints = -10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 14,

                Description = "Another room in the hedge maze.\n" +
                              "Oh, wait.  This is not another room in the hedge maze.  Well, technically speaking, " +
                              "it is another room in the hedge maze.  But, this room is different.  In the middle " +
                              "of the room, a marble statue stands on a pedestal.  There is an opening in the south " +
                              "wall of the room, beyond which lies a dull, red lake.  In front of the opening, a " +
                              "basset hound sits on the ground, watching you." +
                              "" +
                              "",       
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 10, 15, 17 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 15,

                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 11, 14},
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 16,

                Description = "Another dead end." +
                              "" +
                              "",
                GeneralContents = "",
                IsAccessible = true,
                AccessTo =  new List<int>(){ 12 },
                ExperiencePoints = -10
            },

            new Location
            {
               Name = "Lake of Acid",
                LocationID = 17,

                Description = "You stand at the edge of a large, dull red lake.  No breeze disturbs the stilless of " +
                              "the lake.  The air is dry, and smells faintly unpleasant.  There is no sign of life.  " +
                              "No bird song, not even the sound of an insect breaks the heavy silence.  Only the " +
                              "skeletons of various things, sparsely distributed around the lake's edge reveal the " +
                              "cause of the undefinable dread you feel in this place.  The skeletons all end at the " +
                              "lake's edge. \n" +
                              " \n " +
                              "That, and the brightly colored sign that reads: " +
                              "\"Caution: Lake of Acid!  Swim at your own risk!\" \n" +
                              " \n " +
                              "In the middle of the lake, lies your next destination: a small island.  In the middle " +
                              "this island, a stairway descends into the ground.",
                GeneralContents = "",
                IsAccessible = true, // false,
                AccessTo =  new List<int>(){ 14, 18 },
                ExperiencePoints = 20
            },

            new Location
            {
               Name = "Ancient Battlefield",
                LocationID = 18,

                Description = "You stand at the edge of an ancient battlefield: a location so remote and the casualties " +
                              "so great that the few survivors abandoned everything where it lay.  Across an expansive rolling " + 
                              "plain of short grass, fragments of weapons, armor, and machines of war jut out of the " +
                              "ground like weeds.  Where the grass is thin, bones are exposed in the hard dirt, like " +
                              "polished stones.  " +
                              "",
                GeneralContents = "",
                IsAccessible = true, // false,
                AccessTo =  new List<int>(){ },
                ExperiencePoints = 20
            }
        };

        public static List<Location> Locations { get => locations; set => locations = value; }
    }
}
