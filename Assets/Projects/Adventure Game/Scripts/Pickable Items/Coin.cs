using System;
using UnityEngine;

namespace AdventureGame
{

    public class Coin : MonoBehaviour
    {
        public event Action<Coin,bool> OnDisposed;

        private void Update()
        {
            if (transform.position.y < -3f)
                Dispose(false);
        }

        //I wanted to use IDisposable but then i cant ovveride the method
        public virtual void Dispose(bool isTaken)
        {
            OnDisposed.Invoke(this, isTaken);
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "El Chupacabra")
                Dispose(true);
        }
    }
}
