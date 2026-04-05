using GameSystem;
using HealingSystem;
using InteractionSystem;
using InventorySystem;
using PlayerSystem;
using System;
using UISystem;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using WeaponSystem;

namespace Core
{
    public class InputListener
    {
        private readonly PlayerMovementController _playerMovementController;
        private readonly InventoryMenuController _inventoryMenuController;
        private readonly TimePauseMenuController _keyBankMenuController;
        private readonly WeaponSelectorController _weaponEquiperController;
        private readonly WeaponUserController _weaponUserController;
        private readonly InteractionController _interactionController;
        private readonly HealingController _healingController;
        private readonly GamePauseController _pauseController;

        public InputListener(PlayerMovementController playerMovementController,
                             InventoryMenuController inventoryMenuController,
                             TimePauseMenuController keyBankMenuController,
                             WeaponSelectorController weaponEquiperController,
                             WeaponUserController weaponUserController,
                             InteractionController interactionController,
                             HealingController healingController,
                             GamePauseController pauseController)
        {
            _playerMovementController = playerMovementController;
            _inventoryMenuController = inventoryMenuController;
            _keyBankMenuController = keyBankMenuController;
            _weaponEquiperController = weaponEquiperController;
            _weaponUserController = weaponUserController;
            _interactionController = interactionController;
            _healingController = healingController;
            _pauseController = pauseController;
        }

        // TODO: find more elegant solution
        public static event Action OnRotateItemInputRecieved;

        private void OnRotateItemInput(InputAction.CallbackContext context)
        {
            OnRotateItemInputRecieved?.Invoke();
        }

        private void OnHealInput(InputAction.CallbackContext context)
        {
            _healingController.Heal();
        }

        private void OnReloadInput(InputAction.CallbackContext context)
        {
            _weaponUserController.Reload();
        }

        private void OnInteractInput(InputAction.CallbackContext context)
        {
            _interactionController.Interact();
        }

        private void OnToggleInventoryInput(InputAction.CallbackContext context)
        {
            _inventoryMenuController.ToggleInventory();
        }

        private void OnToggleKeyBankInput(InputAction.CallbackContext context)
        {
            _keyBankMenuController.ToggleKeyBank();
        }

        private void OnPauseInput(InputAction.CallbackContext context)
        {
            _pauseController.TogglePause();
        }
    }
}