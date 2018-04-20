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
    public static partial class UniverseObjects
    {
        #region LOCATIONS
        private static List<Location> locations = new List<Location>()
        {

            new Location
            {
               Name = "Wizard's Tower - Your Room",
                ObjectID = 5,
                LocationID = 1,
                Description = "You are currently in your room in your master's tower.\n"  +
                "It is a sparse room, containing nothing more than a bed, a desk, a light,\n" +
                "and a small wardrobe -- an appropriate room for an apprentice.\n",
                GeneralContents = "There's nothing of interest in this room, you included.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 2 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Wizard's Tower - Master's Magical Menagerie",
                LocationID = 2,
                 ObjectID = 6,
                Description = "You stand in your master's magical menagerie: a collection of magical artifacts, materials, books, contraptions, and even automata.  " +
                    "While not a true menagerie, containing no living things or even preserved specimens, the master's magical menagerie is a good bit of alliteration.  " +
                    "So, you can take your semantics and shove them.  " +
                    "In front of you is the section of the menagerie that contains the things you are allowed to touch.",
                GeneralContents = "You stand in front of a large table that contains the portion of your master's collection " +
                    "that you are allowed to handle. You suspect that most of it is useless baubles and gadgets that the master only keeps to keep you " +
                    "occupied and distract you from the urge to handle the good items.  There are a few potentially useful items on this table, though.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 1, 3 },
                ExperiencePoints = 5
            },

            new Location
            {
               Name = "Wizard's Tower - Entry Hall",
                LocationID = 3,
                 ObjectID = 7,
                Description = "You stand in the entry hall of your master's tower -- a modest room that portends nothing of the wondrous quest ahead of you.  " +
                              "On the other side of the front door, your journey awaits.\n" +
                              " \n " +
                              "Step through the door when you are ready to begin your quest: a quest in which you will certainly perish.",
                GeneralContents = "Taking a look around before you set out on your adventure, you notice that this hallway is significantly safer than what waits " +
                                  "for you on the other side of the door.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 2, 4 },
                ExperiencePoints = 5
            },

            new Location
            {
               Name = "The Wall",
                LocationID = 4,
                ObjectID = 8,
                Description = "You have traveled many weeks and faced many trials to get here.  You crossed the Pits of Evil Fire.  " +
                              "Then, you crossed the Evil Pits of Fire.  You out-styled Cliff the Conjurer in a bare-knuckled contest of coiffure-mancy.  " +
                              "You scaled the Cliffs (no relation) of Modest Scalability.  You perservered through Hodeg's " +
                              "Valley of Cute Puppies and Cuddly Kittens.  You survived the interminable boredom " +
                              "of the Featureless Plains.  You waded through the Swamp of the Indifferent Gators.  " +
                              "You cavorted across the sea on a pirate party cruise.  You braved the many perils of the Perilous Path.  " +
                              "You bested Cludar the Fleet-Footed in an Indecision Dance-off.  You did some other stuff too.  And, finally, you " +
                              "have reached... a wall.",
                GeneralContents = "In front of you stands the Long Wall, measuring 15 feet high and hundreds of miles long.  But, your path does not end here.  " +
                                  "It continues through an opening in the wall, beyond which lies the Magic Hedge Maze.  In front of the opening, a wizard blocks " +
                                  "your path.  He looks determined to stay there.  You could use magic to scale the Wall but the need to enforce a narrative prevents " +
                                  "you from doing so.  You will have to find a way through the opening.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 3, 6 },
                ExperiencePoints = 10
            },

             new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 5,
                ObjectID = 9,
                Description = "Another room in the hedge maze." +
                              "" +
                              "\n" +
                              " \n " +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = true,

                AccessTo = new List<int>(){ 6, 9 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze - Entrance",
                LocationID = 6,
                ObjectID = 10,
                Description = "You stand in the first room of the magical hedge maze.  Somewhere in this maze " +
                              "lies a path to the lair of the dragon Jeedub'ex.  You are beginning to feel the " +
                              "weight of your quest.  Jeedub'ex is a powerful dragon that will surely kill you.\n",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = false,
                AccessTo = new List<int>(){ 4, 5, 7 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 7,
                ObjectID = 11,
                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = 
                true,
                AccessTo = new List<int>(){ 6, 8, 11 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 8,
                ObjectID = 12,
                Description = "Another dead end." +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 7 },
                ExperiencePoints = -10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 9,
                ObjectID = 13,
                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 5, 10, 13 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 10,
                ObjectID = 14,
                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 9, 14 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 11,
                ObjectID = 15,
                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 7, 12, 15 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 12,
                ObjectID = 16,
                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 11, 16 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 13,
                ObjectID = 17,
                Description = "Another dead end." +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 9 },
                ExperiencePoints = -10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 14,
                ObjectID = 18,
                Description = "Another room in the hedge maze.\n" +
                              "Oh, wait.  This is not another room in the hedge maze.  Well, technically speaking, " +
                              "it is another room in the hedge maze.  But, this room is different.  In the middle " +
                              "of the room, a marble statue stands on a pedestal.  There is an opening in the south " +
                              "wall of the room, beyond which lies a dull, red lake.  In front of the opening, a " +
                              "basset hound sits on the ground, watching you." +
                              "" +
                              "",       
                GeneralContents = "As you approach the basset hound, it speaks to you.  Standing in front of the opening, " +
                                  "he says \"You can't pass until you find the exit.\" \n" +
                                  " \n " +
                                  "Obviously, the exit appears to be behind the basset hound, but he's not going to let " +
                                  "you pass until you solve his riddle.  " +
                                  "Looking around, you notice a plaque at the base of the statue that reads \"This way to " +
                                  "the exit\".  The statue, a life-size figure of a robed woman, points to the west wall of " +
                                  "the room where there appears to be no exit.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 10, 15, 17 },
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 15,
                ObjectID = 19,
                Description = "Another room in the hedge maze." +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 11, 14},
                ExperiencePoints = 10
            },

            new Location
            {
               Name = "Magic Hedge Maze",
                LocationID = 16,
                ObjectID = 20,
                Description = "Another dead end." +
                              "" +
                              "",
                GeneralContents = "The Magic Hedge Maze consists of lush, vibrant green hedges growing 10 feet high.  " +
                                  "The ground is covered in soft, spongy moss.  The air is thick with the smell of plant life.  " +
                                  "The sounds of birds and insects pleasantly punctuate the sound of a gentle breeze rustling the " +
                                  "foliage.",
                IsAccessible = true,
                AccessTo = new List<int>(){ 12 },
                ExperiencePoints = -10
            },

            new Location
            {
               Name = "Lake of Acid",
                LocationID = 17,
                ObjectID = 21,
                Description = "You stand at the edge of a large, dull red lake.  No breeze disturbs the stillness of " +
                              "the lake.  The air is dry, and smells faintly unpleasant.  There is no sign of life.  " +
                              "No bird song, not even the sound of an insect breaks the heavy silence.  Only the " +
                              "skeletons of various things, sparsely distributed around the lake's edge reveal the " +
                              "cause of the undefinable dread you feel in this place.  The skeletons all end at the " +
                              "lake's edge. \n" +
                              " \n " +
                              "That, and the brightly colored sign that reads: " +
                              "\"Caution: Lake of Acid!  Swim at your own risk!\" \n" +
                              "\n " +
                              "In the middle of the lake, lies your next destination: a small island.  In the middle of " +
                              "this island, a stairway descends into the ground.",
                GeneralContents = "You see no way to get across the lake of acid.  Perhaps something in your inventory might be of use.",
                IsAccessible = false,
                AccessTo =  new List<int>(){ 14, 18 },
                ExperiencePoints = 20
            },

            new Location
            {
               Name = "Ancient Battlefield",
                LocationID = 18,
                ObjectID = 22,
                Description = "You stand at the edge of an ancient battlefield: a location so remote and the casualties " +
                              "so great that the few survivors abandoned everything where it lay.  Across an expansive rolling " + 
                              "plain of short grass, fragments of weapons, armor, and machines of war jut out of the " +
                              "ground like weeds.  Where the grass is thin, bones are exposed in the hard dirt, like " +
                              "white cobblestones.  " +
                              "",
                GeneralContents = "In the distance, you see what must be the enemy you came to confront.  Thirty feet tall " +
                                  "when sitting on its rear haunches, with iridescent black and green scales, a ridge of short, " +
                                  "deep red spines running along its back, and large horns curved like a springbok's, Jeedub-ex " +
                                  "is at once the most beautiful and fearsome creature you have ever seen.  Presently, it holds " +
                                  "a decapitated ox in both of its nimble front claws, pouring the contents of their vascular systems " +
                                  "into its gaping maw.  Not a drop of blood reaches the ground.  Truly, Jeedub-ex is an accomplished " +
                                  "two-fisted drinker.  For a moment, you stand transfixed in awe before realizing you are going to die.",
                IsAccessible = false,
                AccessTo = new List<int>(){ 17 },
                ExperiencePoints = 20
            }
        };

        public static List<Location> Locations { get => locations; set => locations = value; }
       
        public static List<Location> Loc(List<GameObject> objList)
        {
            List<Location> locationList = new List<Location>();

            foreach (GameObject gObj in objList)
            {
                if (gObj is Location)
                {
                    locationList.Add((Location)gObj);
                }
            }

            return locationList;
        }
        
        #endregion
    }
}
