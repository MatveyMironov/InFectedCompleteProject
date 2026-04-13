using UnityEngine;
using UnityEngine.Events;

namespace InteractionSystem
{
    public class UnityEventsInteractableMB : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent OnShowInteraction;
        [Space]
        [SerializeField] private UnityEvent OnHideInteraction;
        [Space]
        [SerializeField] private UnityEvent<InteractionData> OnInteract;

        private void Start()
        {
            HideInteraction();
        }

        public void ShowInteraction()
        {
            OnShowInteraction.Invoke();
        }

        public void HideInteraction()
        {
            OnHideInteraction.Invoke();
        }

        public void Interact(InteractionData interaction)
        {
            OnInteract.Invoke(interaction);
        }
    }
}