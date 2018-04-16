using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// static class to hold objects in the game universe; locations, game objects
    /// </summary>
    public static partial class UniverseObjects
    {

        #region GAMEOBJECTS


        private static List<GameObject> gameObjects = new List<GameObject>()
        {
            new InanimateObject
            {
                Name = "Magic Wand",
                InanimateObjType = InanimateObjectType.Weapon,
                Description = "The \"Magic Wand\" (TM) is possibly the most useless weapon ever.  " +
                              "It doesn't actually do anything.  It is just a bit of deception " +
                              "that wizards use to impress/intimidate the ignorant.",
                CanInventory = true,
                IsConsumable = false,
                IsUsable = true,
                UseCount = 0,
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
                              "running away screaming and playing dead (sometimes both simultaneously).",
                CanInventory = true,
                IsConsumable = false,
                IsUsable = true,
                UseCount = 0,
                LocationID = 0,
                ObjectID = 24
            },
            new InanimateObject
            {
                Name = "Portable Hole",
                InanimateObjType = InanimateObjectType.Item,
                Description = "A literal hole in space that can be picked up, carried, and placed.  " +
                              "The portable hole is about 20 inches in diameter and can be folded or rolled.",
                CanInventory = true,
                IsConsumable = false,
                IsUsable = true,
                UseCount = 0,
                LocationID = 2,
                ObjectID = 25
            },

            new InanimateObject
            {
                Name = "Polymorph Potion",
                InanimateObjType = InanimateObjectType.Item,
                Description = "A mysterious potion with many swirling colors.",
                CanInventory = true,
                IsConsumable = true,
                IsUsable = true,
                UseCount = 1,
                LocationID = 2,
                ObjectID = 26
            },

            new InanimateObject
            {
                Name = "Teleportation Ring",
                InanimateObjType = InanimateObjectType.Item,
                Description = "A ring that allows you to instantly travel home and back.",
                CanInventory = true,
                IsConsumable = false,
                IsUsable = true,
                UseCount = 0,
                LocationID = 2,
                ObjectID = 27
            },

            new InanimateObject
            {
                Name = "Healing Potion",
                InanimateObjType = InanimateObjectType.Medicine,
                Description = "A potion that restores your health.",
                Value = 40,
                CanInventory = true,
                IsConsumable = true,
                IsUsable = true,
                UseCount = 1,
                LocationID = 8,
                ObjectID = 28
            },

            new InanimateObject
            {
                Name = "Gem-encrusted jewel",
                InanimateObjType = InanimateObjectType.Treasure,
                Description = "This appears to be a large ruby, studded with diamonds, sapphires, and more rubies.  " +
                              "In actuality, it is a gaudy piece of cheap costume jewelry crafted (using the term loosely), " +
                              "by someone with more free time than sense, and even less taste.",
                CanInventory = true,
                IsConsumable = false,
                IsUsable = false,
                UseCount = 0,
                LocationID = 5,
                ObjectID = 29
            },

            new InanimateObject
            {
                Name = "Marble Statue",
                InanimateObjType = InanimateObjectType.Other,
                Description = "This is a 3-foot tall marble statue of a woman standing atop a weathered bronze disk.  " +
                              "The statue's left arm extends, finger pointing, in same the direction the statue is facing.  " +
                              "An inscription on the base of the statue reads \"This way to the exit\".",
                CanInventory = false,
                IsConsumable = false,
                IsUsable = true,
                UseCount = 1,
                LocationID = 14,
                ObjectID = 30
            }

        };

        public static List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }

        #endregion

        #region METHODS

        #endregion
    }
}
