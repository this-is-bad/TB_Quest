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
        PickUpItem,
        PickUpTreasure,
        PutDownItem,
        PutDownTreasure,
        Travel,
        PlayerInfo,
        PlayerInventory,
        PlayerTreasure,
        AdminMenu,
        ListCharacters,
        ListLocations,
        ListItems,
        ListTreasures,
        Exit
    }
}
