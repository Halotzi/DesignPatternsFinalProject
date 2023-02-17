using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame
{
    public class CoinSpawner : MonoBehaviour
    {
        public event Action<Coin> OnDropped;
        
        [SerializeField] private float _timeToCreate;
        [SerializeField] private float _repeatRate;
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Terrain _terrain;

        private TerrainData terrainData;

        private void Start()
        {
            terrainData = _terrain.terrainData;
            InvokeRepeating("CreateCoin", _timeToCreate, _repeatRate);
        }

        private void CreateCoin()
        {
            int x = (int)UnityEngine.Random.Range(0, terrainData.size.x);
            int z = (int)UnityEngine.Random.Range(0, terrainData.size.z);
            Vector3 pos = new Vector3(x, 0, z);
            pos.y = _terrain.SampleHeight(pos) + 10;
            GameObject coinGameobject = Instantiate(_coinPrefab.gameObject, pos, Quaternion.identity, gameObject.transform);
            var coin = coinGameobject.GetComponent<Coin>();
            OnDropped.Invoke(coin);
        }
    }
}

