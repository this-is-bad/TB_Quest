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

            //
            // validate on range if either minimumValue or maximumValue are not 0
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {

                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
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
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            Console.CursorVisible = false; 

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

                playing = false;
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
            ClearStatusBox();
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
        /// clear the status box
        /// </summary>
        private void ClearStatusBox()
        {
            int i = ConsoleLayout.StatusBoxWidth - 3;
            string str = " ".PadRight(i);
            Console.ForegroundColor = ConsoleTheme.StatusBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.StatusBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + row);
                Console.Write(str);
            }
            Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
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
            DisplayGamePlayScreen("List: Locations", Text.ListLocations
                (_gameUniverse.Locations), ActionMenu.AdminMenu, "Enter your menu choice: ");
        }

        /// <summary>
        /// show the main menu
        /// </summary>
        public void DisplayMainMenu()
        {

            DisplayGamePlayScreen("Current Location", 
                Text.CurrentLocationInfo(_gameUniverse.GetLocationById(_gamePlayer.LocationID)), 
                ActionMenu.MainMenu, "Enter your menu choice: ");
        }

        /// <summary>
        /// show the admin menu
        /// </summary>
        public void DisplayAdminMenu()
        {
            DisplayGamePlayScreen("Admin Menu", "View the objects in the game.", ActionMenu.AdminMenu, "Enter your menu choice: ");
        }

        /// <summary>
        /// display information about the player
        /// </summary>
        public void DisplayPlayerInfo()
        {
            List<InanimateObject> inventory = _gameUniverse.GetInanimateObjectsByLocationId(_gamePlayer.LocationID);
            DisplayGamePlayScreen("Player Information", Text.PlayerInfo(_gamePlayer, inventory), ActionMenu.PlayerMenu, "");
        }

        /// <summary>
        /// get a location ID from the player
        /// </summary>
        /// <returns>int</returns>
        public int DisplayGetNextLocation()
        {
            int locationId = 0;
            bool validLocationId = false;

            DisplayGamePlayScreen("Travel to a new location", Text.Travel(_gamePlayer, _gameUniverse.GetLocationsFromCurrentLocationID(_gamePlayer.LocationID)),
                ActionMenu.MainMenu, "");

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

            DisplayGamePlayScreen("Locations Visited", Text.VisitedLocations
                (visitedLocations), ActionMenu.PlayerMenu, "");
        }

        /// <summary>
        /// update the player character's name
        /// </summary>
        public void DisplayUpdatePlayerName()
        {
            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);

            DisplayGamePlayScreen("Quest Preparation - Name", Text.InitializeQuestGetPlayerName(), ActionMenu.PlayerSetup, "");
            DisplayInputBoxPrompt("Enter your name: ");

            string name = GetString();
        
            _gamePlayer.Name = (name == "" ? _gamePlayer.Name : name) ;

            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentLocation), ActionMenu.PlayerSetup, "");
        }
        /// <summary>
        /// update the player character's age
        /// </summary>
        public void DisplayUpdatePlayerAge()
        {
            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);

            DisplayGamePlayScreen("Quest Preparation - Age", Text.InitializeQuestGetPlayerAge(_gamePlayer.Name), ActionMenu.PlayerSetup, "");
            int gamePlayerAge;

            GetInteger($"Enter your age {_gamePlayer.Name}: ", 0, 10000, out gamePlayerAge);
            _gamePlayer.Age = gamePlayerAge;
            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentLocation), ActionMenu.PlayerSetup, "");
        }
        /// <summary>
        /// update the player character's age
        /// </summary>
        public void DisplayUpdatePlayerRace()
        {
            Location currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);

            DisplayGamePlayScreen("Quest Preparation - Race", Text.InitializeQuestGetPlayerRace(_gamePlayer), ActionMenu.PlayerSetup, "");
            DisplayInputBoxPrompt($"Enter your race {_gamePlayer.Name}: ");
            Character.RaceType raceType = GetRace();
            _gamePlayer.Race = (raceType == Character.RaceType.None ? _gamePlayer.Race : raceType);
            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentLocation), ActionMenu.PlayerSetup, "");
        }

        /// <summary>
        /// display all inanimate objects in the game
        /// </summary>
        public void DisplayListOfAllGameObjects ()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameObjects(_gameUniverse.GameObjects), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// displays a list of objects in the current location and accepts user input for an object id
        /// </summary>
        /// <returns>int</returns>
        public int DisplayGetGameObjectsToLookAt()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;
            //
            // get a list of game objects in the current location
            //
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectsByLocationId(_gamePlayer.LocationID);

            if (gameObjectsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at an object", Text.GameObjectsChooseList(gameObjectsInLocation), ActionMenu.ObjectMenu, "");

                while (!validGameObjectId)
                {
                    //
                    //get an integer from the player
                    //
                    GetInteger($"Enter the ID number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameUniverse.IsValidObjectByLocationId(gameObjectId, _gamePlayer.LocationID))
                    {
                        validGameObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object ID.  Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at an object", Text.GameObjectsChooseList(gameObjectsInLocation), ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }

        /// <summary>
        /// show information about an object
        /// </summary>
        /// <param name="gameObject"></param>
        public void DisplayGameObjectInfo (GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// display the details of the current location
        /// </summary>
        public void DisplayLookAround()
        {
            //
            // get current location
            //
            Location currentLocation = _gameUniverse.GetLocationByLocationID(_gamePlayer.LocationID);

            //
            // get list of game objects in the current location
            //
            List<GameObject> gameObjectsInCurrentLocation = _gameUniverse.GetGameObjectsByLocationId(_gamePlayer.LocationID);

            //
            // get list of NPCs in current location
            //
            List<NPC> npcsInCurrentLocation = _gameUniverse.GetNpcsByLocationId(_gamePlayer.LocationID);

            string messageBoxText = Text.LookAround(currentLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentLocation);
            messageBoxText += " \n";
            messageBoxText += Text.NpcsChooseList(npcsInCurrentLocation);

            DisplayGamePlayScreen("Current Location", messageBoxText, (currentLocation.LocationID == 1 ? ActionMenu.PlayerSetup : ActionMenu.MainMenu), "");
        }

        /// <summary>
        /// show the player's inventory
        /// </summary>
        public void DisplayInventory()
        {
            List<InanimateObject> inventory = _gameUniverse.GetInanimateObjectsByLocationId(0);
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(inventory), ActionMenu.PlayerMenu, "");
        }

        /// <summary>
        /// show the inanimate objects in the current location and get a choice
        /// </summary>
        /// <returns>int</returns>
        public int DisplayGetInanimateObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of inanimate objects in the current location
            //
            List<InanimateObject> inanimateObjectsInLocation = _gameUniverse.GetInanimateObjectsByLocationId(_gamePlayer.LocationID);

            foreach (InanimateObject inanimateObject in inanimateObjectsInLocation.ToList())
            {
                if (!inanimateObject.CanInventory)
                {
                    inanimateObjectsInLocation.Remove(inanimateObject);
                }
            }

            if (inanimateObjectsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Game Object", Text.GameObjectsChooseList(inanimateObjectsInLocation), ActionMenu.ObjectMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the ID number of the object you wish to add to your inventory: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object ID and in the current location
                    //
                    if (_gameUniverse.IsValidInanimateObjectByLocationId(gameObjectId, _gamePlayer.LocationID))
                    {
                        InanimateObject inanimateObject = _gameUniverse.GetGameObjectById(gameObjectId) as InanimateObject;
                        if (inanimateObject.CanInventory)
                        {
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();

                            DisplayInputErrorMessage("It appears you may not inventory that object.  Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                    
                        DisplayInputErrorMessage("It appears you entered an invalid game object ID.  Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects that can be picked up here.", ActionMenu.ObjectMenu, "");
            }
           
            return gameObjectId;
        }

        /// <summary>
        /// display a message confirming that an object was added to the player's inventory
        /// </summary>
        /// <param name="objectAddedToInventory"></param>
        public void DisplayConfirmInanimateObjectAddedToInventory(InanimateObject objectAddedToInventory)
        {

            string msg = (objectAddedToInventory.PickUpMessage ?? $"The {objectAddedToInventory.Name} has been added to your inventory."); 
            
            DisplayGamePlayScreen("Pick Up Game Object", msg, ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// display a message confirming that an object was added to the player's inventory
        /// </summary>
        /// <param name="objectAddedToInventory"></param>
        public void DisplayConfirmInanimateObjectUsed(InanimateObject objectAddedToInventory)
        {

            string msg = (objectAddedToInventory.PickUpMessage ?? $"The {objectAddedToInventory.Name} has been used.  " +
                "Press any key to continue.");

            DisplayGamePlayScreen("Use Game Object", msg, ActionMenu.ObjectMenu, "");

            Console.ReadKey();

            DisplayGamePlayScreen("Object Menu", "Select an action from the menu", ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// show the inanimate objects in the player's inventory and get a choice
        /// </summary>
        /// <returns>int</returns>
        public int DisplayGetInventoryObjectToPutDown()
        {
            int inanimateObjectId = 0;
            bool validInventoryObjectId = false;
            List<InanimateObject> inventory = _gameUniverse.GetInanimateObjectsByLocationId(0); 

            if (inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(inventory), ActionMenu.ObjectMenu, "");

                while (!validInventoryObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the ID number of the object you wish to remove from your inventory: ", 0, 0, out inanimateObjectId);

                    //
                    // find object in inventory
                    //
                    InanimateObject objectToPutDown = inventory.FirstOrDefault(o => o.ObjectID == inanimateObjectId);

                    //
                    // validate object in inventory
                    //
                    if (objectToPutDown != null)
                    {
                        validInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();

                        DisplayInputErrorMessage("It appears you entered the ID of an object that is not in inventory.  Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Put Down Game Object", "It appears there are no objects currently in inventory.", ActionMenu.ObjectMenu, "");
            }

            return inanimateObjectId;
        }

        /// <summary>
        /// show a message confirming that an object has been removed from inventory
        /// </summary>
        /// <param name="objectRemovedFromInventory"></param>
        public void DisplayConfirmInanimateObjectRemovedFromInventory(InanimateObject objectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.ObjectMenu, "");
        }


        /// <summary>
        /// show the inanimate objects in the current location and get a choice
        /// </summary>
        /// <returns>int</returns>
        public int DisplayGetInanimateObjectToUse()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of inanimate objects in the current location
            //
            List<InanimateObject> currentInanimateObjects = _gameUniverse.GetInanimateObjectsByLocationId(_gamePlayer.LocationID);
            List<InanimateObject> inanimateObjectsInInventory = _gameUniverse.PlayerInventory();
            currentInanimateObjects.AddRange(inanimateObjectsInInventory);
            
            //
            // remove inanimate objects that cannot be used
            //
            currentInanimateObjects.RemoveAll(inanimateObject => !inanimateObject.IsUsable);

            if (currentInanimateObjects.Count > 0)
            {
                List<InanimateObject> sortedInanimateObjectList = currentInanimateObjects.OrderBy(x => x.Name).ToList();

                DisplayGamePlayScreen("Use Game Object", Text.GameObjectsUseList(sortedInanimateObjectList), ActionMenu.ObjectMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the ID number of the object you wish to use: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object ID and in the current location
                    //
                    if (_gameUniverse.IsValidInanimateObjectByPlayerLocationId(gameObjectId, _gamePlayer.LocationID))
                    {
                        InanimateObject inanimateObject = _gameUniverse.GetGameObjectById(gameObjectId) as InanimateObject;
                        if (inanimateObject.IsUsable)
                        {
                            if (!inanimateObject.EffectiveLocations.Contains(0) & !inanimateObject.EffectiveLocations.Contains(_gamePlayer.LocationID))
                            {
                               
                                ClearInputBox();
                                DisplayGamePlayScreen("Use Game Object", "This item is not effective here.  Try using it somewhere else.", ActionMenu.ObjectMenu, "");
                               // DisplayInputErrorMessage("This item is not effective here.  Try using it somewhere else.");
                            }
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();

                            DisplayInputErrorMessage("It appears you may not use that object.  Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();

                        DisplayInputErrorMessage("It appears you entered an invalid game object ID.  Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Use Game Object", "It appears there are no objects to use here.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }

        /// <summary>
        /// show all NPCs in the game
        /// </summary>
        public void DisplayListOfAllNpcObjects()
        {
            DisplayGamePlayScreen("List: NPC Objects", Text.ListAllNpcObjects(_gameUniverse.Npcs), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// get the player's choice of NPC to talk to 
        /// </summary>
        /// <returns>int</returns>
        public int DisplayGetNpcToTalkTo()
        {
            int npcId = 0;
            bool validNpcId = false;

            //
            // get a list of NPCs in the current location
            //
            List<NPC> npcsInLocation = _gameUniverse.GetNpcsByLocationId(_gamePlayer.LocationID);

            if (npcsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose Character to Speak With", Text.NpcsChooseList(npcsInLocation), ActionMenu.NpcMenu, "");

                while (!validNpcId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the ID number of the character you wish to speak with: ", 0, 0, out npcId);

                    //
                    // validate integer as a valid NPC ID and in the current location
                    //
                    if (_gameUniverse.IsValidNpcByLocationId(npcId, _gamePlayer.LocationID))
                    {
                        NPC npc = _gameUniverse.GetNpcById(npcId);
                        if (npc is ISpeak)
                        {
                            validNpcId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you entered an invalid NPC id.  Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid NPC id.  Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Speak With", "It appears there are no NPCs here.", ActionMenu.NpcMenu, "");
            }

            return npcId;
        }

        /// <summary>
        /// display NPC dialog
        /// </summary>
        /// <param name="npc"></param>
        public void DisplayTalkTo(NPC npc)
        {
            ISpeak speakingNpc = npc as ISpeak;
            IModify modifyingNpc = npc as IModify;

            string message = speakingNpc.Speak();

            if (message == "")
            {
                message = "It appears this character has nothing to say.  Please try agian.";
            }

            DisplayGamePlayScreen("Speak to Character", message, ActionMenu.NpcMenu, "");

            _gamePlayer.Health += modifyingNpc.HealthModifier;
        }

        /// <summary>
        /// display message when an invalid teleport is attempted
        /// </summary>
        public void DisplayInvalidTeleport()
        {
            DisplayInputErrorMessage("You may not teleport to another location inside the wizard's tower." + 
                "Press any key to continue.");

            Console.ReadKey();
        }

        /// <summary>
        /// display the end game info and wrap up the game
        /// </summary>
        public void EndGame()
        {
            string message = "Moments away from death, you prepare to meet your fate.  Perhaps facing death " +
                "has heightened your sense of awareness.  You notice wisps of smoke wafting from the portable " +
                "hole on the dragon's head.  The wisps quickly turn into billows and the dragon emits a confused " + 
                "and pained roar.  The dragon begins thrashing around as liquid pours out of the portable hole " +
                "and engulfs the dragon.  It is the acid from the lake (of acid).  The acid quickly dissolves the dragon's " +
                "head and continues to pool on the ground dissolving the rest of the dragon's body.  You quickly run " +
                "away to a safe distance and watch as the dragon disappears into the spreading lake of acid." + 
                "\n"  +
                "\n" +
                "Miraculously, you have prevailed.  Congratulations!";

            DisplayGamePlayScreen("Huzzah!", message, ActionMenu.QuestIntro, "Press any key to continue.");

            Console.ReadKey();

            message = "Your victory appears to be short-lived.  Even as the last of Jeedub'ex's body dissolves away, " + 
                "the ground in all directions appears to boil.  Thousands of juvenile Jeedub'ex dragons erupt from " + 
                "the ground.  The evil wizard Mikrozoff has permeated the land with copies of his dragon.  Soon, they " +
                "invade every corner of the realm.  No place is safe from their ravenous appetites.  You wail in " +
                "despair as a mass of dragons quickly devours you.";

            DisplayGamePlayScreen("Oh $#!%!", message, ActionMenu.QuestIntro, "Press any key to continue.");

            Console.ReadKey();
        }


        /// <summary>
        /// display the notification that the player has expended all lives, ending the game
        /// </summary>
        public void DisplayKillScreen()
        {
            DisplayGamePlayScreen("Game Over, Man!", "You died.  You're dead.  Maybe next time, don't die so much.", ActionMenu.QuestIntro, "Press any key to continue.");

            Console.ReadKey();
            
        }

        #endregion

        #endregion
    }
}
