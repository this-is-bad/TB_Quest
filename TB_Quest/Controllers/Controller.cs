﻿using System;
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
        private int _itsTheFinalCountdown;

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
            // add the event handler for modifying player's health
            //
            _gamePlayer.HealthModified += HandleHealthModified;

            //
            // add the event handler for adding/subtracting to/from inventory and for using objects
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

                    if (_currentLocation.LocationID == 18 && _itsTheFinalCountdown > 0)
                    {
                        if (--_itsTheFinalCountdown == 0)
                        {
                            _gameConsoleView.EndGame();

                            _playingGame = false;

                            playerActionChoice = PlayerAction.None;

                            QuitQuest();
                        }
                    }
                  
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

                            if (_currentLocation.LocationID == 18)
                            {
                                _gameConsoleView.DisplayGamePlayScreen("Current Location",
                                    "Oh no you don't.  You have to stay and defeat this dragon.", ActionMenu.MainMenu, "");
                            }
                            else
                            {
                                //
                                // get new location choice and update the current location property
                                //
                                _gamePlayer.LocationID = _gameConsoleView.DisplayGetNextLocation();

                                _currentLocation = _gameUniverse.GetLocationById(_gamePlayer.LocationID);
                                //
                                // set the game play screen to the current location info format
                                //
                                UpdateLocation();
                            }
                            break;
                        case PlayerAction.WizardExit:

                            NPC npc = _gameUniverse.GetNpcById(1);
                            npc.LocationID = -1;

                            Location location = _gameUniverse.GetLocationByLocationID(6);
                            location.IsAccessible = true;

                            if (_currentLocation.LocationID == 4)
                            {
                                _currentLocation.Description = $"The {npc.Name} Menu exits the game.  The entrance into the Magical " +
                                    "Hedge Maze is now accessible.";

                                UpdateLocation();

                                _currentLocation.Description = "Here you are, at the entrance to the Magical Hedge Maze.  Look, " +
                                    "I know you did a lot of things to get here but I've got better ways to spend my time than " +
                                    "narrating the litany of your mediocre achievements.  Just take satisfaction in knowing you " +
                                    "got here.";

                                _currentLocation.GeneralContents = "In front of you stands the Long Wall, measuring 15 feet high and hundreds of miles long.  But, your path does not end here.  " +
                                    "It continues through an opening in the wall, beyond which lies the Magic Hedge Maze.";
                            }

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

            Player player = _gameConsoleView.GetInitialPlayerInfo();

            _gamePlayer.Name = player.Name; 
            _gamePlayer.Age = player.Age;
            _gamePlayer.Race = player.Race; 
            _gamePlayer.HomeVillage = player.HomeVillage; 
            _gamePlayer.ObjectID = 0;
            _gamePlayer.LocationID = 1;
            _gamePlayer.PreviousLocationID = 1;
            _gamePlayer.ExperiencePoints = 0;
            _gamePlayer.Health = 100;
            _gamePlayer.Lives = 3;


            // testing code to skip user-configured player setup
            //Player player = _gameConsoleView.GetInitialPlayerInfo();
            //_gamePlayer.ObjectID = 0;
            //_gamePlayer.ExperiencePoints = 0;
            //_gamePlayer.Health = 100;
            //_gamePlayer.Lives = 3;
            //_gamePlayer.Name = "random guy";
            //_gamePlayer.Age = 33;
            //_gamePlayer.Race = Character.RaceType.Human;
            //_gamePlayer.HomeVillage = "hoth";
            //_gamePlayer.LocationID = 1;
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
            int inanimateObjectToUseId = _gameConsoleView.DisplayGetInanimateObjectToUse();

            //
            // use the inanimate object
            //
            if (inanimateObjectToUseId != 0)
            {
                //
                // get the game object from the universe
                //
                InanimateObject inanimateObject = _gameUniverse.GetGameObjectById(inanimateObjectToUseId) as InanimateObject;

                if (inanimateObject.EffectiveLocations.Contains(0) || inanimateObject.EffectiveLocations.Contains(_currentLocation.LocationID))
                {

                    //
                    // note: inanimate object usage count is decremented
                    //               
                    inanimateObject.UseCount--;
                }
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
            string message;

            if (gameObject.GetType() == typeof(InanimateObject))
            {
                InanimateObject inanimateObject = gameObject as InanimateObject;

                if (inanimateObject.IsUsable)
                {
                    if ((inanimateObject.CanInventory && inanimateObject.LocationID == 0) || !inanimateObject.CanInventory)
                    {
                        switch (inanimateObject.InanimateObjType)
                        {
                            case InanimateObjectType.Food:
                                break;
                            case InanimateObjectType.Medicine:

                                _gamePlayer.Health += inanimateObject.Value;

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
                    else
                    {
                        message = $"The {inanimateObject.Name} must be in your inventory before you can use it.";

                        _gameConsoleView.DisplayGamePlayScreen("Use Game Object", message, ActionMenu.ObjectMenu, "");
                    }
                }
            }
        }

        /// <summary>
        /// method called by the ObjectAddedToInventory event 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="e"></param>
        private void HandleHealthModified(object player, EventArgs e)
        {
            if (player.GetType() == typeof(Player))
            {
                Player gamePlayer = player as Player;

                //
                // add life if health greater than 100
                //
                if (gamePlayer.Health > 100)
                {
                    gamePlayer.Lives += 1;
                    gamePlayer.Health = 100;
                }

                if (gamePlayer.Health <= 0 && gamePlayer.Lives > 0)
                {
                    gamePlayer.Lives -= 1;

                    if (gamePlayer.Lives < 1)
                    {
                        //
                        // notify the player that the game is over
                        //
                        _gameConsoleView.DisplayKillScreen();

                        QuitQuest();
                    }
                    else
                    {
                        gamePlayer.Health = 100;
                    }
                }

                if (gamePlayer.Lives != 0)
                {
                    _gameConsoleView.DisplayStatusBox();
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
                case ActionMenu.CurrentMenu.WizardMenu:
                    playerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.WizardMenu);
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
            NPC npc;
            string message;
            switch (inanimateObject.ObjectID)
            {
                // magic wand
                case 23:

                    message = "After a few moments of wildly flailing your arm around, you get bored and stop waving your wand.";

                    _gameConsoleView.DisplayGamePlayScreen("Use Game Object", message, ActionMenu.ObjectMenu, "");

                    break;
                // Professor Pluperfect's Primer Promoting Practical Panic
                case 24:
                    switch (_currentLocation.LocationID)
                    {
                        case 18:
                           message = "If only you had studied this primer more earnestly when you had the chance.  Now, you're "+ 
                                "better off using it to prop up a couch that has a broken leg, and there don't appear to be many " +
                                "of those lying around here.";
                        break;
                        default:
    
                            message = $"Wizards wield great power.  They can bend the laws of the universe to their will and alter " +
                                "reality itself.  Regrettably, and much to the detriment of many a wizard, a power that is often " +
                                "overlooked is the power to panic.  Knowing how and when to panic is one of the most important  " +
                                "skills a wizard can possess.  So, when is the right time to panic?  Every wizard knows that there " +
                                "is never a wrong time to panic.  But, the best wizards know that the best way to panic depends on " +
                                "circumstance.  As Volume 1 in Sage Susurrant's Sorceror Survival Series, Professor Pluperfect's " +
                                "Primer Promoting Practical Panic aims to ground wizards in the basic methods of panicking and " +
                                "how to determine the best method of panicking for most common situations.  Let's begin with one " +
                                "of the most difficult, and yet, universally useful, methods for panicking -- playing dead while " +
                                "running away screaming.  The most important thing to know about this method is...   ";
                            break;
                    }
                    _gameConsoleView.DisplayGamePlayScreen("Use Game Object", message, ActionMenu.ObjectMenu, "");
                break;
                // Portable Hole
                case 25:

                    switch (_currentLocation.LocationID)
                    {
                        case 4:
                            npc = _gameUniverse.GetNpcById(1);

                            if (npc.LocationID == _currentLocation.LocationID)
                            {
                                if (inanimateObject.LocationID == 0)
                                {
                                    inanimateObject.LocationID = _currentLocation.LocationID;

                                    message = $"Pulling the portable hole out of your pocket, you throw it at the {npc.Name}.  " +
                                       $"But, the {npc.Name} casually steps to the side, dodging the portable hole which falls to the ground.  " +
                                       $"You will have to find some other way to defeat the {npc.Name}";

                                    _gameConsoleView.DisplayGamePlayScreen("Use Game Object", message, ActionMenu.ObjectMenu, "");
                                   
                                }
                                else
                                {
                                    message = $"The portable hole must be in your inventory before you can use it.";

                                    _gameConsoleView.DisplayGamePlayScreen("Use Game Object", message, ActionMenu.ObjectMenu, "");
                                }
                           // UpdateLocation();
                            }
                            break;
                        case 17:
                            
                            Location specailLocation = _gameUniverse.GetLocationByLocationID(18);
                            specailLocation.IsAccessible = true;

                            _currentLocation.Description = $"You toss the portable hole into the lake of acid.  It appears that the acid " +
                                "is dissolving the hole as the hole sinks.  Then you notice that the acid appears to be pouring into the hole.  " +
                                "After an hour, a vortex appears in the lake where the portable hole is resting.  After a few more hours, the " + 
                                "last of the lake of acid disappears into the portable hole.  Only a few shallow puddles remain.  The path to " +
                                "the island and what lies beyond is now open to you.  You carefully retrieve the portable hole.";

                            UpdateLocation();

                            _currentLocation.Description = "You stand in the large clearing where the lake of acid used to be.  " + 
                                  "A stillness still permeates this place but it is no longer ominous.  With the lake gone, a large ring of " +
                                  "white sand, which takes on a slight pink hue in certain angles of view, surrounds a small grass mound.  " +
                                  "In the middle of this mound, a stairway descends into the ground.";

                            _currentLocation.GeneralContents = "With the lake of acid gone, this area is rather pleasant.  " +
                                "You briefly consider the possibility of building a home here, then you notice that " +
                                "red acid is slowly seeping up from the ground.  You don't have time to determine whether it's " + 
                                "the result of a natural spring or magic.";
                            break;
                        case 18:

                            inanimateObject.LocationID = -1;

                            message  = $"You throw the portable hole at the dragon.  A gust of wind catches it " +
                                "and lifts it up into the air, before gently depositing it on the dragon's left horn.  I'm not sure " +
                                "what you thought that would accomplish.  The portable hole is small and there's not even a chance " +
                                "that the dragon could put a foot in the hole and sprain its ankle.  Even so, you managed to " +
                                "momentarily distract the dragon, prolonging countless lives by an extra 5 seconds, you hero.  " +
                                "Got any other ideas?";

                            _gameConsoleView.DisplayGamePlayScreen("Use Game Object", message, ActionMenu.ObjectMenu, "");

                            _currentLocation.GeneralContents = "Having one horn hidden by the portable hole doesn't diminish the " +
                                "dragon's fearsomeness or the sense of your impending doom.";
                            
                            //UpdateLocation();

                            _itsTheFinalCountdown = 3;

                            break;
                        default:
                            break;
                    }
                    break;
                // Polymorph Potion
                case 26:
                    switch (_currentLocation.LocationID)
                    {
                        case 4:
                            npc = _gameUniverse.GetNpcById(1);

                            inanimateObject.LocationID = -1;

                            _currentLocation.Description = $"With a clever bit of misdirection, you furtively draw out the polymorph potion " + 
                                $"and cast it at the {npc.Name}.  The potion bottle strikes the {npc.Name} and shatters.  The {npc.Name} " +
                                "is transformed into a menu.";

                            _currentLocation.GeneralContents = "In front of you stands the Long Wall, measuring 15 feet high and hundreds of miles long.  But, your path does not end here.  " +
                                "It continues through an opening in the wall, beyond which lies the Magic Hedge Maze.  In front of the opening, a menu blocks " +
                                "your path.  The menu looks determined to stay there.  You could use magic to scale the Wall but the need to enforce a narrative prevents " +
                                "you from doing so.  You will have to find a way through the opening.";

                            UpdateLocation();

                            _currentLocation.Description = "You have traveled many weeks and faced many trials to get here.  You crossed the Pits of Evil Fire.  " +
                                 "Then, you crossed the Evil Pits of Fire.  You out-styled Cliff the Conjurer in a bare-knuckled contest of coiffure-mancy.  " +
                                 "You scaled the Cliffs (no relation) of Modest Scalability.  You perservered through Hodeg's " +
                                 "Valley of Cute Puppies and Cuddly Kittens.  You survived the interminable boredom " +
                                 "of the Featureless Plains.  You waded through the Swamp of the Indifferent Gators.  " +
                                 "You cavorted across the sea on a pirate party cruise.  You braved the many perils of the Perilous Path.  " +
                                 "You bested Cludar the Fleet-Footed in an Indecision Dance-off.  You did some other stuff too.  And, finally, you " +
                                 "have reached a wall.";

                            inanimateObject.ItemUseMessage = "This appears to have no use here.";

                            break;
                default:
                    break;
            }
            break;
                // Teleportation Ring
                case 27:
                    TeleportPlayer();
                    break;
                //Marble Statue
                case 30:
                    _currentLocation.Description = "On a hunch, you try to move the statue and discover that it rotates on the " +
                        "pedestal.  You turn the statue so that it points to the opening where the basset hound is sitting.  With " +
                        "a wink, the basset hound says \"You found the exit\".  Exuding an aura of arcane energy more powerful than " +
                        "anything you have ever witnessed, the basset hound vanishes as purple lightning arcs out from the place he " +
                        "stood.  The way is now open to you.";

                    inanimateObject.IsUsable = false;

                    UpdateLocation();

                    _currentLocation.Description = "In the middle of this room, a marble statue stands on a pedestal.  " +
                        "There is an opening in the south wall of the room, beyond which lies a dull, red lake.";

                    _currentLocation.GeneralContents = "The statue, a life-size figure of a robed woman, points to the " +
                        "opening in the south wall of the room.  A plaque at the base of the statue that reads \"This way to " +
                                  "the exit\".";

                    npc = _gameUniverse.GetNpcById(5);

                    npc.LocationID = -1;

                    Location location = _gameUniverse.GetLocationById(17);

                    location.IsAccessible = true;

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
            if (_currentLocation.LocationID == 18)
            {
                _gameConsoleView.DisplayGamePlayScreen("Current Location",
                    "You must be too far away from home to use the Teleportation Ring cuz you ain't goin' nowhere.", ActionMenu.ObjectMenu, "");
            }
            else
            {
                if (_currentLocation.LocationID > 3 && _currentLocation.LocationID != 18)
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
        }
        
        /// <summary>
        /// update the player's location
        /// </summary>
        private void UpdateLocation()
        {
            switch (_currentLocation.LocationID)
            {
                case 1:
                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.PlayerSetup;

                    _gameConsoleView.DisplayGamePlayScreen("Current Location",
                        Text.CurrentLocationInfo(_currentLocation), ActionMenu.PlayerSetup, "");
                    break;

                case 4:
                    GameObject gameObject = _gameUniverse.GetGameObjectById(26);


                    NPC npc = _gameUniverse.GetNpcById(1);

                    if (gameObject.LocationID == -1 && npc.LocationID != -1)
                    {
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.WizardMenu;

                        _gameConsoleView.DisplayGamePlayScreen("Current Location",
                            Text.CurrentLocationInfo(_currentLocation), ActionMenu.WizardMenu, "");
                    }
                    else
                    {
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;

                        _gameConsoleView.DisplayGamePlayScreen("Current Location",
                            Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                    }
                    break;
                default:
                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;

                    _gameConsoleView.DisplayGamePlayScreen("Current Location",
                        Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                    break;
            }
        }

        #endregion
    }
}
