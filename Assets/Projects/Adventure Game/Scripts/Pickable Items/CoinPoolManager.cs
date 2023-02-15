using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame 
{
    public class CoinPoolManager : MonoBehaviour
    {
        [SerializeField] private CoinPool _coinPool;
        [SerializeField] Coin _coinPrefab;
        [SerializeField] private int AmountToPopulateOnAwake;
        [SerializeField] private int AmountToPopulateAfterSeconds;
        [SerializeField] private int WaitTimeToPopulate;

        private int counter = 0;
        private void Awake()
        {
            for (int i = 0; i < AmountToPopulateOnAwake; i++)
            {
                _coinPool.PopulatePool(_coinPrefab, AmountToPopulateOnAwake);
            }
        }

        private void Update()
        {
        }

    }
}


