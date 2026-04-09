using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [SerializeField] private GameEventSO gameEvent;
        [Space]
        [SerializeField] private UnityEvent response;

        private void Awake()
        {
            gameEvent.AddListener(this);
        }

        private void OnDestroy()
        {
            gameEvent.RemoveListener(this);
        }

        public void Notify()
        {
            response.Invoke();
        }
    }
}