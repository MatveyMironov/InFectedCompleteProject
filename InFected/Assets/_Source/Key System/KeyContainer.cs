using InteractionSystem;
using UnityEngine;

namespace KeySystem
{
    public abstract class KeyContainer : MonoBehaviour, IInteractable
    {
        protected abstract KeyDataSO _key { get; }

        [Header("Interaction")]
        [SerializeField] private InteractionIndicator indicator;
        [SerializeField] private AudioClip interactionClip;

        protected virtual void Start()
        {
            indicator.SetInteractionInformation(_key.Name);
            HideInteraction();
        }

        public virtual void ShowInteraction()
        {
            indicator.ShowIndicator();
        }

        public virtual void HideInteraction()
        {
            indicator.HideIndicator();
        }

        public virtual void Interact(Interaction interaction)
        {
            interaction.PlayInteractionEffect(interactionClip);
            KeyBank keyBank = interaction.KeyBank;
            if (keyBank.TryAddKey(_key))
            {
                gameObject.SetActive(false);
            }
        }

    }
}