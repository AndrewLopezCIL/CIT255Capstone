using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models.Items
{
    public class RubySword : Item
    {
         
        public RubySword(GameSessionViewModel gsm, GameSessionView gsv)
        {
            //Mid Level Sword : Moderate damage
            this.Damage = 6.3;
            this.Consumable = false;
            this.Collected = false;
            this.CanEquip = true;
            this.SpecialObject = false;
            this.Equipped = false;
            this.PicturePath = "/Images/swendivericon.png";
            this.PictureSource = gsv.getPictureSource(this.PicturePath);
           /* if (gsm.Player.Level >= 3) {
                this.CanEquip = true;
            }else{
                this.CanEquip = false;
            }*/
            this.ID = gsm._gameData.itemID += 1;
            this.ItemStackCount += 1;
            this.Value = 225;
            // this.LevelRequirement = 3;
            this.LevelRequirement = 1;
            this.Name = "Ruby Sword";
        }


    }
}
