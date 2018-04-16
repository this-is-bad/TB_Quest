using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_Quest
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum PlayerAction
    {
        None,
        PlayerSetup,
        PlayerNameChange,
        PlayerAgeChange,
        PlayerRaceChange,
        LookAround,
        Travel,

        PlayerMenu,
        PlayerInfo,
        Inventory,
        PlayerLocationsVisited,
        
        ObjectMenu,
        LookAt,
        UseObject,
        PickUp,
        PutDown,
       
        NonplayerCharacterMenu,
        TalkTo,

        AdminMenu,
        ListLocations,
        ListGameObjects,
        ListNonPlayerCharacters,

        ReturnMainMenu,
        Exit,

        WizardExit
    }
}
