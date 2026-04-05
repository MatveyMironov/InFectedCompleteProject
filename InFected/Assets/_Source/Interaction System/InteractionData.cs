using HealthSystem;
using InventorySystem;
using KeySystem;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractionData : MonoBehaviour
    {
        public InventoryInteractionManager InventoryInteractionManager;
        public KeyBank KeyBank;
        public Health Health;
        public AudioSource InteractionSource;

        public void PlayInteractionEffect(AudioClip interactionClip)
        {
            InteractionSource.PlayOneShot(interactionClip);
        }
    }
}