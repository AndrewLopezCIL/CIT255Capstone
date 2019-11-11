using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models.Items
{
    public class SteelSword : Item
    {

        public SteelSword(GameSessionViewModel gsm, GameSessionView gsv)
        {
            //Mid Level Sword : Moderate damage
            this.Damage = 3.1;
            this.Consumable = false;
            this.Collected = false;
            this.CanEquip = true;
            this.SpecialObject = false;
            this.Equipped = false;
            this.PicturePath = "/Images/sword-icon.png";
            this.PictureSource = gsv.getPictureSource(this.PicturePath);
            /* if (gsm.Player.Level >= 3) {
                 this.CanEquip = true;
             }else{
                 this.CanEquip = false;
             }*/
            this.ID = gsm._gameData.itemID += 1;
            this.ItemStackCount += 1;
            this.Value = 22;
            // this.LevelRequirement = 3;
            this.LevelRequirement = 0;
            this.Name = "Steel Sword";
        }


    }
}
