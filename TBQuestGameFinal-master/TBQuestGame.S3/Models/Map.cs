using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;
using TBQuestGame.Models;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    /// <summary>
    /// game map class
    /// </summary>
    public class Map : ObservableObject
    {
        #region FIELDS

        private Location[,] _mapLocations;
        private int _maxRows, _maxColumns;
        private GameMapCoordinates _currentLocationCoordinates;

        #endregion

        #region PROPERTIES

        public Location[,] MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }

        public GameMapCoordinates CurrentLocationCoordinates
        {
            get { return _currentLocationCoordinates; }
            set { _currentLocationCoordinates = value; }
        }

        public Location CurrentLocation
        {
            get { return _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column]; }
        }

        #endregion

        #region CONSTRUCTORS

        public Map(int rows, int columns)
        {
            _maxRows = rows;
            _maxColumns = columns;
            _mapLocations = new Location[rows, columns];
        }

        #endregion

        #region METHODS

        public void MoveNorth()
        {
            //
            // not on north border
            //
            if (_currentLocationCoordinates.Row > 0)
            {
                _currentLocationCoordinates.Row -= 1; 
            }
        }

        public void MoveEast()
        {
            //
            // not on east border
            //
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                _currentLocationCoordinates.Column += 1; 
            }
        }

        public void MoveSouth()
        {
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                _currentLocationCoordinates.Row += 1; 
            }
        }

        public void MoveWest()
        {
            //
            // not on west border
            //
            if (_currentLocationCoordinates.Column > 0)
            {

                _currentLocationCoordinates.Column -= 1; 
            }
        }

        //
        // get the north location if it exists
        //
        public Location NorthLocation()
        {
            Location northLocation = null;

            //
            // not on north border
            //
            if (_currentLocationCoordinates.Row > 0)
            {
                Location nextNorthLocation = _mapLocations[_currentLocationCoordinates.Row - 1, _currentLocationCoordinates.Column];

                //
                // location exists
                //
                if (nextNorthLocation != null)
                {
                    northLocation = nextNorthLocation;
                }
            }

            return northLocation;
        }

        //
        // get the east location if it exists
        //
        public Location EastLocation()
        {
            Location eastLocation = null;

            //
            // not on east border
            //
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                Location nextEastLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];

                //
                // location exists 
                //
                if (nextEastLocation != null)
                {
                    eastLocation = nextEastLocation;
                }
            }

            return eastLocation;
        }

        //
        // get the south location if it exists
        //
        public Location SouthLocation()
        {
            Location southLocation = null;

            //
            // not on south border
            //
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                Location nextSouthLocation = _mapLocations[_currentLocationCoordinates.Row + 1, _currentLocationCoordinates.Column];

                //
                // location exists and player can access location
                //
                if (nextSouthLocation != null)
                {
                    southLocation = nextSouthLocation;
                }
            }

            return southLocation;
        }

        //
        // get the west location if it exists
        //
        public Location WestLocation()
        {
            Location westLocation = null;

            //
            // not on west border
            //
            if (_currentLocationCoordinates.Column > 0)
            {
                Location nextWestLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];

                //
                // location exists and player can access location
                //
                if (nextWestLocation != null)
                {
                    westLocation = nextWestLocation;
                }
            }

            return westLocation;
        }
    }
}

        #endregion