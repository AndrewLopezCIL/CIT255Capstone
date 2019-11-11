using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models.NPCs
{
    interface ISpeak
    {
        void Speak();
        void LeavingArea();
        void ThanksForBuying();
    }
}
