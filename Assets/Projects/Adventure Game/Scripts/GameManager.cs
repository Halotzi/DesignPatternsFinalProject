using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance => _instance;
        private static GameManager _instance;

        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private CoinManager _coinManager;

        public PlayerManager PlayerManager => _playerManager;
        public CoinManager CoinManager => _coinManager;

        private void Awake()
        {
            _instance = this;
        }
    }
}

