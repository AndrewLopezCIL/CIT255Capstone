using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models.Items;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models.Enemies
{
    public class Wizard : Enemy
    {


        private int _level;
        private string _imageString;
        private double health = 125;

        public string Image
        {
            get { return _imageString; }
            set { _imageString = value; }
        }

        public Wizard()
        {

        }
        public Wizard(bool isBoss, GameSessionViewModel _gameSessionViewModel, GameSessionView GSV) : base(_gameSessionViewModel, GSV)
        {


            Random levelRan = new Random();
            this.Level = levelRan.Next(30,60); ;
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
            this.GoldDrop = goldRan.Next(25, 66);
            this._imageString = "mage-icon.png";
            this.Image = "mage-icon.png";
            this.Name = "Wizard";
            _gameSessionViewModel.CurrentEnemyID += 1;
            this.ID = _gameSessionViewModel.CurrentEnemyID;

            BasicHealingPotion potion = new BasicHealingPotion(_gameSessionViewModel, GSV); 
            this.ItemDrop.Add(potion);
            Staff staff = new Staff(_gameSessionViewModel,GSV);
            this.ItemDrop.Add(potion);
            //
            // if passed isBoss bool value is true, then set the property to true, otherwise set the property to false
            //
            isBoss = true ? IsBoss = isBoss : IsBoss = isBoss;
        }
    }


}

