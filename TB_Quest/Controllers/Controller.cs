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
            _playingGame = true;

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

                _gameConsoleView.DisplayGamePlayScreen("Current Location",
                        Text.CurrentLocationInfo(_currentLocation), ActionMenu.ReturnMenu(ActionMenu.MainMenu), "");

                //if (_gamePlayer.LocationID == 1)
                //{
                //    _gameConsoleView.DisplayGamePlayScreen("Current Location",
                //    Text.CurrentLocationInfo(_currentLocation), ActionMenu.PlayerSetup, "");
                //}
                //else
                //{
                //    _gameConsoleView.DisplayGamePlayScreen("Current Location",
                //        Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                //}

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
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ReturnMenu(ActionMenu.MainMenu));

                    //if (_gamePlayer.LocationID == 1)
                    //{
                    //    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.PlayerSetup);
                    //}
                    //else
                    //{
                    //    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    //}
                    

                    //
                    // choose an action based on the player's menu choice
                    //
                    switch (playerActionChoice)
                    {
                        case PlayerAction.None:
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
                        case PlayerAction.ListCharacters:
                            _gameConsoleView.DisplayListOfCharacters();
                            break;
                       case PlayerAction.ListItems:
                            _gameConsoleView.DisplayListOfItems();
                            break;
                       case PlayerAction.ListLocations:
                            _gameConsoleView.DisplayListOfLocations();
                            break;
                       case PlayerAction.ListTreasures:
                            _gameConsoleView.DisplayListOfTreasures();
                            break;
                        case PlayerAction.AdminMenu:
                            _gameConsoleView.DisplayAdminMenu();
                            break;
                        case PlayerAction.LookAround:
                            _gameConsoleView.DisplayLookAround();
                            break;
                        case PlayerAction.PlayerLocationsVisited:
                            _gameConsoleView.DisplayLocationsVisited();
                            break;
                        case PlayerAction.Travel:
                            //
                            // get new location choice and update the current location property
                            //
                            _gamePlayer.LocationID = _gameConsoleView.DisplayGetNextLocation();

                            if (_gamePlayer.LocationID == 1)
                            {
                                Program.Setup = true;
                            }
                            else
                            {
                                Program.Setup = false;
                            }
                            _currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);
                            //
                            // set the game play screen to the current location info format
                            //

                            _gameConsoleView.DisplayGamePlayScreen("Current Location",
                                Text.CurrentLocationInfo(_currentLocation), ActionMenu.ReturnMenu(ActionMenu.MainMenu), "");

                            //if (_gamePlayer.LocationID == 1)
                            //{
                            //    _gameConsoleView.DisplayGamePlayScreen("Current Location",
                            //    Text.CurrentLocationInfo(_currentLocation), ActionMenu.PlayerSetup, "");
                            //}
                            //else
                            //{
                            //    _gameConsoleView.DisplayGamePlayScreen("Current Location",
                            //        Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                            //}
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
            // comment this out after it is fully implemented
            Player player = _gameConsoleView.GetInitialPlayerInfo();

            //_gamePlayer.Name = player.Name;
            //_gamePlayer.Age = player.Age;
            //_gamePlayer.Race = player.Race;
            //_gamePlayer.HomeVillage = player.HomeVillage;
            //_gamePlayer.LocationID = 1;
            //Player player = new Player();
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
            //timer.Elapsed += async (sender, e) => await Timer_Elapsed();
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

        #endregion
    }
}
