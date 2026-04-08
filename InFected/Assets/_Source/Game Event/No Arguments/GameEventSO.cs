using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event/No Arguments")]
    public class GameEventSO : ScriptableObject
    {
        private readonly List<GameEventListener> _listeners = new();

        public void AddListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Call()
        {
            foreach (GameEventListener listener in _listeners)
            {
                listener.Notify();
            }
        }
    }
}