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
            WizardMenu,
            InitializeQuest,
            MainMenu,
            ObjectMenu,
            NpcMenu,
            PlayerMenu,
            PlayerSetup,
            AdminMenu        
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

        /// <summary>
        /// blank menu
        /// </summary>
        public static Menu QuestIntro = new Menu()
        {
            MenuName = "QuestIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, PlayerAction>()
                    {
                        { ' ', PlayerAction.None }
                    }
        };

        /// <summary>
        /// menu to configure up the player's information
        /// </summary>
        public static Menu InitializeQuest = new Menu()
        {
            MenuName = "InitializeQuest",
            MenuTitle = "Initialize Quest",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.PlayerSetup },
                    { '0', PlayerAction.Exit }
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
                    { '2', PlayerAction.ListLocations },
                    { '3', PlayerAction.ListGameObjects},
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
                    { '1', PlayerAction.LookAround },
                    { '2', PlayerAction.Travel },
                    { '3', PlayerAction.PlayerNameChange },
                    { '4', PlayerAction.PlayerAgeChange },
                    { '5', PlayerAction.PlayerRaceChange },
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
                }
        };

        /// <summary>
        /// player information menu for the game
        /// </summary>
        public static Menu PlayerMenu = new Menu()
        {
            MenuName = "PlayerMenu",
            MenuTitle = "Player Menu",
            MenuChoices = new Dictionary<char, PlayerAction>
            {
                { '1', PlayerAction.PlayerInfo },
                { '2', PlayerAction.Inventory },
                { '3', PlayerAction.PlayerLocationsVisited },
                { '0', PlayerAction.ReturnMainMenu }
            }
        };

        /// <summary>
        /// object interaction menu for the game
        /// </summary>
        public static Menu ObjectMenu = new Menu()
        {
            MenuName = "ObjectMenu",
            MenuTitle = "Object Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.LookAt },
                    { '2', PlayerAction.PickUp },
                    { '3', PlayerAction.PutDown },
                    { '4', PlayerAction.UseObject },
                    { '0', PlayerAction.ReturnMainMenu }
                }
        };

        /// <summary>
        ///  menu for the NPC interaction
        /// </summary>
        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.TalkTo },
                    { '0', PlayerAction.ReturnMainMenu }
                }
        };

        /// <summary>
        ///  menu for the Evil? Wizard
        /// </summary>
        public static Menu WizardMenu = new Menu()
        {
            MenuName = "WizardMenu",
            MenuTitle = "Evil? Wizard",
            MenuChoices = new Dictionary<char, PlayerAction>()
                {
                    { '1', PlayerAction.TalkTo },
                    { '0', PlayerAction.WizardExit }
                }
        };

        #region METHODS


        #endregion

    }
}
