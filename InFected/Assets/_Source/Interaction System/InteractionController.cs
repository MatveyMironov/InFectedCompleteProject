using System.Collections.Generic;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractionController : MonoBehaviour
    {
        [SerializeField] private float interactionRadius;
        [SerializeField] private LayerMask interactableLayers;

        [Space]
        [SerializeField] private InteractionData interactionData;

        private IInteractable _currentInteractable;

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

            UpdateCurrentInteractable(interactables);
        }

        public void Interact()
        {
            if (_currentInteractable == null) { return; }

            _currentInteractable.Interact(interactionData);
            _currentInteractable = null;
        }

        private void UpdateCurrentInteractable(List<IInteractable> interactables)
        {
            if (interactables.Contains(_currentInteractable))
            {
                return;
            }
            else
            {
                if (_currentInteractable != null)
                {
                    _currentInteractable.HideInteraction();
                    _currentInteractable = null;
                }

                if (interactables.Count > 0)
                {
                    _currentInteractable = interactables[0];
                    _currentInteractable.ShowInteraction();
                }
            }
        }
    }
}