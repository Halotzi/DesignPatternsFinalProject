using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TICTacToe
{
    public class VisualHandler : MonoBehaviour
    {
        [SerializeField] private Sprite _spriteX;
        [SerializeField] private Sprite _spriteO;

        public Sprite GetSprite(int PlayerID)
        {
            if (PlayerID == 0)
                return _spriteX;

            else
                return _spriteO;
        }
    }
}

