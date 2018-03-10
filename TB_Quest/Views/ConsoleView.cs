using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            PlayerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _gamePlayer;
        Universe _gameUniverse;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gamePlayer, Universe gameUniverse)
        {
            _gamePlayer = gamePlayer;
            _gameUniverse = gameUniverse;

            _viewStatus = ViewStatus.PlayerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayInputBoxPrompt(inputBoxPrompt);
            DisplayStatusBox();
        }

         /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public PlayerAction GetActionMenuChoice(Menu menu)
        {
            PlayerAction choosenAction = PlayerAction.None;

            //
            // create an array of valid menu keys from menu dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            ///
            /// validate key pressed as in MenuChoices dictionary
            ///
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                keyPressed = keyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;


            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
               if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            string race = Console.ReadLine().Trim();
            if (race.Length > 1)
            {
                race = race.Substring(0, 1).ToUpper() + race.Substring(1, (race.Length - 1)).ToLower();
            }
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(race, out raceType);

            return raceType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySplashScreen(bool start)
        {
            bool playing = start;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);

            Console.WriteLine(tabSpace + @" _____  ____      _____                     _   ");
            Console.WriteLine(tabSpace + @"|_   _||  _ \    / ___ \                   | |  ");
            Console.WriteLine(tabSpace + @"  | |  | |_| |  | |  | | _   _   ___   ___ | |_ ");
            Console.WriteLine(tabSpace + @"  | |  |  _ \   | |  | || | | | / _ \ /  _|| __|");
            Console.WriteLine(tabSpace + @"  | |  | |_| |  | |__| || \_/ ||  __/ _\ \ | |_ ");
            Console.WriteLine(tabSpace + @"  \_/  |____/   \____  / \___/  \___| \__/ \__| ");
            Console.WriteLine(tabSpace + @"                     \_\                        ");
            Console.WriteLine(tabSpace + @"                                                ");

            Console.SetCursorPosition((start ? 39 : 50), 25);
            if (start)
            {
                Console.Write("Press any key to continue or Esc to exit.");

                keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    playing = false;
                }
            }
            
            if (!start)
            {
                Console.Write("Thank you for playing.");
            }


            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Text-Based Quest";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, PlayerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != PlayerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gamePlayer))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>player object with all properties updated</returns>
        public Player GetInitialPlayerInfo()
        {
            Player player = new Player();

            //
            // intro
            //
            DisplayGamePlayScreen("Quest Preparation", Text.InitializeQuestIntro(), ActionMenu.QuestIntro, "");
            GetContinueKey();

            ////
            //// get player's name
            ////
            //DisplayGamePlayScreen("Quest Preparation - Name", Text.InitializeQuestGetPlayerName(), ActionMenu.QuestIntro, "");
            //DisplayInputBoxPrompt("Enter your name: ");
            //player.Name = GetString();

            ////
            //// get player's age
            ////
            //DisplayGamePlayScreen("Quest Preparation - Age", Text.InitializeQuestGetPlayerAge(player.Name), ActionMenu.QuestIntro, "");
            //int gamePlayerAge;
            //GetInteger($"Enter your age {player.Name}: ", 0, 1000000, out gamePlayerAge);
            //player.Age = gamePlayerAge;

            ////
            //// get player's race
            ////
            //DisplayGamePlayScreen("Quest Preparation - Race", Text.InitializeQuestGetPlayerRace(player), ActionMenu.QuestIntro, "");
            //DisplayInputBoxPrompt($"Enter your race {player.Name}: ");
            //player.Race = GetRace();

            ////
            //// get player's home village
            ////
            //DisplayGamePlayScreen("Quest Preparation - Home Village", Text.InitializeQuestGetPlayerHomeVillage(player.Name), ActionMenu.QuestIntro, "");
            //DisplayInputBoxPrompt($"Enter your home village: ");
            //player.HomeVillage = GetString();

            ////
            //// get player's choice of greeting
            ////
            //DisplayGamePlayScreen("Quest Preparation - Home Village", Text.InitializeQuestGetPlayerGreeting(), ActionMenu.QuestIntro, "");
            //DisplayInputBoxPrompt($"Would you like a verbose greeting? ");
            //player.VerboseGreeting = (GetString().ToLower() == "y" ? true : false);

            ////
            //// echo the player's info
            ////
            //DisplayGamePlayScreen("Quest Initialization - Complete", Text.InitializeQuestEchoPlayerInfo(player), ActionMenu.QuestIntro, "");
            //GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return player;
        }

        #region ----- display responses to menu action choices -----

        /// <summary>
        /// show all locations in the game
        /// </summary>
        public void DisplayListOfLocations()
        {
            ActionMenu.CurrentActionMenu = ActionMenu.AdminMenu;

            DisplayGamePlayScreen("List: Locations", Text.ListLocations
                (_gameUniverse.Locations), ActionMenu.ReturnMenu(ActionMenu.AdminMenu), "Enter your menu choice: ");
        }

        /// <summary>
        /// show all items in the game
        /// </summary>
        public void DisplayListOfItems()
        {
            ActionMenu.CurrentActionMenu = ActionMenu.AdminMenu;

            DisplayGamePlayScreen("List: Items", Text.ListItems
                (_gameUniverse.Items), ActionMenu.ReturnMenu(ActionMenu.AdminMenu), "Enter your menu choice: ");
        }

        /// <summary>
        /// show all characters in the game
        /// </summary>
        public void DisplayListOfCharacters()
        {
            ActionMenu.CurrentActionMenu = ActionMenu.AdminMenu;

            DisplayGamePlayScreen("List: Characters", Text.ListCharacters
                (_gameUniverse.Characters), ActionMenu.ReturnMenu(ActionMenu.AdminMenu), "Enter your menu choice: ");
        }

        /// <summary>
        /// show all treasures in the game
        /// </summary>
        public void DisplayListOfTreasures()
        {
            ActionMenu.CurrentActionMenu = ActionMenu.AdminMenu;

            DisplayGamePlayScreen("List: Treasures", Text.ListTreasures
                (_gameUniverse.Treasures), ActionMenu.ReturnMenu(ActionMenu.AdminMenu), "Enter your menu choice: ");
        }

        /// <summary>
        /// show the main menu
        /// </summary>
        public void DisplayMainMenu()
        {

            ActionMenu.CurrentActionMenu = ActionMenu.MainMenu;

            DisplayGamePlayScreen("Main Menu", "", ActionMenu.ReturnMenu(ActionMenu.CurrentActionMenu), "");
        }

        /// <summary>
        /// show the admin menu
        /// </summary>
        public void DisplayAdminMenu()
        {
            ActionMenu.CurrentActionMenu = ActionMenu.AdminMenu;

            DisplayGamePlayScreen("Admin Menu", "View the objects in the game.", ActionMenu.ReturnMenu(ActionMenu.AdminMenu), "Enter your menu choice: ");
        }

        /// <summary>
        /// show all objects of the specified type in the game
        /// </summary>
        //public void DisplayListOfObjects()
        //{
        //    DisplayGamePlayScreen("List: Locations", Text.ListObjects //Text.ListLocations
        //        (_gameUniverse.Locations), ActionMenu.ReturnMenu(ActionMenu.AdminMenu), "");
        //}

        /// <summary>
        /// Display the details of the current location
        /// </summary>
        public void DisplayLookAround()
        {
            ActionMenu.CurrentActionMenu = ActionMenu.CurrentActionMenu;

            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);
            DisplayGamePlayScreen("Current Location", Text.LookAround(currentLocation), ActionMenu.ReturnMenu(ActionMenu.CurrentActionMenu), "");
        }

        /// <summary>
        /// display information about the player
        /// </summary>
        public void DisplayPlayerInfo()
        {
            ActionMenu.CurrentActionMenu = ActionMenu.MainMenu;

            DisplayGamePlayScreen("Player Information", Text.PlayerInfo(_gamePlayer), ActionMenu.ReturnMenu(ActionMenu.CurrentActionMenu), "");
        }

        /// <summary>
        /// get a location ID from the player
        /// </summary>
        /// <returns>int</returns>
        public int DisplayGetNextLocation()
        {
            int locationId = 0;
            bool validLocationId = false;
            // original Text.Travel signature
            //DisplayGamePlayScreen("Travel to a new location", Text.Travel(_gamePlayer, _gameUniverse.Locations),
            //    ActionMenu.MainMenu, "");

            ActionMenu.CurrentActionMenu = ActionMenu.MainMenu;

            // new Text.Travel signature
            DisplayGamePlayScreen("Travel to a new location", Text.Travel(_gamePlayer, _gameUniverse.GetLocationsFromCurrentLocationID(_gamePlayer.LocationID)),
                ActionMenu.ReturnMenu(ActionMenu.CurrentActionMenu), "");

            int currentLocationID = _gamePlayer.LocationID;
            List<int> availableLocations = _gameUniverse.GetLocationIDsFromCurrentLocationID(currentLocationID);

            while (!validLocationId)
            {
                //
                // get an integer from the player
                //
                GetInteger($"Enter your new location {_gamePlayer.Name}: ", 1,
                    _gameUniverse.GetMaxLocationId(), out locationId);

                //
                // validate integer as a valid location ID and determine accessibility
                //
                if (_gameUniverse.IsValidLocationId(locationId))
                {
                    //
                    // validate location ID is accessible from the current location
                    //
                    if (availableLocations.Contains(locationId))
                    {
                        //
                        // validate that location is not locked
                        //
                        if (_gameUniverse.IsAccessibleLocation(locationId))
                        {
                            validLocationId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("That way is not open to you yet.  Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("You cannot reach that location from here.  Please try again.");
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage("It appears you entered an invalid locationID.  Please try again.");
                }
            }

            return locationId;
        }

        /// <summary>
        /// generate a list of locations that have been visited
        /// </summary>
        public void DisplayLocationsVisited()
        {
            //
            // generate a list of locations that have been visited
            //
            List<Location> visitedLocations = new List<Location>();
            foreach (int locationId in _gamePlayer.LocationsVisited)
            {
                visitedLocations.Add(_gameUniverse.GetLocationById(locationId));
            }

            ActionMenu.CurrentActionMenu = ActionMenu.MainMenu;

            DisplayGamePlayScreen("Locations Visited", Text.VisitedLocations
                (visitedLocations), ActionMenu.ReturnMenu(ActionMenu.CurrentActionMenu), "");
        }

        /// <summary>
        /// update the player character's name
        /// </summary>
        public void DisplayUpdatePlayerName()
        {
            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);

            ActionMenu.CurrentActionMenu = ActionMenu.PlayerSetup;

            DisplayGamePlayScreen("Quest Preparation - Name", Text.InitializeQuestGetPlayerName(), ActionMenu.CurrentActionMenu, "");
            DisplayInputBoxPrompt("Enter your name: ");

            string name = GetString();
        
            _gamePlayer.Name = (name == "" ? _gamePlayer.Name : name) ;

            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentLocation), ActionMenu.ReturnMenu(ActionMenu.CurrentActionMenu), "");
        }
        /// <summary>
        /// update the player character's age
        /// </summary>
        public void DisplayUpdatePlayerAge()
        {
            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);

            ActionMenu.CurrentActionMenu = ActionMenu.PlayerSetup;


            DisplayGamePlayScreen("Quest Preparation - Age", Text.InitializeQuestGetPlayerAge(_gamePlayer.Name), ActionMenu.CurrentActionMenu, "");
            int gamePlayerAge;

            GetInteger($"Enter your age {_gamePlayer.Name}: ", 0, 10000, out gamePlayerAge);
            _gamePlayer.Age = gamePlayerAge;
            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentLocation), ActionMenu.ReturnMenu(ActionMenu.CurrentActionMenu), "");
        }
        /// <summary>
        /// update the player character's age
        /// </summary>
        public void DisplayUpdatePlayerRace()
        {
            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);

            ActionMenu.CurrentActionMenu = ActionMenu.PlayerSetup;

            DisplayGamePlayScreen("Quest Preparation - Race", Text.InitializeQuestGetPlayerRace(_gamePlayer), ActionMenu.CurrentActionMenu, "");
            DisplayInputBoxPrompt($"Enter your race {_gamePlayer.Name}: ");
            Character.RaceType raceType = GetRace();
            _gamePlayer.Race = (raceType == Character.RaceType.None ? _gamePlayer.Race : raceType);
            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentLocation), ActionMenu.ReturnMenu(ActionMenu.CurrentActionMenu), "");
        }

        public void DisplayLookAt()
        {

        }


        public void DisplayPickUpItem()
        {

        }


        public void DisplayPickUpTreasure()
        {

        }


        public void DisplayPutDownItem()
        {

        }


        public void DisplayPutDownTreasure()
        {

        }


        public void DisplayPlayerInventory()
        {

        }


        public void DisplayPlayerTreasure()
        {

        }

        #endregion

        #endregion
    }
}
