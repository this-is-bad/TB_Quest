using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "TB Quest" };
        public static List<string> FooterText = new List<string>() { "Game Programming Project, 2018" };

        #region INTITIAL GAME SETUP

        public static string QuestIntro()
        {
            string messageBoxText =
            "You are a fledgling wizard apprenticed to the master wizard Torvaldus. " +
            "You have learned that your master's nemesis, the evil wizard Mikrozoff has " +
            "sent the mighty dragon Jeedub'ex to lay waste to the realm.  " +
            "Your master is away and you have no way to contact him, so you " +
            "decide to face the dragon yourself.\n" +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "Your quest begins now.\n" +
            " \n" +
            "\tYour first task will be to prepare for your quest.\n" +
            " \n" +
            "\tPress any key to begin the quest preparation.\n";

            return messageBoxText;
        }

        public static string InitialLocationInfo() //(int locationId)
        {
            string messageBoxText =
            "You are currently in your master's tower -- a wondrous place, full of " +
            "knowledge, bizarre contraptions, and occurrences unimaginable to most people. " +
            " " +
            "\n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Quest Text

        public static string InitializeQuestIntro()
        {
            string messageBoxText =
                "You are currently in your room in your master's tower.\n"  +
                " \n" +
                "Before you begin your quest, you must prepare for your journey.\n" +
                " \n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeQuestGetPlayerName()
        {
            string messageBoxText =
                "Enter your name, apprentice.\n" +
                " \n" +
                "Please use the name you wish to be referred during your quest.";

            return messageBoxText;
        }

        public static string InitializeQuestGetPlayerAge(string name)
        {
            string messageBoxText =
                $"Very good then, we will call you {name} on this quest.\n" +
                " \n" +
                "Enter your age below.";

            return messageBoxText;
        }

        public static string InitializeQuestGetPlayerRace(Player gamePlayer)
        {
            string messageBoxText =
                $"{gamePlayer.Name}, it will be important for us to know your race on this quest.\n" +
                " \n" +
                "Enter your race below. \n";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                if (race != Character.RaceType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeQuestGetPlayerHomeVillage(string name)
        {
            string messageBoxText =
                $"{name}, in case of emergency, it may be necessary to return your remains home.\n" +
                " \n" +
                "Enter your home village below.";

            return messageBoxText;
        }

        public static string InitializeQuestGetPlayerGreeting()
        {
            string messageBoxText =
                $"Press 'y' if you would like a verbose greeting";

            return messageBoxText;
        }
            public static string InitializeQuestEchoPlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"Very good then {gamePlayer.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your quest. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tPlayer Name: {gamePlayer.Name}\n" +
                $"\tPlayer Age: {gamePlayer.Age}\n" +
                $"\tPlayer Race: {gamePlayer.Race}\n" +
                $"\tPlayer Home Village: {gamePlayer.HomeVillage}\n" +
                $" \n" +
                $"\t{gamePlayer.Greeting()} \n" +
                " \n" +
                "Press any key to begin your quest.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string PlayerInfo(Player gamePlayer)
        {
            string messageBoxText =
                $"\tPlayer Name: {gamePlayer.Name}\n" +
                $"\tPlayer Age: {gamePlayer.Age}\n" +
                $"\tPlayer Race: {gamePlayer.Race}\n" +
                $"\tPlayer Home Village: {gamePlayer.HomeVillage}\n" +
                $"\tPlayer Greeting: {gamePlayer.Greeting()}\n" +
                " \n";

            return messageBoxText;
        }

        #endregion

        public static List<string> StatusBox(Player player)
        {
            List<string> statusBoxText = new List<string>();
            statusBoxText.Add("Player");
            statusBoxText.Add($"Name: {player.Name}\n");
            statusBoxText.Add($"Age: {player.Age}\n");
            statusBoxText.Add($"Race: {player.Race}\n");
            statusBoxText.Add($"Village: {player.HomeVillage}\n");
            statusBoxText.Add($"Experience Points: {player.ExperiencePoints}\n");
            statusBoxText.Add($"Health: {player.Health}\n");
            statusBoxText.Add($"Lives: {player.Lives}\n");

            return statusBoxText;
        }

        public static string ListLocations(IEnumerable<Location> Locations)
        {
            string messageBoxText =
                "Locations\n" +
                " \n" +

                ///
                /// display table header 
                /// 
                "ID".PadRight(10) + "Name".PadRight(50) + "\n" +
                "---".PadRight(10) + "--------------------------------------------".PadRight(50) + "\n";

            ///
            /// display all locations
            /// 
            string LocationList = null;
            foreach(Location location in Locations)
            {
                LocationList +=
                    $"{location.LocationID}".PadRight(10) +
                    $"{location.Name}".PadRight(50) +
                    Environment.NewLine;
            }

            messageBoxText += LocationList;

            return messageBoxText;
        }

        /// <summary>
        /// parse the location name and description
        /// </summary>
        /// <param name="location"></param>
        /// <returns>string</returns>
        public static string LookAround(Location location)
        {
            string messageBoxText =
                $"Current Location: {location.Name}\n" +
                " \n " +
                location.GeneralContents;

            return messageBoxText;
        }

        /// <summary>
        /// get the information for the current location
        /// </summary>
        /// <param name="location"></param>
        /// <returns>string</returns>
        public static string CurrentLocationInfo(Location location)
        {
            string messageBoxText =
                $"Current Location: {location.Name}\n" +
                " \n " +
                location.Description;

            return messageBoxText;
        }

        /// <summary>
        /// get locations that can be traveled to
        /// </summary>
        /// <param name="player"></param>
        /// <param name="locations"></param>
        /// <returns>string</returns>
        public static string Travel(Player player, List<Location> locations)
        {
            string messageBoxText =
                $"{player.Name}, where will you go next?\n" +
                " \n " +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(50) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "--------------------------------------------".PadRight(50) + "-------".PadRight(10) + "\n";
            // 
            // display all locations except the current location
            //
            string locationList = null;
            string cardinal;
            int locationDiff;
            foreach (Location location in locations)
            {
                cardinal = "";
                locationDiff = 0;

                if (location.LocationID != player.LocationID)
                {
                    
                    if ((Enumerable.Range(5, 11).Contains(player.LocationID)) && location.Name.Contains("Hedge Maze"))
                    {
                        locationDiff = player.LocationID - location.LocationID;

                        if (locationDiff > 1)
                        {    
                            cardinal = " - North";    
                        }
                        else if (locationDiff == -1)
                        {
                            cardinal = " - West";
                        }
                        else if (locationDiff == 1)
                        {
                            cardinal = " - East";
                        }
                        else if (locationDiff < -1)
                        {
                            cardinal = " - South";
                        }
                        else
                        {
                            cardinal = "";
                        }

                    }
                    else
                    {
                        cardinal = "";
                    }

                    locationList +=
                        $"{location.LocationID}".PadRight(10) +
                        $"{location.Name}{cardinal}".PadRight(50) +
                        $"{location.IsAccessible}".PadRight(10) +
                        Environment.NewLine;
                }
            }
            messageBoxText += locationList;

            return messageBoxText;
        }

        /// <summary>
        /// get locations that can be traveled to
        /// </summary>
        /// <param name="player"></param>
        /// <param name="locations"></param>
        /// <returns>string</returns>
        //public static string Travel(Player player, List<Location> locations)
        //{
        //    Location loc = new Location();

        //    do
        //    {
        //        foreach (Location location in locations)
        //        {
        //            if (location.LocationID == player.LocationID)
        //            {
        //                loc = location;
        //                break;
        //            }
        //        }
        //    }
        //    while (loc.LocationID != player.LocationID);
            
        //    string messageBoxText =
        //        $"{player.Name}, where will you go next?\n" +
        //        " \n " +

        //        //
        //        // display table header
        //        //
        //        "ID".PadRight(10) + "Name".PadRight(50) + "Accessible".PadRight(10) + "\n" +
        //        "---".PadRight(10) + "--------------------------------------------".PadRight(50) + "-------".PadRight(10) + "\n";
        //    // 
        //    // display all locations except the current location
        //    //
        //    string locationList = null;
        //    foreach (Location location in locations)
        //    {
        //        if (location.LocationID != loc.AccessTo)
        //        {
        //            locationList +=
        //                $"{location.LocationID}".PadRight(10) +
        //                $"{location.Name}".PadRight(50) +
        //                $"{location.IsAccessible}".PadRight(10) +
        //                Environment.NewLine;
        //        }
        //    }
        //    messageBoxText += locationList;

        //    return messageBoxText;
        //}

        /// <summary>
        /// get locations visited by the player
        /// </summary>
        /// <param name="locations"></param>
        /// <returns>string</returns>
        public static string VisitedLocations(IEnumerable<Location> locations)
        {
            string messageBoxText =
                "Locations Visited\n" +
                " \n " +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(50) + "\n" +
                "---".PadRight(10) + "--------------------------------------------".PadRight(50) + "\n";
            //
            // display all locations
            //
            string locationList = null;
            foreach (Location location in locations)
            {
                locationList +=
                    $"{location.LocationID}".PadRight(10) +
                    $"{location.Name}".PadRight(50) +
                    Environment.NewLine;
            }

            messageBoxText += locationList;

            return messageBoxText;
        }

        //internal static string InitializeQuestGetPlayerRace(Player player)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
