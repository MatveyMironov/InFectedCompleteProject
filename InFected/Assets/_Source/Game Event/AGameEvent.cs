using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    //[CreateAssetMenu(fileName = "New <Type> Game Event", menuName = "<Type> Game Event")]
    public abstract class AGameEvent<T> : ScriptableObject
    {
        private readonly List<AGameEventListener<T>> _listeners = new();

        public void AddListener(AGameEventListener<T> listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(AGameEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }

        public void Call(T data)
        {
            foreach (AGameEventListener<T> listener in _listeners)
            {
                listener.Notify(data);
            }
        }
    }
}