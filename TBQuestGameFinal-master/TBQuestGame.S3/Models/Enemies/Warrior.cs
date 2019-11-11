using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models.Items;
using TBQuestGame.PresentationLayer;
namespace TBQuestGame.Models
{
    public class Warrior : Enemy
    { 
        private int _level = 35;
        private string _imageString;
        private double health = 125;
        
        public string Image
        {
            get { return _imageString; }
            set { _imageString = value; }
        }
       
        public Warrior()
        {

        }
        public Warrior(bool isBoss, GameSessionViewModel _gameSessionViewModel, GameSessionView GSV) : base(_gameSessionViewModel, GSV)
        {

            this.Level = _level;
            double newHealth = Level + (Level * 2.6);
            this.Health = newHealth;
            this.IsAlive = true;
            this.MaxHealth = newHealth;
            GSV.EnemyHealthDisplay.Maximum = newHealth;
            GSV.EnemyHealthDisplay.Value = newHealth;
           this.BaseAttack = this.BaseAttack += (this.Level / 100) + .50;
           
            Random ranXPDrop = new Random();

            this.XPDrop = ranXPDrop.Next(35, 60);
            Random goldRan = new Random();
            this.GoldDrop = goldRan.Next(8, 14);
            this._imageString = "warrior-icon.png";
            this.Name = "Warrior";
            _gameSessionViewModel.CurrentEnemyID += 1;
            this.ID = _gameSessionViewModel.CurrentEnemyID;

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
