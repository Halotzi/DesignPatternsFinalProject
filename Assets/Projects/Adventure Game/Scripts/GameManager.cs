using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance => _instance;
        private static GameManager _instance;

        private void Awake()
        {
            _instance = this;
        }
    }
}

