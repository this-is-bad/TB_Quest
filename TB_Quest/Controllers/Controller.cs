using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TB_Quest
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Universe _gameUniverse;
        private bool _playingGame;
        private Location _currentLocation;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gamePlayer = new Player();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);
            InanimateObject inanimateObject;
            _playingGame = true;

            //
            // add the event handler for adding/subtracting to/from inventory
            //
            foreach (GameObject gameObject in _gameUniverse.GameObjects)
            {
                if (gameObject is InanimateObject)
                {
                    inanimateObject = gameObject as InanimateObject;
                    inanimateObject.ObjectAddedToInventory += HandleObjectAddedToInventory;
                    inanimateObject.ObjectUsed += HandleObjectUsed;
                }
            }

            Program.Setup = true;

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction playerActionChoice = PlayerAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySplashScreen(true);

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                QuitQuest();
            }
            else
            {
                //
                // display introductory message
                //
                _gameConsoleView.DisplayGamePlayScreen("Quest Intro", Text.QuestIntro(), ActionMenu.QuestIntro, "");
                _gameConsoleView.GetContinueKey();

                //
                // initialize the Quest player
                // 
                InitializeQuest();

                //
                // prepare game play screen
                //
                _currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);

                ActionMenu.currentMenu = ActionMenu.CurrentMenu.PlayerSetup;

                _gameConsoleView.DisplayGamePlayScreen("Current Location",
                    Text.CurrentLocationInfo(_currentLocation), ActionMenu.PlayerSetup, "");

                //
                // game loop
                //
                while (_playingGame)
                {
                    //
                    // process all flags, events, and stats
                    //
                    UpdateGameStatus();

                    //
                    // get next game action from player
                    //
                    playerActionChoice = GetNextPlayerAction();

                    //
                    // choose an action based on the player's menu choice
                    //
                    switch (playerActionChoice)
                    {
                        case PlayerAction.None:
                            break;
                        case PlayerAction.PlayerSetup:
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.PlayerSetup;
                            _gameConsoleView.DisplayGamePlayScreen("Player Menu", "Select an action from the menu.",
                                ActionMenu.PlayerSetup, "");
                            break;
                        case PlayerAction.PlayerMenu:
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.PlayerMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Player Menu", "Select an action from the menu.",
                                ActionMenu.PlayerMenu, "");
                            break;
                        case PlayerAction.PlayerNameChange:
                            _gameConsoleView.DisplayUpdatePlayerName();
                            break;
                        case PlayerAction.PlayerAgeChange:
                            _gameConsoleView.DisplayUpdatePlayerAge();
                            break;
                        case PlayerAction.PlayerRaceChange:
                            _gameConsoleView.DisplayUpdatePlayerRace();
                            break;
                        case PlayerAction.PlayerInfo:
                            _gameConsoleView.DisplayPlayerInfo();
                            break;
                        case PlayerAction.ListNonPlayerCharacters:
                            _gameConsoleView.DisplayListOfAllNpcObjects();
                            break;
                        case PlayerAction.ListGameObjects:
                            _gameConsoleView.DisplayListOfAllGameObjects();
                            break;
                        case PlayerAction.ListLocations:
                            _gameConsoleView.DisplayListOfLocations();
                            break;
                        case PlayerAction.ReturnMainMenu:
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Main Menu", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                            break;
                        case PlayerAction.AdminMenu:
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an action from the menu.", ActionMenu.AdminMenu, "");
                            break;
                        case PlayerAction.ObjectMenu:
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an action from the menu", ActionMenu.ObjectMenu, "");
                            break;
                        case PlayerAction.NonplayerCharacterMenu:
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                            _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an action from the menu", ActionMenu.NpcMenu, "");
                            break;
                        case PlayerAction.TalkTo:
                            TalkToAction();
                            break;
                        case PlayerAction.LookAround:
                            _gameConsoleView.DisplayLookAround();
                            break;
                        case PlayerAction.PlayerLocationsVisited:
                            _gameConsoleView.DisplayLocationsVisited();
                            break;
                        case PlayerAction.LookAt:
                            LookAtAction();
                            break;
                        case PlayerAction.PickUp:
                            PickUpAction();
                            break;
                        case PlayerAction.UseObject:
                            UseObjectAction();
                            break;
                        case PlayerAction.PutDown:
                            PutDownAction();
                            break;
                        case PlayerAction.Inventory:
                            _gameConsoleView.DisplayInventory();
                            break;
                        case PlayerAction.Travel:
                            //
                            // get new location choice and update the current location property
                            //
                            _gamePlayer.LocationID = _gameConsoleView.DisplayGetNextLocation();

                            _currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);
                            //
                            // set the game play screen to the current location info format
                            //
                            UpdateLocation();
                            break;

                        case PlayerAction.Exit:
                            _playingGame = false;
                            break;

                        default:
                            break;
                    }
                }

                //
                // close the application
                //
                QuitQuest();
            }
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeQuest()
        {
            //_gamePlayer.Name = player.Name;
            //_gamePlayer.Age = player.Age;
            //_gamePlayer.Race = player.Race;
            //_gamePlayer.HomeVillage = player.HomeVillage;
            //_gamePlayer.LocationID = 1;
            //_gamePlayer.PreviousLocationID = 1;
            //Player player = new Player();


            // comment this out after it is fully implemented
            Player player = _gameConsoleView.GetInitialPlayerInfo();
            _gamePlayer.ObjectID = 0;
            _gamePlayer.ExperiencePoints = 0;
            _gamePlayer.Health = 100;
            _gamePlayer.Lives = 3;
            _gamePlayer.Name = "random guy";
            _gamePlayer.Age = 33;
            _gamePlayer.Race = Character.RaceType.Human;
            _gamePlayer.HomeVillage = "hoth";
            _gamePlayer.LocationID = 1;
        }

        /// <summary>
        /// quit the game
        /// </summary>
        private void QuitQuest()
        {
            _gameConsoleView.DisplaySplashScreen(false);
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        /// <summary>
        /// event handler for timer elapse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Environment.Exit(1);
        }

        /// <summary>
        /// add new location to the list of visited locations if this is the first visit
        /// </summary>
        private void UpdateGameStatus()
        {
            if (!_gamePlayer.HasVisited(_currentLocation.LocationID))
            {
                // 
                // add new location to the list of visited locations if this is the first visit
                //
                _gamePlayer.LocationsVisited.Add(_currentLocation.LocationID);

                //
                // update experience points for visiting locations
                //
                _gamePlayer.ExperiencePoints += _currentLocation.ExperiencePoints;
            }
        }

        /// <summary>
        /// look at an object
        /// </summary>
        private void LookAtAction()
        {
            //
            // display a list of inanimate objects in the locaction and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectsToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the chosen object
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }

        /// <summary>
        /// display a list of inanimate objects in the location and get a choice
        /// </summary>
        private void PickUpAction()
        {
            //
            // display a list of inanimate objects in the location and get a choice
            //
            int inanimateObjectToPickUpId = _gameConsoleView.DisplayGetInanimateObjectToPickUp();

            //
            // add the inanimate object to player's inventory
            //
            if (inanimateObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                InanimateObject inanimateObject = _gameUniverse.GetGameObjectById(inanimateObjectToPickUpId) as InanimateObject;

                //
                // note: inanimate object is added to the list and the location is set to 0
                //
                inanimateObject.LocationID = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmInanimateObjectAddedToInventory(inanimateObject);
            }
        }
        /// <summary>
        /// display a list of inanimate objects in the location and get a choice
        /// </summary>
        private void UseObjectAction()
        {
            //
            // display a list of inanimate objects in the location and the player's inventory and get a choice
            //
            int inanimateObjectToPickUpId = _gameConsoleView.DisplayGetInanimateObjectToUse();

            //
            // use the inanimate object
            //
            if (inanimateObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                InanimateObject inanimateObject = _gameUniverse.GetGameObjectById(inanimateObjectToPickUpId) as InanimateObject;

                //
                // note: inanimate object usage count is decremented
                //               
                inanimateObject.UseCount--;
            }
        }

        /// <summary>
        /// display a list of inanimate objects in inventory and get a player choice
        /// </summary>
        private void PutDownAction()
        {
            //
            // display a list of inanimate objects in inventory and get a player choice
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the universe
            //
            InanimateObject inanimateObject = _gameUniverse.GetGameObjectById(inventoryObjectToPutDownId) as InanimateObject;

            //
            // remove the object from inventory and set the space-time location to the current value
            //
            inanimateObject.LocationID = _gamePlayer.LocationID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmInanimateObjectRemovedFromInventory(inanimateObject);
        }

        /// <summary>
        /// method called by the ObjectAddedToInventory event 
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="e"></param>
        private void HandleObjectAddedToInventory(object gameObject, EventArgs e)
        {
            if (gameObject.GetType() == typeof(InanimateObject))
            {
                InanimateObject inanimateObject = gameObject as InanimateObject;
                switch (inanimateObject.InanimateObjType)
                {
                    case InanimateObjectType.Food:
                        break;
                    case InanimateObjectType.Medicine:
                        break;
                    case InanimateObjectType.Weapon:
                        break;
                    case InanimateObjectType.Treasure:
                        break;
                    case InanimateObjectType.Information:
                        break;
                    default:
                        break;

                }
            }
        }

        /// <summary>
        /// method called by the ObjectUsed event 
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="e"></param>
        private void HandleObjectUsed(object gameObject, EventArgs e)
        {
            if (gameObject.GetType() == typeof(InanimateObject))
            {
                InanimateObject inanimateObject = gameObject as InanimateObject;

                if (inanimateObject.IsUsable)
                {
                    switch (inanimateObject.InanimateObjType)
                    {
                        case InanimateObjectType.Food:
                            break;
                        case InanimateObjectType.Medicine:

                            _gamePlayer.Health += inanimateObject.Value;

                            //
                            // add life if health greater than 100
                            //
                            if (_gamePlayer.Health >= 100)
                            {
                                _gamePlayer.Health = 100;
                                _gamePlayer.Lives += 1;
                            }
                            break;
                        case InanimateObjectType.Weapon:
                            break;
                        case InanimateObjectType.Treasure:
                            break;
                        case InanimateObjectType.Information:
                            break;
                        default:
                            break;
                    }

                    //
                    // recalculate number of uses
                    // 
                    inanimateObject.UseCount += (inanimateObject.IsUsable && inanimateObject.UseCount > 0 ? -1 : 0);

                    //
                    // remove object from the game if it is consumable and has 0 uses remaining
                    //
                    inanimateObject.LocationID = (inanimateObject.IsConsumable && inanimateObject.UseCount == 0 ? -1 : inanimateObject.LocationID);

                    if (inanimateObject.LocationID == -1)
                    {
                        _gameConsoleView.DisplayConfirmInanimateObjectRemovedFromInventory(inanimateObject);
                    }

                    //
                    // display confirmation message
                    //
                    _gameConsoleView.DisplayConfirmInanimateObjectUsed(inanimateObject);

                    SpecialUseCases(inanimateObject);
                }
            }
        }

        /// <summary>
        /// returns a player action, based on the currentMenu variable
        /// </summary>
        /// <returns>PlayerAction</returns>
        private PlayerAction GetNextPlayerAction()
        {
            PlayerAction playerActionChoice = PlayerAction.None;

            if (_gamePlayer.LocationID == 1)
            {
                ActionMenu.currentMenu = ActionMenu.CurrentMenu.PlayerSetup;
            }

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;
                case ActionMenu.CurrentMenu.ObjectMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
                    break;
                case ActionMenu.CurrentMenu.NpcMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;
                case ActionMenu.CurrentMenu.PlayerMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.PlayerMenu);
                    break;
                case ActionMenu.CurrentMenu.PlayerSetup:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.PlayerSetup);
                    break;
                case ActionMenu.CurrentMenu.AdminMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;
                default: break;
            }

            return playerActionChoice;
        }

        /// <summary>
        /// display a list of NPCs in the location and get a player choice, then display the NPC dialog
        /// </summary>
        private void TalkToAction()
        {
            //
            // display a list of NPCs in the location and get a player choice
            //
            int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

            //
            // display NPC's message
            //
            if (npcToTalkToId != 0)
            {
                //
                // get the NPC from the universe
                //
                NPC npc = _gameUniverse.GetNpcById(npcToTalkToId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayTalkTo(npc);
            }
        }

        /// <summary>
        /// decrement an InanimateObject's number of uses if it is usable and has multiple uses
        /// </summary>
        /// <param name="inanimateObject"></param>
        /// <returns>int</returns>
        private int CalculateNumberOfUses(InanimateObject inanimateObject)
        {
            int numberOfUses = (inanimateObject.IsUsable && inanimateObject.UseCount > 0 ? inanimateObject.UseCount - 1 : inanimateObject.UseCount);

            return numberOfUses;
        }

        /// <summary>
        /// a bad pun and a necessary evil to manage the usage of specific items in specific situations
        /// </summary>
        /// <param name="inanimateObject"></param>
        private void SpecialUseCases(InanimateObject inanimateObject)
        {
            switch (inanimateObject.ObjectID)
            {   
                // magic wand
                case 23:
                    break;
                // Professor Pluperfect's Primer Promoting Practical Panic
                case 24:
                    break;
                // Portable Hole
                case 25:
                    break;
                // Polymorph Potion
                case 26:
                    break;
                // Teleportation Ring
                case 27:
                    TeleportPlayer();
                    break;
                //Marble Statue
                case 30:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// move the player between the wizard's tower and an outside location
        /// </summary>
        private void TeleportPlayer()
        {
            if (_currentLocation.LocationID > 3)
            {
                _gamePlayer.PreviousLocationID = _currentLocation.LocationID;
                _gamePlayer.LocationID = 3;
                _currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);
            }
            else if (_currentLocation.LocationID < 4 && _gamePlayer.PreviousLocationID > 3)
            {
                _gamePlayer.LocationID = _gamePlayer.PreviousLocationID;
                _currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);
            }
            else
            {
                _gameConsoleView.DisplayInvalidTeleport();
            }

            UpdateLocation();
        }
        
        /// <summary>
        /// update the player's location
        /// </summary>
        private void UpdateLocation()
        {
            ActionMenu.currentMenu = (_gamePlayer.LocationID == 1 ? ActionMenu.CurrentMenu.PlayerSetup : ActionMenu.CurrentMenu.MainMenu);

            _gameConsoleView.DisplayGamePlayScreen("Current Location",
                Text.CurrentLocationInfo(_currentLocation), (_gamePlayer.LocationID == 1 ? ActionMenu.PlayerSetup : ActionMenu.MainMenu), "");
        }

        #endregion
    }
}
