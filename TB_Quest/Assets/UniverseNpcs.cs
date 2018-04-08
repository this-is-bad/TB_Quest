﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// static class to hold all NPCs in the game universe 
    /// </summary>
    public static partial class UniverseObjects
    {

        #region NPCs
        private static List<NPC> npcs = new List<NPC>()
        {
            new Opponent
            {
                Id = 1,
                Name = "Evil? Player",
                LocationID = 4,
                ObjectID = 1,
                Description = "A mysterious cloaked figure.",
                Messages = new List<string>
                {
                    "You can only enter the maze if you have a park pass.  Or if you can defeat me."
                }
            },

            new Opponent
            {
                Id = 2,
                Name = "Basset Hound",
                LocationID = 14,
                ObjectID = 2,
                Description = "A totally average basset hound.",
                Messages = new List<string>
                {
                    "Like I said, you can't pass until you find the exit.",
                    "You've gotten all the hints you're going to get from me.",
                    "Woof."
                }
            },

            new Opponent
            {
                Id = 3,
                Name = "Jeedub'ex",
                LocationID = 18,
                ObjectID = 3,
                Description = "A massive dragon, thirty feet tall when sitting on its rear haunches. It has " +
                              "iridescent black and green scales, a ridge of short, " +
                              "deep red spines running along its back, and large horns like a springbok's.",
                Messages = new List<string>
                {
                    "ROAR",
                    "ROOOOAAAAAARRRRRRRRRRRRR",
                    "roooooOOOAAAAAAAAAAARRRRRRRR"
                }
            }
        };

        public static List<NPC> NPC { get => npcs; set => npcs = value; }
        #endregion

        #region METHODS

        #endregion
    }
}
