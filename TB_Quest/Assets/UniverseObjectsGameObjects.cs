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

        #region ITEMS
        private static List<Item> items = new List<Item>()
        {
            new Item
            {
                Name = "Portable Hole",
                Description = "",
                LocationID = 2,
                ObjectID = 25
            }
        };

        public static List<Item> Items { get => items; set => items = value; }
        #endregion

        #region GAMEOBJECTS


        private static List<GameObject> gameObjects = new List<GameObject>()
        {
            new InanimateObject
            {
                Name = "Magic Wand",
                InanimateObjType = InanimateObjectType.Weapon,
                Description = "The \"Magic Wand\" (TM) is possibly the most useless weapon ever." +
                              "It doesn't actually do anything.  It is just a bit of deception " +
                              "that wizards use to impress/intimidate the ignorant.",
                LocationID = 0,
                ObjectID = 23
            },
            new InanimateObject
            {
                Name = "Professor Pluperfect's Primer Promoting Practical Panic",
                InanimateObjType = InanimateObjectType.Information,
                Description = "This text can be found in the collection of any apprentice wizard.  " +
                              "It is a guide for how to survive, detailing the multitudinous situations " +
                              "in which apprentices should panic, and an exhaustive list of methods for " +
                              "running away screaming and playing dead (sometimes both simultaneously)."
                ,
                LocationID = 0,
                ObjectID = 24
            },
            new InanimateObject
            {
                Name = "Portable Hole",
                InanimateObjType = InanimateObjectType.Item,
                Description = "A literal hole in space that can be picked, carried, and placed.  " +
                              "The portable hole is about 20 inches in diameter and can be folded or rolled.",
                LocationID = 2,
                ObjectID = 25
            },

            new InanimateObject
            {
                Name = "Polymorph Potion",
                InanimateObjType = InanimateObjectType.Item,
                Description = "A mysterious potion with many swirling colors.",
                LocationID = 2,
                ObjectID = 26
            }
        };

        public static List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }

        #endregion


        #region NPCs
        private static List<Character> characters = new List<Character>()
        {
            new Character
            {
                Name = "Evil? Player",
                Description = "",
                LocationID = 4,
                ObjectID = 1
            },

            new Character
            {
                Name = "Basset Hound",
                Description = "",
                LocationID = 14,
                ObjectID = 2
            },

            new Character
            {
                Name = "Jeedub'ex",
                Description = "",
                LocationID = 18,
                ObjectID = 3
            }
        };

        public static List<Character> Characters { get => characters; set => characters = value; }
        #endregion

        #region TREASURE
        private static List<Treasure> treasures = new List<Treasure>()
        {
            new Treasure
            {
                Name = "Gem-encrusted jewel",
                Description = "This appears to be a large ruby, studded with diamonds, sapphires, and more rubies.  " +
                              "In actuality, it is a gaudy piece of cheap costume jewelry crafted (using the term loosely), " +
                              "by someone with more free time than sense, and even less taste.",
                LocationID = 4,
                ObjectID = 24
            }
        };
        public static List<Treasure> Treasures { get => treasures; set => treasures = value; }
        #endregion

    }
}
