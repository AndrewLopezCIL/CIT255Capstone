using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models.Items;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models
{
    public class BlackKnight : Enemy
    {
        private int _level = 45;
        private string _imageString;
        private double health = 155;

        public string Image
        {
            get { return _imageString; }
            set { _imageString = value; }
        }

        public BlackKnight()
        {

        }
        public BlackKnight(bool isBoss, GameSessionViewModel _gameSessionViewModel, GameSessionView GSV) : base(_gameSessionViewModel, GSV)
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

            this.XPDrop = ranXPDrop.Next(35,60);
            Random goldRan = new Random();
            this.GoldDrop = goldRan.Next(8,14);
            this._imageString = "warrior-black.png";
            this.Name = "Black Knight";
            _gameSessionViewModel.CurrentEnemyID += 1;
            this.ID = _gameSessionViewModel.CurrentEnemyID; 
            RubySword rubySword = new RubySword(_gameSessionViewModel, GSV);
           
            rubySword.Damage = 45;
            this.ItemDrop.Add(rubySword);
            //
            // if passed isBoss bool value is true, then set the property to true, otherwise set the property to false
            //
            isBoss = true ? IsBoss = isBoss : IsBoss = isBoss;
        }
    }
}
