using InteractionSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeysCollector : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeyDataSO[] requiredKeys = new KeyDataSO[0];

        [Header("Interaction")]
        [SerializeField] private InteractionIndicator indicator;

        public KeyDataSO[] RequiredKeys { get => requiredKeys; }

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

        public void Interact(Interaction interaction)
        {
            KeyBank keyBank = interaction.KeyBank;
            if (CheckIfAllCollected(keyBank))
            {
                OnAllSamplesCollected?.Invoke();
            }
        }

        private void RemoveDoubles()
        {
            List<KeyDataSO> keys = new();

            foreach (KeyDataSO key in requiredKeys)
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
            foreach (KeyDataSO key in requiredKeys)
            {
                if (!keyBank.CheckIfContains(key))
                {
                    return false;
                }
            }

            return true;
        }
    }
}