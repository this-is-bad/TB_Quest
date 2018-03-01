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
            _playingGame = _gameConsoleView.DisplaySpashScreen();

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
                _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");

                //
                // game loop
                //
                while (_playingGame)
                {
                    //
                    // get next game action from player
                    //
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                    //
                    // choose an action based on the player's menu choice
                    //
                    switch (playerActionChoice)
                    {
                        case PlayerAction.None:
                            break;

                        case PlayerAction.PlayerInfo:
                            _gameConsoleView.DisplayPlayerInfo();
                            break;
                        case PlayerAction.ListLocations:
                            _gameConsoleView.DisplayListOfLocations();
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

            _gamePlayer.Name = player.Name;
            _gamePlayer.Age = player.Age;
            _gamePlayer.Race = player.Race;
            _gamePlayer.HomeVillage = player.HomeVillage;
            _gamePlayer.LocationID = 1;

            //_gamePlayer.Name = "Random Guy";
            //_gamePlayer.Age = 33;
            //_gamePlayer.Race = Character.RaceType.Human;
            //_gamePlayer.HomeVillage = "Hoth";
            //_gamePlayer.LocationID = 1;
        }

        /// <summary>
        /// quit the game
        /// </summary>
        private void QuitQuest()
        {
            _gameConsoleView.DisplayExitScreen();
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

        #endregion
    }
}
