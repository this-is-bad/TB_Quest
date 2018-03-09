using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public static Menu QuestIntro = new Menu()
        {
            MenuName = "QuestIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, PlayerAction>()
                    {
                        { ' ', PlayerAction.None }
                    }
        };

        public static Menu InitializeQuest = new Menu()
        {
            MenuName = "InitializeQuest",
            MenuTitle = "Initialize Quest",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerSetup },
                    { '2', PlayerAction.Exit }
                }
        };

        /// <summary>
        /// main menu for the game
        /// </summary>
        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.ListCharacters },
                    { '2', PlayerAction.ListItems },
                    { '3', PlayerAction.ListTreasures },
                    { '4', PlayerAction.ListLocations },
                    { '0', PlayerAction.Exit }
                }
        };

        /// <summary>
        /// setup menu for the player character
        /// </summary>
        public static Menu PlayerSetup = new Menu()
        {
            MenuName = "PlayerSetup",
            MenuTitle = "Player Setup",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerNameChange },
                    { '2', PlayerAction.PlayerAgeChange },
                    { '3', PlayerAction.PlayerRaceChange },
                    { '4', PlayerAction.LookAround },
                    { '5', PlayerAction.Travel },
                    { '0', PlayerAction.Exit }
                }
        };

        /// <summary>
        /// main menu for the game
        /// </summary>
        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerInfo },
                    { '2', PlayerAction.LookAround },
                    { '3', PlayerAction.Travel },
                    { '4', PlayerAction.PlayerLocationsVisited },
                    { '5', PlayerAction.AdminMenu },
                    { '0', PlayerAction.Exit }
                }
        };

#region METHODS

        public static Menu ReturnMenu(Menu menu)
        {
            Menu newMenu = new Menu();
            if (Program.Setup)
            {
                newMenu = PlayerSetup;
            }
            else
            {
                newMenu = (menu == null ? MainMenu : menu);
            }

            return newMenu;
        }

#endregion

    }
}
