using HealthSystem;
using InventorySystem;
using KeySystem;
using UnityEngine;

namespace InteractionSystem
{
    public class Interaction
    {
        public Interaction(
            InventoryInteractionManager inventoryManager,
            KeyBank keyBank,
            Health health,
            AudioSource interactionSource)
        {
            InventoryInteractionManager = inventoryManager;
            KeyBank = keyBank;
            Health = health;
            InteractionSource = interactionSource;
        }

        public InventoryInteractionManager InventoryInteractionManager { get; }
        public KeyBank KeyBank { get; }
        public Health Health { get; }
        public AudioSource InteractionSource { get; }

        public void PlayInteractionEffect(AudioClip interactionClip)
        {
            InteractionSource.PlayOneShot(interactionClip);
        }
    }
}