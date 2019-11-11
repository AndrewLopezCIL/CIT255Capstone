using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBQuestGame.PresentationLayer;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;
using TBQuestGame.Models.Items;
using System.Collections.ObjectModel;
using TBQuestGame.Models.NPCs;
using TBQuestGame.Models.Enemies;

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {

        GameSessionViewModel _gameSessionViewModel;
        
        private string Messages; 
        private double PlayerHealth;
        public MapDisplay mapWindow = new MapDisplay();
        public PlayerStatsDisplay playerStatsWindow;
        public EnemyStats enemyStatsWindow = new EnemyStats();
        public GameMenuDisplay menuWindow = new GameMenuDisplay();
        public InventoryDisplay inventoryWindow;
        BasicHealingPotion potion;
        public TraderSid sid;
        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;
            
           // ActiveEnemies.Items.Add("Testing");
            InitializeComponent();
            Messages = _gameSessionViewModel.Messages;
            PlayerHealth = _gameSessionViewModel.PlayerHealth;
            mapWindow.DataContext = gameSessionViewModel;
            menuWindow.DataContext = gameSessionViewModel;
            ActiveEnemies.DataContext = _gameSessionViewModel.CurrentEnemies;
            DataContext = gameSessionViewModel;
            inventoryWindow = new InventoryDisplay(_gameSessionViewModel, this);
            inventoryWindow.DataContext = _gameSessionViewModel;
            playerStatsWindow = new PlayerStatsDisplay(_gameSessionViewModel);
            enemyStatsWindow.DataContext = _gameSessionViewModel;
            playerStatsWindow.DataContext = _gameSessionViewModel;
           potion = new BasicHealingPotion(_gameSessionViewModel, this);
            sid = new TraderSid(_gameSessionViewModel, this);
            sid.AddBuyables(); 
            _gameSessionViewModel.Sid = sid;
            _gameSessionViewModel.AccessibleLocations.Clear();
            updateAccessibleLocations();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
          
        }

        private void GameOptions_Click(object sender, RoutedEventArgs e)
        {
            menuWindow.Visibility = Visibility.Visible;
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            inventoryWindow.Visibility = Visibility.Visible;
            Location.enableControls(this);
        }

        private void SkillsButton_Click(object sender, RoutedEventArgs e)
        {
         
            //potion.potionUsedWithCooldown(_gameSessionViewModel);
             AddEnemyToList("warrior-black");
            AddEnemyToList("warrior");
            AddEnemyToList("wizard"); 
           AddEnemyToList("bandit");
        }  
        public int getPlacementID(Enemy enemyPassed)
        {
            int id = 0;
            for (int position = 0; position < _gameSessionViewModel.CurrentEnemies.Count; position++)
            {
                if (_gameSessionViewModel.CurrentEnemies[position].ID == enemyPassed.ID)
                {
                    id = position;
                    break;
                }

            }
               return id;
            } 
       public BitmapImage getPictureSource(string picturePath)
        {
            BitmapImage bitImages = new BitmapImage();
            bitImages.BeginInit();
            bitImages.UriSource = new Uri("/Images/" + picturePath, UriKind.Relative);
            bitImages.EndInit(); 

            return bitImages;
        }
        public void AddEnemyToList(string enemyName)
        {
            string nameOfEnemy ="";
            string levelOfEnemy ="";
            string enemyPicturePath = "";
            bool isBoss = false;
            Enemy enemy;
            switch (enemyName.ToLower())
            {
                case "warrior":
                    Warrior warrior = new Warrior(true,_gameSessionViewModel, this);
                    warrior.RemovedFromActiveEnemiesList = false;
                    _gameSessionViewModel.Player.PlayersCurrentState = Player.PlayerState.Fighting;
                    warrior.AttackingPlayer = true;
                    enemy = warrior;
                    _gameSessionViewModel.CurrentEnemies.Add(warrior);
                    nameOfEnemy = "Warrior";
                    levelOfEnemy = "{LVL " + warrior.Level + " }";
                    enemyPicturePath = warrior.Image;
                    warrior.listPlacement = getPlacementID(warrior); 
                    warrior.PictureSource = getPictureSource(enemyPicturePath);
                    break;
                case "warrior-black":
            
                    BlackKnight blackKnight = new BlackKnight(false, _gameSessionViewModel, this);
                    _gameSessionViewModel.CurrentEnemies.Add(blackKnight);
                    enemy = blackKnight;
                    blackKnight.AttackingPlayer = true; 
                    _gameSessionViewModel.Player.PlayersCurrentState = Player.PlayerState.Fighting;
                    nameOfEnemy = blackKnight.Name;
                    levelOfEnemy = "{LVL " + blackKnight.Level + " }";
                    blackKnight.IsBoss = true;
                    isBoss = true;
                    enemyPicturePath = blackKnight.Image;
                    blackKnight.listPlacement = getPlacementID(blackKnight);
                    blackKnight.PictureSource = getPictureSource(enemyPicturePath);

                    break;
                case "bandit":
                    Bandit bandit = new Bandit(false, _gameSessionViewModel, this);
                    bandit.RemovedFromActiveEnemiesList = false;
                    _gameSessionViewModel.Player.PlayersCurrentState = Player.PlayerState.Fighting;
                    bandit.AttackingPlayer = true;
                    enemy = bandit;
                    _gameSessionViewModel.CurrentEnemies.Add(bandit);
                    nameOfEnemy = "Bandit";
                    levelOfEnemy = "{LVL " + bandit.Level + " }";
                    enemyPicturePath = bandit.Image;
                    bandit.listPlacement = getPlacementID(bandit);
                    bandit.PictureSource = getPictureSource(enemyPicturePath);

                    break;
                case "mudcrawler":
                    nameOfEnemy = "MudCrawler";
                    levelOfEnemy = "{LVL 9}";
                    enemyPicturePath = "MudCrawler.png";
                    break;
                case "scuffedspider":
                    nameOfEnemy = "Spider";
                    levelOfEnemy = "{LVL 3}";
                    enemyPicturePath = "scuffedspider.png";
                    break;
                case "wizard":
                    Wizard wizard = new Wizard(false, _gameSessionViewModel, this);
                    wizard.RemovedFromActiveEnemiesList = false;
                    _gameSessionViewModel.Player.PlayersCurrentState = Player.PlayerState.Fighting;
                    wizard.AttackingPlayer = true;
                    enemy = wizard;
                    _gameSessionViewModel.CurrentEnemies.Add(wizard);
                    nameOfEnemy = "Wizard";
                    levelOfEnemy = "{LVL " + wizard.Level + " }";
                    enemyPicturePath = wizard.Image;
                    wizard.listPlacement = getPlacementID(wizard);
                    wizard.PictureSource = getPictureSource(enemyPicturePath);
                    break;
                default:
                    break;
            }
            ListBoxItem item = new ListBoxItem();
            StackPanel new_item = new StackPanel();
            new_item.Orientation = Orientation.Horizontal;
            Image img = new Image();
            BitmapImage bitImage = new BitmapImage();
            bitImage.BeginInit();

            bitImage.UriSource = new Uri("/Images/"+enemyPicturePath, UriKind.Relative);

            bitImage.EndInit();
             
            img.Source = bitImage;
            //
            // Flip image
            //

            
            EnemyPicture.Source = bitImage;

            img.Width = 32;
            img.Height = 32;

            TextBlock entityLevel = new TextBlock();
            entityLevel.Text = levelOfEnemy;
            entityLevel.FontWeight = FontWeights.Bold;
            entityLevel.FontSize = 16;
            entityLevel.VerticalAlignment = VerticalAlignment.Center;

            TextBlock entityName = new TextBlock();
            entityName.Text = nameOfEnemy;
            entityName.FontSize = 15.5;
            entityName.FontWeight = FontWeights.Bold;
            entityName.VerticalAlignment = VerticalAlignment.Center;

            new_item.Children.Add(img);
            new_item.Children.Add(entityLevel);
            new_item.Children.Add(entityName);
            item.Content = new_item;
            if (!isBoss) {
                item.Background = Brushes.Red;
            }
            else if (isBoss == true)
            {
                item.Background = Brushes.Pink;
            }
            item.BorderBrush = Brushes.Black;
            item.BorderThickness = new Thickness(3, 3, 3, 0);

            ActiveEnemies.Items.Add(item); 
 
        }
        private void changePlayerClass(string userClass)
        {
            switch (userClass.ToLower())
            {
                case "warrior":
                    BitmapImage playerBitImage2 = new BitmapImage();
                    playerBitImage2.BeginInit();

                    playerBitImage2.UriSource = new Uri("/Images/warrior-icon.png", UriKind.Relative);

                    playerBitImage2.EndInit();
                    PlayerPicture.Source = playerBitImage2;
                    _gameSessionViewModel.Player.ClassTypeProp = Player.ClassType.Warrior;
                    _gameSessionViewModel.Player.ClassToString = "Warrior";
                    break;
                case "archer":
                    BitmapImage playerBitImage3 = new BitmapImage();
                    playerBitImage3.BeginInit();

                    playerBitImage3.UriSource = new Uri("/Images/archer-icon.png", UriKind.Relative);

                    playerBitImage3.EndInit();
                    PlayerPicture.Source = playerBitImage3;
                    _gameSessionViewModel.Player.ClassTypeProp = Player.ClassType.Archer;
                    _gameSessionViewModel.Player.ClassToString = "Archer";
                    break;
                case "mage":
                    BitmapImage playerBitImage4 = new BitmapImage();
                    playerBitImage4.BeginInit();

                    playerBitImage4.UriSource = new Uri("/Images/mage-icon.png", UriKind.Relative);

                    playerBitImage4.EndInit();
                    PlayerPicture.Source = playerBitImage4;
                    _gameSessionViewModel.Player.ClassTypeProp = Player.ClassType.Mage;
                    _gameSessionViewModel.Player.ClassToString = "Mage";
                    break;
                
                default:
                    break;
            }
          
        }
          private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.Player.AttackEnemy(_gameSessionViewModel, this,Player.AttackType.BasicAttack);   
        }
        public void BossBattleStart()
        {
            switch (_gameSessionViewModel.GameMap.CurrentLocation.Name)
            {
                case "The Dark Forest":
                    AddEnemyToList("wizard");
                    _gameSessionViewModel.bossesDefeated.Add(_gameSessionViewModel.GameMap.CurrentLocation);
                    break;
                case "Vickren Dungeon":
                   AddEnemyToList("warrior");
                    _gameSessionViewModel.bossesDefeated.Add(_gameSessionViewModel.GameMap.CurrentLocation);
                    break;
                case "Kardon Dungeon":
                   AddEnemyToList("bandit");
                    _gameSessionViewModel.bossesDefeated.Add(_gameSessionViewModel.GameMap.CurrentLocation);
                    break;
                default:
                    break;
            }
        }
        private void bossRoomEnterUpdate()
        {
           // TipsBox.Foreground = Brushes.Red;
            //TipsBox.FontWeight = FontWeights.Bold;
           // TipsBox.Text = "{ YOU'VE ENTERED A BOSS ROOM! FIGHT INITIATED }";
            _gameSessionViewModel.PlayerShield += 35;
            BossBattleStart();
            LocationName.Text = _gameSessionViewModel.GameMap.CurrentLocation.Name;
            DialogueBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationMessage;
            _gameSessionViewModel.LocationWarningMessage = _gameSessionViewModel.CurrentLocation.LocationWarningMessage;
            Location.disableControls(this);
        }
        private void setLocationWarningMessage(GameSessionViewModel gsm, GameSessionView gsv)
        {
            if (gsm.GameMap.CurrentLocation.MultiAttackLocation == true)
            {
                gsv.mapWindow.WarningDisplay.Text = "Dangerous area!";
            }
            else if (gsm.GameMap.CurrentLocation.BossFightRoom)
            {
                gsv.mapWindow.WarningDisplay.Text = "[BOSS] Location-Freeze!";
            }
            else if (gsm.GameMap.CurrentLocation.MultiAttackLocation == false)
            {
                gsv.mapWindow.WarningDisplay.Text = "Moderate Area!";
            }
        }
        private void ChanceOfFight()
        {
            if (_gameSessionViewModel.GameMap.CurrentLocation.ChanceOfFight == true)
            {
                int chance; 
                Random fightChance = new Random();
                Random willFight = new Random();
                int willFightEnemy = willFight.Next(2);
                ObservableCollection<string> enemyNames = new ObservableCollection<string>();
                enemyNames.Add("Bandit");
                enemyNames.Add("warrior-black");
                enemyNames.Add("Warrior");
                enemyNames.Add("Wizard");
                switch (willFightEnemy)
                {
                    case 0: 
                        break;
                    case 1:
                        chance = fightChance.Next(4);

                        if (chance == 1)
                        {
                            AddEnemyToList(enemyNames[1]);

                        }
                        else if (chance == 2)
                        {
                            AddEnemyToList(enemyNames[2]);

                        }
                        else if (chance == 3 && _gameSessionViewModel.Player.Level > 2)
                        {
                            AddEnemyToList(enemyNames[3]);
                        }
                        else if (chance == 0)
                        {
                            AddEnemyToList(enemyNames[0]);

                        }
                        break;
                    default:
                        break;
                }
             
               
                
            }
        }
        private void enteredSidsShop()
        {
            if (_gameSessionViewModel.GameMap.CurrentLocation.InSidShop == true)
            {
                 
                Market.IsEnabled = true;
                MarketLabel.IsEnabled = true;
                Market.Visibility = Visibility.Visible;
                Buy.Visibility = Visibility.Visible;
            }
            else if (_gameSessionViewModel.GameMap.CurrentLocation.InSidShop != true) 
            {
                Market.IsEnabled = false;
                MarketLabel.IsEnabled = false;
                Market.Visibility = Visibility.Hidden;
                Buy.Visibility = Visibility.Hidden;
            }
        }
        //
        // NORTH BUTTON 
        //
        private void Button_Click(object sender, RoutedEventArgs e)
        {  
            if (_gameSessionViewModel.GameMap.NorthLocation() != null)
            {
               
                _gameSessionViewModel.GameMap.MoveNorth();
                _gameSessionViewModel.LocationLootableItems = _gameSessionViewModel.GameMap.CurrentLocation.LootableItems;

                /* if (_gameSessionViewModel.GameMap.NorthLocation().Accessible && !_gameSessionViewModel.AccessibleLocations.Contains(_gameSessionViewModel.GameMap.NorthLocation()))
                {
                    _gameSessionViewModel.AccessibleLocations.Add(_gameSessionViewModel.GameMap.NorthLocation());
                }*/
                 

                LocationName.Text = _gameSessionViewModel.GameMap.CurrentLocation.Name;
                DialogueBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationMessage;
                ChanceOfFight();
                setLocationWarningMessage(_gameSessionViewModel, this); 

                if (_gameSessionViewModel.GameMap.CurrentLocation.BossFightRoom)
                {
                    if (!_gameSessionViewModel.bossesDefeated.Contains(_gameSessionViewModel.GameMap.CurrentLocation))
                    {
                        bossRoomEnterUpdate();
                    }
                }
                mapWindow.CurrentLocationDisplay.Text = _gameSessionViewModel.GameMap.CurrentLocation.Name;
                mapWindow.LocationDescriptionDisplay.Text = _gameSessionViewModel.GameMap.CurrentLocation.Description;

            }
            if (_gameSessionViewModel.GameMap.CurrentLocation.LocationTip != "" && _gameSessionViewModel.GameMap.CurrentLocation.LocationTip != null)
            {
                TipsBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationTip;
            }
            
            updateAccessibleLocations();
           enteredSidsShop();
        }



        private void updateAccessibleLocations()
        {
            _gameSessionViewModel.AccessibleLocations.Clear();
            if (_gameSessionViewModel.GameMap.CurrentLocation.Name == "Yin Village" && _gameSessionViewModel.GameMap.CurrentLocation.DefaultWeaponChosen == true)
            {
                _gameSessionViewModel.GameMap.CurrentLocation.ChanceOfFight = true;
                _gameSessionViewModel.GameMap.CurrentLocation.LocationMessage = "You look around and see the bandits have completely\ntaken over, and one of them rushes towards you!";
            }
            else if (_gameSessionViewModel.GameMap.CurrentLocation.Name == "Yin Village" && _gameSessionViewModel.GameMap.CurrentLocation.DefaultWeaponChosen == false)
            {
                Location.disableControls(this);

            }
            this.TipsBox.Foreground = Brushes.Black;
            this.TipsBox.FontWeight = FontWeights.Bold;
            this.TipsBox.FontSize = 15;
            if (_gameSessionViewModel.GameMap.CurrentLocation.LocationTip != "" && _gameSessionViewModel.GameMap.CurrentLocation.LocationTip != null)
            {
                TipsBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationTip;
            }

            if (_gameSessionViewModel.GameMap.NorthLocation() != null)
            {
                _gameSessionViewModel.GameMap.NorthLocation().Direction = "North";
                _gameSessionViewModel.AccessibleLocations.Add(_gameSessionViewModel.GameMap.NorthLocation());
                this.DialogueBox.Foreground = Brushes.Black;
                this.DialogueBox.FontWeight = FontWeights.Bold;
                this.DialogueBox.FontSize = 15; 
            }
            if (_gameSessionViewModel.GameMap.EastLocation() != null)
            {
                _gameSessionViewModel.GameMap.EastLocation().Direction = "East";

                _gameSessionViewModel.AccessibleLocations.Add(_gameSessionViewModel.GameMap.EastLocation());
                this.DialogueBox.Foreground = Brushes.Black;
                this.DialogueBox.FontWeight = FontWeights.Bold;
                this.DialogueBox.FontSize = 15;
                
            }
            if (_gameSessionViewModel.GameMap.WestLocation() != null)
            {
                _gameSessionViewModel.GameMap.WestLocation().Direction = "West";

                _gameSessionViewModel.AccessibleLocations.Add(_gameSessionViewModel.GameMap.WestLocation());
                this.DialogueBox.Foreground = Brushes.Black;
                this.DialogueBox.FontWeight = FontWeights.Bold;
                this.DialogueBox.FontSize = 15;
                
            }
            if (_gameSessionViewModel.GameMap.SouthLocation() != null)
            {
                _gameSessionViewModel.GameMap.SouthLocation().Direction = "South";

                _gameSessionViewModel.AccessibleLocations.Add(_gameSessionViewModel.GameMap.SouthLocation());
                this.DialogueBox.Foreground = Brushes.Black;
                this.DialogueBox.FontWeight = FontWeights.Bold;
                this.DialogueBox.FontSize = 15;
               
            }
        }
        //
        // EAST BUTTON
        //
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            if (_gameSessionViewModel.GameMap.EastLocation() != null) {
               
                _gameSessionViewModel.GameMap.MoveEast();
                _gameSessionViewModel.LocationLootableItems = _gameSessionViewModel.GameMap.CurrentLocation.LootableItems;

                /*if (_gameSessionViewModel.GameMap.EastLocation().Accessible && !_gameSessionViewModel.AccessibleLocations.Contains(_gameSessionViewModel.GameMap.EastLocation()))
                {
                    _gameSessionViewModel.AccessibleLocations.Add(_gameSessionViewModel.GameMap.EastLocation());
                }*/
                LocationName.Text = _gameSessionViewModel.GameMap.CurrentLocation.Name;
                DialogueBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationMessage;
                ChanceOfFight();

                setLocationWarningMessage(_gameSessionViewModel, this); 
                if (_gameSessionViewModel.GameMap.CurrentLocation.BossFightRoom)
                {
                    if (!_gameSessionViewModel.bossesDefeated.Contains(_gameSessionViewModel.GameMap.CurrentLocation))
                    {
                        bossRoomEnterUpdate();
                    }
                }
                mapWindow.CurrentLocationDisplay.Text = _gameSessionViewModel.GameMap.CurrentLocation.Name;
                mapWindow.LocationDescriptionDisplay.Text = _gameSessionViewModel.GameMap.CurrentLocation.Description;

            }
            if (_gameSessionViewModel.GameMap.CurrentLocation.LocationTip != "" && _gameSessionViewModel.GameMap.CurrentLocation.LocationTip != null)
            {
                TipsBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationTip;
            }
            updateAccessibleLocations();
         enteredSidsShop();

        }

        //
        // SOUTH BUTTON
        //
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            if (_gameSessionViewModel.GameMap.SouthLocation() != null)
            {
              
                _gameSessionViewModel.GameMap.MoveSouth();
                _gameSessionViewModel.LocationLootableItems = _gameSessionViewModel.GameMap.CurrentLocation.LootableItems;

                /* if (_gameSessionViewModel.GameMap.SouthLocation().Accessible && !_gameSessionViewModel.AccessibleLocations.Contains(_gameSessionViewModel.GameMap.SouthLocation()))
                 {
                     _gameSessionViewModel.AccessibleLocations.Add(_gameSessionViewModel.GameMap.SouthLocation());
                 }*/
                LocationName.Text = _gameSessionViewModel.GameMap.CurrentLocation.Name;
                DialogueBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationMessage;
                ChanceOfFight();

                setLocationWarningMessage(_gameSessionViewModel, this); 

                if (_gameSessionViewModel.GameMap.CurrentLocation.BossFightRoom)
                {
                    if (!_gameSessionViewModel.bossesDefeated.Contains(_gameSessionViewModel.GameMap.CurrentLocation))
                    {
                        bossRoomEnterUpdate();

                    }

                }
                mapWindow.CurrentLocationDisplay.Text = _gameSessionViewModel.GameMap.CurrentLocation.Name;
                mapWindow.LocationDescriptionDisplay.Text = _gameSessionViewModel.GameMap.CurrentLocation.Description;

            }
            if (_gameSessionViewModel.GameMap.CurrentLocation.LocationTip != "" && _gameSessionViewModel.GameMap.CurrentLocation.LocationTip != null)
            {
                TipsBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationTip;
            }
            updateAccessibleLocations();
             enteredSidsShop();

        }

        //
        // WEST BUTTON
        //
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {  
            if (_gameSessionViewModel.GameMap.WestLocation() != null)
            {
               
                _gameSessionViewModel.GameMap.MoveWest();
                _gameSessionViewModel.LocationLootableItems = _gameSessionViewModel.GameMap.CurrentLocation.LootableItems;
                

                /*if (_gameSessionViewModel.GameMap.WestLocation().Accessible && !_gameSessionViewModel.AccessibleLocations.Contains(_gameSessionViewModel.GameMap.WestLocation()))
                {
                    _gameSessionViewModel.AccessibleLocations.Add(_gameSessionViewModel.GameMap.WestLocation());
                    
                }*/
                LocationName.Text = _gameSessionViewModel.GameMap.CurrentLocation.Name;
                DialogueBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationMessage;
                ChanceOfFight();

                setLocationWarningMessage(_gameSessionViewModel, this); 
                
                if (_gameSessionViewModel.GameMap.CurrentLocation.BossFightRoom)
                {
                    if (!_gameSessionViewModel.bossesDefeated.Contains(_gameSessionViewModel.GameMap.CurrentLocation))
                    {
                        bossRoomEnterUpdate();

                    }

                }
                mapWindow.CurrentLocationDisplay.Text = _gameSessionViewModel.GameMap.CurrentLocation.Name;
                mapWindow.LocationDescriptionDisplay.Text = _gameSessionViewModel.GameMap.CurrentLocation.Description;

            }
            if (_gameSessionViewModel.GameMap.CurrentLocation.LocationTip != "" && _gameSessionViewModel.GameMap.CurrentLocation.LocationTip != null)
            {
                TipsBox.Text = _gameSessionViewModel.GameMap.CurrentLocation.LocationTip;
            }
            updateAccessibleLocations();
          enteredSidsShop();

        }
        //
        // MAP WINDOW BUTTON
        //
        private void OpenMap_Click(object sender, RoutedEventArgs e)
        {
            mapWindow.Visibility = Visibility.Visible;
        }
        //
        // EXIT BUTTON
        //
        private void Close_Application(object sender, EventArgs e)
        {
            //If save game method is added, call it here.
            Environment.Exit(0);
        }

        //
        // PLAYER STATS BUTTON
        //
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            playerStatsWindow.Visibility = Visibility.Visible;
        }
        //
        // ENEMY STATS BUTTON
        //
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            enemyStatsWindow.Visibility = Visibility.Visible;
        }

        private void ActiveEnemies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            _gameSessionViewModel.SelectedEnemySetter(item.SelectedIndex, this);
        }

        private void CommandBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (_gameSessionViewModel.GameMap.CurrentLocation.Name == "Yin Village" && _gameSessionViewModel.GameMap.CurrentLocation.DefaultWeaponChosen == false)
                {
                    SteelSword SteelSword = new SteelSword(_gameSessionViewModel,this);
                    Bow Bow = new Bow(_gameSessionViewModel,this);
                    Bow.Name = "Bow";
                    Staff MagicStaff = new Staff(_gameSessionViewModel,this);
                    MagicStaff.Name = "Magic Staff";
                    switch (this.CommandBox.Text.ToLower())
                    {
                        case "/grab sword":
                            TipsBox.Text = "You grab the Sword!";
                            Location.enableControls(this);
                            CommandBox.Foreground = Brushes.Black;
                            CommandBox.Text = "";
                            _gameSessionViewModel.GameMap.CurrentLocation.DefaultWeaponChosen = true;
                            _gameSessionViewModel.GameMap.CurrentLocation.ChanceOfFight = true;
                            TipsBox.Text = "You're not strong, venture out and become stronger!"; 
                            _gameSessionViewModel.Player.EquippedItems.Add(SteelSword);
                            _gameSessionViewModel.Player.EquippedWeapon = SteelSword;
                            changePlayerClass("Warrior");
                            playerStatsWindow.PlayerClass.Text = "Warrior";

                            DialogueBox.Text = "Where should I go now?";
                            break;
                        case "/grab bow":
                            TipsBox.Text = "You grab the Bow!";
                            Location.enableControls(this);
                            CommandBox.Foreground = Brushes.Black;
                            CommandBox.Text = "";
                            _gameSessionViewModel.GameMap.CurrentLocation.DefaultWeaponChosen = true;
                            _gameSessionViewModel.GameMap.CurrentLocation.ChanceOfFight = true;
                            TipsBox.Text = "You're not strong, venture out and become stronger!";
                            playerStatsWindow.PlayerClass.Text = "Archer";
                            _gameSessionViewModel.Player.EquippedItems.Add(Bow); 
                            _gameSessionViewModel.Player.EquippedWeapon = Bow;
                            changePlayerClass("Archer");
                            DialogueBox.Text = "Where should I go now?";

                            break;
                        case "/grab staff":
                            TipsBox.Text = "You grab the Magic Staff!";
                            Location.enableControls(this);
                            CommandBox.Foreground = Brushes.Black;
                            CommandBox.Text = "";
                            _gameSessionViewModel.GameMap.CurrentLocation.DefaultWeaponChosen = true;
                            _gameSessionViewModel.GameMap.CurrentLocation.ChanceOfFight = true;
                            TipsBox.Text = "You're not strong, venture out and become stronger!"; 
                            _gameSessionViewModel.Player.EquippedItems.Add(MagicStaff); 
                            _gameSessionViewModel.Player.EquippedWeapon = MagicStaff;
                            playerStatsWindow.PlayerClass.Text = "Mage";

                            changePlayerClass("Mage");
                            DialogueBox.Text = "Where should I go now?";

                            break; 
                        default:
                            CommandBox.Foreground = Brushes.Red;
                            break;
                    } 
                }
            }
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            for (int item = 0; item < sid.Buyables.Count; item++)
            {
                if (sid.Buyables[item].HasListSelection == true)
                {
                    //If player has enough for purchasing the item in the shop
                    if (_gameSessionViewModel.Player.Gold >= sid.Buyables[item].Value)
                    {
                        _gameSessionViewModel.Player.Inventory.Add(sid.Buyables[item]);
                        _gameSessionViewModel.PlayerGold -= sid.Buyables[item].Value;
                        sid.ThanksForBuying();
                        break;
                    }
                    else if (_gameSessionViewModel.Player.Gold < sid.Buyables[item].Value)
                    {
                        sid.NotEnoughGold();
                        break;
                    }
                }
                else
                {
                    sid.Buyables[item].HasListSelection = false;
                }
            }
        }

        private void Market_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (DataGrid)sender;
            for (int fixIndex = 0; fixIndex < sid.Buyables.Count; fixIndex++)
            {
                if (sid.Buyables[fixIndex].HasListSelection == true) {
                    sid.Buyables[fixIndex].HasListSelection = false;
                    _gameSessionViewModel.SelectedMarketItem = null;
                }
            }
            _gameSessionViewModel.SelectedMarketItem = sid.Buyables[item.SelectedIndex];
            sid.Buyables[item.SelectedIndex].HasListSelection = true;

        }

        private void MarketLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Buy.Visibility = Visibility.Visible;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Buy.Visibility = Visibility.Hidden;
        }

        private void LocationName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_gameSessionViewModel.GameMap.CurrentLocation.ExceptionRoom == true)
            {
                _gameSessionViewModel.GameMap.CurrentLocation.ExceptionRoom = false;
            }
            else
            {
                TipsBox.Text = "";
            }
            }
    }
}
