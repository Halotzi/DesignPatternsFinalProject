using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AdventureGame
{
    [System.Serializable]
    public class UnityGameObjectEvent : UnityEvent<GameObject> { }

    public class EventListener : MonoBehaviour
    {
        public Event gEvent;
        public UnityEvent respone;

        public void OnEnable()
        {
            gEvent.Register(this);
        }

        private void OnDisable()
        {
            gEvent.Unregister(this);
        }

        public void OnEventOccures(GameObject gameObject)
        {
            respone.Invoke(gameObject);
        }
    }
}

