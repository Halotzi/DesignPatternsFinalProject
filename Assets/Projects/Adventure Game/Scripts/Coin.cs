using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AdventureGame
{

public class Coin : MonoBehaviour, IDisposable
{

    public event Action<Coin> OnDisposed;


    private void Update()
    {
        if (transform.position.y < -10)
            Dispose();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "El Chupacabra")
            Dispose();
    }

    public virtual void Dispose()
    {
        OnDisposed.Invoke(this);
    }
}
}
