using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models
{
    public abstract class Item
    {
        private double _swordDamage;

        public double Damage
        {
            get { return _swordDamage; }
            set { _swordDamage = value; }
        }

        private double protectionBoost;
        public double ProtectionBoost
        {
            get { return protectionBoost; }
            set { protectionBoost = value; }
        }
        private bool isArmor;
        public bool IsArmor
        {
            get { return isArmor; }
            set { isArmor = value; }
        }
        //
        // Current Trackable ID of the Item
        //
        private int _itemID;

        public int ID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        //
        // The item's display name
        //
        private string _itemName;

        public string Name
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        //
        // Item Picture Source
        //
        private ImageSource itemPicture;
        public ImageSource PictureSource
        {
            get { return itemPicture; }
            set { itemPicture = value; }
        }
        private string picturePath;
        public string PicturePath
        {
            get { return picturePath; }
            set { picturePath = value; }
        }
        //
        // Has list selection
        //
        private bool _hasListSelection;
        public bool HasListSelection
        {
            get { return _hasListSelection; }
            set { _hasListSelection = value; }
        }

        //
        // Location List Placement
        //
        private int _locationListPlacement;
        public int LocationListPlacement
        {
            get { return _locationListPlacement; }
            set { _locationListPlacement = value; }
        }

        //
        // Player Inventory List Placement
        // 
        private int _playerInventoryListPlacement;
        public int PlayerInventoryListPlacement
        {
            get { return _playerInventoryListPlacement; }
            set { _playerInventoryListPlacement = value; }
        }

        //
        // Player Inventory Selection
        //
        private bool _hasPlayerInventorySelection;
        public bool HasPlayerInventorySelection
        {
            get { return _hasPlayerInventorySelection; }
            set { _hasPlayerInventorySelection = value; }
        }
        
        //
        // Special Object
        //
        private bool _specialObject;
        public bool SpecialObject
        {
            get { return _specialObject; }
            set { _specialObject = value; } 
        }

        //
        //
        // How much the item is worth in Gold
        //
        private int _itemValue;

        public int Value
        {
            get { return _itemValue; }
            set { _itemValue = value; }
        }
        //
        // To keep track of how much the player is currently carrying
        //
        private int _itemStackCount;

        public int ItemStackCount
        {   
            get { return _itemStackCount; }
            set { _itemStackCount = value; }
        }
        //
        // Whether or not the player can equip the item
        //
        private bool _equipable;

        public bool CanEquip
        {
            get { return _equipable; }
            set { _equipable = value; }
        }
        private bool _itemEquipped;
        public bool Equipped
        {
            get { return _itemEquipped; }
            set { _itemEquipped = value; }
        }
        private bool _armorEquiped;
        public bool ArmorEquipped
        {
            get { return _armorEquiped; }
            set { _armorEquiped = value; }
        }
        //
        // Whether or not the item can be consumed/used ( as in a buff type way not equipable )
        //
        private bool _consumable;

        public bool Consumable
        {
            get { return _consumable; }
            set { _consumable = value; }
        }

        //
        // If the item is in the player's inventory/was collected by the player
        //
        private bool _collected;
            
        public bool Collected
        {
            get { return _collected; }
            set { _collected = value; }
        }

        private bool _consumableUsed;

        public bool ConsumableUsed
        {
            get { return _consumableUsed; }
            set { _consumableUsed = value; }
        }

        private int _levelRequirement;
        public int LevelRequirement
        {
            get { return _levelRequirement; }
            set { _levelRequirement = value; }
        }


        #region METHODS
        public void collectItem(GameSessionViewModel gsm, Item itemObject)
        {
            bool contains = false; 
            for (int item = 0; item < gsm.Player.Inventory.Count; item++)
            {
                if (gsm.Player.Inventory[item].Name == this.Name)
                {
                    contains = true;
                    itemObject = gsm.Player.Inventory[item];
                }
                else if (gsm.Player.Inventory[item].Name != this.Name)
                {
                    contains = false;
                } 
            }
            if (contains)
            {
                itemObject.ItemStackCount += 1;
                this.Collected = true;
            }
            else if (contains == false)
            {
                gsm.Player.Inventory.Add(this);
            }

        }
        #endregion

    }
}
