using InventorySystem;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponSelector : MonoBehaviour
    {
        [SerializeField] private InventorySO inventorySO;
        [SerializeField] private WeaponBody weaponBody;
        [SerializeField] private WeaponUser _weaponUser;

        [Space]
        [SerializeField] private WeaponDataSO defaultWeaponData;
        public Weapon DefaultWeapon { get; private set; }

        private Inventory _inventory;

        private readonly List<WeaponItem> _availableWeaponItems = new();
        public int AvailableWeaponItemsCount => _availableWeaponItems.Count;

        public int SelectedWeaponIndex { get; private set; } = -1;
        public WeaponItem SelectedWeaponItem { get; private set; }

        private void Awake()
        {
            _inventory = inventorySO.Inventory;
            _inventory.OnItemAdded += AddWeaponItem;
            _inventory.OnItemRemoved += RemoveWeaponItem;

            DefaultWeapon = defaultWeaponData.Weapon;
        }

        private void Start()
        {
            SelectDefaultWeapon();
        }

        private void OnDestroy()
        {
            _inventory.OnItemAdded -= AddWeaponItem;
            _inventory.OnItemRemoved -= RemoveWeaponItem;
        }

        public void SelectNextWeapon()
        {
            if (SelectedWeaponIndex >= AvailableWeaponItemsCount - 1)
            {
                //SelectWeapon(0);
                SelectDefaultWeapon();
            }
            else
            {
                SelectWeapon(SelectedWeaponIndex + 1);
            }
        }

        public void SelectPreviousWeapon()
        {
            if (SelectedWeaponIndex < 1)
            {
                if (SelectedWeaponIndex == 0)
                {
                    SelectDefaultWeapon();
                    return;
                }

                SelectWeapon(AvailableWeaponItemsCount - 1);
            }
            else
            {
                SelectWeapon(SelectedWeaponIndex - 1);
            }
        }

        public void SelectWeapon(int weaponIndex)
        {
            if (weaponIndex == SelectedWeaponIndex) { return; }

            WeaponItem weaponItem = _availableWeaponItems[weaponIndex];
            Weapon weapon = weaponItem.Weapon;
            EquipWeapon(weapon);
            SelectedWeaponIndex = weaponIndex;
            SelectedWeaponItem = weaponItem;
        }

        private void AddWeaponItem(Item item)
        {
            if (item is WeaponItem weaponItem)
            {
                _availableWeaponItems.Add(weaponItem);

                if (AvailableWeaponItemsCount < 1)
                {
                    SelectDefaultWeapon();
                }
            }
        }

        private void RemoveWeaponItem(Item item)
        {
            if (item is WeaponItem weaponItem)
            {
                _availableWeaponItems.Remove(weaponItem);
                //Debug.Log($"Remove {weaponItem} available weapons");

                if (item == SelectedWeaponItem)
                {
                    _weaponUser.RemoveWeapon();
                    SelectedWeaponItem = null;
                    SelectedWeaponIndex = -1;
                    //Debug.Log($"Deselect {weaponItem}");
                    SelectDefaultWeapon();
                }
            }
        }

        private void SelectDefaultWeapon()
        {
            EquipWeapon(DefaultWeapon);
            SelectedWeaponIndex = -1;
        }

        private void EquipWeapon(Weapon weapon)
        {
            WeaponController weaponUseController = new(weapon, weaponBody);
            _weaponUser.EquipWeapon(weaponUseController);
        }
    }
}