using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public abstract class Character
    {
        public enum ActionType{
            Defend, Attack, Neutral
        }
        #region fields
        private int _Id;
        private string _name;
        private int _locationId;
        private ActionType _attackType;
        private bool _isAlive;
        private double _health;
        #endregion
        #region properties
        public double Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public ActionType StateOfAction
        {
            get { return _attackType;  }
            set { _attackType = value; }
        }
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }
        #endregion
        #region METHODS
        public virtual string GetName()
        {
            return Name;
        }
        public abstract bool Alive();
        #endregion
        #region CONSTRUCTORS
        public Character()
        {

        }
        public Character(int id, int locationId, string name)
        {
            _Id = id;
            _locationId = locationId;
            _name = name;
        }
        #endregion

    }
}
