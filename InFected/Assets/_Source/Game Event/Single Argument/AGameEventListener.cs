using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem
{
    public abstract class AGameEventListener<T> : MonoBehaviour
    {
        [SerializeField] private AGameEvent<T> gameEvent;
        [Space]
        [SerializeField] private UnityEvent<T> response;

        private void Awake()
        {
            gameEvent.AddListener(this);
        }

        private void OnDestroy()
        {
            gameEvent.RemoveListener(this);
        }

        public void Notify(T data)
        {
            response.Invoke(data);
        }
    }
}