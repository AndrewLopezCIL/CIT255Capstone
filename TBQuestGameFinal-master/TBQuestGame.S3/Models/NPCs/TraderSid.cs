using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TBQuestGame.Models.Items;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models.NPCs
{
    public class TraderSid : Character, ITrade,ISpeak
    {
        private GameSessionView gsv;
        private GameSessionViewModel gsm;
        private string beforeDialogue;
        private string beforeTips;
        public ObservableCollection<Item> Buyables = new ObservableCollection<Item>();
        public DispatcherTimer dialogueTimer = new System.Windows.Threading.DispatcherTimer();
        private int timer = 0;
        bool messageRunning = false;

        public override bool Alive()
        {
            if (gsm.Player.IsAlive == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddBuyables()
        {
            BasicHealingPotion potion = new BasicHealingPotion(gsm,gsv);
            BasicHealingPotion potion2 = new BasicHealingPotion(gsm,gsv);
            BasicHealingPotion potion3 = new BasicHealingPotion(gsm,gsv);
            BasicHealingPotion potion4 = new BasicHealingPotion(gsm,gsv);
            VestOfProtection vest = new VestOfProtection(gsm,gsv);
            vest.Value = 10;
            RubySword RubySword = new RubySword(gsm,gsv);
            Staff Magic_Staff = new Staff(gsm,gsv);
            Excalibur Excalibur = new Excalibur(gsm,gsv);
            Buyables.Add(vest);
            Buyables.Add(Magic_Staff); 
            Buyables.Add(potion); 
            Buyables.Add(potion2); 
            Buyables.Add(potion3); 
            Buyables.Add(potion4);
            Buyables.Add(RubySword); 
            Buyables.Add(Excalibur);
        }
        public void ListBuyables()
        {
            gsm.CurrentLocationMarket = gsm.GameMap.CurrentLocation.Market;
        }

        public void NotEnoughGold()
        {
            if(messageRunning == false && gsm.GameMap.CurrentLocation.InSidShop == true) {
                messageRunning = true; 
                beforeDialogue = gsv.DialogueBox.Text;
                dialogueTimer.Tick += new EventHandler(failedPurchase);
                dialogueTimer.Interval = new TimeSpan(0, 0, 1);
                dialogueTimer.Start();
            }
        }
        public void failedPurchase(object sender, EventArgs e)
        {
                
            if (timer <= 4)
            {
                messageRunning = true;
                gsv.DialogueBox.Text = "Sorry, but you don't have enough gold to buy that...";
                timer += 1;
                Location.disableControls(gsv);
                gsv.Buy.IsEnabled = false;

            }
            else
            {
                gsv.DialogueBox.Text = beforeDialogue;
                gsv.Buy.IsEnabled = true; 
                dialogueTimer.Stop();
                timer = 0; 
                Location.enableControls(gsv);
                messageRunning = false;

            }
            if (messageRunning == false)
            {
                dialogueTimer.Stop();
                Location.enableControls(gsv);
            }
        }
        public void SpeakTimer(object sender, EventArgs e)
        { 
            if (timer <= 4)
            {
                timer += 1;
                gsv.DialogueBox.Text = "Welcome to my shop!";
                Location.disableControls(gsv);
                gsv.Buy.IsEnabled = false;


            }
            else
            {
                gsv.DialogueBox.Text = beforeDialogue;
                gsv.TipsBox.Text = beforeTips;
                gsv.Buy.IsEnabled = true; 
                dialogueTimer.Stop();
                timer = 0;
                messageRunning = false;
                Location.enableControls(gsv);
            }
            if (messageRunning == false)
            {
                dialogueTimer.Stop();

                Location.enableControls(gsv);

            }
        }
        public void Speak()
        {
            if(messageRunning == false && gsm.GameMap.CurrentLocation.InSidShop == true) {
                messageRunning = true;
                beforeTips = gsv.TipsBox.Text;
                beforeDialogue = gsv.DialogueBox.Text;
                dialogueTimer.Tick += new EventHandler(SpeakTimer);
                dialogueTimer.Interval = new TimeSpan(0, 0, 1);
                dialogueTimer.Start();
            }
        }

        public void LeavingArea()
        {
            if(messageRunning == false && gsm.GameMap.CurrentLocation.InSidShop == true)
            {
                messageRunning = true; 
                beforeDialogue = gsv.DialogueBox.Text;
                beforeTips = gsv.TipsBox.Text;
                dialogueTimer.Tick += new EventHandler(leavingArea);
                dialogueTimer.Interval = new TimeSpan(0, 0, 1);
                dialogueTimer.Start();
            }
        }

        public void leavingArea(object sender, EventArgs e)
        { 
            if (timer <= 4)
            {
                timer += 1;
                gsv.DialogueBox.Text = "Thanks for coming, see you another time!\n*You wave goodbye*";
                Location.disableControls(gsv);
                gsv.Buy.IsEnabled = false;


            }
            else
            {
                gsv.DialogueBox.Text = beforeDialogue;
                Location.enableControls(gsv);
                gsv.Buy.IsEnabled = true;

                dialogueTimer.Stop();
                timer = 0;
                messageRunning = false;

            }
            if (messageRunning == false)
            {
                Location.enableControls(gsv);
                dialogueTimer.Stop();
            }

        }
        //First call
        public void ThanksForBuying()
        {
            if(messageRunning == false && gsm.GameMap.CurrentLocation.InSidShop == true) {
                messageRunning = true;

                beforeDialogue = gsv.DialogueBox.Text;
                beforeTips = gsv.TipsBox.Text;
                dialogueTimer.Tick += new EventHandler(thanksForPurchase);
                dialogueTimer.Interval = new TimeSpan(0, 0, 1);
                dialogueTimer.Start();
            }
            }
        public void thanksForPurchase(object sender, EventArgs e)
        {
            if (timer <= 4)
            {
                timer += 1;
                gsv.DialogueBox.Text = "Enjoy your goods!";
                gsv.TipsBox.Text = "Stationary Magic Lingers for a few seconds..."; 
                Location.disableControls(gsv);
                gsv.DialogueBox.Text = timer.ToString();
                gsv.Buy.IsEnabled = false; 
            }
            else
            {
                gsv.DialogueBox.Text = beforeDialogue;
                gsv.TipsBox.Text = beforeTips;
                Location.enableControls(gsv); 
                gsv.Buy.IsEnabled = true;
                dialogueTimer.Stop();
                timer = 0;
                messageRunning = false;

            }
            if (messageRunning == false)
            {
                Location.enableControls(gsv);
                dialogueTimer.Stop();
            }
        }
        public TraderSid(GameSessionViewModel gsm, GameSessionView gsv)
         {
            this.gsv = gsv;
            this.gsm = gsm;
         }
    }

    
}
