using InteractionSystem;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace KeySystem
{
    public class KeysCollectorMB : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeySO[] requiredKeys = new KeySO[0];
        [Space]
        [SerializeField] private UnityEvent OnAllKeysCollected;

        [Header("Interaction")]
        [SerializeField] private GameObject interactionIndicator;

        public KeySO[] RequiredKeys => requiredKeys.ToArray();
        public int RequiredKeysCount => requiredKeys.Length;

        private void Start()
        {
            HideInteraction();
        }

        public void ShowInteraction()
        {
            interactionIndicator.SetActive(true);
        }

        public void HideInteraction()
        {
            interactionIndicator.SetActive(false);
        }

        public void Interact(InteractionData interaction)
        {
            KeyBank keyBank = interaction.KeyBank;
            if (CheckIfAllRequiredKeysPresent(keyBank))
            {
                OnAllKeysCollected.Invoke();
            }
        }

        private bool CheckIfAllRequiredKeysPresent(KeyBank keyBank)
        {
            foreach (KeySO key in requiredKeys)
            {
                if (!keyBank.CheckIfContainsKey(key))
                {
                    return false;
                }
            }

            return true;
        }
    }
}