using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Coin : MonoBehaviour, IDisposable
{
    [SerializeField] private GameObject _coinPrefab;

    public event Action<Coin> OnDisposed;
    public GameObject CoinPrefab => _coinPrefab;

    public virtual void Dispose()
    {
        Destroy(this.gameObject);
    }
}
