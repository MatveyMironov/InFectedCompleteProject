using UnityEngine;
using WeaponSystem;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "NewWeaponItemData", menuName = "Items/Weapon Item Data")]
    public class WeaponItemDataSO : ItemDataSO
    {
        [SerializeField] private WeaponDataSO WeaponDataSO;

        public override Item Item { get { return new WeaponItem(this, itemName, description, maxCount, size, itemUIPrefab, WeaponDataSO.Weapon); } }
        public WeaponItem WeaponItem { get { return new WeaponItem(this, itemName, description, maxCount, size, itemUIPrefab, WeaponDataSO.Weapon); } }
    }
}