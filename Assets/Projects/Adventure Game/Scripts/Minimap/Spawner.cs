using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureGame
{
    public class Spawner : MonoBehaviour
    {
        public GameObject coinPrefab;
        public Terrain terrain;
        public Event coinDrop;
        
        private TerrainData terrainData;

        private void Start()
        {
            terrainData = terrain.terrainData;
            InvokeRepeating("CreateCoin", 1, 0.1f);
        }

        private void CreateCoin()
        {
            int x = (int)Random.Range(0, terrainData.size.x);
            int z = (int)Random.Range(0, terrainData.size.z);
            Vector3 pos = new Vector3(x, 0, z);
            pos.y = terrain.SampleHeight(pos) + 10;
            GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity);
            coinDrop.Occurred(coin);
        }
    }
}

