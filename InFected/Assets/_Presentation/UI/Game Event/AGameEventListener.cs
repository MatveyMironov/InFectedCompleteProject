using UnityEngine;
using UnityEngine.Events;

namespace GameEventSystem
{
    public abstract class AGameEventListener<T> : MonoBehaviour
    {
        [SerializeField] private AGameEvent<T> gameEvent;
        [SerializeField] private UnityEvent<T> response;
        [SerializeField] private UnityEvent voidResponse;

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
            voidResponse.Invoke();
        }
    }
}