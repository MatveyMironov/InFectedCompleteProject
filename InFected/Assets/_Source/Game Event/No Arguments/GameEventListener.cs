using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEventSO gameEvent;
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