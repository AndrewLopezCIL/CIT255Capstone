using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.DataLayer
{
    public class StoryProperties
    {
        #region FIELDS
        //
        // Part of the Main Story
        //
        private int _storyPart;
        //
        // Section of the Part in the story
        //
        private int _storySection;
        //
        // Current Dialogue
        //
        private string _dialogue;
        #endregion
         
        #region PROPERTIES
        public int StoryPart
        {
            get { return _storyPart; }
            set { _storyPart = value; }
        }
        public int StorySection
        {
            get { return _storySection; }
            set { _storySection = value; }
        }
        public string StoryDialogue
        {
            get { return _dialogue; }
            set { _dialogue = value; }
        }
        #endregion

        #region METHODS
        #endregion

        #region CONSTRUCTORS
        #endregion


    }
}
