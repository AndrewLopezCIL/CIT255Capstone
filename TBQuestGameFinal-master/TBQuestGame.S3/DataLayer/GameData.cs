using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.Models.NPCs;

namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        public int currentEnemyID = 0;
        public int itemID = 0;
      //  public ObservableCollection<Item> playerInventory;
        //public ObservableCollection<Item> locationLoot;
        public ObservableCollection<Item> playerEquippedItems;
        
        public static Player PlayerData()
        {

            return new Player()
            {
                Id = 1,
                Name = "Player",
                // default attack = 3.2
                BasicAttack = 3.2,
                Gold = 0,
                Health = 100,
                PlayerShieldMax = 100,
                Shield = 35,
                IsAlive = true,
                LocationId = 0,
                QuestPoints = 0,
                SkillOneAttack = 0,
                SkillTwoAttack = 0,
                SkillThreeAttack = 0,
                ThirdEyeAttack = 0,
                XP = 0,
                Level = 1, 
                MinLevelXPRange = 0, 
                StateOfAction = Character.ActionType.Neutral
            };

        }
        public static List<string> GameMapData()
        {
            List<string> mapLocations = new List<string>();
            mapLocations.Add("Kardon Dungeon");
            mapLocations.Add("Yin Village");
            mapLocations.Add("Dark Forests");
            mapLocations.Add("Vickren Dungeon");
            mapLocations.Add("Rohand Village");
            return mapLocations;
        }
        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }
        public static Map GameMap()
        {
            //3,4
            int rows = 4;
            int columns = 5;

            Map gameMap = new Map(rows, columns);

            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 4,
                Name = "Yin Village",
                Description = "Yin Village used to be home to humans, but was over ran by a group of bandits.",
                Accessible = true,
                BossFightRoom = false,
                ChanceOfFight = false,
                MultiAttackLocation = false,
                DefaultWeaponChosen = false,
                ExceptionRoom = true,
                LocationMessage = "You look around to see your village\n overran by a group of bandits...\n" +
                "You decide to run, but won't leave until you have a weapon\nYou see three weapons on the guards table, which do you choose?",
                LocationTip = "/Grab <Sword> or <Bow> or <Staff>",
                LocationWarningImage = "grayswordiconblack.png", LocationWarningMessage = "Moderate Area!"  
            };
            gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 1,
                Name = "The Dark Forest Swamp",
                Description = "The Dark Forest Swamp is home to dangerous swamp like creatures that aren't very fond of humans.",
                Accessible = true,
                BossFightRoom = false,
                ChanceOfFight = true,
                MultiAttackLocation = false,
                LocationMessage = "You walk into a forest and stumble upon a swamp\nYou sense evil in the area..", LocationWarningImage = "grayswordiconblack.png", LocationWarningMessage = "Moderate Area!"
           ,LocationTip="No enemies in the area, keep moving." 
            };

            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 3,
                Name = "Vickren Dungeon",
                Description = "Vickren Dungeon is where the Great Knight resides... [ BOSS ROOM ]",
                Accessible = true,
                ChanceOfFight = false,
                BossFightRoom = true,
                MultiAttackLocation = true,
                LocationMessage = "You venture into a mysterious dungeon, and find it's a trap! \n{ BOSS ROOM }",
                LocationWarningImage = "grayswordiconblack.png", LocationWarningMessage = "[Boss Room] Multi-Attack Area!" ,LocationTip="Cannot leave the area until all enemies are dead!"
            
            };
            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 4,
                Name = "Kardon Dungeon",
                Description = "Kardon Dungeon is where the Great Kardon Dragon resides... [ BOSS ROOM ]",
                Accessible = false,
                ChanceOfFight = true,
                BossFightRoom = true,
                MultiAttackLocation = true,
                LocationMessage = "You enter the Kardon Dungeon...",
                LocationWarningImage = "grayswordiconblack.png", LocationWarningMessage = "[Boss Room] Multi-Attack Area" 
            };
            gameMap.MapLocations[2, 0] = new Location()
            {
                Id = 5,
                Name = "Rohand Village",
                Description = "Rohand Village is home to the only humans left on the planet.",
                MultiAttackLocation = false,
                Accessible = false, BossFightRoom = false, ChanceOfFight = true, LocationMessage = "You find Rohand Village,\nthe people's eyes are filled with terror\n and an evil presence is noticable.",
                LocationWarningImage = "grayswordiconblack.png", LocationWarningMessage = "Moderate Area" 
            };
            gameMap.MapLocations[2, 1] = new Location()
            {
                Id = 2,
                Name = "The Dark Forest",
                Description = "The Dark Forest is home to many evil forces that try and wipe out humanity.", Accessible = true,
                BossFightRoom = true,
                ChanceOfFight = true,
                MultiAttackLocation = true,
                LocationMessage = "The Dark Forest, home to the Great Wizard...",
                LocationWarningImage = "grayswordiconblack.png", LocationWarningMessage = "Multi-Attack Area!" 
            };
            gameMap.MapLocations[2, 2] = new Location()
            {
                Id = 6,
                Name = "Trader Sid's",
                Description = "A Nice place to purchase some well needed goods.",
                BossFightRoom = false,
                ChanceOfFight = false,
                MultiAttackLocation = false,
                LocationMessage = "Welcome to Trader Sid's!",
                LocationTip = "To interact with Trader Sid, click \nthe interactions tab",
                LocationWarningMessage = "Safe Area!",InSidShop = true
            };
            return gameMap;
        }
        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "Welcome to the text-based game called Swendiver. In this game you will go on an adventure killing monsters and doing quests, " +
                "following an exciting storyline, leveling up your character.",
                "Swendiver was created by Andrew Lopez.",
                " Enjoy the game!"
           };
        }
    }
}
