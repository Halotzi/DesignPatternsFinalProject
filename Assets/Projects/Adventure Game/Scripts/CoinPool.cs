using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour, IDisposable
{
    [SerializeField] private Transform _parent;
    private List<Coin> _allPoolObjects;
    private List<Coin> _reservedList;

    public CoinPool(Transform defaultParent)
    {
        _parent = defaultParent;
        _allPoolObjects = new List<Coin>();
        _reservedList = new List<Coin>();
    }

    public void PopulatePool(Coin coin, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            InstantiateObject(coin).Dispose();
        }

    }

    public Coin Pull()
    {
        Coin @object = default;
        if (_reservedList.Count > 0)
        {
                    @object = _reservedList[0];
                    _reservedList.RemoveAt(0);
        }

        if (@object == null)
        {
            Coin coin = new Coin();
            @object = InstantiateObject(coin);
        }
        return @object;
    }

    private Coin InstantiateObject(Coin coin)
    {

        Coin cache = MonoBehaviour.Instantiate(coin, _parent);
        _allPoolObjects.Add(cache);
        cache.OnDisposed += ReturnBack;
        return cache;
    }

    private void ReturnBack(Coin returningObject)
    {
        returningObject.transform.SetParent(_parent);
        _reservedList.Add(returningObject);
    }

    public void Dispose()
    {
        for (int i = 0; i < _allPoolObjects.Count; i++)
        {
            _allPoolObjects[i].Dispose();
            _allPoolObjects[i].OnDisposed -= ReturnBack;
        }
        _allPoolObjects.Clear();
        _reservedList.Clear();
    }
}

public interface IPoolable<T>
{
    public event Action<T> OnDispos;
}
