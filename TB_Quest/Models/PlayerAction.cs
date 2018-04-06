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
        LookAround,
        Travel,

        PlayerMenu,
        PlayerInfo, 
        PlayerNameChange,
        PlayerAgeChange,
        PlayerRaceChange,
        PlayerLocationsVisited,
        
        ObjectMenu,
        LookAt,
        UseObject,
        PickUp,
        PutDown,
        Inventory,

        //PlayerTreasure,
        NonplayerCharacterMenu,
        Talkto,

        AdminMenu,
        ListLocations,
        ListGameObjects,
        ListNonPlayerCharacters,

        //ListItems,
        //ListTreasures,
        ReturnMainMenu,
        Exit
    }
}
