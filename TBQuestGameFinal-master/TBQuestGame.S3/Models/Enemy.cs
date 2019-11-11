using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models
{
    public abstract class Enemy : ObservableObject
    {

        #region FIELDS
        public enum EnemyType { Archer, Bandit, Wizard, MudCrawler, ScuffedSpider, BlackKnight, Warrior }
        private double _health;
        private double _baseAttack = 3.9;
        private double _criticalAttack;
        private double _xpDrop;
        private ObservableCollection<Item> _itemDrop = new ObservableCollection<Item>();
        private int _level;
        private string _name; 
        private int _listPlacement;
        public int currentID = 0;
        private int _id;
        private double _maxEnemyHealth;
        private bool _isBoss;
        private bool _selectedToFight = false;
        private EnemyType _typeOfEnemy;
        GameSessionViewModel gameSessionViewModel;
        GameSessionView gameSessionView;
       public DispatcherTimer attackTimer = new System.Windows.Threading.DispatcherTimer();
        //
        // Contains all of the enemie objects the player is currently fighting
        //
        public static ObservableCollection<Enemy> attackingEnemies = new ObservableCollection<Enemy>();

        

        #endregion

        #region PROPERTIES
        public double MaxHealth
        {
            get { return _maxEnemyHealth; }
            set { _maxEnemyHealth = value; }
        }
        public EnemyType TypeOfEnemy
        {
            get { return _typeOfEnemy; }
            set { _typeOfEnemy = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public bool IsBoss
        {
            get { return _isBoss; }
            set { _isBoss = value; }
        }
        public double Health
        {
            get { return _health; }
            set { _health = value; }
        } 
        public double XPDrop
        {
            get { return _xpDrop; }
            set { _xpDrop= value; }
        }
        public int GoldDrop
        {
            get { return _goldDrop; }
            set { _goldDrop = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        private bool _isAlive;
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }
        public ObservableCollection<Item> ItemDrop
        {
            get { return _itemDrop; }
            set { _itemDrop = value; }
        } 
        public double BaseAttack
        {
            get { return _baseAttack; }
            set { _baseAttack = value; }
        }
        private ImageSource img;
        public ImageSource PictureSource
        {
            get { return img; }
            set { img = value; }
        }
        public int listPlacement
        {
            get { return _listPlacement; }
            set { _listPlacement = value; }
        }
        private bool _attacking;
        public bool AttackingPlayer
        {
            get { return _attacking; }
            set { _attacking = value; }
        }
        private bool _attackMethodRunning; 
        public bool AttackMethodRunning
        {
            get { return _attackMethodRunning; }
            set { _attackMethodRunning = value; }
        }
        public bool SelectedToFight
        {
            get { return _selectedToFight; }
            set { _selectedToFight = value; OnPropertyChanged(nameof(SelectedToFight)); }
        }
        private bool removedFromActiveEnemiesList;
        private int _goldDrop;

        public bool RemovedFromActiveEnemiesList
        {
            get { return removedFromActiveEnemiesList; }
            set { removedFromActiveEnemiesList = value; }
        }
        #endregion

        #region METHODS
        public double getCriticalAttack()
        { 
            _criticalAttack = _baseAttack + (_baseAttack * .30);
            return _criticalAttack;
        }
        //
        // Updating the enemies' listPlacement to their actual current positions
        // This should be called everytime an enemy is removed from the CurrentEnemies list
        //
        public void refreshAllEnemiesPositions()
        {
            for (int pos = 0; pos < gameSessionViewModel.CurrentEnemies.Count; pos++)
            {
                gameSessionViewModel.CurrentEnemies[pos].listPlacement = pos;
            }
        }
        public int findEnemyWithPosition(int position)
        {
            refreshAllEnemiesPositions();
            for (int epos = 0; epos < gameSessionViewModel.CurrentEnemies.Count; epos++)
            {
                if (gameSessionViewModel.CurrentEnemies[epos].listPlacement == position)
                {
                    position = gameSessionViewModel.CurrentEnemies[epos].listPlacement; 
                }
                else
                {
                    position = 0;
                }
            }
                return position;
        }
        public bool Alive(GameSessionView gsv, GameSessionViewModel gsm, Enemy enemy)
        {
            if (enemy.RemovedFromActiveEnemiesList == false)
            {
                if (enemy.Health > 0)
                {
                    enemy.IsAlive = true;
                }
                else if (enemy.Health <= 0)
                {
                    enemy.Health = 0;
                    enemy.IsAlive = false;
                    if (enemy.SelectedToFight == true)
                    {
                        enemy.stopAttackingPlayer();
                    }
                    // Remove from ActiveEnemies ListBox List (using listPlacement) The index position returned from currentEnemies

                    gsv.ActiveEnemies.Items.RemoveAt(listPlacement);

                    // Remove from currentEnemies list with placementID (Current index position in the list)
                    if (gsm.CurrentEnemies.Count > 0)
                    {
                        //
                        // After removing dead NPC, the currentFightingEnemyID is set to the next-in-line NPC
                        //
                        gsm.CurrentFightingEnemyID = gsm.CurrentEnemies[listPlacement].ID;
                        //
                        // Setting alive to true if it's the next enemy
                        //
                        if (gsm.CurrentEnemies[listPlacement].ID == gsm.CurrentFightingEnemyID)
                        {
                            gsm.CurrentEnemies[listPlacement].IsAlive = true;
                            gsm.CurrentEnemies[listPlacement].Health = gsm.CurrentEnemies[listPlacement].Health;
                        }
                        //
                        // Removes the killed enemy from the list
                        //

                        gsm.CurrentEnemies.RemoveAt(listPlacement);
                        enemy.RemovedFromActiveEnemiesList = true;
                        gsm.EnemySelected = false;
                        //
                        // Only enemies that are alive are in the list at this point
                        //
                        gsv.ActiveEnemies.SelectedItem = listPlacement;
                        //
                        // If there is another enemy next-in-line and the previous has been slain, then make the
                        // current enemy the next-in-line
                        //
                        if (gsm.CurrentEnemies.Count > 0) {
                            // Setting the current attacking enemy in the player's class to the next-in-line enemy
                            if (gsm.Player.currentlyAttacking.listPlacement != gsm.CurrentEnemies.Count)
                            {
                            gsm.Player.currentlyAttacking = gsm.CurrentEnemies[listPlacement];
                            // Setting the enemy picture in the view to the next-in-line enemy's PictureSource property
                            gsv.EnemyPicture.Source = gsm.CurrentEnemies[listPlacement].PictureSource;
                            // Setting the next-in-line enemy's SelectedToFight property to true
                            gsm.CurrentEnemies[listPlacement].SelectedToFight = true;
                            // Setting the GameSessionviewModel's CurrentFightingEnemyID property to equal the next-in-line enemy's ID
                            gsm.CurrentFightingEnemyID = gsm.CurrentEnemies[listPlacement].ID;
                            // Refreshing/Resetting all enemies in the list's listPlacement positions
                            refreshAllEnemiesPositions();
                            // CurrentFightingEnemyListPlacement is set to the next-in-line enemy's listPlacement property/position
                            gsm.CurrentFightingEnemyListPlacement = gsm.CurrentEnemies[listPlacement].listPlacement;
                                
                            }
                            else
                            {
                                gsm.Player.currentlyAttacking = gsm.CurrentEnemies[listPlacement - 1];
                                // Setting the enemy picture in the view to the next-in-line enemy's PictureSource property
                                gsv.EnemyPicture.Source = gsm.CurrentEnemies[listPlacement - 1].PictureSource;
                                // Setting the next-in-line enemy's SelectedToFight property to true
                                gsm.CurrentEnemies[listPlacement - 1].SelectedToFight = true;
                                // Setting the GameSessionviewModel's CurrentFightingEnemyID property to equal the next-in-line enemy's ID
                                gsm.CurrentFightingEnemyID = gsm.CurrentEnemies[listPlacement - 1].ID;
                                // Refreshing/Resetting all enemies in the list's listPlacement positions
                                refreshAllEnemiesPositions();
                                // CurrentFightingEnemyListPlacement is set to the next-in-line enemy's listPlacement property/position
                                gsm.CurrentFightingEnemyListPlacement = gsm.CurrentEnemies[listPlacement - 1].listPlacement;
                            }
                            refreshAllEnemiesPositions();
                             
                            gsm.EnemySelected = true; 

                        }
                    }
                    else if (gsm.CurrentEnemies.Count <= 0)
                    {
                        gsm.CurrentEnemies.RemoveAt(listPlacement);
                        gsv.AttackButton.IsEnabled = false;
                    }
                    if (gsm.CurrentEnemies.Count <= 0)
                    {
                        gsv.EnemyPicture.Source = null;
                    }
                    // Updating the listPlacement to their actual current positions
                    refreshAllEnemiesPositions();
                }
            }
            return IsAlive;
        }
        public void Rewarder(GameSessionViewModel gsm, Enemy enemy)
        {
            gsm.PlayerXP += enemy.XPDrop;
            gsm.PlayerGold += enemy.GoldDrop;
            //gsm.MinPlayerXP = gsm.Player.XP;

            //gsm.MaxPlayerXP = gsm.Player.MaxLevelXPRange;
        }
        public void onDeathRewardPlayer(GameSessionViewModel gsm, Enemy enemy)
        {
            switch (enemy.TypeOfEnemy)
            {
                case EnemyType.Archer:
                    Rewarder(gsm, enemy);
                    break;
                case EnemyType.Bandit:
                    Rewarder(gsm, enemy);
                    break;
                case EnemyType.Wizard:
                    Rewarder(gsm, enemy); 
                    break;
                case EnemyType.MudCrawler:
                    Rewarder(gsm, enemy); 
                    break;
                case EnemyType.ScuffedSpider:
                    Rewarder(gsm, enemy); 
                    break;
                case EnemyType.BlackKnight:
                    Rewarder(gsm, enemy); 
                    break;
                case EnemyType.Warrior:
                    Rewarder(gsm, enemy); 
                    break;
                default:
                    break;
            }

        }
        public void startAttackingPlayer()
        {
        
            if (AttackingPlayer == true && this.AttackMethodRunning == false) {
                attackTimer.Tick += new EventHandler(AttackTimerTick);
                attackTimer.Interval = new TimeSpan(0, 0, 1);
                attackTimer.Start(); 
                this.AttackMethodRunning = true;
            } 

        }
        public void stopAttackingPlayer()
        {
            attackTimer.Stop();
            this.AttackMethodRunning = false;
        }
        #endregion

        #region CONSTRUCTORS
        public Enemy()
        {

        }
        public Enemy(GameSessionViewModel _gameSessionViewModel, GameSessionView _gameSessionView)
        {
            this.gameSessionViewModel = _gameSessionViewModel;
            this.gameSessionView = _gameSessionView;
            //
            // When switching between enemies, it starts each timer and never stops, so the damage being done
            // to player keeps piling on and soon the player gets one-tapped
            //
             
        }

        private void AttackTimerTick(object sender, EventArgs e)
        {
            if (gameSessionViewModel.Player.IsAlive == false || gameSessionViewModel.PlayerHealth <= 0)
            {
                attackTimer.Stop();
            }
            else
            {

                //
                // If the player's shield is less than the base attack (can't withstand another hit)
                // And the shield value is more than 0, then set the shield to 0 and take the difference from
                // The player's health
                //
                if (gameSessionViewModel.PlayerShield < this.BaseAttack && gameSessionViewModel.PlayerShield > 0)
                {
                    double difference = this.BaseAttack - gameSessionViewModel.PlayerShield;
                    gameSessionViewModel.PlayerShield = 0;
                    gameSessionViewModel.PlayerHealth -= difference;
                    gameSessionViewModel.Player.CheckPlayerDeathEvent(gameSessionViewModel, gameSessionView);

                }
                //
                // If the player's shield is more than the base attack (sufficient to withstand a hit) 
                // then decrement shield
                //
                else if (gameSessionViewModel.PlayerShield > this.BaseAttack)
                {
                    gameSessionViewModel.PlayerShield -= this.BaseAttack;
                }   //
                    // If the player's shield is 0/gone, move onto health decrement process
                    //
                else if (gameSessionViewModel.PlayerShield == 0)
                {
                    //
                    // If the player has more than 0 health and is alive, then handle health decrement process
                    //
                    if (gameSessionViewModel.PlayerHealth > 0 && gameSessionViewModel.Player.IsAlive)
                    {
                        gameSessionViewModel.PlayerHealth -= BaseAttack;
                        gameSessionViewModel.Player.CheckPlayerDeathEvent(gameSessionViewModel, gameSessionView);

                        //
                        //If the player has less than 0 health after the attack, then set it to 0 and set isAlive to false
                        //
                        if (gameSessionViewModel.PlayerHealth < 0)
                        {
                            gameSessionViewModel.PlayerHealth = 0;
                            gameSessionViewModel.Player.CheckPlayerDeathEvent(gameSessionViewModel, gameSessionView);
                            gameSessionViewModel.Player.IsAlive = false;
                            attackTimer.Stop();
                        }
                    }
                }
            }
        }
        #endregion


    }
}
