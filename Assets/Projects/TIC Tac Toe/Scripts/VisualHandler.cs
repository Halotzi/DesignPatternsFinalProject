using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TICTacToe
{
    public class VisualHandler : MonoBehaviour
    {
        [SerializeField] private Sprite _spriteX;
        [SerializeField] private Sprite _spriteO;
        [SerializeField] private Sprite _tie;

        public Sprite GetSprite(int PlayerID)
        {
            if (PlayerID == 0)
                return _spriteX;

            else if (PlayerID == 1)
                return _spriteO;

            else
                return _tie;
        }
    }
}

