using PlayerSystem;
using UnityEngine;
using UnityEngine.Events;

namespace TriggerZoneSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerZone2DMB : MonoBehaviour
    {
        [Space]
        public UnityEvent OnTriggerEntered;

        [Space]
        public UnityEvent OnTriggerExited;

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player _))
            {
                OnTriggerEntered.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player _))
            {
                OnTriggerExited.Invoke();
            }
        }
    }
}