namespace WeaponSystem
{
    public class WeaponSelectorController
    {
        private readonly WeaponSelector _weaponSelector;

        public WeaponSelectorController(WeaponSelector weaponSelector)
        {
            _weaponSelector = weaponSelector;
        }

        public void SwitchWeapon(float switchDirection)
        {
            if (switchDirection < 0)
            {
                StartEquipingPreviousWeapon();
            }
            else if (switchDirection > 0)
            {
                StartEquipingNextWeapon();
            }
        }

        private void StartEquipingNextWeapon()
        {
            if (_weaponSelector.SelectedWeaponIndex >= _weaponSelector.AvailableWeaponItemsCount - 1)
            {
                _weaponSelector.SelectWeapon(0);
            }
            else
            {
                _weaponSelector.SelectWeapon(_weaponSelector.SelectedWeaponIndex + 1);
            }
        }

        private void StartEquipingPreviousWeapon()
        {
            if (_weaponSelector.SelectedWeaponIndex <= 0)
            {
                _weaponSelector.SelectWeapon(_weaponSelector.AvailableWeaponItemsCount - 1);
            }
            else
            {
                _weaponSelector.SelectWeapon(_weaponSelector.SelectedWeaponIndex - 1);
            }
        }
    }
}