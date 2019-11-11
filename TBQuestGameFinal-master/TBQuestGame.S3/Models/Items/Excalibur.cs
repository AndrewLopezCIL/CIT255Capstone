using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models.Items
{
    public class Excalibur : Item
    {
          
        public Excalibur(GameSessionViewModel gsm, GameSessionView gsv)
        {
            this.Damage = 15.6;
            this.Name = "Excalibur";
            this.Collected = false;
            this.Equipped = false;
            this.ID = gsm._gameData.itemID += 1;
            this.Value = 7593;
            this.ItemStackCount += 1;
            this.SpecialObject = false;
            this.PicturePath = "/Images/sword-icon.png";
            this.PictureSource = gsv.getPictureSource(this.PicturePath);
            this.CanEquip = true;
            // this.LevelRequirement = 5;

            this.LevelRequirement = 2;
            /*if (gsm.Player.Level > 7)
            {
            this.CanEquip = true;
            }
            else
            {
                this.CanEquip = false;
            }*/
            this.Consumable = false;
            this.Collected = true;

        }
    }
}
