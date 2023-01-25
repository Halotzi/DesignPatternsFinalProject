using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace TICTacToe
{
    public class Soilder
    {
        private Sprite _sprite;
        private bool _isX;
        public Soilder(Sprite sprite, bool isX)
        {
            _sprite = sprite;
            _isX = isX;
        }
    }
}

