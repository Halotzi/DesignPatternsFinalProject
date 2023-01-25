using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TICTacToe
{
    public class TurnHandler
    {
        public int TurnCounter;

        public int PlayerIDTurn => _playerIdTurn;
        private int _playerIdTurn;

        public void RandomStarter()
        {
            int random = Random.Range(0, 2);
            _playerIdTurn = random;
        }

        public void ChangePlayerTurn()
        {
            if (_playerIdTurn == 0)
                _playerIdTurn = 1;

            else
                _playerIdTurn = 0;
        }
    }

}
