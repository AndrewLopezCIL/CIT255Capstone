using System.Collections.ObjectModel;

namespace TBQuestGame.Models.NPCs
{
    interface ITrade
    { 
        string Name { get; set; } 
        void NotEnoughGold();
        void ListBuyables();
    }
}