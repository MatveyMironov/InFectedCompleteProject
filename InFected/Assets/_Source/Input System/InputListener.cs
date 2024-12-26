using GameSystem;
using HealingSystem;
using InteractionSystem;
using InventorySystem;
using PlayerSystem;
using System;
using UISystem;
using UnityEngine;
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

        public InputListener(ActionMapsController actionMapsController,
                             PlayerMovementController playerMovementController,
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

            InitializeInputActions(actionMapsController.PlayerControls);
        }

        // TODO: find more elegant solution
        public static event Action OnRotateItemInputRecieved;

        private void InitializeInputActions(PlayerControls playerControls)
        {
            playerControls.MainActionMap.Move.started += OnMoveInput;
            playerControls.MainActionMap.Move.performed += OnMoveInput;
            playerControls.MainActionMap.Move.canceled += OnMoveInput;

            playerControls.MainActionMap.Sprint.started += OnSprintInput;
            playerControls.MainActionMap.Sprint.canceled += OnSprintInput;

            playerControls.MainActionMap.Direct.performed += OnAimInput;

            playerControls.MainActionMap.Shoot.started += OnShootInput;
            playerControls.MainActionMap.Shoot.canceled += OnShootInput;

            playerControls.MainActionMap.Reload.performed += OnReloadInput;

            playerControls.MainActionMap.Interact.performed += OnInteractInput;

            playerControls.MainActionMap.Scroll.performed += OnScrollInput;

            playerControls.MainActionMap.Heal.performed += OnHealInput;

            playerControls.JournalActionMap.ToggleInventory.performed += OnToggleInventoryInput;

            playerControls.JournalActionMap.ToggleKeyBank.performed += OnToggleKeyBankInput;

            playerControls.JournalActionMap.RotateItem.performed += OnRotateItemInput;

            playerControls.PauseActionMap.Pause.performed += OnPauseInput;
        }

        private void OnRotateItemInput(InputAction.CallbackContext context)
        {
            OnRotateItemInputRecieved?.Invoke();
        }

        private void OnHealInput(InputAction.CallbackContext context)
        {
            _healingController.Heal();
        }

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            _playerMovementController.Move(movementInput);
        }

        private void OnSprintInput(InputAction.CallbackContext context)
        {
            bool shouldSprint = context.ReadValueAsButton();
            _playerMovementController.SwitchSprint(shouldSprint);
        }

        private void OnAimInput(InputAction.CallbackContext context)
        {
            Vector2 mousePosition = context.ReadValue<Vector2>();
            _playerMovementController.Aim(mousePosition);
        }

        private void OnShootInput(InputAction.CallbackContext context)
        {
            bool isTriggerPulled = context.ReadValueAsButton();
            _weaponUserController.ControlTrigger(isTriggerPulled);
        }

        private void OnReloadInput(InputAction.CallbackContext context)
        {
            _weaponUserController.Reload();
        }

        private void OnInteractInput(InputAction.CallbackContext context)
        {
            _interactionController.Interact();
        }

        private void OnScrollInput(InputAction.CallbackContext context)
        {
            float scrollInput = context.ReadValue<float>();
            _weaponEquiperController.SwitchWeapon(scrollInput);
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
