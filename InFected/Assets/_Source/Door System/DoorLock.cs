using InteractionSystem;
using KeySystem;
using System;
using UnityEngine;

namespace DoorSystem
{
    public class DoorLock
    {
        private KeyCardDataSO _requiredKeyCard;
        private SpriteRenderer _colorIndicator;

        public DoorLock(KeyCardDataSO requiredKeyCard, SpriteRenderer colorIndicator)
        {
            _requiredKeyCard = requiredKeyCard ?? throw new ArgumentNullException("requiredKeyCard");
            _colorIndicator = colorIndicator ?? throw new ArgumentNullException("colorIndicator");

            _colorIndicator.color = requiredKeyCard.Color;
        }

        public bool IsLocked { get; private set; }

        public bool TryFindRequiredKey(KeyBank keyBank)
        {
            if (keyBank.CheckIfContains(_requiredKeyCard))
            {
                IsLocked = true;

                return true;
            }

            return false;
        }
    }
}
