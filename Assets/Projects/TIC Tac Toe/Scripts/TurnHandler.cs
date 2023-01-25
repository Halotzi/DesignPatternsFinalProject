using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace TICTacToe
{
    public class TurnHandler
    {
        public event Action<int> OnPlayerTurnChanged; 

        public int PlayerIDTurn => _playerIdTurn;
        public int TurnCounter => _turnCounter;

        private int _playerIdTurn;
        private int _turnCounter;

        public void RandomStarter()
        {
            int random = UnityEngine.Random.Range(0, 2);
            _playerIdTurn = random;
            GameManager.Instance.UIHandler.UpdateIndicator(_playerIdTurn);
        }

        public void ChangePlayerTurn()
        {
            if (_playerIdTurn == 0)
                _playerIdTurn = 1;

            else
                _playerIdTurn = 0;

            _turnCounter++;

            if (OnPlayerTurnChanged!=null)
            OnPlayerTurnChanged.Invoke(PlayerIDTurn);
        }
    }

}
