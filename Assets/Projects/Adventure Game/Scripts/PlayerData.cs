using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame 
{
    public class PlayerData : MonoBehaviour
    {
        private int _coinsCollected;
        private int HP;

        public void GetDamage(int enemyDamage)
        {
            HP -= enemyDamage;
        }
    }
}

