using System;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractionFinder : MonoBehaviour
    {
        [SerializeField] private float interactionRadius;
        [SerializeField] private LayerMask interactableLayers;

        public event Action<List<IInteractable>> OnInteractablesUpdated;

        private void FixedUpdate()
        {
            List<IInteractable> interactables = new();

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius, interactableLayers);
            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    interactables.Add(interactable);
                }
            }

            OnInteractablesUpdated?.Invoke(interactables);
        }
    }
}