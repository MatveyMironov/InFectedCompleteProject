using Core;
using GameSystem;
using System;
using UISystem;

namespace InventorySystem
{
    public class InventoryMenuController
    {
        private readonly HideableUI _inventoryMenu;
        private readonly TimePause _timePause;
        private readonly ActionMapsController _actionMapsController;

        public event Action OnInventoryOpened;
        public event Action OnInventoryClosed;

        public InventoryMenuController(HideableUI inventoryMenu, TimePause timePause, ActionMapsController actionMapsController)
        {
            _inventoryMenu = inventoryMenu;
            _timePause = timePause;
            _actionMapsController = actionMapsController;
        }

        public void ToggleInventory()
        {
            if (_inventoryMenu.IsUIShown)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }

        public void OpenInventory()
        {
            if (_inventoryMenu.IsUIShown) { return; }

            _actionMapsController.DisableMainActionMap();
            _timePause.Pause();
            _inventoryMenu.Show();

            OnInventoryOpened?.Invoke();
        }

        public void CloseInventory()
        {
            if ( !_inventoryMenu.IsUIShown) { return; }

            _inventoryMenu.Hide();
            _timePause.Unpause();
            _actionMapsController.EnableMainActionMap();

            OnInventoryClosed?.Invoke();
        }
    }
}
