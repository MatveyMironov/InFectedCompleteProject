using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem
{
    public class MultipleGameEventsListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private GameEventSO[] gameEvents = new GameEventSO[0];
        [SerializeField] private UnityEvent response;

        private void Awake()
        {
            foreach (var gameEvent in gameEvents)
            {
                gameEvent.AddListener(this);
            }
        }

        private void OnDestroy()
        {
            foreach (var gameEvent in gameEvents)
            {
                gameEvent.RemoveListener(this);
            }
        }

        public void Notify()
        {
            response.Invoke();
        }
    }
}