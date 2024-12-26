using PlayerSystem;
using System;
using UnityEngine;

namespace TriggerZoneSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerZone2D : MonoBehaviour
    {
        public bool IsActive;

        public event Action OnTriggerEntered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsActive) return;

            if (other.TryGetComponent(out Player player))
            {
                OnTriggerEntered?.Invoke();
            }
        }
    }
}