using UnityEngine;
using WeaponSystem;

namespace InventorySystem
{
    public class WeaponItem : Item
    {
        public WeaponItem(WeaponItemDataSO weaponItemData,
                          string name,
                          string description,
                          int maxCount,
                          Vector2Int size,
                          ItemUI itemUIPrefab,
                          Weapon weapon) : base(weaponItemData,
                                                name,
                                                description,
                                                maxCount,
                                                size,
                                                itemUIPrefab)
        {
            Weapon = weapon;
        }

        public Weapon Weapon { get; }
    }
}