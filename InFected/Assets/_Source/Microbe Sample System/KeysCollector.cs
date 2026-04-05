using InteractionSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeysCollector : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeyConfiguration[] requiredKeys = new KeyConfiguration[0];

        [Header("Interaction")]
        [SerializeField] private InteractionIndicator indicator;

        public KeyConfiguration[] RequiredKeys { get => requiredKeys; }

        public event Action OnAllSamplesCollected;

        private void Start()
        {
            RemoveDoubles();
            indicator.SetInteractionInformation($"Collect {requiredKeys.Length} Microbe Samples");
            HideInteraction();
        }

        public void ShowInteraction()
        {
            indicator.ShowIndicator();
        }

        public void HideInteraction()
        {
            indicator.HideIndicator();
        }

        public void Interact(InteractionData interaction)
        {
            KeyBank keyBank = interaction.KeyBank;
            if (CheckIfAllCollected(keyBank))
            {
                OnAllSamplesCollected?.Invoke();
            }
        }

        private void RemoveDoubles()
        {
            List<KeyConfiguration> keys = new();

            foreach (KeyConfiguration key in requiredKeys)
            {
                if (!keys.Contains(key))
                {
                    keys.Add(key);
                }
            }

            requiredKeys = keys.ToArray();
        }

        private bool CheckIfAllCollected(KeyBank keyBank)
        {
            foreach (KeyConfiguration key in requiredKeys)
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