using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models.Items
{
    public class VestOfProtection:Item
    {
        public VestOfProtection(GameSessionViewModel gsm, GameSessionView gsv)
        {
           
            this.ProtectionBoost = 35;
            this.Consumable = false;
            this.Collected = false;
            this.CanEquip = true;
            this.ArmorEquipped = false;
            this.SpecialObject = false;
            this.Equipped = false;
            this.PicturePath = "/Images/swendivericon.png";
            this.PictureSource = gsv.getPictureSource(this.PicturePath);
     
            this.ID = gsm._gameData.itemID += 1;
            this.ItemStackCount += 1;
            this.Value = 66; 
            this.LevelRequirement = 1;
            this.Name = "Vest of Protection";
            this.IsArmor = true;
        }

    }
}
