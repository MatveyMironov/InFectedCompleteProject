using GameSystem;
using System;

namespace UISystem
{
    public class TimePauseMenuController
    {
        private HideableUI _menu;
        private TimePause _timePause;

        public event Action OnInventoryOpened;
        public event Action OnInventoryClosed;

        public TimePauseMenuController(HideableUI menu, TimePause timePause)
        {
            _menu = menu;
            _timePause = timePause;
        }

        public void ToggleKeyBank()
        {
            if (_menu.IsUIShown)
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
            if (_menu.IsUIShown) { return; }

            _timePause.Pause();
            _menu.Show();

            OnInventoryOpened?.Invoke();
        }

        public void CloseInventory()
        {
            if (!_menu.IsUIShown) { return; }

            _menu.Hide();
            _timePause.Unpause();

            OnInventoryClosed?.Invoke();
        }
    }
}