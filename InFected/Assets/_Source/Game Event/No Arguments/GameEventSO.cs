using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event/No Arguments")]
    public class GameEventSO : ScriptableObject
    {
        private readonly List<IGameEventListener> _listeners = new();

        public void AddListener(IGameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(IGameEventListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Call()
        {
            foreach (var listener in _listeners)
            {
                listener.Notify();
            }
        }
    }
}