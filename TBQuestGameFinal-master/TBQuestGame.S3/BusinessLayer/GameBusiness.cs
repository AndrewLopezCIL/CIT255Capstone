using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;
using TBQuestGame.PresentationLayer;
using System.Collections.ObjectModel;

namespace TBQuestGame.BusinessLayer
{
   public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        Player _player;
        List<string> _messages;
        Map _gameMap;
        Location _currentLocation;
        GameData gameData;
        //Bug was being thrown, this was the only fix in this class
        ObservableCollection<Enemy> _currentEnemies= new ObservableCollection<Enemy>();
        //PlayerSetupView _playerSetupView = null;
        bool _newPlayer = false;
         

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        /// <summary>
        /// setup new or existing player
        /// </summary>
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                //_playerSetupView = new PlayerSetupView(_player);
               // _playerSetupView.ShowDialog();

                //
                // setup up game based player properties
                // 
                _player.QuestPoints = 0;
                _player.IsAlive = true;
                _player.Gold = 50;
                _player.Shield = 25;
                _player.Name = "Player";
                _player.Health = 100; 
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
            _messages = GameData.InitialMessages();
        }

        private void InstantiateAndShowView()
        {

            _gameSessionViewModel = new GameSessionViewModel( _player,
                GameData.InitialMessages(),
                GameData.GameMap(),
                GameData.InitialGameMapLocation(), _currentEnemies
                );
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

        }
    }
}
