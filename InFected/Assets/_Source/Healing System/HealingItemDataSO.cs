using InventorySystem;
using UnityEngine;

namespace HealingSystem
{
    [CreateAssetMenu(fileName = "NewHealingItemData", menuName = "Items/Healing Item")] 
    public class HealingItemDataSO : ItemDataSO
    {
        [SerializeField] private int restoredHealth;

        public override Item Item { get { return new HealingItem(this, itemName, description, maxCount, size, itemUIPrefab, restoredHealth); } }
    }
}