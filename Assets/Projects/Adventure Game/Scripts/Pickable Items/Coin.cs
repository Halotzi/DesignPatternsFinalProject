using System;
using UnityEngine;

namespace AdventureGame
{

    public class Coin : MonoBehaviour, IDisposable
    {
        public event Action<Coin> OnDisposed;

        private void Update()
        {
            if (transform.position.y < -3f)
                Dispose();
        }

        public virtual void Dispose()
        {
            OnDisposed.Invoke(this);
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "El Chupacabra")
                Dispose();
        }
    }
}
