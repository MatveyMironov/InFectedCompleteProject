using InteractionSystem;
using KeySystem;
using MicrobeSampleSystem;
using UnityEngine;

namespace DoorSystem
{
    public class KeyCardContainer : KeyContainer
    {
        [SerializeField] private KeyCardDataSO keyCard;

        [Space]
        [SerializeField] private SpriteRenderer colorIndicator;

        protected override KeyDataSO _key => keyCard;

        protected override void Start()
        {
            ResetColor();
            base.Start();
        }

        [ContextMenu("Reset Color")]
        private void ResetColor()
        {
            colorIndicator.color = keyCard.Color;
        }
    }
}