using InventorySystem;
using UnityEngine;

namespace HealingSystem
{
    public class HealingItem : Item
    {
        public readonly int RestoredHealth;

        public HealingItem(HealingItemDataSO healingItemData,
                           string name,
                           string description,
                           int maxCount,
                           Vector2Int size,
                           ItemUI itemUIPrefab,
                           int restoredHealth) : base(healingItemData,
                                                      name,
                                                      description,
                                                      maxCount,
                                                      size,
                                                      itemUIPrefab)
        {
            RestoredHealth = restoredHealth;
        }
    }
}