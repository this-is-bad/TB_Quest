using System;
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
                Name = "Evil? Wizard",
                LocationID = 4,
                ObjectID = 1,
                Description = "A mysterious cloaked figure.",
                HealthModifier = -10,
                Messages = new List<string>
                {
                    "You can only enter the maze if you have a park pass.  Or if you can defeat me."
                }
            },

             new Opponent
            {
                Id = 2,
                Name = "Stephan Platitude",
                LocationID = 8,
                ObjectID = 2,
                Description = "Matt Daemon (pronounced \"dee-mon\") is the master's butler/housekeeper.  " +
                              "He is currently engaged in dusting the master's collection of magical objects.  " +
                              "He briefly pauses to give you a disapproving glance before resuming his work.",
                HealthModifier = -10,
                 Messages = new List<string>
                {
                    "Nice weather we're having.",
                    "Have a nice day.",
                    "What doesn't kill you only makes you stronger."
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
                HealthModifier = -30,
                Messages = new List<string>
                {
                    "ROAR",
                    "ROOOOAAAAAARRRRRRRRRRRRR",
                    "roooooOOOAAAAAAAAAAARRRRRRRR"
                }
            },

            new Friend
            {
                Id = 4,
                Name = "Matt Daemon",
                LocationID = 2,
                ObjectID = 31,
                Description = "Matt Daemon (pronounced \"dee-mon\") is the master's butler/housekeeper.  " +
                              "He is currently engaged in dusting the master's collection of magical objects.  " +
                              "He briefly pauses to give you a disapproving glance before resuming his work.",
                HealthModifier = 0,
                Messages = new List<string>
                {
                    "If you're planning on going out, please wipe your shoes before entering the tower.",
                    "Please don't disturb me while I'm dusting the master's collection.  I don't want to " +
                        "explain to him why he needs to find another apprentice.",
                    "Blah.  Blah!  AAAaaaah!  brbblphtbbbt."
                }
            },

            new Friend
            {
                Id = 5,
                Name = "Basset Hound",
                LocationID = 14,
                ObjectID = 32,
                Description = "A totally average basset hound.",
                HealthModifier = 5,
                Messages = new List<string>
                {
                    "Like I said, you can't pass until you find the exit.",
                    "You've gotten all the hints you're going to get from me.",
                    "Woof."
                }
            },

            new Friend
            {
                Id = 6,
                Name = "Random Dancing Stranger",
                LocationID = 15,
                ObjectID = 33,
                Description = "This odd person is dancing non-stop.  They appear " +
                    "to be here for no other reason than to meet a grade requirement.",
                HealthModifier = 5,
                Messages = new List<string>
                {
                    "I can't stop dancing!",
                    "EVERYTHING IS RHYTHM!",
                    "I've been dancing since I was 4 years old."
                }
            },

        };

        public static List<NPC> NPC { get => npcs; set => npcs = value; }
        #endregion

        #region METHODS

        #endregion
    }
}
