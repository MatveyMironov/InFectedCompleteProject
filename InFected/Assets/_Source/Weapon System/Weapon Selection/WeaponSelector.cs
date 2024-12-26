using InventorySystem;
using System.Collections.Generic;

namespace WeaponSystem
{
    public class WeaponSelector
    {
        private readonly Inventory _inventory;

        private readonly WeaponBody _weaponBody;
        private readonly WeaponUser _weaponUser;

        private readonly List<WeaponItem> _availableWeaponItems;

        public WeaponSelector(Inventory inventory, WeaponBody weaponBody, WeaponUser weaponUser)
        {
            _inventory = inventory;
            _weaponBody = weaponBody;
            _weaponUser = weaponUser;

            _availableWeaponItems = new();

            _inventory.OnItemAdded += AddWeaponItem;
            _inventory.OnItemRemoved += RemoveWeaponItem;
        }

        public int AvailableWeaponItemsCount { get { return _availableWeaponItems.Count;} }
        public int SelectedWeaponIndex { get; private set; } = -1;
        public WeaponItem SelectedWeaponItem { get { return _availableWeaponItems[SelectedWeaponIndex]; } }

        public void SelectWeapon(int weaponIndex)
        {
            if (weaponIndex != SelectedWeaponIndex)
            {
                Weapon weapon = _availableWeaponItems[weaponIndex].Weapon;
                WeaponController weaponUseController = new(weapon, _weaponBody);

                _weaponUser.EquipWeapon(weaponUseController);


                SelectedWeaponIndex = weaponIndex;
            }
        }

        private void AddWeaponItem(Item item)
        {
            if (item is WeaponItem weaponItem)
            {
                _availableWeaponItems.Add(weaponItem);

                if (AvailableWeaponItemsCount == 1)
                {
                    SelectWeapon(0);
                }
            }
        }

        private void RemoveWeaponItem(Item item)
        {
            if (item is WeaponItem weaponItem)
            {
                if (item == SelectedWeaponItem)
                {
                    _weaponUser.RemoveWeapon();
                    SelectedWeaponIndex = -1;
                }

                _availableWeaponItems.Remove(weaponItem);
            }
        }
    }
}
