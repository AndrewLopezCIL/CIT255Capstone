using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;
using TBQuestGame.Models.Items;
namespace TBQuestGame.Models
{
    public class Bandit : Enemy
    {
        private int _level = 15;
        private string _imageString;
        private int health = 125;

        public string Image
        {
            get { return _imageString; }
            set { _imageString = value; }
        }

        public Bandit()
        {

        }
        public Bandit(bool isBoss, GameSessionViewModel _gameSessionViewModel, GameSessionView GSV) : base(_gameSessionViewModel, GSV)
        {
             //
             // Can possibly move most of this stuff into the enemy class constructor
             //
            this.Level = _level;
            this.IsAlive = true;
            double newHealth = Level + (Level * 2.6);
            this.Health = newHealth;
            this.MaxHealth = newHealth;
            GSV.EnemyHealthDisplay.Value = newHealth;
            GSV.EnemyHealthDisplay.Maximum = newHealth;
            Random lvlRan = new Random();
            this.Level = lvlRan.Next(15,18);
            Random ran = new Random();
            this.GoldDrop = ran.Next(10, 19);
            this._imageString = "Bandit.png";
            Random ranXPDrop = new Random();

            this.XPDrop = ranXPDrop.Next(20, 35);
            this.Name = "Bandit";
            this.BaseAttack = this.BaseAttack += (this.Level / 100) + .75;
            _gameSessionViewModel.CurrentEnemyID += 1;
            this.ID = _gameSessionViewModel.CurrentEnemyID;

            //
            // Lootable items
            //
            BasicHealingPotion potion = new BasicHealingPotion(_gameSessionViewModel, GSV);
            Excalibur excalibur = new Excalibur(_gameSessionViewModel, GSV);
            RubySword rubySword = new RubySword(_gameSessionViewModel, GSV);
            this.ItemDrop.Add(potion);
            this.ItemDrop.Add(excalibur);

            this.ItemDrop.Add(rubySword);

            //
            // if passed isBoss bool value is true, then set the property to true, otherwise set the property to false
            //
            isBoss = true ? IsBoss = isBoss : IsBoss = isBoss;
        }
    }
}
