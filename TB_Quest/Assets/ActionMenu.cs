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
        public enum CurrentMenu
        {
            QuestIntro,
            InitializeQuest,
            MainMenu,
            ObjectMenu,
            NpcMenu,
            PlayerMenu,
            AdminMenu        
        }

        /// <summary>
        /// global variable used to change the menu to the setup menu when current LocationID is "1"
        /// </summary>
        public static Menu CurrentActionMenu { get; set; }

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
                    { '1', PlayerAction.ListNonPlayerCharacters },
                    { '2', PlayerAction.ListItems },
                    { '3', PlayerAction.ListTreasures },
                    { '4', PlayerAction.ListLocations },
                    { '5', PlayerAction.ListGameObjects},
                    { '0', PlayerAction.ReturnMainMenu }
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

                    { '1', PlayerAction.LookAround },
                    { '2', PlayerAction.Travel },
                    { '3', PlayerAction.ObjectMenu },
                    { '4', PlayerAction.NonplayerCharacterMenu },
                    { '5', PlayerAction.PlayerMenu },
                    { '6', PlayerAction.AdminMenu },
                    { '0', PlayerAction.Exit }

                    //{ '1', PlayerAction.PlayerInfo },
                    //{ '2', PlayerAction.LookAround },
                    //{ '3', PlayerAction.LookAt },
                    //{ '4', PlayerAction.PickUp },
                    //{ '5', PlayerAction.PutDown },
                    //{ '6', PlayerAction.Inventory },
                    //{ '7', PlayerAction.Travel },
                    //{ '8', PlayerAction.PlayerLocationsVisited },
                    //{ '9', PlayerAction.AdminMenu },
                    //{ '0', PlayerAction.Exit }
                }
        };

        /// <summary>
        /// item interaction menu for the game
        /// </summary>
        public static Menu ItemMenu = new Menu()
        {
            MenuName = "ItemMenu",
            MenuTitle = "Item Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.LookAt },
                    { '2', PlayerAction.PickUp },
                    { '3', PlayerAction.PutDown },
                    //{ '4', PlayerAction.PickUpTreasure },
                    //{ '5', PlayerAction.PutDownTreasure },
                    { '6', PlayerAction.Inventory },
                    { '7', PlayerAction.PlayerTreasure },
                    { '0', PlayerAction.ReturnMainMenu }
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
                newMenu = (menu ?? MainMenu);
            }

            return newMenu;
        }

#endregion

    }
}
