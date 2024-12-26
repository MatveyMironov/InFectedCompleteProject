using InteractionSystem;
using UnityEngine;

namespace DoorSystem
{
    public class Door : MonoBehaviour, IInteractable
    {
        [Header("Door Motor")]
        [SerializeField] private Transform door;
        [SerializeField] private Vector3 closedPosition;
        [SerializeField] private Vector3 openedPosition;
        [SerializeField] private float movingSpeed;
        [SerializeField] private AudioSource audioSource;

        [Header("Interaction")]
        [SerializeField] private InteractionIndicator indicator;

        [Header("Lock")]
        [SerializeField] private KeyCardDataSO requiredKeyCard;
        [SerializeField] private SpriteRenderer colorIndicator;

        private DoorMotor _doorMotor;
        private DoorLock _doorLock;

        public bool IsBlocked { get; set; }

        private void Start()
        {
            _doorMotor = new(door, closedPosition, openedPosition, movingSpeed, audioSource);
            
            if (requiredKeyCard != null)
            {
                _doorLock = new(requiredKeyCard, colorIndicator);
                indicator.SetInteractionInformation($"You need\r\n{requiredKeyCard.Name}\r\nto pass");
            }
            else
            {
                indicator.SetInteractionInformation($"Open door");
            }

            indicator.HideIndicator();
        }

        public void ShowInteraction()
        {
            if (IsBlocked || _doorMotor.IsOpened || _doorMotor.IsOpening) return;

            indicator.ShowIndicator();
        }

        public void HideInteraction()
        {
            indicator.HideIndicator();
        }

        public void Interact(Interaction interaction)
        {
            if (IsBlocked || _doorMotor.IsOpened || _doorMotor.IsOpening) return;

            if (_doorLock == null)
            {
                _doorMotor.OpenDoor();
                HideInteraction();
            }
            else
            {
                if (_doorLock.TryFindRequiredKey(interaction.KeyBank))
                {
                    _doorMotor.OpenDoor();
                    HideInteraction();
                }
            }
        }
    }
}