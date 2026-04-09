using HealthSystem;
using InventorySystem;
using KeySystem;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractionData : MonoBehaviour
    {
        [SerializeField] private KeyBankSO keyBankSO;
        [SerializeField] private AudioSource interactionSource;
        [SerializeField] private InventoryInteractionManager inventoryInteractionManager;

        public InventoryInteractionManager InventoryInteractionManager => inventoryInteractionManager;
        public KeyBank KeyBank { get; private set; }
        public Health Health { get; private set; }
        public AudioSource InteractionSource => interactionSource;

        private void Awake()
        {
            KeyBank = keyBankSO.KeyBank;
        }

        public void PlayInteractionEffect(AudioClip interactionClip)
        {
            InteractionSource.PlayOneShot(interactionClip);
        }
    }
}