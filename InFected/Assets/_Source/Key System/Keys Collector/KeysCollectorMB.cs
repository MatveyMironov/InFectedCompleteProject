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
        [SerializeField] private KeyBankSO keyBankSO;
        [SerializeField] private UnityEvent OnAllKeysCollected;

        [Header("Interaction")]
        [SerializeField] private GameObject interactionIndicator;

        private KeyBank _keyBank;

        public KeySO[] RequiredKeys => requiredKeys.ToArray();
        public int RequiredKeysCount => requiredKeys.Length;

        private void Awake()
        {
            _keyBank = keyBankSO.KeyBank;
        }

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
            //Debug.Log("Interact");

            if (CheckIfAllRequiredKeysPresent(_keyBank))
            {
                //Debug.Log("All required keys present");
                OnAllKeysCollected.Invoke();
            }
        }

        private bool CheckIfAllRequiredKeysPresent(KeyBank keyBank)
        {
            foreach (KeySO key in requiredKeys)
            {
                if (!keyBank.CheckIfContainsKey(key))
                {
                    //Debug.Log($"{key.Name} is not present");
                    return false;
                }

                //Debug.Log($"{key.Name} is present");
            }

            return true;
        }
    }
}