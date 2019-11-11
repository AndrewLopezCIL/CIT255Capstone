using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        public enum AttackType {
            BasicAttack, SkillOneAttack, SkillTwoAttack, SkillThreeAttack, ThirdEyeAttack
        }
        public enum ClassType
        {
            Warrior, Archer, Mage
        }
        public enum PlayerState
        {
            Fighting, Neutral
        }
        #region FIELDS
        private double _shield;
        //private double _basicAttack = 3.2;
        private double _basicAttack = 50.0;
        private double _skillOneAttack;
        private double _skillTwoAttack;
        private double _skillThreeAttack;
        private double _thirdEyeAttack;
        private int _playerLevel;
        private double _playerXP;
        private int _gold;
        private AttackType attackType;
        private ClassType classType;
        private PlayerState _playerState;
        private Enemy _currentlyAttacking;
        private double _maxLevelXPRange = 250.5;
        private double _minLevelXPRange;
        // May remove quest points in the future
        private int _questPoints;
        private Item _equippedWeapon;
        private Item _equippedArmor;
        #endregion

        #region PROPERTIES
        public Item EquippedWeapon
        {
            get { return _equippedWeapon; }
            set { _equippedWeapon = value; }
        }
        public Item EquippedArmor
        {
            get { return _equippedArmor; }
            set { _equippedArmor = value; }
        }

        public double MaxLevelXPRange
        {
            get { return Level * _maxLevelXPRange; } 
        }
        public double MinLevelXPRange
        {
            get { return _minLevelXPRange; }
            set { _minLevelXPRange = value; }
        }
         
        private double playerShieldMax;
            public double PlayerShieldMax
        {
            get { return playerShieldMax; }
            set { playerShieldMax = value; }
        }
        public PlayerState PlayersCurrentState
        {
            get { return _playerState;  }
            set { _playerState = value; }
        }

        public AttackType AttackTypeProp
        {
            get { return attackType; }
            set { attackType = value;  }
        }
        public ClassType ClassTypeProp
        {
            get { return classType; }
            set { classType = value; }
        }
        private string _classToString;
        public string ClassToString
        {
            get { return _classToString; }
            set { _classToString = ClassTypeProp.ToString(); }
        }

        public int Level
        {
            get { return _playerLevel; }
            set { _playerLevel = value; }
        }

        public int QuestPoints
        {
            get { return _questPoints; }
            set { _questPoints = value; }
        }
        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
        public double XP
        {
            get { return _playerXP; }
            set { _playerXP = value; }
        }

        public double Shield
        {
            get{ return _shield; }
            set { _shield = value; }
        }
        public double BasicAttack
        {
            get { return _basicAttack; }
            set { _basicAttack = value; }
        }
        public double SkillOneAttack
        {
            get { return _skillOneAttack; }
            set { _skillOneAttack = value; }
        }
        public double SkillTwoAttack
        {
            get { return _skillTwoAttack; }
            set { _skillTwoAttack = value; }
        }
        public double SkillThreeAttack
        {
            get { return _skillThreeAttack; }
            set { _skillThreeAttack = value; }
        }
        public double ThirdEyeAttack
        {
            get { return _thirdEyeAttack; }
            set { _thirdEyeAttack = value; }
        }
        public Enemy currentlyAttacking
        {
            get{ return _currentlyAttacking; }
            set { _currentlyAttacking = value; }
        }
        private ObservableCollection<Item> _inventory = new ObservableCollection<Item>();
        public ObservableCollection<Item> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        private ObservableCollection<Item> _equippedItems = new ObservableCollection<Item>();
        public ObservableCollection<Item> EquippedItems
        {
            get { return _equippedItems; }
            set { _equippedItems = value; }
        }

        

        #endregion

        #region METHODS 
        public override string GetName()
            {
                return base.GetName();
            }
        
            public override bool Alive()
            {
                return IsAlive ? true : false;
            }
        public void setClassTypeSkillDamage()
        {
            switch (classType)
            {
                case ClassType.Warrior:
                    //SkillOneAttack = 
                    //SkillTwoAttack =
                    //SkillThreeAttack = 
                    break;
                case ClassType.Archer:
                    //SkillOneAttack = 
                    //SkillTwoAttack =
                    //SkillThreeAttack = 
                    break;
                case ClassType.Mage:
                    //SkillOneAttack = 
                    //SkillTwoAttack =
                    //SkillThreeAttack = 
                    break;
                default:
                    break;
            }
        }
        public void CheckPlayerDeathEvent(GameSessionViewModel gsm, GameSessionView gsv)
        {
            if (gsm.PlayerHealth <= 0)
            {
                gsm.Player.IsAlive = false;
                gsv.AttackButton.IsEnabled = false;
                gsv.InventoryButton.IsEnabled = false;
                gsv.SkillsButton.IsEnabled = false;
                gsv.DialogueBox.Foreground = Brushes.Red;
                gsv.DialogueBox.FontWeight = FontWeights.Bold;
                gsv.DialogueBox.Text = "YOU HAVE FALLEN!";
                gsv.TipsBox.FontWeight = FontWeights.Bold;
                gsv.TipsBox.Text = "{ GAVE OVER }: Load last save or restart the game.";
                Location.disableControls(gsv);
            }
            }
        public void playerLevelUp(GameSessionViewModel gsm, GameSessionView gsv)
        {
            gsm.PlayerLevel += 1; 
            gsm.MinPlayerXP = gsm.Player.XP;
            gsv.playerStatsWindow.PlayerXPBar.Value = gsm.PlayerXP;
            gsv.playerStatsWindow.PlayerXPBar.Minimum = gsm.PlayerXP;
            
            gsv.playerStatsWindow.PlayerXPBar.Maximum = gsm.MaxPlayerXP;
            
        }
        #endregion

        #region CONSTRUCTORS 

        public void AttackEnemy(GameSessionViewModel gsm, GameSessionView GSV, AttackType typeOfAttack)
        {
            // setting fightingEnemy to the enemy with position in currentEnemies of 
            // Send id of currentfightingenemy and set fightingenemy to currentenemieswiththat position
            // What if current fighting id is 15 and the list is only 4 big, then it would be out of bounds error
            // Need to look for enemy with a specific listPlacement 
            Enemy fightingEnemy = gsm.Player.currentlyAttacking;
            attackType = typeOfAttack;
            //
            // ADD IN, IF NOT SELECTED THEN AUTOMATICALLY ATTACK FIRST ENEMY IN LIST
            // 
            if (gsm.CurrentEnemies.Count > 0) {
                //If current enemy is alive/has more than 0 health
                if (PlayersCurrentState == PlayerState.Fighting) {
                    bool anEnemyHasSelection = false;
                    for(int enemy = 0; enemy < gsm.CurrentEnemies.Count; enemy++){
                            if(gsm.CurrentEnemies[enemy].SelectedToFight == true){
                                anEnemyHasSelection = true;break;
                            }
                            else if(gsm.CurrentEnemies[enemy].SelectedToFight == false){
                                 anEnemyHasSelection = false;
                                }                              
                            }
                    /*
                    foreach (Enemy enemy in gsm.CurrentEnemies)
                    { 
                        if (enemy.SelectedToFight == true)
                        {
                            anEnemyHasSelection = true; break;
                        }
                        else if (enemy.SelectedToFight == false)
                        {
                            anEnemyHasSelection = false;
                        } 
                    }
                    */

                    if (anEnemyHasSelection == false)
                    {
                        gsm.Player.currentlyAttacking = gsm.CurrentEnemies[0];
                        gsm.CurrentEnemies[0].SelectedToFight = true;
                        gsm.CurrentEnemies[0].AttackingPlayer = true; 
                        gsm.CurrentEnemies[0].startAttackingPlayer();
                        gsm.CurrentEnemyID = gsm.CurrentEnemies[0].ID;
                        gsm.CurrentFightingEnemyListPlacement = gsm.CurrentEnemies[0].listPlacement;
                        fightingEnemy = gsm.CurrentEnemies[0];
                        GSV.EnemyHealthDisplay.Visibility = System.Windows.Visibility.Visible;
                        GSV.EnemyHealthDisplay.Maximum = fightingEnemy.MaxHealth;
                        GSV.EnemyHealthDisplay.Value = fightingEnemy.Health;
                        gsm.EnemyDamage = fightingEnemy.BaseAttack;
                        gsm.EnemyHealth = fightingEnemy.Health;
                        gsm.EnemyLevel = fightingEnemy.Level;
                        gsm.EnemyName = fightingEnemy.Name;
                        GSV.EnemyPicture.Source = gsm.Player.currentlyAttacking.PictureSource;
                        GSV.enemyStatsWindow.EnemyStatsPicture.Source = gsm.Player.currentlyAttacking.PictureSource;
                        GSV.enemyStatsWindow.EnemyStatsPicture.Visibility = System.Windows.Visibility.Visible; 
                    }
                    if (fightingEnemy.IsAlive == true)
            {
                switch (attackType)
                {
                    case AttackType.BasicAttack:
                        GSV.EnemyHealthDisplay.Visibility = System.Windows.Visibility.Visible;
                                if (gsm.Player.EquippedWeapon != null) { fightingEnemy.Health -= gsm.Player.EquippedWeapon.Damage; }
                                else if (gsm.Player.EquippedWeapon == null) { fightingEnemy.Health -= gsm.Player.BasicAttack; }
                        GSV.EnemyHealthDisplay.Value = fightingEnemy.Health;
                       // GSV.DialogueBox.Text = fightingEnemy.Health.ToString();
                        gsm.EnemyDamage = fightingEnemy.BaseAttack;
                        gsm.EnemyHealth = fightingEnemy.Health;
                        gsm.EnemyLevel = fightingEnemy.Level;
                        gsm.EnemyName = fightingEnemy.Name;
                        GSV.EnemyPicture.Source = fightingEnemy.PictureSource;
                        GSV.enemyStatsWindow.EnemyStatsPicture.Source = fightingEnemy.PictureSource;
                         if (fightingEnemy.Health <= 0)
                            {
                            fightingEnemy.Health = 0;
                            //deals with removal of enemy from lists
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy);
                            fightingEnemy.stopAttackingPlayer();
                                    if (fightingEnemy.IsBoss == true) {
                                        GSV.TipsBox.Foreground = Brushes.LightBlue;
                                        GSV.TipsBox.FontSize = 15;
                                        GSV.TipsBox.Text = "Congratulations, you have slain the boss!";
                                    }
                                    if (gsm.GameMap.CurrentLocation.BossFightRoom == true && gsm.CurrentEnemies.Count <= 0)
                                    {
                                        GSV.DialogueBox.Foreground = Brushes.LightBlue;
                                        GSV.DialogueBox.FontSize = 15;
                                        GSV.DialogueBox.FontWeight = FontWeights.Bold;
                                        GSV.DialogueBox.HorizontalContentAlignment = HorizontalAlignment.Center;
                                        GSV.DialogueBox.VerticalContentAlignment = VerticalAlignment.Center;
                                        GSV.DialogueBox.Text = "You have cleared the boss room!";
                                    }
                            //GSV.DialogueBox.Text = fightingEnemy.Health.ToString();
                            fightingEnemy.onDeathRewardPlayer(gsm, fightingEnemy);
                            GSV.EnemyHealthDisplay.Visibility = System.Windows.Visibility.Hidden;
                            fightingEnemy.AttackingPlayer = false;
                            GSV.enemyStatsWindow.EnemyStatsPicture.Visibility = System.Windows.Visibility.Hidden;
                                    //
                                    // On enemy death, add enemy loot drop items to the current location's inventory
                                    //
                                    foreach (Item itemDrop in fightingEnemy.ItemDrop)
                                    {
                                        bool hasItem = false;
                                        //
                                        // Search the current location's lootable items inventory
                                        //
                                    for(int item = 0; item < gsm.GameMap.CurrentLocation.LootableItems.Count; item++)
                                    {
                                            //
                                            // If the current location's lootable items inventory has an item with the name
                                            // that is the same as the item drop's name, then increment it's stack count
                                            //
                                        if (gsm.GameMap.CurrentLocation.LootableItems[item].Name == itemDrop.Name && itemDrop.SpecialObject == false)
                                        {
                                                hasItem = true;
                                                gsm.GameMap.CurrentLocation.LootableItems[item].ItemStackCount += 1;
                                                break;
                                        } 
                                        else if (gsm.GameMap.CurrentLocation.LootableItems[item].Name == itemDrop.Name && itemDrop.SpecialObject == true)
                                            {
                                                hasItem = true;
                                                gsm.GameMap.CurrentLocation.LootableItems.Add(itemDrop);
                                                break;
                                            }
                                        //
                                        // If the current location's lootable items inventory does not have an item with the same
                                        // name as the item drop item then set hasItem to false
                                        //
                                        else if (gsm.GameMap.CurrentLocation.LootableItems[item].Name != itemDrop.Name)
                                            {
                                                hasItem = false;
                                            } 
                                    }
                                    //
                                    // OUT OF THE FOR LOOP 
                                    // If hasItem = false then add the item to the lootable item's inventory
                                    //
                                        if (hasItem == false)
                                        {
                                            gsm.GameMap.CurrentLocation.LootableItems.Add(itemDrop);
                                        }
                                    }
                              for(int enemy = 0; enemy < gsm.CurrentEnemies.Count; enemy++){
                                   if(gsm.CurrentEnemies[enemy].SelectedToFight == true){
                                            gsm.CurrentEnemies[enemy].SelectedToFight = false;
                                        }
                                }/*
                                foreach (Enemy enemy in gsm.CurrentEnemies)
                                    {
                                        if (enemy.SelectedToFight == true)
                                        {
                                            enemy.SelectedToFight = false;
                                        } 
                                    }
                                    */
                            fightingEnemy.SelectedToFight = false;
                            
                            if (gsm.PlayerXP >= gsm.MaxPlayerXP)
                            {
                                playerLevelUp(gsm,GSV);
                            }
                            if (gsm.CurrentEnemies.Count == 0)
                            {
                              Location.enableControls(GSV);
                                        gsm.EnemyDamage = 0;
                                        gsm.EnemyHealth = 0;
                                        gsm.EnemyName = "Currently Not Fighting";
                                        gsm.EnemyLevel = 0;
                            }
                        }
                         
                        break;
                    case AttackType.SkillOneAttack:
                        fightingEnemy.Health -= SkillOneAttack;
                        if (fightingEnemy.Health <= 0)
                        {
                            fightingEnemy.Health = 0;
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy);
                        }
                        break;
                    case AttackType.SkillTwoAttack:
                        fightingEnemy.Health -= SkillTwoAttack;
                        if (fightingEnemy.Health <= 0)
                        {
                            fightingEnemy.Health = 0;
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy);
                        }
                        break;
                    case AttackType.SkillThreeAttack:
                        fightingEnemy.Health -= SkillThreeAttack;
                        if (fightingEnemy.Health <= 0)
                        {
                            fightingEnemy.Health = 0;
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy);
                        }
                        break;
                    case AttackType.ThirdEyeAttack:


                        if (fightingEnemy.IsAlive == true)
                        {
                            fightingEnemy.Health -= ThirdEyeAttack;
                        }
                        if (fightingEnemy.Health <= 0)
                        {
                            fightingEnemy.Health = 0;
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy);
                        }
                        break;
                    default:
                        break;
                }

            }
        }
            
        }
        #endregion

        
    }
}
    }