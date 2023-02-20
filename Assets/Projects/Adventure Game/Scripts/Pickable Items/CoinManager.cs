using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventureGame
{

    public class CoinManager : MonoBehaviour
    {
        public event Action<bool> OnCollected;
        public event Action OnDropped;

        [SerializeField] private CoinSpawner _coinSpawner;
        private List<Coin> _coins;

        private void Start()
        {
            _coins = new List<Coin>();
            _coinSpawner.OnDropped += RegisterCoin;
        }

        private void RegisterCoin(Coin coin)
        {
            _coins.Add(coin);
            coin.OnDisposed += UnregisterCoin;
            if(OnDropped!=null)
            OnDropped.Invoke();
        }

        private void UnregisterCoin(Coin coin, bool isTaken)
        {
            _coins.Remove(coin);
            if (OnCollected != null)
                OnCollected.Invoke(isTaken);
        }

        private void OnDestroy()
        {
            _coinSpawner.OnDropped -= RegisterCoin;
            if(_coins.Count>0)
            {
                for (int i = 0; i < _coins.Count; i++)
                {
                    _coins[i].OnDisposed -= UnregisterCoin;
                }
            }
        }
    }
}
