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
        PlayerLocationsVisited,
        LookAround,
        LookAt,
        PickUp,
        PutDown,
        Travel,
        PlayerInfo,
        Inventory,
        PlayerTreasure,
        AdminMenu,
        ListCharacters,
        ListGameObjects,
        ListLocations,
        ListItems,
        ListTreasures,
        ReturnMainMenu,
        Exit
    }
}
